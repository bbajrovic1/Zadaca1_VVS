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
		//FUNKCIONALNOST 5 -EMA MEKIC
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

		//FUNKCIONALNOST 5 -EMA MEKIC
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
		
		//FUNKCIONALNOST 4 - Bakir Bajrovic
		public string prikaziGlasoveKandidataURukovodstvu()
        {
			int brGlasova = 0;
			string s = "";
			foreach (Kandidat kandidat in Kandidati)
            {
				if (kandidat.Rukovodstvo)
					brGlasova += kandidat.BrojGlasova;
            }
			s = s + "Ukupan broj glasova: " + brGlasova + "\n";
			s += "Kandidati:\n";
			foreach (Kandidat kandidat in Kandidati)
			{
				if (kandidat.Rukovodstvo)
					s = s + "ID: " + kandidat.ID + "\n";
			}
			return s;
		}
		
	}
}
