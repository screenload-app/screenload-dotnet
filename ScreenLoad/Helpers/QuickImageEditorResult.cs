﻿using System;
using System.Drawing;

namespace ScreenLoad.Helpers
{
    public enum QuickImageEditorAction
    {
        None,
        DownloadRu,
        Copy,
        Save,
        Editor,
    }

    public sealed class QuickImageEditorResult : IDisposable
    {
        public static readonly QuickImageEditorResult NoAction = new QuickImageEditorResult();

        public QuickImageEditorAction Action { get; }
        public Image Image { get; }
        public Rectangle Rectangle { get; }

        private QuickImageEditorResult()
        {
            Action = QuickImageEditorAction.None;
        }

        public QuickImageEditorResult(QuickImageEditorAction action, Image image, Rectangle rectangle)
        {
            if (rectangle.IsEmpty)
                throw new ArgumentOutOfRangeException(nameof(rectangle));

            Action = action;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Rectangle = rectangle;

            //byte[] surfaceBytes;

            //using (MemoryStream stream = new MemoryStream())
            //{
            //    ImageOutput.SaveToStream(surface, stream, new SurfaceOutputSettings(OutputFormat.ScreenLoad));
            //    surfaceBytes = stream.ToArray();
            //}
        }

        public void Dispose()
        {
            Image?.Dispose();
        }
    }
}
