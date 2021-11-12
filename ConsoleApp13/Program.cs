using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp13
{
	class Program
	{
		static void Main(string[] args)
		{
			/*File.WriteAllText("nesto.txt", "asdasdasd" + Environment.NewLine);
			File.AppendAllText("nesto.txt", "        dodato :D" + Environment.NewLine);

			List<string> asd = new List<string>();
			asd.Add("Jen");
			asd.Add("Dva");
			asd.Add("Tri");

			File.WriteAllLines("nesto.txt", asd);
			
			if (File.Exists("nesto.txt"))
			{
				//string nesto = File.ReadAllText("nesto.txt");
				foreach (string red in File.ReadLines("nesto.txt"))
				{
					Console.WriteLine(red);
				}
			} else
				Console.WriteLine($"Greska, nema fajla");*/
			List<Artikal> listaArt = new();
			listaArt.AddRange(new Artikal[] { new Artikal{ Cena = 15, Kolicina = 10, Naziv = "Asd" },
				new Artikal{ Cena = 25, Kolicina = 11, Naziv = "Kafffa" },
				new Artikal{ Cena = 43, Kolicina = 2, Naziv = "Kjhsf" },
				new Artikal{ Cena = 167, Kolicina = 32, Naziv = "svsdv" }});

			foreach(var art in listaArt)
			{
				File.AppendAllText("art.txt", $"{art.Naziv};{art.Kolicina};{art.Cena}"
					+ Environment.NewLine);
			}
			List<Artikal> ucitani = new();
			if (File.Exists("art.txt"))
			{   // 0 - Naziv   1 - Kolocina   2- Cena
				// Asd      ;10             ;15
				foreach (string red in File.ReadLines("art.txt"))
				{
					string[] stvari = red.Split(';');
					if (stvari.Length != 3)
						throw new Exception("Jooook!");
					var a = new Artikal
					{
						Naziv = stvari[0],
						Kolicina = int.Parse(stvari[1]),
						Cena = decimal.Parse(stvari[2])
					};
					ucitani.Add(a);
				}
			}
		}
	}
	public class Artikal
	{
		public string Naziv { get; set; }
		public decimal Cena { get; set; }
		public int Kolicina { get; set; }
	}
}


