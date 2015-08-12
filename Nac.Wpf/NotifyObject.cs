using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nac.Wpf
{
	public class NotifyObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
		{
			if(!field.Equals(value))
			{
				field = value;
				Raise(propertyName);
			}
		}

		protected void Raise([CallerMemberName]string propertyName = null)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	static class NotifyExtention
	{
		public static void Raise(this PropertyChangedEventHandler propertyChanged, object sender, [CallerMemberName]string propertyName = null)
		{
			if(propertyChanged != null)
			{
				propertyChanged(sender, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
