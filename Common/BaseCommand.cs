﻿using System;
using System.Drawing;
using FreeSCADA.Interfaces;

namespace FreeSCADA.Common
{
	public abstract class BaseCommand : ICommand
	{
		bool canExecute = false;

		public BaseCommand()
		{
		}

		public event EventHandler CanExecuteChanged;

		public virtual string Name { get { throw new NotImplementedException(); } }
		public virtual string Description { get { throw new NotImplementedException(); } }
		public virtual Bitmap Icon { get { return null; } }
		public virtual CommandType Type { get { return CommandType.Standard; } }

		public virtual bool CanExecute
		{
			get { return canExecute; }
			set 
			{
				if (canExecute != value)
				{
					canExecute = value;
					FireCanExecuteChanged();
				}
			}
		}

		public virtual void Execute()
		{
		}

		public void FireCanExecuteChanged()
		{
			if (CanExecuteChanged != null)
				CanExecuteChanged(this, new EventArgs());
		}
	}
}
