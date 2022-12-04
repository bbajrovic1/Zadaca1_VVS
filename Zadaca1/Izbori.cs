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
		{	
			Stranke = stranke;
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
				{  if(stranka.BrojGlasova != 0) { 
					kandidat.ProcenatGlasova = (kandidat.BrojGlasova / (double)stranka.BrojGlasova)*100; //resolved - Mirza

						}
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
		{
			if (brojStranke < 0 || brojStranke >= Stranke.Count)
				throw new Exception("Nevalidan broj stranke.");
            Stranka odabrana = Stranke[brojStranke - 1];
			int i = 1;
			foreach(Kandidat kandidat in odabrana.Kandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + " " + kandidat.JMBG.Substring(4, 3) + "\n"); //resolved - Mirza
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

		public void prikaziSveKandidate()
		{
            int i = 1;
            foreach (Stranka stranka in Stranke)
			{
                foreach (Kandidat kandidat in stranka.Kandidati)
                {
                    Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n");
                    i++;
                }
            }
        
			foreach (Kandidat kandidat in NezavisniKandidati)
			{
                Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n");
                i++;
            }
				
		}

		public void prikaziProsleStrankeZaKandidata(int odabirStranke, int noviKandidat)
		{   if (odabirStranke < 1 || odabirStranke > Stranke.Count || noviKandidat < 1 || noviKandidat > Stranke[odabirStranke - 1].Kandidati.Count)
				throw new Exception("Nevalidan odabir.");
			Stranke[odabirStranke-1].Kandidati[noviKandidat-1].prikaziProsleStranke();
		}


		public void prikaziRezultateZaStranku(Stranka stranka, List<Kandidat> kandidati)
		{
			Console.WriteLine("Rezultati za stranku: " + stranka.Naziv +  "\nUkupan broj glasova je: " + stranka.BrojGlasova
				+ "\nPostotak osvojenih glasova je: " + stranka.ProcenatGlasova + "\nBroj osvojenih mandata je: " + kandidati.Count);
			foreach(Kandidat kandidat in kandidati)
				Console.WriteLine(kandidat.prikaziKandidata() + "\n");
			Console.WriteLine("\n");

		}
		public void prikaziRezultateZaSveStranke()
		{   List<Kandidat> mandatorni = dajKandidateSaMandatom();
			if(mandatorni.Count == 0) { 
				Console.WriteLine("Trenutno jos nema rezultata.");
				return;
				}
			foreach(Stranka stranka in Stranke) { 
				List<Kandidat> mandatorniIzStranke = mandatorni.FindAll(k => string.Equals(k.Stranka.Naziv, stranka.Naziv));

				prikaziRezultateZaStranku(stranka, mandatorniIzStranke);
			}
		}

		public void prikaziRezultateRukovodstvaZaStranku(int odabirStranke)
        {
			if (odabirStranke < 1 || odabirStranke > Stranke.Count)
				throw new Exception("Nevalidan odabir.");
			Stranke[odabirStranke - 1].prikaziGlasoveKandidataURukovodstvu();
		}
	}
}

