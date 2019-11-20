﻿using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Greenshot.Helpers;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;

namespace Greenshot.Controls
{
    internal partial class HotkeyResolvingControl : UserControl
    {
        private readonly bool _initializationComplete;

        private readonly ReadOnlyCollection<HotkeyInfo> _hotkeyInfoCollection;

        public HotkeyInfo HotkeyInfo { get; }

        public HotkeyResolvingControl(ReadOnlyCollection<HotkeyInfo> hotkeyInfoCollection, HotkeyInfo hotkeyInfo)
            : this()
        {
            if (null == hotkeyInfo)
                throw new ArgumentNullException(nameof(hotkeyInfo));

            _hotkeyInfoCollection = hotkeyInfoCollection ?? throw new ArgumentNullException(nameof(hotkeyInfoCollection));

            mGroupBox.Text = hotkeyInfo.ActionText;

            var defaultHotkeyText = HotkeyControl.GetLocalizedHotkeyStringFromString(hotkeyInfo.DefaultHotkey);
            defaultRadioButton.Text = string.Format(CultureInfo.InvariantCulture,
                Language.GetString("hotkey_resolving_retry"), defaultHotkeyText);

            switch (hotkeyInfo.Solution)
            {
                case HotkeySolution.Default:
                    defaultRadioButton.Checked = true;
                    break;
                case HotkeySolution.Custom:
                    otherCombinationRadioButton.Checked = true;
                    otherCombinationHotkeyControl.SetHotkey(hotkeyInfo.Hotkey);
                    break;
                case HotkeySolution.Disabled:
                    ignoreRadioButton.Checked = true;
                    break;
            }

            HotkeyInfo = hotkeyInfo;

            _initializationComplete = true;
        }

        public HotkeyResolvingControl()
        {
            InitializeComponent();
        }

        public bool Inspect()
        {
            if (otherCombinationRadioButton.Checked)
            {
                if (string.IsNullOrEmpty(otherCombinationHotkeyControl.Text))
                {
                    var emptyHotkeyErrorMessage = Language.GetString("empty_hotkey_error_message");
                    mErrorProvider.SetError(otherCombinationHotkeyControl, emptyHotkeyErrorMessage);
                    return false;
                }
            }

            return true;
        }

        private void defaultRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (!defaultRadioButton.Checked)
                return;

            SetDefaultHotkey();
        }

        private void otherCombinationHotkeyControl_Enter(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            otherCombinationRadioButton.Checked = true;
            mErrorProvider.SetError(otherCombinationHotkeyControl, null);
        }

        private void otherCombinationHotkeyControl_TextChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (!otherCombinationRadioButton.Checked)
                return;

            if (string.IsNullOrEmpty(otherCombinationHotkeyControl.Text))
                return;

            var hotkey = otherCombinationHotkeyControl.ToString();

            if (HotkeyHelper.IsNoneKey(hotkey))
            {
                otherCombinationHotkeyControl.Clear();
                return;
            }

            if (HotkeySolution.Custom == HotkeyInfo.Solution && HotkeyHelper.Equals(hotkey, HotkeyInfo.Hotkey))
                return;

            if (HotkeyHelper.Equals(hotkey, HotkeyInfo.DefaultHotkey))
            {
                SetDefaultHotkey();
                return;
            }

            var internalConflictHotkeyInfo = _hotkeyInfoCollection.FirstOrDefault(hi =>
                hi.Solution == HotkeySolution.Custom && HotkeyHelper.Equals(hi.Hotkey, hotkey) ||
                hi.Solution == HotkeySolution.Default && HotkeyHelper.Equals(hi.DefaultHotkey, hotkey));

            if (null != internalConflictHotkeyInfo)
            {
                ShowConflictMessage(internalConflictHotkeyInfo.ActionText);
                return;
            }

            if (HotkeySolution.Default == HotkeyInfo.Solution)
                HotkeyHelper.UnregisterHotkey(HotkeyInfo.DefaultHotkey);

            if (HotkeySolution.Custom == HotkeyInfo.Solution)
                HotkeyHelper.UnregisterHotkey(HotkeyInfo.Hotkey);

            if (!HotkeyHelper.TryRegisterHotkey(HotkeyInfo.Action, hotkey))
            {
                ShowConflictMessage();

                var form = FindForm();

                if (form != null)
                    form.ActiveControl = (Control) form.AcceptButton;

                otherCombinationRadioButton.Checked = false;
                otherCombinationHotkeyControl.Clear();

                return;
            }

            HotkeyInfo.Solution = HotkeySolution.Custom;
            HotkeyInfo.Hotkey = hotkey;
        }

        private void otherCombinationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (otherCombinationRadioButton.Checked)
                otherCombinationHotkeyControl.Focus();
            else
            {
                otherCombinationHotkeyControl.Clear();
                mErrorProvider.SetError(otherCombinationHotkeyControl, null);
            }
        }

        private void ignoreRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!_initializationComplete)
                return;

            if (ignoreRadioButton.Checked)
            {
                switch (HotkeyInfo.Solution)
                {
                    case HotkeySolution.Default:
                        HotkeyHelper.UnregisterHotkey(HotkeyInfo.DefaultHotkey);
                        break;
                    case HotkeySolution.Custom:
                        HotkeyHelper.UnregisterHotkey(HotkeyInfo.Hotkey);
                        break;
                }

                HotkeyInfo.Solution = HotkeySolution.Disabled;
            }
        }

        private void ShowConflictMessage(string internalConflictActionText = null)
        {
            var conflictHotkeyErrorMessage = null == internalConflictActionText
                ? Language.GetString("hotkey_external_conflict_message")
                : Language.GetFormattedString("hotkey_internal_conflict_message", internalConflictActionText);

            MessageBox.Show(this, conflictHotkeyErrorMessage, "Greenshot", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void SetDefaultHotkey()
        {
            if (HotkeySolution.Default == HotkeyInfo.Solution)
                return;

            var internalConflictHotkeyInfo = _hotkeyInfoCollection.FirstOrDefault(hi =>
                hi.Solution == HotkeySolution.Custom && HotkeyHelper.Equals(hi.Hotkey, HotkeyInfo.DefaultHotkey));

            if (null != internalConflictHotkeyInfo)
            {
                ShowConflictMessage(internalConflictHotkeyInfo.ActionText);
                return;
            }

            if (HotkeySolution.Custom == HotkeyInfo.Solution)
                HotkeyHelper.UnregisterHotkey(HotkeyInfo.Hotkey);

            if (!HotkeyHelper.TryRegisterHotkey(HotkeyInfo.Action, HotkeyInfo.DefaultHotkey))
            {
                ShowConflictMessage();
                defaultRadioButton.Checked = false;

                return;
            }

            HotkeyInfo.Solution = HotkeySolution.Default;
        }
    }
}