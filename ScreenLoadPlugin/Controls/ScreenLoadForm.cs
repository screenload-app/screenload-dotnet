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
using System.Windows.Forms;
using System.Reflection;
using ScreenLoadPlugin.Core;
using ScreenLoad.IniFile;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using log4net;
using FlowLayoutPanel = System.Windows.Forms.FlowLayoutPanel;

namespace ScreenLoadPlugin.Controls
{
    /// <summary>
    /// This form is used for automatically binding the elements of the form to the language
    /// </summary>
    public class ScreenLoadForm : Form, IScreenLoadLanguageBindable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ScreenLoadForm));
        private static readonly IDictionary<Type, FieldInfo[]> ReflectionCache = new Dictionary<Type, FieldInfo[]>();

        protected static CoreConfiguration coreConfiguration;
        private IComponentChangeService m_changeService;
        private bool _isDesignModeLanguageSet;
        private bool _applyLanguageManually;
        private bool _storeFieldsManually;
        private IDictionary<string, Control> _designTimeControls;
        private IDictionary<string, ToolStripItem> _designTimeToolStripItems;

        static ScreenLoadForm()
        {
            if (!IsInDesignMode)
            {
                coreConfiguration = IniConfig.GetIniSection<CoreConfiguration>();
            }
        }

        [Category("ScreenLoad"), DefaultValue(null),
         Description("Specifies key of the language file to use when displaying the text.")]
        public string LanguageKey { get; set; }

        /// <summary>
        /// Used to check the designmode during a constructor
        /// </summary>
        /// <returns></returns>
        protected static bool IsInDesignMode
        {
            get
            {
                return (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1) ||
                       (Application.ExecutablePath.IndexOf("sharpdevelop.exe", StringComparison.OrdinalIgnoreCase) >
                        -1 || (Application.ExecutablePath.IndexOf("wdexpress.exe", StringComparison.OrdinalIgnoreCase) >
                               -1));
            }
        }

        protected bool ManualLanguageApply
        {
            get { return _applyLanguageManually; }
            set { _applyLanguageManually = value; }
        }

        protected bool ManualStoreFields
        {
            get { return _storeFieldsManually; }
            set { _storeFieldsManually = value; }
        }

        /// <summary>
        /// When this is set, the form will be brought to the foreground as soon as it is shown.
        /// </summary>
        protected bool ToFront { get; set; }

        /// <summary>
        /// Code to initialize the language etc during design time
        /// </summary>
        protected void InitializeForDesigner()
        {
            if (DesignMode)
            {
                _designTimeControls = new Dictionary<string, Control>();
                _designTimeToolStripItems = new Dictionary<string, ToolStripItem>();
                try
                {
                    ITypeResolutionService typeResService =
                        GetService(typeof(ITypeResolutionService)) as ITypeResolutionService;

                    // Add a hard-path if you are using SharpDevelop
                    // Language.AddLanguageFilePath(@"C:\ScreenLoad\ScreenLoad\Languages");

                    // this "type"
                    Assembly currentAssembly = GetType().Assembly;
                    if (typeResService != null)
                    {
                        string assemblyPath = typeResService.GetPathOfAssembly(currentAssembly.GetName());
                        string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
                        if (assemblyDirectory != null &&
                            !Language.AddLanguageFilePath(
                                Path.Combine(assemblyDirectory, @"..\..\ScreenLoad\Languages\")))
                        {
                            Language.AddLanguageFilePath(Path.Combine(assemblyDirectory,
                                @"..\..\..\ScreenLoad\Languages\"));
                        }

                        if (assemblyDirectory != null &&
                            !Language.AddLanguageFilePath(Path.Combine(assemblyDirectory, @"..\..\Languages\")))
                        {
                            Language.AddLanguageFilePath(Path.Combine(assemblyDirectory, @"..\..\..\Languages\"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// This override is only for the design-time of the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode)
            {
                if (!_isDesignModeLanguageSet)
                {
                    _isDesignModeLanguageSet = true;
                    try
                    {
                        ApplyLanguage();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }

            base.OnPaint(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            // Every ScreenLoadForm should have it's default icon
            // And it might not ne needed for a Tool Window, but still for the task manager / switcher it's important
            Icon = ScreenLoadResources.win_old;
            if (!DesignMode)
            {
                if (!_applyLanguageManually)
                {
                    ApplyLanguage();
                }

                FillFields();
                base.OnLoad(e);
            }
            else
            {
                Log.Info("OnLoad called from designer.");
                InitializeForDesigner();
                base.OnLoad(e);
                ApplyLanguage();
            }
        }

        /// <summary>
        /// Make sure the form is visible, if this is wanted
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (ToFront)
            {
                WindowDetails.ToForeground(Handle);
            }
        }

        /// <summary>
        /// check if the form was closed with an OK, if so store the values in the ScreenLoadControls
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            if (!DesignMode && !_storeFieldsManually)
            {
                if (DialogResult == DialogResult.OK)
                {
                    Log.Info("Form was closed with OK: storing field values.");
                    StoreFields();
                }
            }

            base.OnClosed(e);
        }

        /// <summary>
        /// This override allows the control to register event handlers for IComponentChangeService events
        /// at the time the control is sited, which happens only in design mode.
        /// </summary>
        public override ISite Site
        {
            get { return base.Site; }
            set
            {
                // Clear any component change event handlers.
                ClearChangeNotifications();

                // Set the new Site value.
                base.Site = value;

                m_changeService = (IComponentChangeService) GetService(typeof(IComponentChangeService));

                // Register event handlers for component change events.
                RegisterChangeNotifications();
            }
        }

        private void ClearChangeNotifications()
        {
            // The m_changeService value is null when not in design mode, 
            // as the IComponentChangeService is only available at design time.	
            m_changeService = (IComponentChangeService) GetService(typeof(IComponentChangeService));

            // Clear our the component change events to prepare for re-siting.				
            if (m_changeService != null)
            {
                m_changeService.ComponentChanged -= OnComponentChanged;
                m_changeService.ComponentAdded -= OnComponentAdded;
            }
        }

        private void RegisterChangeNotifications()
        {
            // Register the event handlers for the IComponentChangeService events
            if (m_changeService != null)
            {
                m_changeService.ComponentChanged += OnComponentChanged;
                m_changeService.ComponentAdded += OnComponentAdded;
            }
        }

        /// <summary>
        /// This method handles the OnComponentChanged event to display a notification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ce"></param>
        private void OnComponentChanged(object sender, ComponentChangedEventArgs ce)
        {
            if (((IComponent) ce.Component)?.Site != null && ce.Member != null)
            {
                if ("LanguageKey".Equals(ce.Member.Name))
                {
                    Control control = ce.Component as Control;
                    if (control != null)
                    {
                        Log.InfoFormat("Changing LanguageKey for {0} to {1}", control.Name, ce.NewValue);
                        ApplyLanguage(control, (string) ce.NewValue);
                    }
                    else
                    {
                        ToolStripItem item = ce.Component as ToolStripItem;
                        if (item != null)
                        {
                            Log.InfoFormat("Changing LanguageKey for {0} to {1}", item.Name, ce.NewValue);
                            ApplyLanguage(item, (string) ce.NewValue);
                        }
                        else
                        {
                            Log.InfoFormat("Not possible to changing LanguageKey for {0} to {1}",
                                ce.Component.GetType(), ce.NewValue);
                        }
                    }
                }
            }
        }

        private void OnComponentAdded(object sender, ComponentEventArgs ce)
        {
            if (ce.Component?.Site != null)
            {
                Control control = ce.Component as Control;
                if (control != null)
                {
                    if (!_designTimeControls.ContainsKey(control.Name))
                    {
                        _designTimeControls.Add(control.Name, control);
                    }
                    else
                    {
                        _designTimeControls[control.Name] = control;
                    }
                }
                else
                {
                    var stripItem = ce.Component as ToolStripItem;
                    if (stripItem != null)
                    {
                        ToolStripItem item = stripItem;
                        if (!_designTimeControls.ContainsKey(item.Name))
                        {
                            _designTimeToolStripItems.Add(item.Name, item);
                        }
                        else
                        {
                            _designTimeToolStripItems[item.Name] = item;
                        }
                    }
                }
            }
        }

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ClearChangeNotifications();
            }

            base.Dispose(disposing);
        }

        protected void ApplyLanguage(ToolStripItem applyTo, string languageKey)
        {
            string langString;
            if (!string.IsNullOrEmpty(languageKey))
            {
                if (!Language.TryGetString(languageKey, out langString))
                {
                    Log.WarnFormat("Unknown language key '{0}' configured for control '{1}', this might be okay.",
                        languageKey, applyTo.Name);
                    return;
                }

                applyTo.Text = langString;
            }
            else
            {
                // Fallback to control name!
                if (Language.TryGetString(applyTo.Name, out langString))
                {
                    applyTo.Text = langString;
                    return;
                }

                if (!DesignMode)
                {
                    Log.DebugFormat("ScreenLoad control without language key: {0}", applyTo.Name);
                }
            }
        }

        protected void ApplyLanguage(ToolStripItem applyTo)
        {
            IScreenLoadLanguageBindable languageBindable = applyTo as IScreenLoadLanguageBindable;
            if (languageBindable != null)
            {
                ApplyLanguage(applyTo, languageBindable.LanguageKey);
            }
        }

        protected void ApplyLanguage(Control applyTo)
        {
            if (applyTo is UserControl userControl)
            {
                foreach (var field in GetCachedFields(userControl.GetType()))
                {
                    object controlObject = field.GetValue(userControl);

                    if (controlObject == null)
                    {
                        Log.DebugFormat("No value: {0}", field.Name);
                        continue;
                    }

                    var applyToControl = controlObject as Control;

                    if (applyToControl == null)
                        continue;

                    ApplyLanguage(applyToControl);
                }

                return;
            }

            if (applyTo is FlowLayoutPanel flowLayoutPanel)
            {
                foreach (Control control in flowLayoutPanel.Controls)
                {
                    ApplyLanguage(control);
                }

                return;
            }

            IScreenLoadLanguageBindable languageBindable = applyTo as IScreenLoadLanguageBindable;

            if (languageBindable == null)
            {
                if (applyTo is ToolStrip toolStrip)
                {
                    foreach (ToolStripItem item in toolStrip.Items)
                    {
                        ApplyLanguage(item);
                    }
                }

                return;
            }

            // Apply language text to the control
            ApplyLanguage(applyTo, languageBindable.LanguageKey);

            // Repopulate the combox boxes
            IScreenLoadConfigBindable configBindable = applyTo as IScreenLoadConfigBindable;
            ScreenLoadComboBox comboxBox = applyTo as ScreenLoadComboBox;

            if (configBindable != null && comboxBox != null)
            {
                if (!string.IsNullOrEmpty(configBindable.SectionName) &&
                    !string.IsNullOrEmpty(configBindable.PropertyName))
                {
                    IniSection section = IniConfig.GetIniSection(configBindable.SectionName);
                    if (section != null)
                    {
                        // Only update the language, so get the actual value and than repopulate
                        Enum currentValue = comboxBox.GetSelectedEnum();
                        comboxBox.Populate(section.Values[configBindable.PropertyName].ValueType);
                        comboxBox.SetValue(currentValue);
                    }
                }
            }
        }

        /// <summary>
        /// Helper method to cache the fieldinfo values, so we don't need to reflect all the time!
        /// </summary>
        /// <param name="typeToGetFieldsFor"></param>
        /// <returns></returns>
        private static FieldInfo[] GetCachedFields(Type typeToGetFieldsFor)
        {
            FieldInfo[] fields;
            if (!ReflectionCache.TryGetValue(typeToGetFieldsFor, out fields))
            {
                fields = typeToGetFieldsFor.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                      BindingFlags.Instance);
                ReflectionCache.Add(typeToGetFieldsFor, fields);
            }

            return fields;
        }

        /// <summary>
        /// Apply all the language settings to the "ScreenLoad" Controls on this form
        /// </summary>
        protected void ApplyLanguage()
        {
            SuspendLayout();
            try
            {
                // Set title of the form
                string langString;
                if (!string.IsNullOrEmpty(LanguageKey) && Language.TryGetString(LanguageKey, out langString))
                {
                    Text = langString;
                }

                // Reset the text values for all ScreenLoadControls
                foreach (FieldInfo field in GetCachedFields(GetType()))
                {
                    object controlObject = field.GetValue(this);

                    if (controlObject == null)
                    {
                        Log.DebugFormat("No value: {0}", field.Name);
                        continue;
                    }

                    Control applyToControl = controlObject as Control;

                    if (applyToControl == null)
                    {
                        var applyToItem = controlObject as ToolStripItem;

                        if (applyToItem == null)
                        {
                            Log.DebugFormat("No Control or ToolStripItem: {0}", field.Name);
                            continue;
                        }

                        ApplyLanguage(applyToItem);
                    }
                    else
                    {
                        ApplyLanguage(applyToControl);
                    }
                }

                if (DesignMode)
                {
                    foreach (Control designControl in _designTimeControls.Values)
                    {
                        ApplyLanguage(designControl);
                    }

                    foreach (ToolStripItem designToolStripItem in _designTimeToolStripItems.Values)
                    {
                        ApplyLanguage(designToolStripItem);
                    }
                }
            }
            finally
            {
                ResumeLayout();
            }
        }

        /// <summary>
        /// Apply the language text to supplied control
        /// </summary>
        protected void ApplyLanguage(Control applyTo, string languageKey)
        {
            string langString;
            if (!string.IsNullOrEmpty(languageKey))
            {
                if (!Language.TryGetString(languageKey, out langString))
                {
                    Log.WarnFormat("Wrong language key '{0}' configured for control '{1}'", languageKey, applyTo.Name);
                    return;
                }

                applyTo.Text = langString;
            }
            else
            {
                // Fallback to control name!
                if (Language.TryGetString(applyTo.Name, out langString))
                {
                    applyTo.Text = langString;
                    return;
                }

                if (!DesignMode)
                {
                    Log.DebugFormat("ScreenLoad control without language key: {0}", applyTo.Name);
                }
            }
        }

        /// <summary>
        /// Fill all ScreenLoadControls with the values from the configuration
        /// </summary>
        protected void FillFields()
        {
            foreach (FieldInfo field in GetCachedFields(GetType()))
            {
                var controlObject = field.GetValue(this);
                IScreenLoadConfigBindable configBindable = controlObject as IScreenLoadConfigBindable;
                if (!string.IsNullOrEmpty(configBindable?.SectionName) &&
                    !string.IsNullOrEmpty(configBindable.PropertyName))
                {
                    IniSection section = IniConfig.GetIniSection(configBindable.SectionName);
                    if (section != null)
                    {
                        IniValue iniValue;
                        if (!section.Values.TryGetValue(configBindable.PropertyName, out iniValue))
                        {
                            Log.DebugFormat("Wrong property '{0}' configured for field '{1}'",
                                configBindable.PropertyName, field.Name);
                            continue;
                        }

                        CheckBox checkBox = controlObject as CheckBox;
                        if (checkBox != null)
                        {
                            checkBox.Checked = (bool) iniValue.Value;
                            checkBox.Enabled = !iniValue.IsFixed;
                            continue;
                        }

                        RadioButton radíoButton = controlObject as RadioButton;
                        if (radíoButton != null)
                        {
                            radíoButton.Checked = (bool) iniValue.Value;
                            radíoButton.Enabled = !iniValue.IsFixed;
                            continue;
                        }

                        TextBox textBox = controlObject as TextBox;
                        if (textBox != null)
                        {
                            HotkeyControl hotkeyControl = controlObject as HotkeyControl;
                            if (hotkeyControl != null)
                            {
                                string hotkeyValue = (string) iniValue.Value;
                                if (!string.IsNullOrEmpty(hotkeyValue))
                                {
                                    hotkeyControl.SetHotkey(hotkeyValue);
                                    hotkeyControl.Enabled = !iniValue.IsFixed;
                                }

                                continue;
                            }

                            textBox.Text = iniValue.ToString();
                            textBox.Enabled = !iniValue.IsFixed;
                            continue;
                        }

                        ScreenLoadComboBox comboxBox = controlObject as ScreenLoadComboBox;
                        if (comboxBox != null)
                        {
                            comboxBox.Populate(iniValue.ValueType);
                            comboxBox.SetValue((Enum) iniValue.Value);
                            comboxBox.Enabled = !iniValue.IsFixed;
                        }
                    }
                }
            }

            OnFieldsFilled();
        }

        protected virtual void OnFieldsFilled()
        {
        }

        /// <summary>
        /// Store all ScreenLoadControl values to the configuration
        /// </summary>
        protected void StoreFields()
        {
            bool iniDirty = false;
            foreach (FieldInfo field in GetCachedFields(GetType()))
            {
                var controlObject = field.GetValue(this);
                IScreenLoadConfigBindable configBindable = controlObject as IScreenLoadConfigBindable;

                if (!string.IsNullOrEmpty(configBindable?.SectionName) &&
                    !string.IsNullOrEmpty(configBindable.PropertyName))
                {
                    IniSection section = IniConfig.GetIniSection(configBindable.SectionName);
                    if (section != null)
                    {
                        IniValue iniValue;
                        if (!section.Values.TryGetValue(configBindable.PropertyName, out iniValue))
                        {
                            continue;
                        }

                        CheckBox checkBox = controlObject as CheckBox;
                        if (checkBox != null)
                        {
                            iniValue.Value = checkBox.Checked;
                            iniDirty = true;
                            continue;
                        }

                        RadioButton radioButton = controlObject as RadioButton;
                        if (radioButton != null)
                        {
                            iniValue.Value = radioButton.Checked;
                            iniDirty = true;
                            continue;
                        }

                        TextBox textBox = controlObject as TextBox;
                        if (textBox != null)
                        {
                            HotkeyControl hotkeyControl = controlObject as HotkeyControl;
                            if (hotkeyControl != null)
                            {
                                iniValue.Value = hotkeyControl.ToString();
                                iniDirty = true;
                                continue;
                            }

                            iniValue.UseValueOrDefault(textBox.Text);
                            iniDirty = true;
                            continue;
                        }

                        ScreenLoadComboBox comboxBox = controlObject as ScreenLoadComboBox;
                        if (comboxBox != null)
                        {
                            iniValue.Value = comboxBox.GetSelectedEnum();
                            iniDirty = true;
                        }

                    }
                }
            }

            if (iniDirty)
            {
                IniConfig.Save();
            }
        }
    }
}