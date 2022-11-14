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
			ProcenatGlasova = 0; //Stefani - feedback
			BrojGlasova = 0;
			

		}
		public Stranka(string naziv)
		{
			Naziv = naziv;
			Kandidati = new List<Kandidat>();
			BrojGlasova = 0;
			ProcenatGlasova = 0;

		}
		public void dodajGlas() //Emin komentar: Ime metode ne ukazuje kome se daje glas. Ime indicira da se glas daje samo stranki ali se kasnije treba updatovati i dodati glas svakom pojedinačnom članu stranke. 
		{
			BrojGlasova++;
// 			foreach (Kandidat kandidat in Kandidati)
// 			{
// 				kandidat.dodajGlas();

// 			} //dodano u issues
		}
		public void dodajGlasSamoStranci()
		{
			BrojGlasova++;
		}
		
	}
}
