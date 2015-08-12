using System.Windows;
using System.Windows.Controls;

namespace Nac.Wpf
{
	/// <summary>
	/// MasterList.xaml の相互作用ロジック
	/// </summary>
	public partial class MasterListView : UserControl
	{
		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public static readonly DependencyProperty ItemTemplateProperty =
			DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(MasterListView), new PropertyMetadata(null));

		public MasterListView()
		{
			InitializeComponent();
		}
	}
}
