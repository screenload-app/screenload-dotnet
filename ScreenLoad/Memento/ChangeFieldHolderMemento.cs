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

using ScreenLoad.Plugin.Drawing;
using ScreenLoadPlugin.Interfaces.Drawing;

namespace ScreenLoad.Memento
{
	/// <summary>
	/// The ChangeFieldHolderMemento makes it possible to undo-redo an IDrawableContainer move
	/// </summary>
	public class ChangeFieldHolderMemento : IMemento
	{
		private IDrawableContainer _drawableContainer;
		private readonly IField _fieldToBeChanged;
		private readonly object _oldValue;

        internal IField FieldToBeChanged => _fieldToBeChanged;

        public ChangeFieldHolderMemento(IDrawableContainer drawableContainer, IField fieldToBeChanged)
		{
			_drawableContainer = drawableContainer;
			_fieldToBeChanged = fieldToBeChanged;
			_oldValue = fieldToBeChanged.Value;
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_drawableContainer?.Dispose();
			}
			_drawableContainer = null;
		}

		public bool Merge(IMemento otherMemento)
		{
			ChangeFieldHolderMemento other = otherMemento as ChangeFieldHolderMemento;
			if (other != null)
			{
				if (other._drawableContainer.Equals(_drawableContainer))
				{
					if (other._fieldToBeChanged.Equals(_fieldToBeChanged))
					{
						// Match, do not store anything as the initial state is what we want.
						return true;
					}
				}
			}
			return false;
		}

		public IMemento Restore()
		{
			// Before
			_drawableContainer.Invalidate();
			ChangeFieldHolderMemento oldState = new ChangeFieldHolderMemento(_drawableContainer, _fieldToBeChanged);
			_fieldToBeChanged.Value = _oldValue;
			// After
			_drawableContainer.Invalidate();
			return oldState;
		}
	}
}
