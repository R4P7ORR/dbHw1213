using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dbHw1213
{
	public partial class MainWindow : Window
	{
		InternetService service = new InternetService();
		public MainWindow()
		{
			//American Hospital Simulator
			InitializeComponent();
			userTable.ItemsSource = service.GetAll();
		}
		private void btnOpenForm(object sender, RoutedEventArgs e)
		{
			UserForm form = new UserForm();
			form.Closed += (_, _) =>
			{
				userTable.ItemsSource = service.GetAll();
			};
			form.ShowDialog();
		}
		private void btnReload(object sender, RoutedEventArgs e)
		{
			userTable.ItemsSource = service.GetAll();
		}
		private void btnRemove(object sender, RoutedEventArgs e)
		{
			DataDef selected = userTable.SelectedItem as DataDef;
			if (selected == null)
			{
				MessageBox.Show("To delete data, you MUST select an item from the list!");
				return;
			}
			MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selected.name}'s data from the list?", "Delete", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.Yes)
			{
				if (!service.Delete(selected))
				{
					MessageBox.Show($"An ERROR has occurred during the removal of {selected.name}!");
				}
				else
				{
					MessageBox.Show("Successfully deleted user from the table!");
				}
				userTable.ItemsSource = service.GetAll();
			}
		}
		private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			DataDef selected = userTable.SelectedItem as DataDef;
			ModiForm mod= new ModiForm(selected);
			mod.Closed += (_, _) =>
			{
				userTable.ItemsSource = service.GetAll();
			};
			mod.ShowDialog();
		}
	}
}

