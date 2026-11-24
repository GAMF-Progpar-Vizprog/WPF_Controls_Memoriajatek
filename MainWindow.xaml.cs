using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace WPF_Controls_Memoriajatek
{
	public partial class MainWindow : Window
	{
		string Hátlapnév = "hatlap.png";
		string[] Képnevek = { "grabowski.JPG", "kukori.JPG", "kuldonc.JPG", "vili.JPG" };
		BitmapImage[] biKépek;
		BitmapImage biHátlap;
		Image[] imKépek;
		Random rnd = new Random();

		public MainWindow()
		{
			InitializeComponent();
			imKépek = new Image[] 
			{ im00, im01,im02, im03,
				im10,im11,im12,im13
			};
			biKépek = new BitmapImage[8];
			KépeketBetölt();
			KépeketMutat();
			HátlapotMutat();
		}

		private void HátlapotMutat()
		{
			for (int i = 0; i < 8; i++)
				imKépek[i].Source = biHátlap;
		}

		private void KépeketMutat()
		{
				for (int i = 0; i < 8; i++)
				{
					imKépek[i].Source = biKépek[i];
				}
		}

		private void KépeketBetölt()
		{
			biHátlap = new BitmapImage(new Uri(Hátlapnév, UriKind.Relative));
			for (int i = 0; i < 4; i++)
			{
				biKépek[i] = new BitmapImage(new Uri(Képnevek[i], UriKind.Relative));
				biKépek[i + 4] = biKépek[i];
			}
		}

		private void miKilép_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();	
    }

		private async void miKever_Click(object sender, RoutedEventArgs e)
		{
			List<BitmapImage> lista = new List<BitmapImage>();
			lista.AddRange(biKépek);
			for (int i = 0; i < 8; i++)
			{
				int véletlen = rnd.Next(lista.Count);
				biKépek[i] = lista[véletlen];
				lista.RemoveAt(véletlen);
			}
			KépeketMutat();
			await Task.Delay(2000);
			HátlapotMutat();
			
		}

		private void miKérdez_Click(object sender, RoutedEventArgs e)
		{
			var wnd = new wndKitalal();
			var kép = biKépek[rnd.Next(8)];
			wnd.biKitalál = kép;
			if (wnd.ShowDialog()==true)
			{
				if (biKépek[wnd.ElsőElőfordulás] == kép 
					&&
					biKépek[wnd.MásodikElőfordulás] == kép)
						MessageBox.Show("Hurrá, eltaláltad!");
				else
					MessageBox.Show("Sajnos nem talált!");
			};	
		}

		private void miSúgó_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}