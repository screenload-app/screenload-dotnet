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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScreenLoadPlugin.Core;
using ScreenLoad.IniFile;
using ScreenLoadPlugin.Effects;

namespace ScreenLoad.Plugin {
    [Serializable]
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class PluginAttribute : Attribute, IComparable
    {
        public string Name
        {
            get;
            set;
        }
        public string CreatedBy
        {
            get;
            set;
        }
        public string Version
        {
            get;
            set;
        }
        public string EntryType
        {
            get;
            private set;
        }
        public bool Configurable
        {
            get;
            private set;
        }

        public string DllFile
        {
            get;
            set;
        }

        public PluginAttribute(string entryType, bool configurable)
        {
            EntryType = entryType;
            Configurable = configurable;
        }

        public int CompareTo(object obj)
        {
            PluginAttribute other = obj as PluginAttribute;
            if (other != null)
            {
                return Name.CompareTo(other.Name);
            }
            throw new ArgumentException("object is not a PluginAttribute");
        }
    }

    // Delegates for hooking up events.
    public delegate void HotKeyHandler();

	public class SurfaceOutputSettings {
		private static readonly CoreConfiguration CoreConfig = IniConfig.GetIniSection<CoreConfiguration>();
		private bool _reduceColors;
		private bool _disableReduceColors;

		public SurfaceOutputSettings() {
			_disableReduceColors = false;
			Format = CoreConfig.OutputFileFormat;
			JPGQuality = CoreConfig.OutputFileJpegQuality;
			ReduceColors = CoreConfig.OutputFileReduceColors;
		}

		public SurfaceOutputSettings(OutputFormat format) : this() {
			Format = format;
		}

		public SurfaceOutputSettings(OutputFormat format, int quality) : this(format) {
			JPGQuality = quality;
		}

		public SurfaceOutputSettings(OutputFormat format, int quality, bool reduceColors) : this(format, quality) {
			ReduceColors = reduceColors;
		}

		/// <summary>
		/// BUG-2056 reported a logical issue, using ScreenLoad format as the default causes issues with the external commands.
		/// </summary>
		/// <returns>this for fluent API usage</returns>
		public SurfaceOutputSettings PreventScreenLoadFormat()
		{
			// If OutputFormat is ScreenLoad, use PNG instead.
			if (Format == OutputFormat.ScreenLoad)
			{
				Format = OutputFormat.png;
			}
			return this;
		}

		public OutputFormat Format {
			get;
			set;
		}

		public int JPGQuality {
			get;
			set;
		}

		public bool SaveBackgroundOnly {
			get;
			set;
		}

		public List<IEffect> Effects { get; } = new List<IEffect>();

		public bool ReduceColors {
				get {
					// Fix for Bug #3468436, force quantizing when output format is gif as this has only 256 colors!
					if (OutputFormat.gif.Equals(Format)) {
						return true;
					}
					return _reduceColors;
				}
				set {
					_reduceColors = value;
				}
		}

		/// <summary>
		/// Disable the reduce colors option, this overrules the enabling
		/// </summary>
		public bool DisableReduceColors {
			get {
				return _disableReduceColors;
			}
			set {
				// Quantizing os needed when output format is gif as this has only 256 colors!
				if (!OutputFormat.gif.Equals(Format)) {
					_disableReduceColors = value;
				}
			}
		}
	}

	/// <summary>
	/// This interface is the ScreenLoadPluginHost, that which "Hosts" the plugin.
	/// For ScreenLoad this is implmented in the PluginHelper
	/// </summary>
	public interface IScreenLoadHost {
        ContextMenuStrip MainMenu
        {
            get;
        }

        // This is a reference to the MainForm, can be used for Invoking on the UI thread.
        Form ScreenLoadForm {
			get;
		}
		
		NotifyIcon NotifyIcon {
			get;
		}

		/// <summary>
		/// Create a Thumbnail
		/// </summary>
		/// <param name="image">Image of which we need a Thumbnail</param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns>Image with Thumbnail</returns>
		Image GetThumbnail(Image image, int width, int height);
		
		/// <summary>
		/// List of available plugins with their PluginAttributes
		/// This can be usefull for a plugin manager plugin...
		/// </summary>
		IDictionary<PluginAttribute, IScreenLoadPlugin> Plugins {
			get;
		}

		/// <summary>
		/// Get a destination by it's designation
		/// </summary>
		/// <param name="designation"></param>
		/// <returns>IDestination</returns>
		IDestination GetDestination(string designation);

		/// <summary>
		/// Get a list of all available destinations
		/// </summary>
		/// <returns>List of IDestination</returns>
		List<IDestination> GetAllDestinations();

		/// <summary>
		/// Export a surface to the destination with has the supplied designation
		/// </summary>
		/// <param name="manuallyInitiated"></param>
		/// <param name="designation"></param>
		/// <param name="surface"></param>
		/// <param name="captureDetails"></param>
		ExportInformation ExportCapture(bool manuallyInitiated, string designation, ISurface surface, ICaptureDetails captureDetails);

		/// <summary>
		/// Make region capture with specified Handler
		/// </summary>
		/// <param name="captureMouseCursor">bool false if the mouse should not be captured, true if the configuration should be checked</param>
		/// <param name="destination">IDestination destination</param>
		void CaptureRegion(bool captureMouseCursor, IDestination destination);

		/// <summary>
		/// Use the supplied capture, and handle it as if it's captured.
		/// </summary>
		/// <param name="captureToImport">ICapture to import</param>
		void ImportCapture(ICapture captureToImport);

		/// <summary>
		/// Use the supplied image, and ICapture a capture object for it
		/// </summary>
		/// <param name="imageToCapture">Image to create capture for</param>
		/// <returns>ICapture</returns>
		ICapture GetCapture(Image imageToCapture);
	}

	public interface IScreenLoadPlugin : IDisposable {
		/// <summary>
		/// Is called after the plugin is instanciated, the Plugin should keep a copy of the host and pluginAttribute.
		/// </summary>
		/// <param name="host">The IPluginHost that will be hosting the plugin</param>
		/// <param name="pluginAttribute">The PluginAttribute for the actual plugin</param>
		/// <returns>true if plugin is initialized, false if not (doesn't show)</returns>
		bool Initialize(IScreenLoadHost host, PluginAttribute pluginAttribute);

		/// <summary>
		/// Unload of the plugin
		/// </summary>
		void Shutdown();

		/// <summary>
		/// Open the Configuration Form, will/should not be called before handshaking is done
		/// </summary>
		void Configure();
		
		/// <summary>
		/// Return IDestination's, if the plugin wants to
		/// </summary>
		IEnumerable<IDestination> Destinations();

		/// <summary>
		/// Return IProcessor's, if the plugin wants to
		/// </summary>
		IEnumerable<IProcessor> Processors();
	}
}