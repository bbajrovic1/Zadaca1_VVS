using System;
using System.Collections.Generic;
namespace Zadaca1
{
	public class Izbori
	{
		public List<Stranka> Stranke { get; set; }
		public List<Kandidat> NezavisniKandidati { get; set; }
		public List<Glasac> Glasaci { get; set; }
		public int BrojIzlazaka { get; set; }
		

		public Izbori()
		{
			BrojIzlazaka = 0;
			
		}
		public Izbori(List<Stranka> stranke, List<Kandidat> nezavisniKandidati, List<Glasac> glasaci)
		{ Stranke = stranke;
			NezavisniKandidati = nezavisniKandidati;
			Glasaci = glasaci;
			BrojIzlazaka = 0;
			
		}
		public void glasajZaStranku(int brojStranke) //Merjem
		{ if(brojStranke > 0 && brojStranke <= Stranke.Count) //u suprotnom je nevazeci glasacki "listic"
			Stranke[brojStranke - 1].dodajGlasStranciISvimKandidatima();  
		}


		public void glasajZaKandidateIzStranke(int brojStranke, List<int> odabraniKandidati)//Merjem
		{  
			if (brojStranke > 0 && brojStranke <= Stranke.Count)
			{
				Stranke[brojStranke - 1].dodajGlasSamoStranci();

				foreach (int i in odabraniKandidati)
				{   if(i > 0 && i <= Stranke[brojStranke - 1].Kandidati.Count)
					Stranke[brojStranke - 1].Kandidati[i - 1].dodajGlas(); 
				}
			}
		}


		public void glasajZaNezavisnog(int odabraniNezavisniKandidat)//Merjem
		{
            if (odabraniNezavisniKandidat > 0 && odabraniNezavisniKandidat <= NezavisniKandidati.Count)
                NezavisniKandidati[odabraniNezavisniKandidat - 1].dodajGlas(); 

		}

		
		public double izracunajIzlaznost()	//resolved - Bakir
		{ if (Glasaci.Count == 0) return 0;
			BrojIzlazaka = 0;				/*resolved - Bakir*/
			foreach (Glasac glasac in Glasaci)
			{
				if (glasac.Glasao == true)
					BrojIzlazaka++;
			}

			return ((double)BrojIzlazaka / Glasaci.Count) * 100; /*resolved - Bakir*/

        }


        public void izracunajProcenteGlasovaZaStranke() // resolved issue - Ema
        {	izracunajIzlaznost();
			if (BrojIzlazaka == 0) return;
			foreach (Stranka stranka in Stranke)
			{
				stranka.ProcenatGlasova = (stranka.BrojGlasova / (double)BrojIzlazaka) * 100; // Merjem: Zahtjev za pregled: dijeljenje s nulom nije provjereno
		    											/*resolved - Ema*/
			}
		}


		public List<Stranka> dajStrankeSaMandatom() //Stefani
		{
			//resolved - Ema
			izracunajProcenteGlasovaZaStranke();
            List<Stranka> mandatorne = new List<Stranka>();
			if (BrojIzlazaka == 0) return mandatorne;
		foreach(Stranka stranka in Stranke)
				if (stranka.ProcenatGlasova > 2)
					mandatorne.Add(stranka);
			return mandatorne;
	
		}


		public void izracunajProcenteGlasovaZaKandidate() //Mirza
		{  foreach(Stranka stranka in Stranke)
			{
				foreach(Kandidat kandidat in stranka.Kandidati)
				{  if(stranka.BrojGlasova != 0)
					kandidat.ProcenatGlasova = kandidat.BrojGlasova / stranka.BrojGlasova; //potreban cast u double
				}

			}
		}


		public List<Kandidat> dajKandidateSaMandatom() //resolved - Bakir
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			izracunajProcenteGlasovaZaKandidate();
            List<Kandidat> kandidatiSaMandatom = new List<Kandidat>();
			if (BrojIzlazaka == 0) return kandidatiSaMandatom;
			foreach(Stranka stranka in mandatorne)
			{ 
				foreach(Kandidat kandidat in stranka.Kandidati) {
					if (kandidat.ProcenatGlasova > 20)
						kandidatiSaMandatom.Add(kandidat);
				}
			}
			return kandidatiSaMandatom;
		}

		public bool identificirajGlasaca(string id) /*resolved - Ema*/
		{ bool pronadjen = false;
			foreach(Glasac glasac in Glasaci)
			{
				if (String.Equals(glasac.ID, id) && glasac.Glasao == false)
				{
					pronadjen = true;
					glasac.Glasao = true;
					break; /*resolved - Ema*/
				}
			}
			return pronadjen;
		}

		public void prikaziStranke() //Stefani - feedback
		{ int i = 1;
			foreach(Stranka stranka in Stranke)
			{ Console.WriteLine(i + ". " + stranka.Naziv + Environment.NewLine);
				i++;
			}
		}


		public void prikaziKandidateIzStranke(int brojStranke) //Mirza
		{ //ovdje ce biti greska ako brojStranke bude veci od broja stranki ili negativan broj
			Stranka odabrana = Stranke[brojStranke - 1];
			int i = 1;
			foreach(Kandidat kandidat in odabrana.Kandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n"); //ako se neko isto zove greska jer glasac ne zna kojeg ce
				i++;
			}

		}


		public void prikaziNezavisneKandidate() //Merjem
		{ int i = 1;
			foreach(Kandidat kandidat in NezavisniKandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n"); //Merjem: Zahtjev za pregled: Bilo bi ljepse koristiti neke naprednije metode sa lambda funkcijama
				i++;
			}
		}


		public void ispisiMandatorneStranke() //resolved - Bakir
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			foreach(Stranka stranka in mandatorne)
				Console.WriteLine(stranka.Naziv + " sa " + stranka.BrojGlasova + " glasova.\n");
		}


		public void ispisiKandidateSaMandatima() //resolved - Ema
		{
			List<Kandidat> mandatorni = dajKandidateSaMandatom();
			foreach(Kandidat kandidat in mandatorni)
				Console.WriteLine(kandidat.Ime + " " + kandidat.Prezime + " sa " + kandidat.BrojGlasova + " glasova.\n");
		}




	}
}

