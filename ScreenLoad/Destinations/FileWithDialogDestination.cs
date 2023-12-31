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

using System.Drawing;
using System.Windows.Forms;

using ScreenLoad.Configuration;
using ScreenLoadPlugin.Core;
using ScreenLoad.Plugin;
using ScreenLoad.IniFile;

namespace ScreenLoad.Destinations {
	/// <summary>
	/// Description of FileWithDialog.
	/// </summary>
	public class FileWithDialogDestination : AbstractDestination {
		private static readonly CoreConfiguration conf = IniConfig.GetIniSection<CoreConfiguration>();
		public const string DESIGNATION = "FileDialog";

		public override string Designation {
			get {
				return DESIGNATION;
			}
		}

		public override string Description {
			get {
				return Language.GetString(LangKey.settings_destination_fileas);
			}
		}

		public override int Priority {
			get {
				return 0;
			}
		}
		
		public override Keys EditorShortcutKeys {
			get {
				return Keys.Control | Keys.Shift | Keys.S;
			}
		}

        public override Icon DisplayIcon => ScreenLoadResources.Save;

        public override ExportInformation ExportCapture(bool manuallyInitiated, ISurface surface, ICaptureDetails captureDetails) {
            var exportInformation = new ExportInformation(Designation, Description)
            {
                SuccessMessage = Language.GetString("exported_to_FileDialog")
            };
            // Bug #2918756 don't overwrite path if SaveWithDialog returns null!
            var savedTo = ImageOutput.SaveWithDialog(surface, captureDetails);
			if (savedTo != null) {
				exportInformation.ExportMade = true;
				exportInformation.Filepath = savedTo;
				captureDetails.Filename = savedTo;
				conf.OutputFileAsFullpath = savedTo;
			}
			ProcessExport(exportInformation, surface);
			return exportInformation;
		}
	}
}
