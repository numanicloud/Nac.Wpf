using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Nac.Wpf
{
	public class MasterList<T> : ObservableCollection<T>, IEnumerable<T> where T : new()
	{
		public ICommand AddCommand
		{
			get
			{
				if(_AddCommand == null)
					_AddCommand = new DelegateCommand { CommandHandler = this.AddCommandHandler };
				return _AddCommand;
			}
		}
		public ICommand RemoveCommand
		{
			get
			{
				if(_RemoveCommand == null)
					_RemoveCommand = new DelegateCommand { CommandHandler = this.RemoveCommandHandler };
				return _RemoveCommand;
			}
		}
		public T SelectedItem
		{
			get { return selectedItem_; }
			set
			{
				selectedItem_ = value;
				OnPropertyChanged(new PropertyChangedEventArgs("SelectedItem"));
			}
		}
		public IList<T> List
		{
			get { return this; }
		}


		public MasterList()
		{
		}

		public MasterList(IEnumerable<T> source)
			: base(source)
		{
		}

		private void AddCommandHandler(object parameter)
		{
			if(parameter == null)
			{
				Add(new T());
			}
			else
			{
				Add((T)parameter);
			}
		}

		private void RemoveCommandHandler(object parameter)
		{
			Remove((T)parameter);
		}

		private ICommand _AddCommand;
		private ICommand _RemoveCommand;
		private T selectedItem_;
	}
}
