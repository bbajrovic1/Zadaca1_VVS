using System;
using System.Collections.Generic;
namespace Zadaca1
{
	public class Stranka
	{
		public string Naziv { get; set; }
		public List<Kandidat> Kandidati { get; set; }
		public int BrojGlasova { get; set; }
		public double ProcenatGlasova { get; set; }

		public Stranka(string naziv, List<Kandidat> kandidati)
		{
			Naziv = naziv;
			Kandidati = kandidati;
			BrojGlasova = 0;
			ProcenatGlasova = 0; //mora biti 0

		}
		public Stranka(string naziv)
		{
			Naziv = naziv;
			Kandidati = new List<Kandidat>();
			BrojGlasova = 0;
			ProcenatGlasova = 0;

		}
		public void dodajGlas()
		{
			BrojGlasova++;
			foreach (Kandidat kandidat in Kandidati)
			{
				kandidat.dodajGlas();

			}
		}
		public void dodajGlasSamoStranci()
		{
			BrojGlasova++;
		}
		
	}
}
