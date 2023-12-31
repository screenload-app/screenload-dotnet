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
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ScreenLoadPlugin.Core;

namespace ScreenLoadPlugin.Controls {
	/// <summary>
	/// Description of PleaseWaitForm.
	/// </summary>
	public sealed partial class BackgroundForm : Form {
		private volatile bool _shouldClose;
				
		private void BackgroundShowDialog() {
			ShowDialog();
		}

		public static BackgroundForm ShowAndWait(string title, string text) {
			BackgroundForm backgroundForm = new BackgroundForm(title, text);
			// Show form in background thread
			Thread backgroundTask = new Thread (backgroundForm.BackgroundShowDialog);
			backgroundForm.Name = "Background form";
			backgroundTask.IsBackground = true;
			backgroundTask.SetApartmentState(ApartmentState.STA);
			backgroundTask.Start();
			return backgroundForm;
		}

		public BackgroundForm(string title, string text){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Icon = ScreenLoadResources.win_old;
			_shouldClose = false;
			Text = title;
			label_pleasewait.Text = text;
			FormClosing += PreventFormClose;
			timer_checkforclose.Start();
		}
		
		// Can be used instead of ShowDialog
		public new void Show() {
			base.Show();
			bool positioned = false;
			foreach(Screen screen in Screen.AllScreens) {
				if (screen.Bounds.Contains(Cursor.Position)) {
					positioned = true;
					Location = new Point(screen.Bounds.X + (screen.Bounds.Width / 2) - (Width / 2), screen.Bounds.Y + (screen.Bounds.Height / 2) - (Height / 2));
					break;
				}
			}
			if (!positioned) {
				Location = new Point(Cursor.Position.X - Width / 2, Cursor.Position.Y - Height / 2);
			}
		}

		private void PreventFormClose(object sender, FormClosingEventArgs e) {
			if(!_shouldClose) {
				e.Cancel = true;
			}
		}

		private void Timer_checkforcloseTick(object sender, EventArgs e) {
			if (_shouldClose) {
				timer_checkforclose.Stop();
				BeginInvoke(new EventHandler( delegate {Close();}));
			}
		}
		
		public void CloseDialog() {
			_shouldClose = true;
			Application.DoEvents();
		}

		private void BackgroundFormFormClosing(object sender, FormClosingEventArgs e) {
			timer_checkforclose.Stop();
		}
	}
}
