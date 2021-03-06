﻿using System;
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

			Kvadrat k1 = new Kvadrat();
			Kvadrat k2 = new Kvadrat();
			k1.a = 5;
			k2.a = 5;
			MessageBox.Show(k1.GetHashCode().ToString());
			MessageBox.Show(((decimal)5).GetHashCode().ToString());

			if (k1.Equals(k2))
			{
				MessageBox.Show("Isti su!");
			}else
			{
				MessageBox.Show("Nisu :/");
			}

			Kvadrat k = new Kvadrat();
			k.a = 5;
			
			Pravougaonik p = new Pravougaonik();
			p.a = 2;
			p.b = 3;

			Krug o = new Krug();
			o.Poluprecnik = 10;

			List<IFigura> svi = new List<IFigura>();
			svi.Add(k);
			svi.Add(p);
			svi.Add(o);

			foreach (IFigura f in svi)
			{
				MessageBox.Show($"{f} P:{f.Povrsina()} O:{f.Obim()}");
			}
		}
	}

	public interface IFigura
	{
		decimal Povrsina();
		decimal Obim();
	}
	
	public class Kvadrat : IFigura
	{
		public decimal a;

		public virtual decimal Povrsina() => a * a;
		public virtual decimal Obim() => 4 * a;

		public override string ToString() => $"kvadrat: a:{a}";

		public override bool Equals(object obj) => obj is Kvadrat k && k.a == a;
		public override int GetHashCode() => (GetType().ToString() + a).GetHashCode();
	}

	public class Pravougaonik : Kvadrat
	{
		public decimal b;

		public override decimal Povrsina() => a * b;
		public new decimal Obim() => 2*a + 2*b;

		public override string ToString() => $"pravougaonik: a:{a} b:{b}";
	}

	public class Krug : IFigura
	{
		public decimal Poluprecnik;

		public decimal Povrsina() => (decimal)Math.PI * Poluprecnik * Poluprecnik;
		public decimal Obim() => (decimal)Math.PI * 2 * Poluprecnik;

		public override string ToString() => $"krug: pp:{Poluprecnik}";
	}
}
