﻿/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on GitHub https://github.com/greenshot/greenshot
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using ScreenLoad.IniFile;
using ScreenLoad.Plugin;
using ScreenLoadPlugin.UnmanagedHelpers;
using log4net;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenLoadPlugin.Core {
	/// <summary>
	/// Description of PluginUtils.
	/// </summary>
	public static class PluginUtils {
		private static readonly ILog Log = LogManager.GetLogger(typeof(PluginUtils));
		private static readonly CoreConfiguration CoreConfig = IniConfig.GetIniSection<CoreConfiguration>();
		private const string PathKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\";
		private static readonly IDictionary<string, Image> ExeIconCache = new Dictionary<string, Image>();

		static PluginUtils() {
			CoreConfig.PropertyChanged += OnIconSizeChanged;
		}

		/// <summary>
		/// Simple global property to get the ScreenLoad host
		/// </summary>
		public static IScreenLoadHost Host {
			get;
			set;
		}

		/// <summary>
		/// Clear icon cache
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void OnIconSizeChanged(object sender, PropertyChangedEventArgs e) {
			if (e.PropertyName == "IconSize") {
				List<Image> cachedImages = new List<Image>();
				lock (ExeIconCache) {
					foreach (string key in ExeIconCache.Keys) {
						cachedImages.Add(ExeIconCache[key]);
					}
					ExeIconCache.Clear();
				}
				foreach (Image cachedImage in cachedImages)
				{
					cachedImage?.Dispose();
				}

			}
		}

		/// <summary>
		/// Get the path of an executable
		/// </summary>
		/// <param name="exeName">e.g. cmd.exe</param>
		/// <returns>Path to file</returns>
		public static string GetExePath(string exeName) {
			using (RegistryKey key = Registry.LocalMachine.OpenSubKey(PathKey + exeName, false)) {
				if (key != null) {
					// "" is the default key, which should point to the requested location
					return (string)key.GetValue("");
				}
			}
			foreach (string pathEntry in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';')) {
				try {
					string path = pathEntry.Trim();
					if (!string.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, exeName))) {
						return Path.GetFullPath(path);
					}
				} catch (Exception) {
					Log.WarnFormat("Problem with path entry '{0}'.", pathEntry);
				}
			}
			return null;
		}

        /// <summary>
        /// Get icon from resource files, from the cache.
        /// Examples can be found here: https://diymediahome.org/windows-icons-reference-list-with-details-locations-images/
        /// </summary>
        /// <param name="path">path to the exe or dll</param>
        /// <param name="index">index of the icon</param>
        /// <returns>Bitmap with the icon or null if something happended</returns>
        public static Image GetCachedExeIcon(string path, int index)
        {
            string cacheKey = $"{path}:{index}";
            Image returnValue;
            lock (ExeIconCache)
            {
                if (ExeIconCache.TryGetValue(cacheKey, out returnValue))
                {
                    return returnValue;
                }

                lock (ExeIconCache)
                {
                    if (ExeIconCache.TryGetValue(cacheKey, out returnValue))
                    {
                        return returnValue;
                    }

                    returnValue = GetExeIcon(path, index, CoreConfig.UseLargeIcons);
                    if (returnValue != null)
                    {
                        ExeIconCache.Add(cacheKey, returnValue);
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Get icon for executable
        /// </summary>
        /// <param name="path">path to the exe or dll</param>
        /// <param name="index">index of the icon</param>
        /// <returns>Bitmap with the icon or null if something happended</returns>
        public static Bitmap GetExeIcon(string path, int index, bool useLargeIcon)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            try
            {
                using (Icon appIcon = ImageHelper.ExtractAssociatedIcon(path, index, useLargeIcon))
                {
                    if (appIcon != null)
                    {
                        return appIcon.ToBitmap();
                    }
                }

                using (Icon appIcon = Shell32.GetFileIcon(path,
                    useLargeIcon ? Shell32.IconSize.Large : Shell32.IconSize.Small, false))
                {
                    if (appIcon != null)
                    {
                        return appIcon.ToBitmap();
                    }
                }
            }
            catch (Exception exIcon)
            {
                Log.Error("error retrieving icon: ", exIcon);
            }

            return null;
        }

        /// <summary>
		/// Helper method to add a MenuItem to the File MenuItem of an ImageEditor
		/// </summary>
		/// <param name="imageEditor"></param>
		/// <param name="image">Image to display in the menu</param>
		/// <param name="text">Text to display in the menu</param>
		/// <param name="tag">The TAG value</param>
		/// <param name="shortcutKeys">Keys which can be used as shortcut</param>
		/// <param name="handler">The onclick handler</param>
		public static void AddToFileMenu(IImageEditor imageEditor, Image image, string text, object tag, Keys? shortcutKeys, EventHandler handler) {
			var item = new ToolStripMenuItem
			{
				Image = image,
				Text = text,
				Tag = tag
			};
			if (shortcutKeys.HasValue) {
				item.ShortcutKeys = shortcutKeys.Value;
			}
			item.Click += handler;
			AddToFileMenu(imageEditor, item);
		}

		/// <summary>
		/// Helper method to add a MenuItem to the File MenuItem of an ImageEditor
		/// </summary>
		/// <param name="imageEditor"></param>
		/// <param name="item"></param>
		public static void AddToFileMenu(IImageEditor imageEditor, ToolStripMenuItem item) {
			ToolStripMenuItem toolStripMenuItem = imageEditor.GetFileMenuItem();
			bool added = false;
			for(int i = 0; i< toolStripMenuItem.DropDownItems.Count; i++) {
				if (toolStripMenuItem.DropDownItems[i].GetType() == typeof(ToolStripSeparator)) {
					toolStripMenuItem.DropDownItems.Insert(i, item);
					added = true;
					break;
				}
			}
			if (!added) {
				toolStripMenuItem.DropDownItems.Add(item);
			}
		}
		
		/// <summary>
		/// Helper method to add a MenuItem to the Plugin MenuItem of an ImageEditor
		/// </summary>
		/// <param name="imageEditor"></param>
		/// <param name="item"></param>
		public static void AddToPluginMenu(IImageEditor imageEditor, ToolStripMenuItem item) {
			ToolStripMenuItem toolStripMenuItem = imageEditor.GetPluginMenuItem();
			bool added = false;
			for(int i = 0; i< toolStripMenuItem.DropDownItems.Count; i++) {
				if (toolStripMenuItem.DropDownItems[i].GetType() == typeof(ToolStripSeparator)) {
					toolStripMenuItem.DropDownItems.Insert(i, item);
					added = true;
					break;
				}
			}
			if (!added) {
				toolStripMenuItem.DropDownItems.Add(item);
			}
		}

        /// <summary>
        /// Helper method to add a plugin MenuItem to the ScreenLoad context menu
        /// </summary>
        /// <param name="host">IScreenLoadHost</param>
        /// <param name="item">ToolStripMenuItem</param>
        public static void AddToContextMenu(IScreenLoadHost host, ToolStripMenuItem item)
        {
            // Here we can hang ourselves to the main context menu!
            var menuItems = host.MainMenu.Items.Find("contextmenu_settings", true);

            if (0 == menuItems.Length)
                return;

            var settingsMenuItem = (ToolStripMenuItem) menuItems[0];
            settingsMenuItem.DropDownItems.Insert(0, item);

            // Try to find a separator, so we insert ourselves after it 
            //for (int i = 0; i < contextMenu.Items.Count; i++)
            //{
            //    if (contextMenu.Items[i].GetType() == typeof(ToolStripSeparator))
            //    {
            //        // Check if we need to add a new separator, which is done if the first found has a Tag with the value "PluginsAreAddedBefore"
            //        if ("PluginsAreAddedBefore".Equals(contextMenu.Items[i].Tag))
            //        {
            //            var separator = new ToolStripSeparator
            //            {
            //                Tag = "PluginsAreAddedAfter",
            //                Size = new Size(305, 6)
            //            };
            //            contextMenu.Items.Insert(i, separator);
            //        }
            //        else if (!"PluginsAreAddedAfter".Equals(contextMenu.Items[i].Tag))
            //        {
            //            continue;
            //        }

            //        contextMenu.Items.Insert(i + 1, item);
            //        addedItem = true;
            //        break;
            //    }
            //}

            // If we didn't insert the item, we just add it...
            //if (!addedItem)
            //{
            //    contextMenu.Items.Add(item);
            //}
        }
    }
}
