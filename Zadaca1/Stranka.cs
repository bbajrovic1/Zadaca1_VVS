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
			ProcenatGlasova = 0;
			BrojGlasova = 0;
			

		}
		public Stranka(string naziv)
		{
			Naziv = naziv;
			Kandidati = new List<Kandidat>();
			BrojGlasova = 0;
			ProcenatGlasova = 0;

		}
		public void dodajGlasStranciISvimKandidatima()
		{
			BrojGlasova++;
			foreach (Kandidat kandidat in Kandidati)
			{
 				kandidat.dodajGlas();

 			}
		}

		public void OduzmiGlasStranciISvimKandidatima()
		{
			BrojGlasova--;
			foreach (Kandidat kandidat in Kandidati)
			{
				kandidat.oduzmiGlas();

			}
		}



		public void dodajGlasSamoStranci()
		{
			BrojGlasova++;
		}

		public void oduzmiGlasSamoStranci()
		{
			BrojGlasova--;
		}
		public void prikaziKandidate()
		{
			int i = 1;
			foreach (Kandidat kandidat in Kandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n");
				i++;
			}
		}

		public void prikaziGlasoveKandidataURukovodstvu()
        {
			int brGlasova = 0;
			foreach (Kandidat kandidat in Kandidati)
            {
				if (kandidat.Rukovodstvo)
					brGlasova += kandidat.BrojGlasova;
            }
			Console.WriteLine("Ukupan broj glasova: " + brGlasova);
			Console.WriteLine("Kandidati:");
			foreach (Kandidat kandidat in Kandidati)
			{
				if (kandidat.Rukovodstvo)
					Console.WriteLine("ID: " + kandidat.ID);
			}
		}
		
	}
}
