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
namespace ScreenLoad {
	partial class SettingsForm {
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.textbox_storagelocation = new ScreenLoadPlugin.Controls.ScreenLoadTextBox();
            this.label_storagelocation = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.settings_cancel = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.settings_confirm = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browse = new System.Windows.Forms.Button();
            this.label_screenshotname = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textbox_screenshotname = new ScreenLoadPlugin.Controls.ScreenLoadTextBox();
            this.label_language = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.combobox_language = new System.Windows.Forms.ComboBox();
            this.combobox_primaryimageformat = new ScreenLoadPlugin.Controls.ScreenLoadComboBox();
            this.label_primaryimageformat = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.groupbox_preferredfilesettings = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.screenLoadCheckBox1 = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.btnPatternHelp = new System.Windows.Forms.Button();
            this.checkbox_copypathtoclipboard = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_zoomer = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.groupbox_applicationsettings = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.IconSizeComboBox = new System.Windows.Forms.ComboBox();
            this.quickSettingsCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.label_icon_size = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.checkbox_autostartshortcut = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_usedefaultproxy = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.groupbox_qualitysettings = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.checkbox_reducecolors = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_alwaysshowqualitydialog = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.label_jpegquality = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textBoxJpegQuality = new System.Windows.Forms.TextBox();
            this.trackBarJpegQuality = new System.Windows.Forms.TrackBar();
            this.groupbox_destination = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.useQuickEditModeCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_picker = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.listview_destinations = new System.Windows.Forms.ListView();
            this.destination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tab_general = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.groupbox_network = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.checkUpdatesOnceADayCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkUpdatesAfterSavingCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkUpdatesAtStartupCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkUpdatesManuallyRadioButton = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.checkUpdatesAutoRadioButton = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.checkUpdatesButton = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.groupbox_hotkeys = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.label_lastregion_hotkey = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.lastregion_hotkeyControl = new ScreenLoadPlugin.Controls.HotkeyControl();
            this.label_ie_hotkey = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.ie_hotkeyControl = new ScreenLoadPlugin.Controls.HotkeyControl();
            this.label_region_hotkey = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.label_window_hotkey = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.label_fullscreen_hotkey = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.region_hotkeyControl = new ScreenLoadPlugin.Controls.HotkeyControl();
            this.window_hotkeyControl = new ScreenLoadPlugin.Controls.HotkeyControl();
            this.fullscreen_hotkeyControl = new ScreenLoadPlugin.Controls.HotkeyControl();
            this.tab_capture = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.groupbox_editor = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.askSavingPathCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.editorConfirmationCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_editor_match_capture_size = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.groupbox_iecapture = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.checkbox_ie_capture = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.groupbox_windowscapture = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.colorButton_window_background = new ScreenLoad.Controls.ColorButton();
            this.radiobuttonWindowCapture = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.radiobuttonInteractiveCapture = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.combobox_window_capture_mode = new System.Windows.Forms.ComboBox();
            this.groupbox_capture = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.captureAreaColorCheckBox = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.captureAreaColorButton = new ScreenLoad.Controls.ColorButton();
            this.checkbox_notifications = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_playsound = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_capture_mousepointer = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.numericUpDownWaitTime = new System.Windows.Forms.NumericUpDown();
            this.label_waittime = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.tab_output = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.tab_destinations = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.tab_printer = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.groupBoxColors = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.checkboxPrintInverted = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.radioBtnColorPrint = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.radioBtnGrayScale = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.radioBtnMonochrome = new ScreenLoadPlugin.Controls.ScreenLoadRadioButton();
            this.groupBoxPrintLayout = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.checkboxDateTime = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkboxAllowShrink = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkboxAllowEnlarge = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkboxAllowRotate = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkboxAllowCenter = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_alwaysshowprintoptionsdialog = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.tab_plugins = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.groupbox_plugins = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.listview_plugins = new System.Windows.Forms.ListView();
            this.button_pluginconfigure = new ScreenLoadPlugin.Controls.ScreenLoadButton();
            this.tab_expert = new ScreenLoadPlugin.Controls.ScreenLoadTabPage();
            this.groupbox_expert = new ScreenLoadPlugin.Controls.ScreenLoadGroupBox();
            this.checkbox_reuseeditor = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_minimizememoryfootprint = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_checkunstableupdates = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_suppresssavedialogatclose = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.label_counter = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textbox_counter = new ScreenLoadPlugin.Controls.ScreenLoadTextBox();
            this.label_footerpattern = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.textbox_footerpattern = new ScreenLoadPlugin.Controls.ScreenLoadTextBox();
            this.checkbox_thumbnailpreview = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_optimizeforrdp = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.checkbox_autoreducecolors = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.label_clipboardformats = new ScreenLoadPlugin.Controls.ScreenLoadLabel();
            this.checkbox_enableexpert = new ScreenLoadPlugin.Controls.ScreenLoadCheckBox();
            this.listview_clipboardformats = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupbox_preferredfilesettings.SuspendLayout();
            this.groupbox_applicationsettings.SuspendLayout();
            this.groupbox_qualitysettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarJpegQuality)).BeginInit();
            this.groupbox_destination.SuspendLayout();
            this.tabcontrol.SuspendLayout();
            this.tab_general.SuspendLayout();
            this.groupbox_network.SuspendLayout();
            this.groupbox_hotkeys.SuspendLayout();
            this.tab_capture.SuspendLayout();
            this.groupbox_editor.SuspendLayout();
            this.groupbox_iecapture.SuspendLayout();
            this.groupbox_windowscapture.SuspendLayout();
            this.groupbox_capture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaitTime)).BeginInit();
            this.tab_output.SuspendLayout();
            this.tab_destinations.SuspendLayout();
            this.tab_printer.SuspendLayout();
            this.groupBoxColors.SuspendLayout();
            this.groupBoxPrintLayout.SuspendLayout();
            this.tab_plugins.SuspendLayout();
            this.groupbox_plugins.SuspendLayout();
            this.tab_expert.SuspendLayout();
            this.groupbox_expert.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_storagelocation
            // 
            this.textbox_storagelocation.Location = new System.Drawing.Point(138, 18);
            this.textbox_storagelocation.Name = "textbox_storagelocation";
            this.textbox_storagelocation.Size = new System.Drawing.Size(287, 20);
            this.textbox_storagelocation.TabIndex = 1;
            this.textbox_storagelocation.TextChanged += new System.EventHandler(this.StorageLocationChanged);
            // 
            // label_storagelocation
            // 
            this.label_storagelocation.AutoSize = true;
            this.label_storagelocation.LanguageKey = "settings_storagelocation";
            this.label_storagelocation.Location = new System.Drawing.Point(6, 21);
            this.label_storagelocation.Name = "label_storagelocation";
            this.label_storagelocation.Size = new System.Drawing.Size(84, 13);
            this.label_storagelocation.TabIndex = 0;
            this.label_storagelocation.Text = "Storage location";
            // 
            // settings_cancel
            // 
            this.settings_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_cancel.LanguageKey = "CANCEL";
            this.settings_cancel.Location = new System.Drawing.Point(429, 532);
            this.settings_cancel.Name = "settings_cancel";
            this.settings_cancel.Size = new System.Drawing.Size(75, 23);
            this.settings_cancel.TabIndex = 2;
            this.settings_cancel.Text = "Cancel";
            this.settings_cancel.UseVisualStyleBackColor = true;
            this.settings_cancel.Click += new System.EventHandler(this.Settings_cancelClick);
            // 
            // settings_confirm
            // 
            this.settings_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settings_confirm.LanguageKey = "OK";
            this.settings_confirm.Location = new System.Drawing.Point(348, 532);
            this.settings_confirm.Name = "settings_confirm";
            this.settings_confirm.Size = new System.Drawing.Size(75, 23);
            this.settings_confirm.TabIndex = 1;
            this.settings_confirm.Text = "Ok";
            this.settings_confirm.UseVisualStyleBackColor = true;
            this.settings_confirm.Click += new System.EventHandler(this.Settings_okayClick);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(431, 16);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(35, 23);
            this.browse.TabIndex = 2;
            this.browse.Text = "...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.BrowseClick);
            // 
            // label_screenshotname
            // 
            this.label_screenshotname.AutoSize = true;
            this.label_screenshotname.LanguageKey = "settings_filenamepattern";
            this.label_screenshotname.Location = new System.Drawing.Point(6, 47);
            this.label_screenshotname.Name = "label_screenshotname";
            this.label_screenshotname.Size = new System.Drawing.Size(85, 13);
            this.label_screenshotname.TabIndex = 3;
            this.label_screenshotname.Text = "Filename pattern";
            // 
            // textbox_screenshotname
            // 
            this.textbox_screenshotname.Location = new System.Drawing.Point(138, 44);
            this.textbox_screenshotname.Name = "textbox_screenshotname";
            this.textbox_screenshotname.PropertyName = "OutputFileFilenamePattern";
            this.textbox_screenshotname.Size = new System.Drawing.Size(287, 20);
            this.textbox_screenshotname.TabIndex = 4;
            this.textbox_screenshotname.TextChanged += new System.EventHandler(this.FilenamePatternChanged);
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.LanguageKey = "settings_language";
            this.label_language.Location = new System.Drawing.Point(6, 19);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(55, 13);
            this.label_language.TabIndex = 0;
            this.label_language.Text = "Language";
            // 
            // combobox_language
            // 
            this.combobox_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_language.FormattingEnabled = true;
            this.combobox_language.Location = new System.Drawing.Point(236, 16);
            this.combobox_language.MaxDropDownItems = 15;
            this.combobox_language.Name = "combobox_language";
            this.combobox_language.Size = new System.Drawing.Size(230, 21);
            this.combobox_language.TabIndex = 1;
            // 
            // combobox_primaryimageformat
            // 
            this.combobox_primaryimageformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_primaryimageformat.FormattingEnabled = true;
            this.combobox_primaryimageformat.Location = new System.Drawing.Point(138, 70);
            this.combobox_primaryimageformat.Name = "combobox_primaryimageformat";
            this.combobox_primaryimageformat.PropertyName = "OutputFileFormat";
            this.combobox_primaryimageformat.Size = new System.Drawing.Size(328, 21);
            this.combobox_primaryimageformat.TabIndex = 7;
            // 
            // label_primaryimageformat
            // 
            this.label_primaryimageformat.AutoSize = true;
            this.label_primaryimageformat.LanguageKey = "settings_primaryimageformat";
            this.label_primaryimageformat.Location = new System.Drawing.Point(6, 73);
            this.label_primaryimageformat.Name = "label_primaryimageformat";
            this.label_primaryimageformat.Size = new System.Drawing.Size(68, 13);
            this.label_primaryimageformat.TabIndex = 6;
            this.label_primaryimageformat.Text = "Image format";
            // 
            // groupbox_preferredfilesettings
            // 
            this.groupbox_preferredfilesettings.AutoSize = true;
            this.groupbox_preferredfilesettings.Controls.Add(this.screenLoadCheckBox1);
            this.groupbox_preferredfilesettings.Controls.Add(this.btnPatternHelp);
            this.groupbox_preferredfilesettings.Controls.Add(this.checkbox_copypathtoclipboard);
            this.groupbox_preferredfilesettings.Controls.Add(this.combobox_primaryimageformat);
            this.groupbox_preferredfilesettings.Controls.Add(this.label_primaryimageformat);
            this.groupbox_preferredfilesettings.Controls.Add(this.label_storagelocation);
            this.groupbox_preferredfilesettings.Controls.Add(this.browse);
            this.groupbox_preferredfilesettings.Controls.Add(this.textbox_storagelocation);
            this.groupbox_preferredfilesettings.Controls.Add(this.textbox_screenshotname);
            this.groupbox_preferredfilesettings.Controls.Add(this.label_screenshotname);
            this.groupbox_preferredfilesettings.LanguageKey = "settings_preferredfilesettings";
            this.groupbox_preferredfilesettings.Location = new System.Drawing.Point(6, 6);
            this.groupbox_preferredfilesettings.Name = "groupbox_preferredfilesettings";
            this.groupbox_preferredfilesettings.Size = new System.Drawing.Size(472, 156);
            this.groupbox_preferredfilesettings.TabIndex = 0;
            this.groupbox_preferredfilesettings.TabStop = false;
            this.groupbox_preferredfilesettings.Text = "Preferred Output File Settings";
            // 
            // screenLoadCheckBox1
            // 
            this.screenLoadCheckBox1.AutoSize = true;
            this.screenLoadCheckBox1.LanguageKey = "settings_openfolderafterimagesaved";
            this.screenLoadCheckBox1.Location = new System.Drawing.Point(6, 120);
            this.screenLoadCheckBox1.Name = "screenLoadCheckBox1";
            this.screenLoadCheckBox1.PropertyName = "OpenFolderAfterImageSaved";
            this.screenLoadCheckBox1.Size = new System.Drawing.Size(234, 17);
            this.screenLoadCheckBox1.TabIndex = 9;
            this.screenLoadCheckBox1.Text = "Open folder with the file after image is saved";
            this.screenLoadCheckBox1.UseVisualStyleBackColor = true;
            // 
            // btnPatternHelp
            // 
            this.btnPatternHelp.Location = new System.Drawing.Point(431, 41);
            this.btnPatternHelp.Name = "btnPatternHelp";
            this.btnPatternHelp.Size = new System.Drawing.Size(35, 23);
            this.btnPatternHelp.TabIndex = 5;
            this.btnPatternHelp.Text = "?";
            this.btnPatternHelp.UseVisualStyleBackColor = true;
            this.btnPatternHelp.Click += new System.EventHandler(this.BtnPatternHelpClick);
            // 
            // checkbox_copypathtoclipboard
            // 
            this.checkbox_copypathtoclipboard.AutoSize = true;
            this.checkbox_copypathtoclipboard.LanguageKey = "settings_copypathtoclipboard";
            this.checkbox_copypathtoclipboard.Location = new System.Drawing.Point(6, 97);
            this.checkbox_copypathtoclipboard.Name = "checkbox_copypathtoclipboard";
            this.checkbox_copypathtoclipboard.PropertyName = "OutputFileCopyPathToClipboard";
            this.checkbox_copypathtoclipboard.Size = new System.Drawing.Size(287, 17);
            this.checkbox_copypathtoclipboard.TabIndex = 8;
            this.checkbox_copypathtoclipboard.Text = "Copy file path to clipboard every time an image is saved";
            this.checkbox_copypathtoclipboard.UseVisualStyleBackColor = true;
            // 
            // checkbox_zoomer
            // 
            this.checkbox_zoomer.AutoSize = true;
            this.checkbox_zoomer.LanguageKey = "settings_zoom";
            this.checkbox_zoomer.Location = new System.Drawing.Point(6, 88);
            this.checkbox_zoomer.Name = "checkbox_zoomer";
            this.checkbox_zoomer.PropertyName = "ZoomerEnabled";
            this.checkbox_zoomer.Size = new System.Drawing.Size(98, 17);
            this.checkbox_zoomer.TabIndex = 3;
            this.checkbox_zoomer.Text = "Show magnifier";
            this.checkbox_zoomer.UseVisualStyleBackColor = true;
            // 
            // groupbox_applicationsettings
            // 
            this.groupbox_applicationsettings.AutoSize = true;
            this.groupbox_applicationsettings.Controls.Add(this.IconSizeComboBox);
            this.groupbox_applicationsettings.Controls.Add(this.quickSettingsCheckBox);
            this.groupbox_applicationsettings.Controls.Add(this.label_language);
            this.groupbox_applicationsettings.Controls.Add(this.combobox_language);
            this.groupbox_applicationsettings.Controls.Add(this.label_icon_size);
            this.groupbox_applicationsettings.Controls.Add(this.checkbox_autostartshortcut);
            this.groupbox_applicationsettings.Controls.Add(this.checkbox_usedefaultproxy);
            this.groupbox_applicationsettings.LanguageKey = "settings_applicationsettings";
            this.groupbox_applicationsettings.Location = new System.Drawing.Point(6, 6);
            this.groupbox_applicationsettings.Name = "groupbox_applicationsettings";
            this.groupbox_applicationsettings.Size = new System.Drawing.Size(472, 146);
            this.groupbox_applicationsettings.TabIndex = 0;
            this.groupbox_applicationsettings.TabStop = false;
            this.groupbox_applicationsettings.Text = "Application Settings";
            // 
            // IconSizeComboBox
            // 
            this.IconSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IconSizeComboBox.Location = new System.Drawing.Point(236, 42);
            this.IconSizeComboBox.MaxDropDownItems = 10;
            this.IconSizeComboBox.Name = "IconSizeComboBox";
            this.IconSizeComboBox.Size = new System.Drawing.Size(230, 21);
            this.IconSizeComboBox.TabIndex = 3;
            // 
            // quickSettingsCheckBox
            // 
            this.quickSettingsCheckBox.AutoSize = true;
            this.quickSettingsCheckBox.LanguageKey = "Settings_ShowQuickSettings";
            this.quickSettingsCheckBox.Location = new System.Drawing.Point(6, 110);
            this.quickSettingsCheckBox.Name = "quickSettingsCheckBox";
            this.quickSettingsCheckBox.PropertyName = "ShowQuickSettings";
            this.quickSettingsCheckBox.Size = new System.Drawing.Size(150, 17);
            this.quickSettingsCheckBox.TabIndex = 6;
            this.quickSettingsCheckBox.Text = "Show quick settings menu";
            this.quickSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label_icon_size
            // 
            this.label_icon_size.AutoSize = true;
            this.label_icon_size.LanguageKey = "settings_iconsize";
            this.label_icon_size.Location = new System.Drawing.Point(6, 45);
            this.label_icon_size.Name = "label_icon_size";
            this.label_icon_size.Size = new System.Drawing.Size(49, 13);
            this.label_icon_size.TabIndex = 2;
            this.label_icon_size.Text = "Icon size";
            // 
            // checkbox_autostartshortcut
            // 
            this.checkbox_autostartshortcut.AutoSize = true;
            this.checkbox_autostartshortcut.LanguageKey = "settings_autostartshortcut";
            this.checkbox_autostartshortcut.Location = new System.Drawing.Point(6, 64);
            this.checkbox_autostartshortcut.Name = "checkbox_autostartshortcut";
            this.checkbox_autostartshortcut.Size = new System.Drawing.Size(173, 17);
            this.checkbox_autostartshortcut.TabIndex = 4;
            this.checkbox_autostartshortcut.Text = "Launch ScreenLoad on startup";
            this.checkbox_autostartshortcut.UseVisualStyleBackColor = true;
            // 
            // checkbox_usedefaultproxy
            // 
            this.checkbox_usedefaultproxy.AutoSize = true;
            this.checkbox_usedefaultproxy.LanguageKey = "settings_usedefaultproxy";
            this.checkbox_usedefaultproxy.Location = new System.Drawing.Point(6, 87);
            this.checkbox_usedefaultproxy.Name = "checkbox_usedefaultproxy";
            this.checkbox_usedefaultproxy.PropertyName = "UseProxy";
            this.checkbox_usedefaultproxy.Size = new System.Drawing.Size(143, 17);
            this.checkbox_usedefaultproxy.TabIndex = 5;
            this.checkbox_usedefaultproxy.Text = "Use default system proxy";
            this.checkbox_usedefaultproxy.UseVisualStyleBackColor = true;
            // 
            // groupbox_qualitysettings
            // 
            this.groupbox_qualitysettings.AutoSize = true;
            this.groupbox_qualitysettings.Controls.Add(this.checkbox_reducecolors);
            this.groupbox_qualitysettings.Controls.Add(this.checkbox_alwaysshowqualitydialog);
            this.groupbox_qualitysettings.Controls.Add(this.label_jpegquality);
            this.groupbox_qualitysettings.Controls.Add(this.textBoxJpegQuality);
            this.groupbox_qualitysettings.Controls.Add(this.trackBarJpegQuality);
            this.groupbox_qualitysettings.LanguageKey = "settings_qualitysettings";
            this.groupbox_qualitysettings.Location = new System.Drawing.Point(6, 164);
            this.groupbox_qualitysettings.Name = "groupbox_qualitysettings";
            this.groupbox_qualitysettings.Size = new System.Drawing.Size(472, 129);
            this.groupbox_qualitysettings.TabIndex = 1;
            this.groupbox_qualitysettings.TabStop = false;
            this.groupbox_qualitysettings.Text = "Quality settings";
            // 
            // checkbox_reducecolors
            // 
            this.checkbox_reducecolors.AutoSize = true;
            this.checkbox_reducecolors.LanguageKey = "settings_reducecolors";
            this.checkbox_reducecolors.Location = new System.Drawing.Point(6, 93);
            this.checkbox_reducecolors.Name = "checkbox_reducecolors";
            this.checkbox_reducecolors.PropertyName = "OutputFileReduceColors";
            this.checkbox_reducecolors.Size = new System.Drawing.Size(263, 17);
            this.checkbox_reducecolors.TabIndex = 4;
            this.checkbox_reducecolors.Text = "Reduce the amount of colors to a maximum of 256";
            this.checkbox_reducecolors.UseVisualStyleBackColor = true;
            // 
            // checkbox_alwaysshowqualitydialog
            // 
            this.checkbox_alwaysshowqualitydialog.AutoSize = true;
            this.checkbox_alwaysshowqualitydialog.LanguageKey = "settings_alwaysshowqualitydialog";
            this.checkbox_alwaysshowqualitydialog.Location = new System.Drawing.Point(6, 70);
            this.checkbox_alwaysshowqualitydialog.Name = "checkbox_alwaysshowqualitydialog";
            this.checkbox_alwaysshowqualitydialog.PropertyName = "OutputFilePromptQuality";
            this.checkbox_alwaysshowqualitydialog.Size = new System.Drawing.Size(256, 17);
            this.checkbox_alwaysshowqualitydialog.TabIndex = 3;
            this.checkbox_alwaysshowqualitydialog.Text = "Show quality dialog every time an image is saved";
            this.checkbox_alwaysshowqualitydialog.UseVisualStyleBackColor = true;
            // 
            // label_jpegquality
            // 
            this.label_jpegquality.AutoSize = true;
            this.label_jpegquality.LanguageKey = "settings_jpegquality";
            this.label_jpegquality.Location = new System.Drawing.Point(6, 24);
            this.label_jpegquality.Name = "label_jpegquality";
            this.label_jpegquality.Size = new System.Drawing.Size(67, 13);
            this.label_jpegquality.TabIndex = 0;
            this.label_jpegquality.Text = "JPEG quality";
            // 
            // textBoxJpegQuality
            // 
            this.textBoxJpegQuality.Enabled = false;
            this.textBoxJpegQuality.Location = new System.Drawing.Point(431, 19);
            this.textBoxJpegQuality.Name = "textBoxJpegQuality";
            this.textBoxJpegQuality.ReadOnly = true;
            this.textBoxJpegQuality.Size = new System.Drawing.Size(35, 20);
            this.textBoxJpegQuality.TabIndex = 2;
            this.textBoxJpegQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trackBarJpegQuality
            // 
            this.trackBarJpegQuality.LargeChange = 10;
            this.trackBarJpegQuality.Location = new System.Drawing.Point(138, 19);
            this.trackBarJpegQuality.Maximum = 100;
            this.trackBarJpegQuality.Name = "trackBarJpegQuality";
            this.trackBarJpegQuality.Size = new System.Drawing.Size(287, 45);
            this.trackBarJpegQuality.TabIndex = 1;
            this.trackBarJpegQuality.TickFrequency = 10;
            this.trackBarJpegQuality.Scroll += new System.EventHandler(this.TrackBarJpegQualityScroll);
            // 
            // groupbox_destination
            // 
            this.groupbox_destination.AutoSize = true;
            this.groupbox_destination.Controls.Add(this.useQuickEditModeCheckBox);
            this.groupbox_destination.Controls.Add(this.checkbox_picker);
            this.groupbox_destination.Controls.Add(this.listview_destinations);
            this.groupbox_destination.LanguageKey = "settings_destination";
            this.groupbox_destination.Location = new System.Drawing.Point(6, 6);
            this.groupbox_destination.Name = "groupbox_destination";
            this.groupbox_destination.Size = new System.Drawing.Size(474, 351);
            this.groupbox_destination.TabIndex = 0;
            this.groupbox_destination.TabStop = false;
            this.groupbox_destination.Text = "Destination";
            // 
            // useQuickEditModeCheckBox
            // 
            this.useQuickEditModeCheckBox.AutoSize = true;
            this.useQuickEditModeCheckBox.LanguageKey = "settings_useQuickEditMode";
            this.useQuickEditModeCheckBox.Location = new System.Drawing.Point(6, 19);
            this.useQuickEditModeCheckBox.Name = "useQuickEditModeCheckBox";
            this.useQuickEditModeCheckBox.PropertyName = "UseQuickEditMode";
            this.useQuickEditModeCheckBox.Size = new System.Drawing.Size(171, 17);
            this.useQuickEditModeCheckBox.TabIndex = 0;
            this.useQuickEditModeCheckBox.Text = "Preferably use quick edit mode";
            this.useQuickEditModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkbox_picker
            // 
            this.checkbox_picker.AutoSize = true;
            this.checkbox_picker.LanguageKey = "settings_destination_picker";
            this.checkbox_picker.Location = new System.Drawing.Point(6, 42);
            this.checkbox_picker.Name = "checkbox_picker";
            this.checkbox_picker.Size = new System.Drawing.Size(167, 17);
            this.checkbox_picker.TabIndex = 1;
            this.checkbox_picker.Text = "Select destination dynamically";
            this.checkbox_picker.UseVisualStyleBackColor = true;
            this.checkbox_picker.CheckStateChanged += new System.EventHandler(this.DestinationsCheckStateChanged);
            // 
            // listview_destinations
            // 
            this.listview_destinations.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listview_destinations.AutoArrange = false;
            this.listview_destinations.CheckBoxes = true;
            this.listview_destinations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.destination});
            this.listview_destinations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview_destinations.HideSelection = false;
            this.listview_destinations.LabelWrap = false;
            this.listview_destinations.Location = new System.Drawing.Point(6, 65);
            this.listview_destinations.Name = "listview_destinations";
            this.listview_destinations.ShowGroups = false;
            this.listview_destinations.Size = new System.Drawing.Size(462, 267);
            this.listview_destinations.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listview_destinations.TabIndex = 2;
            this.listview_destinations.UseCompatibleStateImageBehavior = false;
            this.listview_destinations.View = System.Windows.Forms.View.Details;
            // 
            // destination
            // 
            this.destination.Text = "Destination";
            this.destination.Width = 380;
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.tab_general);
            this.tabcontrol.Controls.Add(this.tab_capture);
            this.tabcontrol.Controls.Add(this.tab_output);
            this.tabcontrol.Controls.Add(this.tab_destinations);
            this.tabcontrol.Controls.Add(this.tab_printer);
            this.tabcontrol.Controls.Add(this.tab_plugins);
            this.tabcontrol.Controls.Add(this.tab_expert);
            this.tabcontrol.Location = new System.Drawing.Point(12, 13);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(492, 508);
            this.tabcontrol.TabIndex = 0;
            // 
            // tab_general
            // 
            this.tab_general.BackColor = System.Drawing.Color.Transparent;
            this.tab_general.Controls.Add(this.groupbox_network);
            this.tab_general.Controls.Add(this.groupbox_hotkeys);
            this.tab_general.Controls.Add(this.groupbox_applicationsettings);
            this.tab_general.LanguageKey = "settings_general";
            this.tab_general.Location = new System.Drawing.Point(4, 22);
            this.tab_general.Name = "tab_general";
            this.tab_general.Padding = new System.Windows.Forms.Padding(3);
            this.tab_general.Size = new System.Drawing.Size(484, 482);
            this.tab_general.TabIndex = 0;
            this.tab_general.Text = "General";
            this.tab_general.UseVisualStyleBackColor = true;
            // 
            // groupbox_network
            // 
            this.groupbox_network.AutoSize = true;
            this.groupbox_network.Controls.Add(this.checkUpdatesOnceADayCheckBox);
            this.groupbox_network.Controls.Add(this.checkUpdatesAfterSavingCheckBox);
            this.groupbox_network.Controls.Add(this.checkUpdatesAtStartupCheckBox);
            this.groupbox_network.Controls.Add(this.checkUpdatesManuallyRadioButton);
            this.groupbox_network.Controls.Add(this.checkUpdatesAutoRadioButton);
            this.groupbox_network.Controls.Add(this.checkUpdatesButton);
            this.groupbox_network.LanguageKey = "Settings_UpdatesGroup";
            this.groupbox_network.Location = new System.Drawing.Point(6, 323);
            this.groupbox_network.Name = "groupbox_network";
            this.groupbox_network.Size = new System.Drawing.Size(472, 153);
            this.groupbox_network.TabIndex = 2;
            this.groupbox_network.TabStop = false;
            this.groupbox_network.Text = "Check for updates";
            // 
            // checkUpdatesOnceADayCheckBox
            // 
            this.checkUpdatesOnceADayCheckBox.AutoSize = true;
            this.checkUpdatesOnceADayCheckBox.LanguageKey = "Settings_CheckUpdatesOnceADay";
            this.checkUpdatesOnceADayCheckBox.Location = new System.Drawing.Point(18, 88);
            this.checkUpdatesOnceADayCheckBox.Name = "checkUpdatesOnceADayCheckBox";
            this.checkUpdatesOnceADayCheckBox.PropertyName = "CheckUpdatesOnceADay";
            this.checkUpdatesOnceADayCheckBox.Size = new System.Drawing.Size(81, 17);
            this.checkUpdatesOnceADayCheckBox.TabIndex = 4;
            this.checkUpdatesOnceADayCheckBox.Text = "Once a day";
            this.checkUpdatesOnceADayCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkUpdatesAfterSavingCheckBox
            // 
            this.checkUpdatesAfterSavingCheckBox.AutoSize = true;
            this.checkUpdatesAfterSavingCheckBox.LanguageKey = "Settings_CheckUpdatesAfterSaving";
            this.checkUpdatesAfterSavingCheckBox.Location = new System.Drawing.Point(18, 65);
            this.checkUpdatesAfterSavingCheckBox.Name = "checkUpdatesAfterSavingCheckBox";
            this.checkUpdatesAfterSavingCheckBox.PropertyName = "CheckUpdatesAfterSaving";
            this.checkUpdatesAfterSavingCheckBox.Size = new System.Drawing.Size(291, 17);
            this.checkUpdatesAfterSavingCheckBox.TabIndex = 3;
            this.checkUpdatesAfterSavingCheckBox.Text = "After saving the screenshot to the cloud, file or clipboard";
            this.checkUpdatesAfterSavingCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkUpdatesAtStartupCheckBox
            // 
            this.checkUpdatesAtStartupCheckBox.AutoSize = true;
            this.checkUpdatesAtStartupCheckBox.LanguageKey = "Settings_CheckUpdatesAtStartup";
            this.checkUpdatesAtStartupCheckBox.Location = new System.Drawing.Point(18, 42);
            this.checkUpdatesAtStartupCheckBox.Name = "checkUpdatesAtStartupCheckBox";
            this.checkUpdatesAtStartupCheckBox.PropertyName = "CheckUpdatesAtStartup";
            this.checkUpdatesAtStartupCheckBox.Size = new System.Drawing.Size(112, 17);
            this.checkUpdatesAtStartupCheckBox.TabIndex = 2;
            this.checkUpdatesAtStartupCheckBox.Text = "At program startup";
            this.checkUpdatesAtStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkUpdatesManuallyRadioButton
            // 
            this.checkUpdatesManuallyRadioButton.AutoSize = true;
            this.checkUpdatesManuallyRadioButton.LanguageKey = "Settings_CheckUpdatesManually";
            this.checkUpdatesManuallyRadioButton.Location = new System.Drawing.Point(236, 19);
            this.checkUpdatesManuallyRadioButton.Name = "checkUpdatesManuallyRadioButton";
            this.checkUpdatesManuallyRadioButton.PropertyName = "";
            this.checkUpdatesManuallyRadioButton.Size = new System.Drawing.Size(67, 17);
            this.checkUpdatesManuallyRadioButton.TabIndex = 1;
            this.checkUpdatesManuallyRadioButton.Text = "Manually";
            this.checkUpdatesManuallyRadioButton.UseVisualStyleBackColor = true;
            // 
            // checkUpdatesAutoRadioButton
            // 
            this.checkUpdatesAutoRadioButton.AutoSize = true;
            this.checkUpdatesAutoRadioButton.Checked = true;
            this.checkUpdatesAutoRadioButton.LanguageKey = "Settings_CheckUpdatesAuto";
            this.checkUpdatesAutoRadioButton.Location = new System.Drawing.Point(6, 19);
            this.checkUpdatesAutoRadioButton.Name = "checkUpdatesAutoRadioButton";
            this.checkUpdatesAutoRadioButton.PropertyName = "CheckUpdatesAuto";
            this.checkUpdatesAutoRadioButton.Size = new System.Drawing.Size(87, 17);
            this.checkUpdatesAutoRadioButton.TabIndex = 0;
            this.checkUpdatesAutoRadioButton.TabStop = true;
            this.checkUpdatesAutoRadioButton.Text = "Automatically";
            this.checkUpdatesAutoRadioButton.UseVisualStyleBackColor = true;
            this.checkUpdatesAutoRadioButton.CheckedChanged += new System.EventHandler(this.checkUpdatesAutoRadioButton_CheckedChanged);
            // 
            // checkUpdatesButton
            // 
            this.checkUpdatesButton.LanguageKey = "settings_checkupdatesbutton";
            this.checkUpdatesButton.Location = new System.Drawing.Point(236, 106);
            this.checkUpdatesButton.Name = "checkUpdatesButton";
            this.checkUpdatesButton.Size = new System.Drawing.Size(230, 23);
            this.checkUpdatesButton.TabIndex = 5;
            this.checkUpdatesButton.Text = "Check for updates right now";
            this.checkUpdatesButton.UseVisualStyleBackColor = true;
            this.checkUpdatesButton.Click += new System.EventHandler(this.checkUpdatesButton_Click);
            // 
            // groupbox_hotkeys
            // 
            this.groupbox_hotkeys.AutoSize = true;
            this.groupbox_hotkeys.Controls.Add(this.label_lastregion_hotkey);
            this.groupbox_hotkeys.Controls.Add(this.lastregion_hotkeyControl);
            this.groupbox_hotkeys.Controls.Add(this.label_ie_hotkey);
            this.groupbox_hotkeys.Controls.Add(this.ie_hotkeyControl);
            this.groupbox_hotkeys.Controls.Add(this.label_region_hotkey);
            this.groupbox_hotkeys.Controls.Add(this.label_window_hotkey);
            this.groupbox_hotkeys.Controls.Add(this.label_fullscreen_hotkey);
            this.groupbox_hotkeys.Controls.Add(this.region_hotkeyControl);
            this.groupbox_hotkeys.Controls.Add(this.window_hotkeyControl);
            this.groupbox_hotkeys.Controls.Add(this.fullscreen_hotkeyControl);
            this.groupbox_hotkeys.LanguageKey = "hotkeys";
            this.groupbox_hotkeys.Location = new System.Drawing.Point(6, 158);
            this.groupbox_hotkeys.Name = "groupbox_hotkeys";
            this.groupbox_hotkeys.Size = new System.Drawing.Size(472, 159);
            this.groupbox_hotkeys.TabIndex = 1;
            this.groupbox_hotkeys.TabStop = false;
            this.groupbox_hotkeys.Text = "Hotkeys";
            // 
            // label_lastregion_hotkey
            // 
            this.label_lastregion_hotkey.AutoSize = true;
            this.label_lastregion_hotkey.LanguageKey = "contextmenu_capturelastregion";
            this.label_lastregion_hotkey.Location = new System.Drawing.Point(6, 94);
            this.label_lastregion_hotkey.Name = "label_lastregion_hotkey";
            this.label_lastregion_hotkey.Size = new System.Drawing.Size(95, 13);
            this.label_lastregion_hotkey.TabIndex = 6;
            this.label_lastregion_hotkey.Text = "Capture last region";
            // 
            // lastregion_hotkeyControl
            // 
            this.lastregion_hotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.lastregion_hotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.lastregion_hotkeyControl.Location = new System.Drawing.Point(236, 94);
            this.lastregion_hotkeyControl.Name = "lastregion_hotkeyControl";
            this.lastregion_hotkeyControl.PropertyName = "LastregionHotkey";
            this.lastregion_hotkeyControl.Size = new System.Drawing.Size(230, 20);
            this.lastregion_hotkeyControl.TabIndex = 7;
            this.lastregion_hotkeyControl.TextChanged += new System.EventHandler(this.Lastregion_hotkeyControl_TextChanged);
            // 
            // label_ie_hotkey
            // 
            this.label_ie_hotkey.AutoSize = true;
            this.label_ie_hotkey.LanguageKey = "contextmenu_captureie";
            this.label_ie_hotkey.Location = new System.Drawing.Point(6, 120);
            this.label_ie_hotkey.Name = "label_ie_hotkey";
            this.label_ie_hotkey.Size = new System.Drawing.Size(124, 13);
            this.label_ie_hotkey.TabIndex = 8;
            this.label_ie_hotkey.Text = "Capture Internet Explorer";
            // 
            // ie_hotkeyControl
            // 
            this.ie_hotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.ie_hotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.ie_hotkeyControl.Location = new System.Drawing.Point(236, 120);
            this.ie_hotkeyControl.Name = "ie_hotkeyControl";
            this.ie_hotkeyControl.PropertyName = "IEHotkey";
            this.ie_hotkeyControl.Size = new System.Drawing.Size(230, 20);
            this.ie_hotkeyControl.TabIndex = 9;
            this.ie_hotkeyControl.TextChanged += new System.EventHandler(this.Ie_hotkeyControl_TextChanged);
            // 
            // label_region_hotkey
            // 
            this.label_region_hotkey.AutoSize = true;
            this.label_region_hotkey.LanguageKey = "contextmenu_capturearea";
            this.label_region_hotkey.Location = new System.Drawing.Point(6, 68);
            this.label_region_hotkey.Name = "label_region_hotkey";
            this.label_region_hotkey.Size = new System.Drawing.Size(76, 13);
            this.label_region_hotkey.TabIndex = 4;
            this.label_region_hotkey.Text = "Capture region";
            // 
            // label_window_hotkey
            // 
            this.label_window_hotkey.AutoSize = true;
            this.label_window_hotkey.LanguageKey = "contextmenu_capturewindow";
            this.label_window_hotkey.Location = new System.Drawing.Point(6, 42);
            this.label_window_hotkey.Name = "label_window_hotkey";
            this.label_window_hotkey.Size = new System.Drawing.Size(83, 13);
            this.label_window_hotkey.TabIndex = 2;
            this.label_window_hotkey.Text = "Capture window";
            // 
            // label_fullscreen_hotkey
            // 
            this.label_fullscreen_hotkey.AutoSize = true;
            this.label_fullscreen_hotkey.LanguageKey = "contextmenu_capturefullscreen";
            this.label_fullscreen_hotkey.Location = new System.Drawing.Point(6, 16);
            this.label_fullscreen_hotkey.Name = "label_fullscreen_hotkey";
            this.label_fullscreen_hotkey.Size = new System.Drawing.Size(95, 13);
            this.label_fullscreen_hotkey.TabIndex = 0;
            this.label_fullscreen_hotkey.Text = "Capture full screen";
            // 
            // region_hotkeyControl
            // 
            this.region_hotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.region_hotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.region_hotkeyControl.Location = new System.Drawing.Point(236, 68);
            this.region_hotkeyControl.Name = "region_hotkeyControl";
            this.region_hotkeyControl.PropertyName = "RegionHotkey";
            this.region_hotkeyControl.Size = new System.Drawing.Size(230, 20);
            this.region_hotkeyControl.TabIndex = 5;
            this.region_hotkeyControl.TextChanged += new System.EventHandler(this.Region_hotkeyControl_TextChanged);
            // 
            // window_hotkeyControl
            // 
            this.window_hotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.window_hotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.window_hotkeyControl.Location = new System.Drawing.Point(236, 42);
            this.window_hotkeyControl.Name = "window_hotkeyControl";
            this.window_hotkeyControl.PropertyName = "WindowHotkey";
            this.window_hotkeyControl.Size = new System.Drawing.Size(230, 20);
            this.window_hotkeyControl.TabIndex = 3;
            this.window_hotkeyControl.TextChanged += new System.EventHandler(this.Window_hotkeyControl_TextChanged);
            // 
            // fullscreen_hotkeyControl
            // 
            this.fullscreen_hotkeyControl.Hotkey = System.Windows.Forms.Keys.None;
            this.fullscreen_hotkeyControl.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.fullscreen_hotkeyControl.Location = new System.Drawing.Point(236, 16);
            this.fullscreen_hotkeyControl.Name = "fullscreen_hotkeyControl";
            this.fullscreen_hotkeyControl.PropertyName = "FullscreenHotkey";
            this.fullscreen_hotkeyControl.Size = new System.Drawing.Size(230, 20);
            this.fullscreen_hotkeyControl.TabIndex = 1;
            this.fullscreen_hotkeyControl.TextChanged += new System.EventHandler(this.Fullscreen_hotkeyControl_TextChanged);
            // 
            // tab_capture
            // 
            this.tab_capture.Controls.Add(this.groupbox_editor);
            this.tab_capture.Controls.Add(this.groupbox_iecapture);
            this.tab_capture.Controls.Add(this.groupbox_windowscapture);
            this.tab_capture.Controls.Add(this.groupbox_capture);
            this.tab_capture.LanguageKey = "settings_capture";
            this.tab_capture.Location = new System.Drawing.Point(4, 22);
            this.tab_capture.Name = "tab_capture";
            this.tab_capture.Size = new System.Drawing.Size(484, 482);
            this.tab_capture.TabIndex = 3;
            this.tab_capture.Text = "Capture";
            this.tab_capture.UseVisualStyleBackColor = true;
            // 
            // groupbox_editor
            // 
            this.groupbox_editor.AutoSize = true;
            this.groupbox_editor.Controls.Add(this.askSavingPathCheckBox);
            this.groupbox_editor.Controls.Add(this.editorConfirmationCheckBox);
            this.groupbox_editor.Controls.Add(this.checkbox_editor_match_capture_size);
            this.groupbox_editor.LanguageKey = "settings_editor";
            this.groupbox_editor.Location = new System.Drawing.Point(6, 338);
            this.groupbox_editor.Name = "groupbox_editor";
            this.groupbox_editor.Size = new System.Drawing.Size(472, 100);
            this.groupbox_editor.TabIndex = 3;
            this.groupbox_editor.TabStop = false;
            this.groupbox_editor.Text = "Editor";
            // 
            // askSavingPathCheckBox
            // 
            this.askSavingPathCheckBox.AutoSize = true;
            this.askSavingPathCheckBox.LanguageKey = "settings_quickeditorasksavingpath";
            this.askSavingPathCheckBox.Location = new System.Drawing.Point(6, 41);
            this.askSavingPathCheckBox.Name = "askSavingPathCheckBox";
            this.askSavingPathCheckBox.PropertyName = "QuickEditorAskSavingPath";
            this.askSavingPathCheckBox.Size = new System.Drawing.Size(206, 17);
            this.askSavingPathCheckBox.TabIndex = 1;
            this.askSavingPathCheckBox.Text = "Ask for saving path in quick edit mode";
            this.askSavingPathCheckBox.UseVisualStyleBackColor = true;
            // 
            // editorConfirmationCheckBox
            // 
            this.editorConfirmationCheckBox.AutoSize = true;
            this.editorConfirmationCheckBox.LanguageKey = "settings_editorconfirmation";
            this.editorConfirmationCheckBox.Location = new System.Drawing.Point(6, 64);
            this.editorConfirmationCheckBox.Name = "editorConfirmationCheckBox";
            this.editorConfirmationCheckBox.PropertyName = "";
            this.editorConfirmationCheckBox.SectionName = "";
            this.editorConfirmationCheckBox.Size = new System.Drawing.Size(263, 17);
            this.editorConfirmationCheckBox.TabIndex = 2;
            this.editorConfirmationCheckBox.Text = "Ask for confirmation when leaving quick edit mode";
            this.editorConfirmationCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkbox_editor_match_capture_size
            // 
            this.checkbox_editor_match_capture_size.AutoSize = true;
            this.checkbox_editor_match_capture_size.LanguageKey = "editor_match_capture_size";
            this.checkbox_editor_match_capture_size.Location = new System.Drawing.Point(6, 19);
            this.checkbox_editor_match_capture_size.Name = "checkbox_editor_match_capture_size";
            this.checkbox_editor_match_capture_size.PropertyName = "MatchSizeToCapture";
            this.checkbox_editor_match_capture_size.SectionName = "Editor";
            this.checkbox_editor_match_capture_size.Size = new System.Drawing.Size(116, 17);
            this.checkbox_editor_match_capture_size.TabIndex = 0;
            this.checkbox_editor_match_capture_size.Text = "Match capture size";
            this.checkbox_editor_match_capture_size.UseVisualStyleBackColor = true;
            // 
            // groupbox_iecapture
            // 
            this.groupbox_iecapture.AutoSize = true;
            this.groupbox_iecapture.Controls.Add(this.checkbox_ie_capture);
            this.groupbox_iecapture.LanguageKey = "settings_iecapture";
            this.groupbox_iecapture.Location = new System.Drawing.Point(6, 277);
            this.groupbox_iecapture.Name = "groupbox_iecapture";
            this.groupbox_iecapture.Size = new System.Drawing.Size(472, 55);
            this.groupbox_iecapture.TabIndex = 2;
            this.groupbox_iecapture.TabStop = false;
            this.groupbox_iecapture.Text = "Internet Explorer capture";
            // 
            // checkbox_ie_capture
            // 
            this.checkbox_ie_capture.AutoSize = true;
            this.checkbox_ie_capture.LanguageKey = "settings_iecapture";
            this.checkbox_ie_capture.Location = new System.Drawing.Point(6, 19);
            this.checkbox_ie_capture.Name = "checkbox_ie_capture";
            this.checkbox_ie_capture.PropertyName = "IECapture";
            this.checkbox_ie_capture.Size = new System.Drawing.Size(142, 17);
            this.checkbox_ie_capture.TabIndex = 0;
            this.checkbox_ie_capture.Text = "Internet Explorer capture";
            this.checkbox_ie_capture.UseVisualStyleBackColor = true;
            // 
            // groupbox_windowscapture
            // 
            this.groupbox_windowscapture.AutoSize = true;
            this.groupbox_windowscapture.Controls.Add(this.colorButton_window_background);
            this.groupbox_windowscapture.Controls.Add(this.radiobuttonWindowCapture);
            this.groupbox_windowscapture.Controls.Add(this.radiobuttonInteractiveCapture);
            this.groupbox_windowscapture.Controls.Add(this.combobox_window_capture_mode);
            this.groupbox_windowscapture.LanguageKey = "settings_windowscapture";
            this.groupbox_windowscapture.Location = new System.Drawing.Point(6, 185);
            this.groupbox_windowscapture.Name = "groupbox_windowscapture";
            this.groupbox_windowscapture.Size = new System.Drawing.Size(472, 86);
            this.groupbox_windowscapture.TabIndex = 1;
            this.groupbox_windowscapture.TabStop = false;
            this.groupbox_windowscapture.Text = "Window capture";
            // 
            // colorButton_window_background
            // 
            this.colorButton_window_background.AutoSize = true;
            this.colorButton_window_background.Image = ((System.Drawing.Image)(resources.GetObject("colorButton_window_background.Image")));
            this.colorButton_window_background.Location = new System.Drawing.Point(437, 37);
            this.colorButton_window_background.Name = "colorButton_window_background";
            this.colorButton_window_background.SelectedColor = System.Drawing.Color.White;
            this.colorButton_window_background.Size = new System.Drawing.Size(29, 30);
            this.colorButton_window_background.TabIndex = 3;
            this.colorButton_window_background.UseVisualStyleBackColor = true;
            // 
            // radiobuttonWindowCapture
            // 
            this.radiobuttonWindowCapture.AutoSize = true;
            this.radiobuttonWindowCapture.LanguageKey = "settings_window_capture_mode";
            this.radiobuttonWindowCapture.Location = new System.Drawing.Point(6, 44);
            this.radiobuttonWindowCapture.Name = "radiobuttonWindowCapture";
            this.radiobuttonWindowCapture.Size = new System.Drawing.Size(132, 17);
            this.radiobuttonWindowCapture.TabIndex = 1;
            this.radiobuttonWindowCapture.TabStop = true;
            this.radiobuttonWindowCapture.Text = "Window capture mode";
            this.radiobuttonWindowCapture.UseVisualStyleBackColor = true;
            // 
            // radiobuttonInteractiveCapture
            // 
            this.radiobuttonInteractiveCapture.AutoSize = true;
            this.radiobuttonInteractiveCapture.LanguageKey = "settings_capture_windows_interactive";
            this.radiobuttonInteractiveCapture.Location = new System.Drawing.Point(6, 21);
            this.radiobuttonInteractiveCapture.Name = "radiobuttonInteractiveCapture";
            this.radiobuttonInteractiveCapture.PropertyName = "CaptureWindowsInteractive";
            this.radiobuttonInteractiveCapture.Size = new System.Drawing.Size(203, 17);
            this.radiobuttonInteractiveCapture.TabIndex = 0;
            this.radiobuttonInteractiveCapture.TabStop = true;
            this.radiobuttonInteractiveCapture.Text = "Use interactive window capture mode";
            this.radiobuttonInteractiveCapture.UseVisualStyleBackColor = true;
            this.radiobuttonInteractiveCapture.CheckedChanged += new System.EventHandler(this.radiobutton_CheckedChanged);
            // 
            // combobox_window_capture_mode
            // 
            this.combobox_window_capture_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_window_capture_mode.FormattingEnabled = true;
            this.combobox_window_capture_mode.Location = new System.Drawing.Point(217, 43);
            this.combobox_window_capture_mode.MaxDropDownItems = 15;
            this.combobox_window_capture_mode.Name = "combobox_window_capture_mode";
            this.combobox_window_capture_mode.Size = new System.Drawing.Size(214, 21);
            this.combobox_window_capture_mode.TabIndex = 2;
            this.combobox_window_capture_mode.SelectedIndexChanged += new System.EventHandler(this.Combobox_window_capture_modeSelectedIndexChanged);
            // 
            // groupbox_capture
            // 
            this.groupbox_capture.AutoSize = true;
            this.groupbox_capture.Controls.Add(this.captureAreaColorCheckBox);
            this.groupbox_capture.Controls.Add(this.captureAreaColorButton);
            this.groupbox_capture.Controls.Add(this.checkbox_notifications);
            this.groupbox_capture.Controls.Add(this.checkbox_playsound);
            this.groupbox_capture.Controls.Add(this.checkbox_capture_mousepointer);
            this.groupbox_capture.Controls.Add(this.numericUpDownWaitTime);
            this.groupbox_capture.Controls.Add(this.label_waittime);
            this.groupbox_capture.Controls.Add(this.checkbox_zoomer);
            this.groupbox_capture.LanguageKey = "settings_capture";
            this.groupbox_capture.Location = new System.Drawing.Point(6, 6);
            this.groupbox_capture.Name = "groupbox_capture";
            this.groupbox_capture.Size = new System.Drawing.Size(472, 173);
            this.groupbox_capture.TabIndex = 0;
            this.groupbox_capture.TabStop = false;
            this.groupbox_capture.Text = "Capture";
            // 
            // captureAreaColorCheckBox
            // 
            this.captureAreaColorCheckBox.AutoSize = true;
            this.captureAreaColorCheckBox.LanguageKey = "capture_area_color";
            this.captureAreaColorCheckBox.Location = new System.Drawing.Point(6, 111);
            this.captureAreaColorCheckBox.Name = "captureAreaColorCheckBox";
            this.captureAreaColorCheckBox.PropertyName = "IsCaptureAreaColorUsed";
            this.captureAreaColorCheckBox.Size = new System.Drawing.Size(131, 17);
            this.captureAreaColorCheckBox.TabIndex = 4;
            this.captureAreaColorCheckBox.Text = "Set capture area color";
            this.captureAreaColorCheckBox.UseVisualStyleBackColor = true;
            this.captureAreaColorCheckBox.CheckedChanged += new System.EventHandler(this.CaptureAreaColorCheckBox_CheckedChanged);
            // 
            // captureAreaColorButton
            // 
            this.captureAreaColorButton.Image = ((System.Drawing.Image)(resources.GetObject("captureAreaColorButton.Image")));
            this.captureAreaColorButton.Location = new System.Drawing.Point(217, 103);
            this.captureAreaColorButton.Name = "captureAreaColorButton";
            this.captureAreaColorButton.SelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.captureAreaColorButton.Size = new System.Drawing.Size(29, 30);
            this.captureAreaColorButton.TabIndex = 5;
            this.captureAreaColorButton.UseVisualStyleBackColor = true;
            this.captureAreaColorButton.Visible = false;
            // 
            // checkbox_notifications
            // 
            this.checkbox_notifications.AutoSize = true;
            this.checkbox_notifications.LanguageKey = "settings_shownotify";
            this.checkbox_notifications.Location = new System.Drawing.Point(6, 65);
            this.checkbox_notifications.Name = "checkbox_notifications";
            this.checkbox_notifications.PropertyName = "ShowTrayNotification";
            this.checkbox_notifications.Size = new System.Drawing.Size(112, 17);
            this.checkbox_notifications.TabIndex = 2;
            this.checkbox_notifications.Text = "Show notifications";
            this.checkbox_notifications.UseVisualStyleBackColor = true;
            // 
            // checkbox_playsound
            // 
            this.checkbox_playsound.AutoSize = true;
            this.checkbox_playsound.LanguageKey = "settings_playsound";
            this.checkbox_playsound.Location = new System.Drawing.Point(6, 42);
            this.checkbox_playsound.Name = "checkbox_playsound";
            this.checkbox_playsound.PropertyName = "PlayCameraSound";
            this.checkbox_playsound.Size = new System.Drawing.Size(116, 17);
            this.checkbox_playsound.TabIndex = 1;
            this.checkbox_playsound.Text = "Play camera sound";
            this.checkbox_playsound.UseVisualStyleBackColor = true;
            // 
            // checkbox_capture_mousepointer
            // 
            this.checkbox_capture_mousepointer.AutoSize = true;
            this.checkbox_capture_mousepointer.LanguageKey = "settings_capture_mousepointer";
            this.checkbox_capture_mousepointer.Location = new System.Drawing.Point(6, 19);
            this.checkbox_capture_mousepointer.Name = "checkbox_capture_mousepointer";
            this.checkbox_capture_mousepointer.PropertyName = "CaptureMousepointer";
            this.checkbox_capture_mousepointer.Size = new System.Drawing.Size(129, 17);
            this.checkbox_capture_mousepointer.TabIndex = 0;
            this.checkbox_capture_mousepointer.Text = "Capture mousepointer";
            this.checkbox_capture_mousepointer.UseVisualStyleBackColor = true;
            // 
            // numericUpDownWaitTime
            // 
            this.numericUpDownWaitTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownWaitTime.Location = new System.Drawing.Point(6, 134);
            this.numericUpDownWaitTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWaitTime.Name = "numericUpDownWaitTime";
            this.numericUpDownWaitTime.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownWaitTime.TabIndex = 6;
            this.numericUpDownWaitTime.ThousandsSeparator = true;
            // 
            // label_waittime
            // 
            this.label_waittime.AutoSize = true;
            this.label_waittime.LanguageKey = "settings_waittime";
            this.label_waittime.Location = new System.Drawing.Point(76, 136);
            this.label_waittime.Name = "label_waittime";
            this.label_waittime.Size = new System.Drawing.Size(170, 13);
            this.label_waittime.TabIndex = 7;
            this.label_waittime.Text = "Milliseconds to wait before capture";
            // 
            // tab_output
            // 
            this.tab_output.BackColor = System.Drawing.Color.Transparent;
            this.tab_output.Controls.Add(this.groupbox_preferredfilesettings);
            this.tab_output.Controls.Add(this.groupbox_qualitysettings);
            this.tab_output.LanguageKey = "settings_output";
            this.tab_output.Location = new System.Drawing.Point(4, 22);
            this.tab_output.Name = "tab_output";
            this.tab_output.Padding = new System.Windows.Forms.Padding(3);
            this.tab_output.Size = new System.Drawing.Size(484, 482);
            this.tab_output.TabIndex = 1;
            this.tab_output.Text = "Output";
            this.tab_output.UseVisualStyleBackColor = true;
            // 
            // tab_destinations
            // 
            this.tab_destinations.Controls.Add(this.groupbox_destination);
            this.tab_destinations.LanguageKey = "settings_destination";
            this.tab_destinations.Location = new System.Drawing.Point(4, 22);
            this.tab_destinations.Name = "tab_destinations";
            this.tab_destinations.Size = new System.Drawing.Size(484, 482);
            this.tab_destinations.TabIndex = 4;
            this.tab_destinations.Text = "Destination";
            this.tab_destinations.UseVisualStyleBackColor = true;
            // 
            // tab_printer
            // 
            this.tab_printer.Controls.Add(this.groupBoxColors);
            this.tab_printer.Controls.Add(this.groupBoxPrintLayout);
            this.tab_printer.Controls.Add(this.checkbox_alwaysshowprintoptionsdialog);
            this.tab_printer.LanguageKey = "settings_printer";
            this.tab_printer.Location = new System.Drawing.Point(4, 22);
            this.tab_printer.Name = "tab_printer";
            this.tab_printer.Padding = new System.Windows.Forms.Padding(3);
            this.tab_printer.Size = new System.Drawing.Size(484, 482);
            this.tab_printer.TabIndex = 2;
            this.tab_printer.Text = "Printer";
            this.tab_printer.UseVisualStyleBackColor = true;
            // 
            // groupBoxColors
            // 
            this.groupBoxColors.AutoSize = true;
            this.groupBoxColors.Controls.Add(this.checkboxPrintInverted);
            this.groupBoxColors.Controls.Add(this.radioBtnColorPrint);
            this.groupBoxColors.Controls.Add(this.radioBtnGrayScale);
            this.groupBoxColors.Controls.Add(this.radioBtnMonochrome);
            this.groupBoxColors.LanguageKey = "printoptions_colors";
            this.groupBoxColors.Location = new System.Drawing.Point(6, 159);
            this.groupBoxColors.Name = "groupBoxColors";
            this.groupBoxColors.Size = new System.Drawing.Size(472, 124);
            this.groupBoxColors.TabIndex = 1;
            this.groupBoxColors.TabStop = false;
            this.groupBoxColors.Text = "Color settings";
            // 
            // checkboxPrintInverted
            // 
            this.checkboxPrintInverted.AutoSize = true;
            this.checkboxPrintInverted.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxPrintInverted.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxPrintInverted.LanguageKey = "printoptions_inverted";
            this.checkboxPrintInverted.Location = new System.Drawing.Point(6, 88);
            this.checkboxPrintInverted.Name = "checkboxPrintInverted";
            this.checkboxPrintInverted.PropertyName = "OutputPrintInverted";
            this.checkboxPrintInverted.Size = new System.Drawing.Size(141, 17);
            this.checkboxPrintInverted.TabIndex = 3;
            this.checkboxPrintInverted.Text = "Print with inverted colors";
            this.checkboxPrintInverted.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxPrintInverted.UseVisualStyleBackColor = true;
            // 
            // radioBtnColorPrint
            // 
            this.radioBtnColorPrint.AutoSize = true;
            this.radioBtnColorPrint.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnColorPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnColorPrint.LanguageKey = "printoptions_printcolor";
            this.radioBtnColorPrint.Location = new System.Drawing.Point(6, 19);
            this.radioBtnColorPrint.Name = "radioBtnColorPrint";
            this.radioBtnColorPrint.PropertyName = "OutputPrintColor";
            this.radioBtnColorPrint.Size = new System.Drawing.Size(90, 17);
            this.radioBtnColorPrint.TabIndex = 0;
            this.radioBtnColorPrint.Text = "Full color print";
            this.radioBtnColorPrint.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnColorPrint.UseVisualStyleBackColor = true;
            // 
            // radioBtnGrayScale
            // 
            this.radioBtnGrayScale.AutoSize = true;
            this.radioBtnGrayScale.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnGrayScale.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnGrayScale.LanguageKey = "printoptions_printgrayscale";
            this.radioBtnGrayScale.Location = new System.Drawing.Point(6, 42);
            this.radioBtnGrayScale.Name = "radioBtnGrayScale";
            this.radioBtnGrayScale.PropertyName = "OutputPrintGrayscale";
            this.radioBtnGrayScale.Size = new System.Drawing.Size(137, 17);
            this.radioBtnGrayScale.TabIndex = 1;
            this.radioBtnGrayScale.Text = "Force grayscale printing";
            this.radioBtnGrayScale.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnGrayScale.UseVisualStyleBackColor = true;
            // 
            // radioBtnMonochrome
            // 
            this.radioBtnMonochrome.AutoSize = true;
            this.radioBtnMonochrome.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnMonochrome.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnMonochrome.LanguageKey = "printoptions_printmonochrome";
            this.radioBtnMonochrome.Location = new System.Drawing.Point(6, 65);
            this.radioBtnMonochrome.Name = "radioBtnMonochrome";
            this.radioBtnMonochrome.PropertyName = "OutputPrintMonochrome";
            this.radioBtnMonochrome.Size = new System.Drawing.Size(148, 17);
            this.radioBtnMonochrome.TabIndex = 2;
            this.radioBtnMonochrome.Text = "Force black/white printing";
            this.radioBtnMonochrome.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioBtnMonochrome.UseVisualStyleBackColor = true;
            // 
            // groupBoxPrintLayout
            // 
            this.groupBoxPrintLayout.AutoSize = true;
            this.groupBoxPrintLayout.Controls.Add(this.checkboxDateTime);
            this.groupBoxPrintLayout.Controls.Add(this.checkboxAllowShrink);
            this.groupBoxPrintLayout.Controls.Add(this.checkboxAllowEnlarge);
            this.groupBoxPrintLayout.Controls.Add(this.checkboxAllowRotate);
            this.groupBoxPrintLayout.Controls.Add(this.checkboxAllowCenter);
            this.groupBoxPrintLayout.LanguageKey = "printoptions_layout";
            this.groupBoxPrintLayout.Location = new System.Drawing.Point(6, 6);
            this.groupBoxPrintLayout.Name = "groupBoxPrintLayout";
            this.groupBoxPrintLayout.Size = new System.Drawing.Size(472, 147);
            this.groupBoxPrintLayout.TabIndex = 0;
            this.groupBoxPrintLayout.TabStop = false;
            this.groupBoxPrintLayout.Text = "Page layout settings";
            // 
            // checkboxDateTime
            // 
            this.checkboxDateTime.AutoSize = true;
            this.checkboxDateTime.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxDateTime.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxDateTime.LanguageKey = "printoptions_timestamp";
            this.checkboxDateTime.Location = new System.Drawing.Point(6, 111);
            this.checkboxDateTime.Name = "checkboxDateTime";
            this.checkboxDateTime.PropertyName = "OutputPrintFooter";
            this.checkboxDateTime.Size = new System.Drawing.Size(187, 17);
            this.checkboxDateTime.TabIndex = 4;
            this.checkboxDateTime.Text = "Print date / time at bottom of page";
            this.checkboxDateTime.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxDateTime.UseVisualStyleBackColor = true;
            // 
            // checkboxAllowShrink
            // 
            this.checkboxAllowShrink.AutoSize = true;
            this.checkboxAllowShrink.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowShrink.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowShrink.LanguageKey = "printoptions_allowshrink";
            this.checkboxAllowShrink.Location = new System.Drawing.Point(6, 19);
            this.checkboxAllowShrink.Name = "checkboxAllowShrink";
            this.checkboxAllowShrink.PropertyName = "OutputPrintAllowShrink";
            this.checkboxAllowShrink.Size = new System.Drawing.Size(168, 17);
            this.checkboxAllowShrink.TabIndex = 0;
            this.checkboxAllowShrink.Text = "Shrink printout to fit paper size";
            this.checkboxAllowShrink.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowShrink.UseVisualStyleBackColor = true;
            // 
            // checkboxAllowEnlarge
            // 
            this.checkboxAllowEnlarge.AutoSize = true;
            this.checkboxAllowEnlarge.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowEnlarge.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowEnlarge.LanguageKey = "printoptions_allowenlarge";
            this.checkboxAllowEnlarge.Location = new System.Drawing.Point(6, 42);
            this.checkboxAllowEnlarge.Name = "checkboxAllowEnlarge";
            this.checkboxAllowEnlarge.PropertyName = "OutputPrintAllowEnlarge";
            this.checkboxAllowEnlarge.Size = new System.Drawing.Size(174, 17);
            this.checkboxAllowEnlarge.TabIndex = 1;
            this.checkboxAllowEnlarge.Text = "Enlarge printout to fit paper size";
            this.checkboxAllowEnlarge.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowEnlarge.UseVisualStyleBackColor = true;
            // 
            // checkboxAllowRotate
            // 
            this.checkboxAllowRotate.AutoSize = true;
            this.checkboxAllowRotate.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowRotate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowRotate.LanguageKey = "printoptions_allowrotate";
            this.checkboxAllowRotate.Location = new System.Drawing.Point(6, 65);
            this.checkboxAllowRotate.Name = "checkboxAllowRotate";
            this.checkboxAllowRotate.PropertyName = "OutputPrintAllowRotate";
            this.checkboxAllowRotate.Size = new System.Drawing.Size(187, 17);
            this.checkboxAllowRotate.TabIndex = 2;
            this.checkboxAllowRotate.Text = "Rotate printout to page orientation";
            this.checkboxAllowRotate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowRotate.UseVisualStyleBackColor = true;
            // 
            // checkboxAllowCenter
            // 
            this.checkboxAllowCenter.AutoSize = true;
            this.checkboxAllowCenter.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowCenter.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowCenter.LanguageKey = "printoptions_allowcenter";
            this.checkboxAllowCenter.Location = new System.Drawing.Point(6, 88);
            this.checkboxAllowCenter.Name = "checkboxAllowCenter";
            this.checkboxAllowCenter.PropertyName = "OutputPrintCenter";
            this.checkboxAllowCenter.Size = new System.Drawing.Size(137, 17);
            this.checkboxAllowCenter.TabIndex = 3;
            this.checkboxAllowCenter.Text = "Center printout on page";
            this.checkboxAllowCenter.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkboxAllowCenter.UseVisualStyleBackColor = true;
            // 
            // checkbox_alwaysshowprintoptionsdialog
            // 
            this.checkbox_alwaysshowprintoptionsdialog.AutoSize = true;
            this.checkbox_alwaysshowprintoptionsdialog.LanguageKey = "settings_alwaysshowprintoptionsdialog";
            this.checkbox_alwaysshowprintoptionsdialog.Location = new System.Drawing.Point(12, 289);
            this.checkbox_alwaysshowprintoptionsdialog.Name = "checkbox_alwaysshowprintoptionsdialog";
            this.checkbox_alwaysshowprintoptionsdialog.PropertyName = "OutputPrintPromptOptions";
            this.checkbox_alwaysshowprintoptionsdialog.Size = new System.Drawing.Size(286, 17);
            this.checkbox_alwaysshowprintoptionsdialog.TabIndex = 2;
            this.checkbox_alwaysshowprintoptionsdialog.Text = "Show print options dialog every time an image is printed";
            this.checkbox_alwaysshowprintoptionsdialog.UseVisualStyleBackColor = true;
            // 
            // tab_plugins
            // 
            this.tab_plugins.Controls.Add(this.groupbox_plugins);
            this.tab_plugins.LanguageKey = "settings_plugins";
            this.tab_plugins.Location = new System.Drawing.Point(4, 22);
            this.tab_plugins.Name = "tab_plugins";
            this.tab_plugins.Size = new System.Drawing.Size(484, 482);
            this.tab_plugins.TabIndex = 2;
            this.tab_plugins.Text = "Plugins";
            this.tab_plugins.UseVisualStyleBackColor = true;
            // 
            // groupbox_plugins
            // 
            this.groupbox_plugins.AutoSize = true;
            this.groupbox_plugins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupbox_plugins.Controls.Add(this.listview_plugins);
            this.groupbox_plugins.Controls.Add(this.button_pluginconfigure);
            this.groupbox_plugins.LanguageKey = "settings_plugins";
            this.groupbox_plugins.Location = new System.Drawing.Point(6, 6);
            this.groupbox_plugins.Name = "groupbox_plugins";
            this.groupbox_plugins.Size = new System.Drawing.Size(472, 300);
            this.groupbox_plugins.TabIndex = 0;
            this.groupbox_plugins.TabStop = false;
            this.groupbox_plugins.Text = "Plugins";
            // 
            // listview_plugins
            // 
            this.listview_plugins.Dock = System.Windows.Forms.DockStyle.Top;
            this.listview_plugins.FullRowSelect = true;
            this.listview_plugins.HideSelection = false;
            this.listview_plugins.Location = new System.Drawing.Point(3, 16);
            this.listview_plugins.Name = "listview_plugins";
            this.listview_plugins.Size = new System.Drawing.Size(466, 233);
            this.listview_plugins.TabIndex = 0;
            this.listview_plugins.UseCompatibleStateImageBehavior = false;
            this.listview_plugins.View = System.Windows.Forms.View.Details;
            this.listview_plugins.SelectedIndexChanged += new System.EventHandler(this.Listview_pluginsSelectedIndexChanged);
            this.listview_plugins.Click += new System.EventHandler(this.Listview_pluginsSelectedIndexChanged);
            // 
            // button_pluginconfigure
            // 
            this.button_pluginconfigure.AutoSize = true;
            this.button_pluginconfigure.Enabled = false;
            this.button_pluginconfigure.LanguageKey = "settings_configureplugin";
            this.button_pluginconfigure.Location = new System.Drawing.Point(6, 258);
            this.button_pluginconfigure.Name = "button_pluginconfigure";
            this.button_pluginconfigure.Size = new System.Drawing.Size(75, 23);
            this.button_pluginconfigure.TabIndex = 1;
            this.button_pluginconfigure.Text = "Configure";
            this.button_pluginconfigure.UseVisualStyleBackColor = true;
            this.button_pluginconfigure.Click += new System.EventHandler(this.Button_pluginconfigureClick);
            // 
            // tab_expert
            // 
            this.tab_expert.Controls.Add(this.groupbox_expert);
            this.tab_expert.LanguageKey = "expertsettings";
            this.tab_expert.Location = new System.Drawing.Point(4, 22);
            this.tab_expert.Name = "tab_expert";
            this.tab_expert.Size = new System.Drawing.Size(484, 482);
            this.tab_expert.TabIndex = 5;
            this.tab_expert.Text = "Expert";
            this.tab_expert.UseVisualStyleBackColor = true;
            // 
            // groupbox_expert
            // 
            this.groupbox_expert.AutoSize = true;
            this.groupbox_expert.Controls.Add(this.checkbox_reuseeditor);
            this.groupbox_expert.Controls.Add(this.checkbox_minimizememoryfootprint);
            this.groupbox_expert.Controls.Add(this.checkbox_checkunstableupdates);
            this.groupbox_expert.Controls.Add(this.checkbox_suppresssavedialogatclose);
            this.groupbox_expert.Controls.Add(this.label_counter);
            this.groupbox_expert.Controls.Add(this.textbox_counter);
            this.groupbox_expert.Controls.Add(this.label_footerpattern);
            this.groupbox_expert.Controls.Add(this.textbox_footerpattern);
            this.groupbox_expert.Controls.Add(this.checkbox_thumbnailpreview);
            this.groupbox_expert.Controls.Add(this.checkbox_optimizeforrdp);
            this.groupbox_expert.Controls.Add(this.checkbox_autoreducecolors);
            this.groupbox_expert.Controls.Add(this.label_clipboardformats);
            this.groupbox_expert.Controls.Add(this.checkbox_enableexpert);
            this.groupbox_expert.Controls.Add(this.listview_clipboardformats);
            this.groupbox_expert.LanguageKey = "expertsettings";
            this.groupbox_expert.Location = new System.Drawing.Point(6, 6);
            this.groupbox_expert.Name = "groupbox_expert";
            this.groupbox_expert.Size = new System.Drawing.Size(472, 353);
            this.groupbox_expert.TabIndex = 0;
            this.groupbox_expert.TabStop = false;
            this.groupbox_expert.Text = "Expert";
            // 
            // checkbox_reuseeditor
            // 
            this.checkbox_reuseeditor.AutoSize = true;
            this.checkbox_reuseeditor.LanguageKey = "expertsettings_reuseeditorifpossible";
            this.checkbox_reuseeditor.Location = new System.Drawing.Point(6, 257);
            this.checkbox_reuseeditor.Name = "checkbox_reuseeditor";
            this.checkbox_reuseeditor.PropertyName = "ReuseEditor";
            this.checkbox_reuseeditor.SectionName = "Editor";
            this.checkbox_reuseeditor.Size = new System.Drawing.Size(135, 17);
            this.checkbox_reuseeditor.TabIndex = 9;
            this.checkbox_reuseeditor.Text = "Reuse editor if possible";
            this.checkbox_reuseeditor.UseVisualStyleBackColor = true;
            // 
            // checkbox_minimizememoryfootprint
            // 
            this.checkbox_minimizememoryfootprint.AutoSize = true;
            this.checkbox_minimizememoryfootprint.LanguageKey = "expertsettings_minimizememoryfootprint";
            this.checkbox_minimizememoryfootprint.Location = new System.Drawing.Point(6, 234);
            this.checkbox_minimizememoryfootprint.Name = "checkbox_minimizememoryfootprint";
            this.checkbox_minimizememoryfootprint.PropertyName = "MinimizeWorkingSetSize";
            this.checkbox_minimizememoryfootprint.Size = new System.Drawing.Size(364, 17);
            this.checkbox_minimizememoryfootprint.TabIndex = 8;
            this.checkbox_minimizememoryfootprint.Text = "Minimize memory footprint, but with a performance penalty (not advised).";
            this.checkbox_minimizememoryfootprint.UseVisualStyleBackColor = true;
            // 
            // checkbox_checkunstableupdates
            // 
            this.checkbox_checkunstableupdates.AutoSize = true;
            this.checkbox_checkunstableupdates.LanguageKey = "expertsettings_checkunstableupdates";
            this.checkbox_checkunstableupdates.Location = new System.Drawing.Point(6, 211);
            this.checkbox_checkunstableupdates.Name = "checkbox_checkunstableupdates";
            this.checkbox_checkunstableupdates.PropertyName = "CheckForUnstable";
            this.checkbox_checkunstableupdates.Size = new System.Drawing.Size(156, 17);
            this.checkbox_checkunstableupdates.TabIndex = 7;
            this.checkbox_checkunstableupdates.Text = "Check for unstable updates";
            this.checkbox_checkunstableupdates.UseVisualStyleBackColor = true;
            this.checkbox_checkunstableupdates.CheckedChanged += new System.EventHandler(this.checkbox_checkunstableupdates_CheckedChanged);
            // 
            // checkbox_suppresssavedialogatclose
            // 
            this.checkbox_suppresssavedialogatclose.AutoSize = true;
            this.checkbox_suppresssavedialogatclose.LanguageKey = "expertsettings_suppresssavedialogatclose";
            this.checkbox_suppresssavedialogatclose.Location = new System.Drawing.Point(6, 189);
            this.checkbox_suppresssavedialogatclose.Name = "checkbox_suppresssavedialogatclose";
            this.checkbox_suppresssavedialogatclose.PropertyName = "SuppressSaveDialogAtClose";
            this.checkbox_suppresssavedialogatclose.SectionName = "Editor";
            this.checkbox_suppresssavedialogatclose.Size = new System.Drawing.Size(257, 17);
            this.checkbox_suppresssavedialogatclose.TabIndex = 6;
            this.checkbox_suppresssavedialogatclose.Text = "Suppress the save dialog when closing the editor";
            this.checkbox_suppresssavedialogatclose.UseVisualStyleBackColor = true;
            // 
            // label_counter
            // 
            this.label_counter.AutoSize = true;
            this.label_counter.LanguageKey = "expertsettings_counter";
            this.label_counter.Location = new System.Drawing.Point(6, 313);
            this.label_counter.Name = "label_counter";
            this.label_counter.Size = new System.Drawing.Size(246, 13);
            this.label_counter.TabIndex = 12;
            this.label_counter.Text = "The number for the ${NUM} in the filename pattern";
            // 
            // textbox_counter
            // 
            this.textbox_counter.Location = new System.Drawing.Point(264, 310);
            this.textbox_counter.Name = "textbox_counter";
            this.textbox_counter.PropertyName = "OutputFileIncrementingNumber";
            this.textbox_counter.Size = new System.Drawing.Size(202, 20);
            this.textbox_counter.TabIndex = 13;
            // 
            // label_footerpattern
            // 
            this.label_footerpattern.AutoSize = true;
            this.label_footerpattern.LanguageKey = "expertsettings_footerpattern";
            this.label_footerpattern.Location = new System.Drawing.Point(6, 287);
            this.label_footerpattern.Name = "label_footerpattern";
            this.label_footerpattern.Size = new System.Drawing.Size(103, 13);
            this.label_footerpattern.TabIndex = 10;
            this.label_footerpattern.Text = "Printer footer pattern";
            // 
            // textbox_footerpattern
            // 
            this.textbox_footerpattern.Location = new System.Drawing.Point(236, 284);
            this.textbox_footerpattern.Name = "textbox_footerpattern";
            this.textbox_footerpattern.PropertyName = "OutputPrintFooterPattern";
            this.textbox_footerpattern.Size = new System.Drawing.Size(230, 20);
            this.textbox_footerpattern.TabIndex = 11;
            // 
            // checkbox_thumbnailpreview
            // 
            this.checkbox_thumbnailpreview.AutoSize = true;
            this.checkbox_thumbnailpreview.LanguageKey = "expertsettings_thumbnailpreview";
            this.checkbox_thumbnailpreview.Location = new System.Drawing.Point(6, 166);
            this.checkbox_thumbnailpreview.Name = "checkbox_thumbnailpreview";
            this.checkbox_thumbnailpreview.PropertyName = "ThumnailPreview";
            this.checkbox_thumbnailpreview.Size = new System.Drawing.Size(344, 17);
            this.checkbox_thumbnailpreview.TabIndex = 5;
            this.checkbox_thumbnailpreview.Text = "Show window thumbnails in context menu (for Vista and windows 7)";
            this.checkbox_thumbnailpreview.UseVisualStyleBackColor = true;
            // 
            // checkbox_optimizeforrdp
            // 
            this.checkbox_optimizeforrdp.AutoSize = true;
            this.checkbox_optimizeforrdp.LanguageKey = "expertsettings_optimizeforrdp";
            this.checkbox_optimizeforrdp.Location = new System.Drawing.Point(6, 143);
            this.checkbox_optimizeforrdp.Name = "checkbox_optimizeforrdp";
            this.checkbox_optimizeforrdp.PropertyName = "OptimizeForRDP";
            this.checkbox_optimizeforrdp.Size = new System.Drawing.Size(289, 17);
            this.checkbox_optimizeforrdp.TabIndex = 4;
            this.checkbox_optimizeforrdp.Text = "Make some optimizations for usage with remote desktop";
            this.checkbox_optimizeforrdp.UseVisualStyleBackColor = true;
            // 
            // checkbox_autoreducecolors
            // 
            this.checkbox_autoreducecolors.AutoSize = true;
            this.checkbox_autoreducecolors.LanguageKey = "expertsettings_autoreducecolors";
            this.checkbox_autoreducecolors.Location = new System.Drawing.Point(6, 120);
            this.checkbox_autoreducecolors.Name = "checkbox_autoreducecolors";
            this.checkbox_autoreducecolors.PropertyName = "OutputFileAutoReduceColors";
            this.checkbox_autoreducecolors.Size = new System.Drawing.Size(406, 17);
            this.checkbox_autoreducecolors.TabIndex = 3;
            this.checkbox_autoreducecolors.Text = "Create an 8-bit image if the colors are less than 256 while having a > 8 bits ima" +
    "ge";
            this.checkbox_autoreducecolors.UseVisualStyleBackColor = true;
            // 
            // label_clipboardformats
            // 
            this.label_clipboardformats.AutoSize = true;
            this.label_clipboardformats.LanguageKey = "expertsettings_clipboardformats";
            this.label_clipboardformats.Location = new System.Drawing.Point(6, 39);
            this.label_clipboardformats.Name = "label_clipboardformats";
            this.label_clipboardformats.Size = new System.Drawing.Size(88, 13);
            this.label_clipboardformats.TabIndex = 1;
            this.label_clipboardformats.Text = "Clipboard formats";
            // 
            // checkbox_enableexpert
            // 
            this.checkbox_enableexpert.AutoSize = true;
            this.checkbox_enableexpert.LanguageKey = "expertsettings_enableexpert";
            this.checkbox_enableexpert.Location = new System.Drawing.Point(6, 19);
            this.checkbox_enableexpert.Name = "checkbox_enableexpert";
            this.checkbox_enableexpert.Size = new System.Drawing.Size(139, 17);
            this.checkbox_enableexpert.TabIndex = 0;
            this.checkbox_enableexpert.Text = "I know what I am doing!";
            this.checkbox_enableexpert.UseVisualStyleBackColor = true;
            this.checkbox_enableexpert.CheckedChanged += new System.EventHandler(this.checkbox_enableexpert_CheckedChanged);
            // 
            // listview_clipboardformats
            // 
            this.listview_clipboardformats.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listview_clipboardformats.AutoArrange = false;
            this.listview_clipboardformats.CheckBoxes = true;
            this.listview_clipboardformats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listview_clipboardformats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview_clipboardformats.HideSelection = false;
            this.listview_clipboardformats.LabelWrap = false;
            this.listview_clipboardformats.Location = new System.Drawing.Point(236, 19);
            this.listview_clipboardformats.Name = "listview_clipboardformats";
            this.listview_clipboardformats.ShowGroups = false;
            this.listview_clipboardformats.Size = new System.Drawing.Size(230, 72);
            this.listview_clipboardformats.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listview_clipboardformats.TabIndex = 2;
            this.listview_clipboardformats.UseCompatibleStateImageBehavior = false;
            this.listview_clipboardformats.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Destination";
            this.columnHeader1.Width = 225;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(516, 567);
            this.Controls.Add(this.tabcontrol);
            this.Controls.Add(this.settings_confirm);
            this.Controls.Add(this.settings_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "settings_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupbox_preferredfilesettings.ResumeLayout(false);
            this.groupbox_preferredfilesettings.PerformLayout();
            this.groupbox_applicationsettings.ResumeLayout(false);
            this.groupbox_applicationsettings.PerformLayout();
            this.groupbox_qualitysettings.ResumeLayout(false);
            this.groupbox_qualitysettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarJpegQuality)).EndInit();
            this.groupbox_destination.ResumeLayout(false);
            this.groupbox_destination.PerformLayout();
            this.tabcontrol.ResumeLayout(false);
            this.tab_general.ResumeLayout(false);
            this.tab_general.PerformLayout();
            this.groupbox_network.ResumeLayout(false);
            this.groupbox_network.PerformLayout();
            this.groupbox_hotkeys.ResumeLayout(false);
            this.groupbox_hotkeys.PerformLayout();
            this.tab_capture.ResumeLayout(false);
            this.tab_capture.PerformLayout();
            this.groupbox_editor.ResumeLayout(false);
            this.groupbox_editor.PerformLayout();
            this.groupbox_iecapture.ResumeLayout(false);
            this.groupbox_iecapture.PerformLayout();
            this.groupbox_windowscapture.ResumeLayout(false);
            this.groupbox_windowscapture.PerformLayout();
            this.groupbox_capture.ResumeLayout(false);
            this.groupbox_capture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaitTime)).EndInit();
            this.tab_output.ResumeLayout(false);
            this.tab_output.PerformLayout();
            this.tab_destinations.ResumeLayout(false);
            this.tab_destinations.PerformLayout();
            this.tab_printer.ResumeLayout(false);
            this.tab_printer.PerformLayout();
            this.groupBoxColors.ResumeLayout(false);
            this.groupBoxColors.PerformLayout();
            this.groupBoxPrintLayout.ResumeLayout(false);
            this.groupBoxPrintLayout.PerformLayout();
            this.tab_plugins.ResumeLayout(false);
            this.tab_plugins.PerformLayout();
            this.groupbox_plugins.ResumeLayout(false);
            this.groupbox_plugins.PerformLayout();
            this.tab_expert.ResumeLayout(false);
            this.tab_expert.PerformLayout();
            this.groupbox_expert.ResumeLayout(false);
            this.groupbox_expert.PerformLayout();
            this.ResumeLayout(false);

		}
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_notifications;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_minimizememoryfootprint;
		private System.Windows.Forms.ColumnHeader destination;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_picker;
		private System.Windows.Forms.ListView listview_destinations;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_editor;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_editor_match_capture_size;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_network;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_usedefaultproxy;
		private ScreenLoadPlugin.Controls.HotkeyControl fullscreen_hotkeyControl;
		private ScreenLoadPlugin.Controls.HotkeyControl window_hotkeyControl;
		private ScreenLoadPlugin.Controls.HotkeyControl region_hotkeyControl;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_fullscreen_hotkey;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_window_hotkey;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_region_hotkey;
		private ScreenLoadPlugin.Controls.HotkeyControl ie_hotkeyControl;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_ie_hotkey;
		private ScreenLoadPlugin.Controls.HotkeyControl lastregion_hotkeyControl;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_lastregion_hotkey;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_hotkeys;
		private ScreenLoad.Controls.ColorButton colorButton_window_background;
		private ScreenLoadPlugin.Controls.ScreenLoadRadioButton radiobuttonWindowCapture;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_ie_capture;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_capture;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_windowscapture;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_iecapture;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_capture;
		private System.Windows.Forms.ComboBox combobox_window_capture_mode;
		private System.Windows.Forms.NumericUpDown numericUpDownWaitTime;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_waittime;
		private ScreenLoadPlugin.Controls.ScreenLoadRadioButton radiobuttonInteractiveCapture;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_capture_mousepointer;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_printer;
		private System.Windows.Forms.ListView listview_plugins;
		private ScreenLoadPlugin.Controls.ScreenLoadButton button_pluginconfigure;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_plugins;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_plugins;
		private System.Windows.Forms.Button btnPatternHelp;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_copypathtoclipboard;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_output;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_general;
		private System.Windows.Forms.TabControl tabcontrol;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_autostartshortcut;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_destination;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_alwaysshowqualitydialog;
		private System.Windows.Forms.TextBox textBoxJpegQuality;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_jpegquality;
		private System.Windows.Forms.TrackBar trackBarJpegQuality;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_qualitysettings;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_applicationsettings;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_preferredfilesettings;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_playsound;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_primaryimageformat;
		private ScreenLoadPlugin.Controls.ScreenLoadComboBox combobox_primaryimageformat;
		private System.Windows.Forms.ComboBox combobox_language;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_language;
		private ScreenLoadPlugin.Controls.ScreenLoadTextBox textbox_screenshotname;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_screenshotname;
		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private ScreenLoadPlugin.Controls.ScreenLoadButton settings_cancel;
		private ScreenLoadPlugin.Controls.ScreenLoadButton settings_confirm;
		private ScreenLoadPlugin.Controls.ScreenLoadTextBox textbox_storagelocation;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_storagelocation;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_destinations;
		private ScreenLoadPlugin.Controls.ScreenLoadTabPage tab_expert;
		private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupbox_expert;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_clipboardformats;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_enableexpert;
		private System.Windows.Forms.ListView listview_clipboardformats;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_autoreducecolors;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_optimizeforrdp;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_thumbnailpreview;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_footerpattern;
		private ScreenLoadPlugin.Controls.ScreenLoadTextBox textbox_footerpattern;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_counter;
		private ScreenLoadPlugin.Controls.ScreenLoadTextBox textbox_counter;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_reducecolors;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_suppresssavedialogatclose;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_checkunstableupdates;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_reuseeditor;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_alwaysshowprintoptionsdialog;
        private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupBoxColors;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkboxPrintInverted;
        private ScreenLoadPlugin.Controls.ScreenLoadRadioButton radioBtnColorPrint;
        private ScreenLoadPlugin.Controls.ScreenLoadRadioButton radioBtnGrayScale;
        private ScreenLoadPlugin.Controls.ScreenLoadRadioButton radioBtnMonochrome;
        private ScreenLoadPlugin.Controls.ScreenLoadGroupBox groupBoxPrintLayout;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkboxDateTime;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkboxAllowShrink;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkboxAllowEnlarge;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkboxAllowRotate;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkboxAllowCenter;
		private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkbox_zoomer;
		private ScreenLoadPlugin.Controls.ScreenLoadLabel label_icon_size;
        private Controls.ColorButton captureAreaColorButton;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox captureAreaColorCheckBox;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox editorConfirmationCheckBox;
        private ScreenLoadPlugin.Controls.ScreenLoadButton checkUpdatesButton;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox useQuickEditModeCheckBox;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkUpdatesOnceADayCheckBox;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkUpdatesAfterSavingCheckBox;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox checkUpdatesAtStartupCheckBox;
        private ScreenLoadPlugin.Controls.ScreenLoadRadioButton checkUpdatesManuallyRadioButton;
        private ScreenLoadPlugin.Controls.ScreenLoadRadioButton checkUpdatesAutoRadioButton;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox quickSettingsCheckBox;
        private System.Windows.Forms.ComboBox IconSizeComboBox;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox screenLoadCheckBox1;
        private ScreenLoadPlugin.Controls.ScreenLoadCheckBox askSavingPathCheckBox;
    }
}
