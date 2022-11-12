using System;

namespace Zadaca1
{
	public class Stranka
	{
		public string Naziv { get; set; }
		public List<Kandidat> Kandidati { get; set; }
		public int BrojGlasova { get; }
		public double procenatGlasova { get; set; }

		public Stranka(string naziv, List<Kandidat> kandidati)
		{
			Naziv = naziv;
			Kandidati = kandidati;
			BrojGlasova = 0;
			procenatGlasova = 0;

		}
		public Stranka(string naziv)
		{
			Naziv = naziv;
			Kandidati = new List<Kandidat>();
			BrojGlasova = 0;
			procenatGlasova = 0;

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
		public void dajProcenatGlasova()
		{

		}
	}
}
