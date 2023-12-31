/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2016  Thomas Braun, Jens Klingen, Robin Krom
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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using ScreenLoad.Configuration;
using ScreenLoad.Destinations;
using ScreenLoad.Helpers;
using ScreenLoadPlugin.Controls;
using ScreenLoadPlugin.Core;
using ScreenLoadPlugin.UnmanagedHelpers;
using ScreenLoad.Plugin;
using ScreenLoad.IniFile;
using System.Text.RegularExpressions;
using log4net;

namespace ScreenLoad
{
    /// <summary>
    /// Description of SettingsForm.
    /// </summary>
    public partial class SettingsForm : BaseForm
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SettingsForm));

        private readonly ToolTip _toolTip = new ToolTip();
        private bool _inHotkey;
        //private int _daysbetweencheckPreviousValue;

        private HotkeyHelper _hotkeyHelper;

        public SettingsForm()
        {
            InitializeComponent();

            // Make sure the store isn't called to early, that's why we do it manually
            ManualStoreFields = true;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Fix for Vista/XP differences
            trackBarJpegQuality.BackColor =
                Environment.OSVersion.Version.Major >= 6 ? SystemColors.Window : SystemColors.Control;

            // This makes it possible to still capture the settings screen
            fullscreen_hotkeyControl.Enter += EnterHotkeyControl;
            fullscreen_hotkeyControl.Leave += LeaveHotkeyControl;
            window_hotkeyControl.Enter += EnterHotkeyControl;
            window_hotkeyControl.Leave += LeaveHotkeyControl;
            region_hotkeyControl.Enter += EnterHotkeyControl;
            region_hotkeyControl.Leave += LeaveHotkeyControl;
            ie_hotkeyControl.Enter += EnterHotkeyControl;
            ie_hotkeyControl.Leave += LeaveHotkeyControl;
            lastregion_hotkeyControl.Enter += EnterHotkeyControl;
            lastregion_hotkeyControl.Leave += LeaveHotkeyControl;

            //_daysbetweencheckPreviousValue = (int) numericUpDown_daysbetweencheck.Value;

            //HotkeyControl.UnregisterHotkeys();
            _hotkeyHelper = new HotkeyHelper(coreConfiguration);

            DisplayPluginTab();
            UpdateUi();
            ExpertSettingsEnableState(false);
            DisplaySettings();
            CheckSettings();
        }

        private void EnterHotkeyControl(object sender, EventArgs e)
        {
            _inHotkey = true;
        }

        private void LeaveHotkeyControl(object sender, EventArgs e)
        {
            _inHotkey = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    if (!_inHotkey)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        /// <summary>
        /// This is a method to populate the ComboBox
        /// with the items from the enumeration
        /// </summary>
        /// <param name="comboBox">ComboBox to populate</param>
        /// <param name="availableValues"></param>
        /// <param name="selectedValue"></param>
        private void PopulateComboBox<TEnum>(ComboBox comboBox, TEnum[] availableValues, TEnum selectedValue)
            where TEnum : struct
        {
            comboBox.Items.Clear();
            foreach (TEnum enumValue in availableValues)
            {
                comboBox.Items.Add(Language.Translate(enumValue));
            }

            comboBox.SelectedItem = Language.Translate(selectedValue);
        }


        /// <summary>
        /// Get the selected enum value from the combobox, uses generics
        /// </summary>
        /// <param name="comboBox">Combobox to get the value from</param>
        /// <returns>The generics value of the combobox</returns>
        private TEnum GetSelected<TEnum>(ComboBox comboBox)
        {
            string enumTypeName = typeof(TEnum).Name;
            string selectedValue = comboBox.SelectedItem as string;
            TEnum[] availableValues = (TEnum[]) Enum.GetValues(typeof(TEnum));
            TEnum returnValue = availableValues[0];
            foreach (TEnum enumValue in availableValues)
            {
                string translation = Language.GetString(enumTypeName + "." + enumValue);
                if (translation.Equals(selectedValue))
                {
                    returnValue = enumValue;
                    break;
                }
            }

            return returnValue;
        }

        private void SetWindowCaptureMode(WindowCaptureMode selectedWindowCaptureMode)
        {
            WindowCaptureMode[] availableModes;
            if (!DWM.IsDwmEnabled())
            {
                // Remove DWM from configuration, as DWM is disabled!
                if (coreConfiguration.WindowCaptureMode == WindowCaptureMode.Aero ||
                    coreConfiguration.WindowCaptureMode == WindowCaptureMode.AeroTransparent)
                {
                    coreConfiguration.WindowCaptureMode = WindowCaptureMode.GDI;
                }

                availableModes = new[] {WindowCaptureMode.Auto, WindowCaptureMode.Screen, WindowCaptureMode.GDI};
            }
            else
            {
                availableModes = new[]
                {
                    WindowCaptureMode.Auto, WindowCaptureMode.Screen, WindowCaptureMode.GDI, WindowCaptureMode.Aero,
                    WindowCaptureMode.AeroTransparent
                };
            }

            PopulateComboBox(combobox_window_capture_mode, availableModes, selectedWindowCaptureMode);
        }

        private void DisplayPluginTab()
        {
            if (!PluginHelper.Instance.HasPlugins())
            {
                tabcontrol.TabPages.Remove(tab_plugins);
            }
            else
            {
                // Draw the Plugin listview
                listview_plugins.BeginUpdate();
                listview_plugins.Items.Clear();
                listview_plugins.Columns.Clear();
                string[] columns =
                {
                    Language.GetString("settings_plugins_name"),
                    Language.GetString("settings_plugins_version"),
                    Language.GetString("settings_plugins_createdby"),
                    Language.GetString("settings_plugins_dllpath")
                };
                foreach (string column in columns)
                {
                    listview_plugins.Columns.Add(column);
                }

                PluginHelper.Instance.FillListview(listview_plugins);
                // Maximize Column size!
                for (int i = 0; i < listview_plugins.Columns.Count; i++)
                {
                    listview_plugins.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                    int width = listview_plugins.Columns[i].Width;
                    listview_plugins.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                    if (width > listview_plugins.Columns[i].Width)
                    {
                        listview_plugins.Columns[i].Width = width;
                    }
                }

                listview_plugins.EndUpdate();
                listview_plugins.Refresh();

                // Disable the configure button, it will be enabled when a plugin is selected AND isConfigurable
                button_pluginconfigure.Enabled = false;
            }
        }

        /// <summary>
        /// Update the UI to reflect the language and other text settings
        /// </summary>
        private void UpdateUi()
        {
            if (coreConfiguration.HideExpertSettings)
            {
                tabcontrol.Controls.Remove(tab_expert);
            }

            _toolTip.SetToolTip(label_language, Language.GetString(LangKey.settings_tooltip_language));
            _toolTip.SetToolTip(label_storagelocation, Language.GetString(LangKey.settings_tooltip_storagelocation));
            _toolTip.SetToolTip(label_screenshotname, Language.GetString(LangKey.settings_tooltip_filenamepattern));
            _toolTip.SetToolTip(label_primaryimageformat,
                Language.GetString(LangKey.settings_tooltip_primaryimageformat));

            // Removing, otherwise we keep getting the event multiple times!
            combobox_language.SelectedIndexChanged -= Combobox_languageSelectedIndexChanged;

            // Initialize the Language ComboBox
            combobox_language.DisplayMember = "Description";
            combobox_language.ValueMember = "Ietf";
            // Set datasource last to prevent problems
            // See: http://www.codeproject.com/KB/database/scomlistcontrolbinding.aspx?fid=111644
            combobox_language.DataSource = Language.SupportedLanguages;
            if (Language.CurrentLanguage != null)
            {
                combobox_language.SelectedValue = Language.CurrentLanguage;
            }

            // Delaying the SelectedIndexChanged events untill all is initiated
            combobox_language.SelectedIndexChanged += Combobox_languageSelectedIndexChanged;
            UpdateDestinationDescriptions();
            UpdateClipboardFormatDescriptions();

            var selectedIndex = IconSizeComboBox.SelectedIndex;

            IconSizeComboBox.BeginUpdate();
            IconSizeComboBox.Items.Clear();
            IconSizeComboBox.Items.Add(Language.GetString("settings_iconsize_default"));
            IconSizeComboBox.Items.Add(Language.GetString("settings_iconsize_large"));
            IconSizeComboBox.SelectedIndex = selectedIndex;
            IconSizeComboBox.EndUpdate();
        }

        // Check the settings and somehow visibly mark when something is incorrect
        private bool CheckSettings()
        {
            return CheckFilenamePattern() && CheckStorageLocationPath();
        }

        private bool CheckFilenamePattern()
        {
            string filename = FilenameHelper.GetFilenameFromPattern(textbox_screenshotname.Text,
                coreConfiguration.OutputFileFormat, null);
            // we allow dynamically created subfolders, need to check for them, too
            string[] pathParts = filename.Split(Path.DirectorySeparatorChar);

            string filenamePart = pathParts[pathParts.Length - 1];
            var settingsOk = FilenameHelper.IsFilenameValid(filenamePart);

            for (int i = 0; settingsOk && i < pathParts.Length - 1; i++)
            {
                settingsOk = FilenameHelper.IsDirectoryNameValid(pathParts[i]);
            }

            DisplayTextBoxValidity(textbox_screenshotname, settingsOk);

            return settingsOk;
        }

        private bool CheckStorageLocationPath()
        {
            bool settingsOk = Directory.Exists(FilenameHelper.FillVariables(textbox_storagelocation.Text, false));
            DisplayTextBoxValidity(textbox_storagelocation, settingsOk);
            return settingsOk;
        }

        private void DisplayTextBoxValidity(ScreenLoadTextBox textbox, bool valid)
        {
            if (valid)
            {
                // "Added" feature #3547158
                textbox.BackColor = Environment.OSVersion.Version.Major >= 6
                    ? SystemColors.Window
                    : SystemColors.Control;
            }
            else
            {
                textbox.BackColor = Color.Red;
            }
        }

        private void FilenamePatternChanged(object sender, EventArgs e)
        {
            CheckFilenamePattern();
        }

        private void StorageLocationChanged(object sender, EventArgs e)
        {
            CheckStorageLocationPath();
        }

        /// <summary>
        /// Show all destination descriptions in the current language
        /// </summary>
        private void UpdateDestinationDescriptions()
        {
            foreach (ListViewItem item in listview_destinations.Items)
            {
                IDestination destinationFromTag = item.Tag as IDestination;
                if (destinationFromTag != null)
                {
                    item.Text = destinationFromTag.Description;
                }
            }
        }

        /// <summary>
        /// Show all clipboard format descriptions in the current language
        /// </summary>
        private void UpdateClipboardFormatDescriptions()
        {
            foreach (ListViewItem item in listview_clipboardformats.Items)
            {
                ClipboardFormat cf = (ClipboardFormat) item.Tag;
                item.Text = Language.Translate(cf);
            }
        }

        /// <summary>
        /// Build the view with all the destinations
        /// </summary>
        private void DisplayDestinations()
        {
            bool destinationsEnabled = true;
            if (coreConfiguration.Values.ContainsKey("Destinations"))
            {
                destinationsEnabled = !coreConfiguration.Values["Destinations"].IsFixed;
            }

            checkbox_picker.Checked = false;

            listview_destinations.Items.Clear();
            listview_destinations.ListViewItemSorter = new ListviewWithDestinationComparer();
            ImageList imageList = new ImageList();
            listview_destinations.SmallImageList = imageList;
            int imageNr = -1;
            foreach (IDestination currentDestination in DestinationHelper.GetAllDestinations())
            {
                Image destinationImage = currentDestination.DisplayImage;
                if (destinationImage != null)
                {
                    imageList.Images.Add(currentDestination.DisplayImage);
                    imageNr++;
                }

                if (PickerDestination.DESIGNATION.Equals(currentDestination.Designation))
                {
                    checkbox_picker.Checked =
                        coreConfiguration.OutputDestinations.Contains(currentDestination.Designation);
                    checkbox_picker.Text = currentDestination.Description;
                }
                else
                {
                    ListViewItem item;
                    if (destinationImage != null)
                    {
                        item = listview_destinations.Items.Add(currentDestination.Description, imageNr);
                    }
                    else
                    {
                        item = listview_destinations.Items.Add(currentDestination.Description);
                    }

                    item.Tag = currentDestination;
                    item.Checked = coreConfiguration.OutputDestinations.Contains(currentDestination.Designation);
                }
            }

            if (checkbox_picker.Checked)
            {
                listview_destinations.Enabled = false;
                foreach (int index in listview_destinations.CheckedIndices)
                {
                    ListViewItem item = listview_destinations.Items[index];
                    item.Checked = false;
                }
            }

            checkbox_picker.Enabled = destinationsEnabled;
            listview_destinations.Enabled = destinationsEnabled;
        }

        private void DisplaySettings()
        {
            if (coreConfiguration.IsCaptureAreaColorUsed)
            {
                var captureAreaColor = Color.FromArgb(255, coreConfiguration.CaptureAreaColor);
                captureAreaColorButton.SelectedColor = captureAreaColor;
            }

            colorButton_window_background.SelectedColor = coreConfiguration.DWMBackgroundColor;

            // Expert mode, the clipboard formats
            foreach (ClipboardFormat clipboardFormat in Enum.GetValues(typeof(ClipboardFormat)))
            {
                ListViewItem item = listview_clipboardformats.Items.Add(Language.Translate(clipboardFormat));
                item.Tag = clipboardFormat;
                item.Checked = coreConfiguration.ClipboardFormats.Contains(clipboardFormat);
            }

            if (Language.CurrentLanguage != null)
            {
                combobox_language.SelectedValue = Language.CurrentLanguage;
            }

            // Disable editing when the value is fixed
            combobox_language.Enabled = !coreConfiguration.Values["Language"].IsFixed;

            textbox_storagelocation.Text = FilenameHelper.FillVariables(coreConfiguration.OutputFilePath, false);
            // Disable editing when the value is fixed
            textbox_storagelocation.Enabled = !coreConfiguration.Values["OutputFilePath"].IsFixed;

            SetWindowCaptureMode(coreConfiguration.WindowCaptureMode);
            // Disable editing when the value is fixed
            combobox_window_capture_mode.Enabled = !coreConfiguration.CaptureWindowsInteractive &&
                                                   !coreConfiguration.Values["WindowCaptureMode"].IsFixed;
            radiobuttonWindowCapture.Checked = !coreConfiguration.CaptureWindowsInteractive;

            trackBarJpegQuality.Value = coreConfiguration.OutputFileJpegQuality;
            trackBarJpegQuality.Enabled = !coreConfiguration.Values["OutputFileJpegQuality"].IsFixed;
            textBoxJpegQuality.Text = coreConfiguration.OutputFileJpegQuality + "%";

            DisplayDestinations();

            numericUpDownWaitTime.Value = coreConfiguration.CaptureDelay >= 0 ? coreConfiguration.CaptureDelay : 0;
            numericUpDownWaitTime.Enabled = !coreConfiguration.Values["CaptureDelay"].IsFixed;
            if (IniConfig.IsPortable)
            {
                checkbox_autostartshortcut.Visible = false;
                checkbox_autostartshortcut.Checked = false;
            }
            else
            {
                // Autostart checkbox logic.
                if (StartupHelper.HasRunAll())
                {
                    // Remove runUser if we already have a run under all
                    StartupHelper.DeleteRunUser();
                    checkbox_autostartshortcut.Enabled = StartupHelper.CanWriteRunAll();
                    checkbox_autostartshortcut.Checked = true; // We already checked this
                }
                else if (StartupHelper.IsInStartupFolder())
                {
                    checkbox_autostartshortcut.Enabled = false;
                    checkbox_autostartshortcut.Checked = true; // We already checked this
                }
                else
                {
                    // No run for all, enable the checkbox and set it to true if the current user has a key
                    checkbox_autostartshortcut.Enabled = StartupHelper.CanWriteRunUser();
                    checkbox_autostartshortcut.Checked = StartupHelper.HasRunUser();
                }
            }

            switch (coreConfiguration.IconSize.Width)
            {
                case 16:
                    IconSizeComboBox.SelectedIndex = 0;
                    break;
                case 32:
                    IconSizeComboBox.SelectedIndex = 1;
                    break;
            }

            CheckDestinationSettings();

            editorConfirmationCheckBox.Checked =
                !DialogHelper.IsDoNotShowDialogSet(QuickImageEditorForm.ConfirmationDialogName);
        }

        private void SaveSettings()
        {
            if (combobox_language.SelectedItem != null)
            {
                string newLang = combobox_language.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(newLang))
                {
                    coreConfiguration.Language = combobox_language.SelectedValue.ToString();
                }
            }

            // retrieve the set clipboard formats
            List<ClipboardFormat> clipboardFormats = new List<ClipboardFormat>();
            foreach (int index in listview_clipboardformats.CheckedIndices)
            {
                ListViewItem item = listview_clipboardformats.Items[index];
                if (item.Checked)
                {
                    clipboardFormats.Add((ClipboardFormat) item.Tag);
                }
            }

            coreConfiguration.ClipboardFormats = clipboardFormats;

            coreConfiguration.WindowCaptureMode = GetSelected<WindowCaptureMode>(combobox_window_capture_mode);
            if (!FilenameHelper.FillVariables(coreConfiguration.OutputFilePath, false)
                .Equals(textbox_storagelocation.Text))
            {
                coreConfiguration.OutputFilePath = textbox_storagelocation.Text;
            }

            coreConfiguration.OutputFileJpegQuality = trackBarJpegQuality.Value;

            List<string> destinations = new List<string>();
            if (checkbox_picker.Checked)
            {
                destinations.Add(PickerDestination.DESIGNATION);
            }

            foreach (int index in listview_destinations.CheckedIndices)
            {
                ListViewItem item = listview_destinations.Items[index];

                IDestination destinationFromTag = item.Tag as IDestination;
                if (item.Checked && destinationFromTag != null)
                {
                    destinations.Add(destinationFromTag.Designation);
                }
            }

            coreConfiguration.OutputDestinations = destinations;
            coreConfiguration.CaptureDelay = (int) numericUpDownWaitTime.Value;

            if (captureAreaColorButton.Visible)
                coreConfiguration.CaptureAreaColor = Color.FromArgb(255, captureAreaColorButton.SelectedColor);

            coreConfiguration.DWMBackgroundColor = colorButton_window_background.SelectedColor;

            switch (IconSizeComboBox.SelectedIndex)
            {
                case 0:
                    coreConfiguration.IconSize = new Size(16, 16);
                    break;
                case 1:
                    coreConfiguration.IconSize = new Size(32, 32);
                    break;
            }

            try
            {
                if (checkbox_autostartshortcut.Checked)
                {
                    // It's checked, so we set the RunUser if the RunAll isn't set.
                    // Do this every time, so the executable is correct.
                    if (!StartupHelper.HasRunAll())
                    {
                        StartupHelper.SetRunUser();
                    }
                }
                else
                {
                    // Delete both settings if it's unchecked
                    if (StartupHelper.HasRunAll())
                    {
                        StartupHelper.DeleteRunAll();
                    }

                    if (StartupHelper.HasRunUser())
                    {
                        StartupHelper.DeleteRunUser();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Warn("Problem checking registry, ignoring for now: ", e);
            }

            DialogHelper.SetDoNotShowDialog(QuickImageEditorForm.ConfirmationDialogName,
                !editorConfirmationCheckBox.Checked);

            if (checkUpdatesAutoRadioButton.Checked && !checkUpdatesAtStartupCheckBox.Checked &&
                !checkUpdatesAfterSavingCheckBox.Checked && !checkUpdatesOnceADayCheckBox.Checked)
                checkUpdatesManuallyRadioButton.Checked = true;
        }

        private void Settings_cancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Settings_okayClick(object sender, EventArgs e)
        {
            if (CheckSettings())
            {
                SaveSettings();
                StoreFields();

                _hotkeyHelper.RegisterHotkeys(this);

                // Make sure the current language & settings are reflected in the Main-context menu
                MainForm.Instance.UpdateUi();
                DialogResult = DialogResult.OK;
            }
            else
            {
                tabcontrol.SelectTab(tab_output);
            }
        }

        private void BrowseClick(object sender, EventArgs e)
        {
            // Get the storage location and replace the environment variables
            folderBrowserDialog1.SelectedPath = FilenameHelper.FillVariables(textbox_storagelocation.Text, false);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Only change if there is a change, otherwise we might overwrite the environment variables
                if (folderBrowserDialog1.SelectedPath != null &&
                    !folderBrowserDialog1.SelectedPath.Equals(
                        FilenameHelper.FillVariables(textbox_storagelocation.Text, false)))
                {
                    textbox_storagelocation.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void TrackBarJpegQualityScroll(object sender, EventArgs e)
        {
            textBoxJpegQuality.Text = trackBarJpegQuality.Value.ToString(CultureInfo.InvariantCulture);
        }


        private void BtnPatternHelpClick(object sender, EventArgs e)
        {
            string filenamepatternText = Language.GetString(LangKey.settings_message_filenamepattern);
            // Convert %NUM% to ${NUM} for old language files!
            filenamepatternText = Regex.Replace(filenamepatternText, "%([a-zA-Z_0-9]+)%", @"${$1}");
            MessageBox.Show(filenamepatternText, Language.GetString(LangKey.settings_filenamepattern));
        }

        private void Listview_pluginsSelectedIndexChanged(object sender, EventArgs e)
        {
            button_pluginconfigure.Enabled = PluginHelper.Instance.IsSelectedItemConfigurable(listview_plugins);
        }

        private void Button_pluginconfigureClick(object sender, EventArgs e)
        {
            PluginHelper.Instance.ConfigureSelectedItem(listview_plugins);
        }

        private void Combobox_languageSelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the combobox values BEFORE changing the language
            //EmailFormat selectedEmailFormat = GetSelected<EmailFormat>(combobox_emailformat);
            WindowCaptureMode selectedWindowCaptureMode = GetSelected<WindowCaptureMode>(combobox_window_capture_mode);
            if (combobox_language.SelectedItem != null)
            {
                Log.Debug("Setting language to: " + (string) combobox_language.SelectedValue);
                Language.CurrentLanguage = (string) combobox_language.SelectedValue;
            }

            // Reflect language changes to the settings form
            UpdateUi();

            // Reflect Language changes form
            ApplyLanguage();

            // Update the email & windows capture mode
            //SetEmailFormat(selectedEmailFormat);
            SetWindowCaptureMode(selectedWindowCaptureMode);
        }

        private void Combobox_window_capture_modeSelectedIndexChanged(object sender, EventArgs e)
        {
            int windowsVersion = Environment.OSVersion.Version.Major;
            WindowCaptureMode mode = GetSelected<WindowCaptureMode>(combobox_window_capture_mode);
            if (windowsVersion >= 6)
            {
                switch (mode)
                {
                    case WindowCaptureMode.Aero:
                        colorButton_window_background.Visible = true;
                        return;
                }
            }

            colorButton_window_background.Visible = false;
        }

        /// <summary>
        /// Check the destination settings
        /// </summary>
        private void CheckDestinationSettings()
        {
            bool clipboardDestinationChecked = false;
            bool pickerSelected = checkbox_picker.Checked;
            bool destinationsEnabled = true;
            if (coreConfiguration.Values.ContainsKey("Destinations"))
            {
                destinationsEnabled = !coreConfiguration.Values["Destinations"].IsFixed;
            }

            listview_destinations.Enabled = destinationsEnabled;

            foreach (int index in listview_destinations.CheckedIndices)
            {
                ListViewItem item = listview_destinations.Items[index];
                IDestination destinationFromTag = item.Tag as IDestination;
                if (destinationFromTag != null &&
                    destinationFromTag.Designation.Equals(ClipboardDestination.DESIGNATION))
                {
                    clipboardDestinationChecked = true;
                    break;
                }
            }

            if (pickerSelected)
            {
                listview_destinations.Enabled = false;
                foreach (int index in listview_destinations.CheckedIndices)
                {
                    ListViewItem item = listview_destinations.Items[index];
                    item.Checked = false;
                }
            }
            else
            {
                // Prevent multiple clipboard settings at once, see bug #3435056
                if (clipboardDestinationChecked)
                {
                    checkbox_copypathtoclipboard.Checked = false;
                    checkbox_copypathtoclipboard.Enabled = false;
                }
                else
                {
                    checkbox_copypathtoclipboard.Enabled = true;
                }
            }
        }

        private void DestinationsCheckStateChanged(object sender, EventArgs e)
        {
            CheckDestinationSettings();
        }

        protected override void OnFieldsFilled()
        {
            // the color radio button is not actually bound to a setting, but checked when monochrome/grayscale are not checked
            if (!radioBtnGrayScale.Checked && !radioBtnMonochrome.Checked)
            {
                radioBtnColorPrint.Checked = true;
            }
        }

        /// <summary>
        /// Set the enable state of the expert settings
        /// </summary>
        /// <param name="state"></param>
        private void ExpertSettingsEnableState(bool state)
        {
            listview_clipboardformats.Enabled = state;
            checkbox_autoreducecolors.Enabled = state;
            checkbox_optimizeforrdp.Enabled = state;
            checkbox_thumbnailpreview.Enabled = state;
            textbox_footerpattern.Enabled = state;
            textbox_counter.Enabled = state;
            checkbox_suppresssavedialogatclose.Enabled = state;
            checkbox_checkunstableupdates.Enabled = state;
            checkbox_minimizememoryfootprint.Enabled = state;
            checkbox_reuseeditor.Enabled = state;
        }

        /// <summary>
        /// Called if the "I know what I am doing" on the settings form is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkbox_enableexpert_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                ExpertSettingsEnableState(checkBox.Checked);
            }
        }

        private void radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            combobox_window_capture_mode.Enabled = radiobuttonWindowCapture.Checked;
        }

        private void CaptureAreaColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            captureAreaColorButton.Visible = captureAreaColorCheckBox.Checked;
        }

        private void Fullscreen_hotkeyControl_TextChanged(object sender, EventArgs e)
        {
            SetHotkey(fullscreen_hotkeyControl, HotkeyAction.CaptureFullScreen);
        }

        private void Window_hotkeyControl_TextChanged(object sender, EventArgs e)
        {
            SetHotkey(window_hotkeyControl, HotkeyAction.CaptureWindow);
        }

        private void Region_hotkeyControl_TextChanged(object sender, EventArgs e)
        {
            SetHotkey(region_hotkeyControl, HotkeyAction.CaptureArea);
        }

        private void Lastregion_hotkeyControl_TextChanged(object sender, EventArgs e)
        {
            SetHotkey(lastregion_hotkeyControl, HotkeyAction.CaptureLastRegion);
        }

        private void Ie_hotkeyControl_TextChanged(object sender, EventArgs e)
        {
            SetHotkey(ie_hotkeyControl, HotkeyAction.CaptureIE);
        }

        private void SetHotkey(HotkeyControl hotkeyControl, HotkeyAction hotkeyAction)
        {
            if (null == _hotkeyHelper)
                return;

            var hotkeyInfo = _hotkeyHelper.GetHotkeyInfo(hotkeyAction);
            var hotkey = hotkeyControl.ToString();

            if (HotkeyHelper.IsNoneKey(hotkey))
            {
                hotkeyControl.Clear();

                if (HotkeySolution.Disabled != hotkeyInfo.Solution && HotkeySolution.Unsolved != hotkeyInfo.Solution)
                {
                    HotkeyHelper.UnregisterHotkey(hotkeyInfo.Hotkey);
                    hotkeyInfo.Solution = HotkeySolution.Disabled;
                }

                if (HotkeySolution.Unsolved == hotkeyInfo.Solution)
                {
                    hotkeyInfo.Solution = HotkeySolution.Disabled;
                }
                
                return;
            }

            if (HotkeyHelper.Equals(hotkey, hotkeyInfo.Hotkey))
                return;

            if (!_hotkeyHelper.TrySetHotkey(this, hotkeyAction, hotkey))
            {
                ActiveControl = settings_confirm;
                hotkeyControl.Clear();
            }
        }

        private void checkUpdatesButton_Click(object sender, EventArgs e)
        {
            checkUpdatesButton.Text = Language.GetString("checkingforupdates");
            checkUpdatesButton.Enabled = false;

            UpdateHelper.CheckAndAskForUpdateInThread(UpdateRaised.Manually, coreConfiguration, 0, result =>
            {
                this.InvokeAction(() =>
                {
                    if (IsDisposed)
                        return;

                    checkUpdatesButton.Text = Language.GetString("settings_checkupdatesbutton");
                    checkUpdatesButton.Enabled = true;

                    if (UpdateCheckingResult.NotFound == result)
                    {
                        MainForm.Instance.NotifyIcon.ShowBalloonTip(10000, "ScreenLoad",
                            Language.GetString("noupdatesfound"), ToolTipIcon.Info);
                    }
                });
            });
        }

        private void checkbox_checkunstableupdates_CheckedChanged(object sender, EventArgs e)
        {
            coreConfiguration.CheckForUnstable = checkbox_checkunstableupdates.Checked;
        }

        private void checkUpdatesAutoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool checkUpdatesAuto = checkUpdatesAutoRadioButton.Checked;

            checkUpdatesAtStartupCheckBox.Enabled = checkUpdatesAuto;
            checkUpdatesAfterSavingCheckBox.Enabled = checkUpdatesAuto;
            checkUpdatesOnceADayCheckBox.Enabled = checkUpdatesAuto;

            if (!checkUpdatesAuto)
            {
                checkUpdatesAtStartupCheckBox.Checked = false;
                checkUpdatesAfterSavingCheckBox.Checked = false;
                checkUpdatesOnceADayCheckBox.Checked = false;

                checkUpdatesManuallyRadioButton.Checked = true;
            }

            if (checkUpdatesAuto)
                coreConfiguration.PostponeUpdateMode = PostponeUpdateMode.None;
        }
    }

    public class ListviewWithDestinationComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (!(x is ListViewItem))
            {
                return 0;
            }

            if (!(y is ListViewItem))
            {
                return 0;
            }

            ListViewItem l1 = (ListViewItem) x;
            ListViewItem l2 = (ListViewItem) y;

            IDestination firstDestination = l1.Tag as IDestination;
            IDestination secondDestination = l2.Tag as IDestination;

            if (secondDestination == null)
            {
                return 1;
            }

            if (firstDestination != null && firstDestination.Priority == secondDestination.Priority)
            {
                return string.Compare(firstDestination.Description, secondDestination.Description,
                    StringComparison.Ordinal);
            }

            if (firstDestination != null)
            {
                return firstDestination.Priority - secondDestination.Priority;
            }

            return 0;
        }
    }
}