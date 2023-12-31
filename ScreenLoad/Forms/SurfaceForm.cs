﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ScreenLoad.Drawing;
using ScreenLoad.Plugin;
using ScreenLoadPlugin.Core;

namespace ScreenLoad
{
    public partial class SurfaceForm : Form
    {
        public Surface Surface { get; }

        public SurfaceForm(ICapture capture)
        {
            if (null == capture)
                throw new ArgumentNullException(nameof(capture));

            InitializeComponent();

            var captureCopy = new Capture((Image) capture.Image.Clone())
            {
                CaptureDetails = capture.CaptureDetails,
                
            };

            if (null != capture.Cursor)
            {
                captureCopy.CursorVisible = capture.CursorVisible;
                captureCopy.CursorLocation = capture.CursorLocation;
                captureCopy.Cursor = (Icon) capture.Cursor.Clone();
            }

            var surface = new Surface(captureCopy)
            {
                CaptureDetails = capture.CaptureDetails,
                Modified = false
            };

            surface.ResetUndoStack();

            Surface = surface;

            Surface.MouseWheel += (sender, args) =>
            {
                if ((ModifierKeys & Keys.Control) != Keys.Control)
                    return;

                if (args.Delta > 0)
                    Surface.ProcessCmdKey(Keys.Control | Keys.Add);
                else
                    Surface.ProcessCmdKey(Keys.Control | Keys.Subtract);
            };

            SuspendLayout();
            Bounds = capture.ScreenBounds;
            Controls.Add(surface);
            ResumeLayout(true);
        }

        protected override bool ProcessKeyPreview(ref Message msg)
        {
            //if (Surface.KeysLocked)
            //    return false;

            return base.ProcessKeyPreview(ref msg);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool keysLocked;

            switch (keyData)
            {
                // Не учитываем блокировку для клавиш изменения размера текста
                // TODO $ Перенести в Surface?
                case Keys.Add | Keys.Control:
                case Keys.Subtract | Keys.Control:
                    keysLocked = false;
                    break;
                default:
                    keysLocked = Surface.KeysLocked;
                    break;
            }

            if (!keysLocked && !Surface.ProcessCmdKey(keyData))
                return base.ProcessCmdKey(ref msg, keyData);

            return false;
        }
    }
}