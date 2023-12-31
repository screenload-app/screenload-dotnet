﻿/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on Sourceforge: http://sourceforge.net/projects/ScreenLoad/
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

namespace ScreenLoadDownloadRuPlugin
{
    /// <summary>
    /// This class is merely a placeholder for the file keeping the API key and secret for Box integration.
    /// Copy this file to BoxCredentials.private.cs and fill in valid credentials. (Or empty strings, but of course you won't be able to use the plugin then.)
    /// </summary>
    public static class Constants
    {
        //public static string ClientId = "7c3254ec63a2b33ddaaf99f835c527e9c186abc24dd1db6adfc8cefd35ef8dbc";
        //public static string ClientSecret = "ae5d23cee6611e546e3f393e248f7fcfe0bc23ea53a6022de9faa2fb0ab6dbc8";

        public static string ClientId = "0524f0e89a3fd0912b1ed4484e21cde8c02e5e5625fe070ba65e5ff2deaf78e2";
        public static string ClientSecret = "7f090e18d58cf2983f071b3f5afb544e0aaba1e8ce80f83e9a9bfb9ee9b917f5";

        public static string AnonymousKey = "d0327c42657d96742bcd979acedbf0a3";

        public const string LanguagePrefix = "downloadru";
    }
}