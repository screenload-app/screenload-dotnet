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
using System.Windows.Forms;
using ScreenLoadInterop.Interop;

namespace ScreenLoadPlugin.Controls {
	public class ExtendedWebBrowser : WebBrowser {
		protected class ExtendedWebBrowserSite : WebBrowserSite, IOleCommandTarget {
			private const int OLECMDID_SHOWSCRIPTERROR = 40;
			private const int OLECMDID_SHOWMESSAGE = 41;

			private static readonly Guid CGID_DocHostCommandHandler = new Guid("F38BC242-B950-11D1-8918-00C04FC2C836");

			private const int S_OK = 0;
			private const int OLECMDERR_E_NOTSUPPORTED = (-2147221248);
			private const int OLECMDERR_E_UNKNOWNGROUP = (-2147221244);

			public ExtendedWebBrowserSite(WebBrowser wb) : base(wb) {
			}

			#region IOleCommandTarget Members
			public int QueryStatus(Guid pguidCmdGroup, int cCmds, IntPtr prgCmds, IntPtr pCmdText) {
				return OLECMDERR_E_NOTSUPPORTED;
			}

			public int Exec(Guid pguidCmdGroup, int nCmdID, int nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut) {
				if (pguidCmdGroup == CGID_DocHostCommandHandler) {
					if (nCmdID == OLECMDID_SHOWSCRIPTERROR) {
						// do not need to alter pvaOut as the docs says, enough to return S_OK here
						return S_OK;
					}
				}

				return OLECMDERR_E_NOTSUPPORTED;
			}

			#endregion
		}

		protected override WebBrowserSiteBase CreateWebBrowserSiteBase() {
			return new ExtendedWebBrowserSite(this);
		}
	}
}