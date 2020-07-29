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

namespace PolimorfizamPrimer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Kvadrat k = new Kvadrat();
			k.a = 5;

			Pravougaonik p = new Pravougaonik();
			p.a = 2;
			p.b = 3;

			Krug o = new Krug();
			o.Poluprecnik = 10;

			List<Figura> svi = new List<Figura>();
			svi.Add(k);
			svi.Add(p);
			svi.Add(o);

			foreach (Figura f in svi)
			{
				MessageBox.Show(f.Povrsina().ToString());
				MessageBox.Show(f.Obim().ToString());
			}
		}
	}

	public abstract class Figura
	{
		public abstract decimal Povrsina();

		public abstract decimal Obim();

		public double DajPi() => Math.PI;
	}
	
	public class Kvadrat : Figura
	{
		public decimal a;

		public override decimal Povrsina() => a * a;
		public override decimal Obim() => 4 * a;
	}

	public class Pravougaonik : Kvadrat
	{
		public decimal b;

		public override decimal Povrsina() => a * b;
		public new decimal Obim() => 2*a + 2*b;
	}

	public class Krug : Figura
	{
		public decimal Poluprecnik;

		public override decimal Povrsina() => (decimal)Math.PI * Poluprecnik * Poluprecnik;
		public override decimal Obim() => (decimal)Math.PI * 2 * Poluprecnik;
	}
}
