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
using System.Windows.Shapes;

namespace WPF_Controls_Memoriajatek
{
	
	public partial class wndKitalal : Window
	{
		public BitmapImage? biKitalál
		{
			set { imKitalál.Source = value; }
			get { return imKitalál.Source as BitmapImage; }
		}
		public int ElsőElőfordulás
		{
			get
			{
				int Kiválasztott = -1;
				for (int i = 0; i < 8; i++)
					if (((RadioButton)wpElső.Children[i]).IsChecked == true)
					{
						Kiválasztott = i;
						break;
					}
				return Kiválasztott;
			}
		}
		public int MásodikElőfordulás
		{
			get
			{
				int Kiválasztott = -1;
				for (int i = 0; i < 8; i++)
					if (((RadioButton)wpMásodik.Children[i]).IsChecked == true)
					{
						Kiválasztott = i;
						break;
					}
				return Kiválasztott;
			}
		}
		public wndKitalal()
		{
			InitializeComponent();
		}

		private void btOK_Click(object sender, RoutedEventArgs e)
		{
			if(ElsőElőfordulás==-1)
			{
				MessageBox.Show("Az első előfordulás helyének megadása kötelező!");
				return; 
			}
			if (MásodikElőfordulás == -1)
			{
				MessageBox.Show("A második előfordulás helyének megadása kötelező!");
				return;
			}
			if(ElsőElőfordulás==MásodikElőfordulás)
			{
				MessageBox.Show("A két előfordulás helye nem lehet azonos!");
				return;
			}
			DialogResult=true;
		}
	}
}
