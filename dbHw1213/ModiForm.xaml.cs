using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dbHw1213
{
	public partial class ModiForm : Window
	{
		InternetService service = new InternetService();
		public ModiForm(DataDef selected)
		{
			InitializeComponent();
			inputName.Text = selected.name;
			inputIP.Text = selected.ipAddress;
			inputLocation.Text = selected.location;
		}
		private void inputIP_KeyPress(object sender, TextCompositionEventArgs e)
		{
			if (Regex.IsMatch(e.Text, "^[0-9.]"))
			{
				e.Handled = true;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string name = inputName.Text.Trim();
			string IP = inputIP.Text.Trim();
			string location = inputLocation.Text.Trim();
			if (string.IsNullOrEmpty(name))
			{
				MessageBox.Show("Name MUST be declared!");
				return;
			}
			if (string.IsNullOrEmpty(IP))
			{
				MessageBox.Show("IP address MUST be declared!");
				return;
			}
			if (!Regex.IsMatch(IP, "^[0-9.]"))
			{
				MessageBox.Show("The entered IP address is not valid!");
				return;
			}
			if (string.IsNullOrEmpty(location))
			{
				MessageBox.Show("Location MUST be declared!");
				return;
			}
			DataDef user = new DataDef();
			user.name = name;
			user.ipAddress = IP;
			user.location = location;
			service.Modify(user);
			inputName.Text = "";
			inputIP.Text = "";
			inputLocation.Text = "";
			MessageBox.Show($"Successfully modified {user.name}'s data!");
		}
	}
}
