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

using System.Runtime.InteropServices;

namespace ScreenLoad.Interop.IE {
	[ComVisible(true), ComImport(), Guid("3050f6cf-98b5-11cf-bb82-00aa00bdce0b"),
	 TypeLibType(TypeLibTypeFlags.FDual),
	 InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IHTMLWindow4 {
        [DispId(1181)]
        IHTMLFrameBase frameElement {
        	[return: MarshalAs(UnmanagedType.IDispatch)]
        	get;
        }
    }
}