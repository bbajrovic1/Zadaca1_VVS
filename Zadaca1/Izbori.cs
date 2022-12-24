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
		public void glasajZaStranku(string id, int brojStranke)
		{ 
			if(brojStranke > 0 && brojStranke <= Stranke.Count)
            {
				Stranke[brojStranke - 1].dodajGlasStranciISvimKandidatima();
				dajGlasacaPodIDem(id).dodajStranku(brojStranke);
			}
				
		}


		public void glasajZaKandidateIzStranke(string id, int brojStranke, List<int> odabraniKandidati)
		{
			int brStranaka = Stranke.Count;
			if (brojStranke > 0 && brojStranke <= brStranaka && brStranaka > 0)
			{
				Stranka trenutnaStranka = Stranke[brojStranke - 1];
				trenutnaStranka.dodajGlasSamoStranci();

				foreach (int i in odabraniKandidati)
				{   if(i > 0 && i <= trenutnaStranka.Kandidati.Count)
					trenutnaStranka.Kandidati[i - 1].dodajGlas(); 
				}
				Glasac glasac = dajGlasacaPodIDem(id);
				glasac.dodajStranku(brojStranke);
				glasac.dodajKandidate(odabraniKandidati);
			}
		}

		//FUNKCIONALNOST 5 -EMA MEKIC
		public void oduzmiGlasoveZaKandidateIzStranke(int brojStranke, List<int> odabraniKandidati)
		{
			if (brojStranke > 0 && brojStranke <= Stranke.Count)
			{
				Stranke[brojStranke - 1].oduzmiGlasSamoStranci();

				foreach (int i in odabraniKandidati)
				{
					if (i > 0 && i <= Stranke[brojStranke - 1].Kandidati.Count)
						Stranke[brojStranke - 1].Kandidati[i - 1].oduzmiGlas();
				}
			}
		}


		public void glasajZaNezavisnog(string id, int odabraniNezavisniKandidat)
		{
            if (odabraniNezavisniKandidat > 0 && odabraniNezavisniKandidat <= NezavisniKandidati.Count)
            {
				NezavisniKandidati[odabraniNezavisniKandidat - 1].dodajGlas();
				dajGlasacaPodIDem(id).dodajKandidate(new List<int> { odabraniNezavisniKandidat });
			}
                
		}

		//FUNKCIONALNOST 5 -EMA MEKIC
		public void oduzmiGlasZaNezavisnog(int odabraniNezavisniKandidat)
		{
			if (odabraniNezavisniKandidat > 0 && odabraniNezavisniKandidat <= NezavisniKandidati.Count)
			{
				NezavisniKandidati[odabraniNezavisniKandidat - 1].oduzmiGlas();
			}

		}


		public double izracunajIzlaznost()
		{ if (Glasaci.Count == 0) return 0;
			BrojIzlazaka = 0;				
			foreach (Glasac glasac in Glasaci)
			{
				if (glasac.Glasao == true)
					BrojIzlazaka++;
			}

			return ((double)BrojIzlazaka / Glasaci.Count) * 100; 

        }


        public void izracunajProcenteGlasovaZaStranke() 
        {	izracunajIzlaznost();
			if (BrojIzlazaka == 0) return;
			foreach (Stranka stranka in Stranke)
			{
				stranka.ProcenatGlasova = (stranka.BrojGlasova / (double)BrojIzlazaka) * 100; 
		    											
			}
		}


		public List<Stranka> dajStrankeSaMandatom() 
		{
			
			izracunajProcenteGlasovaZaStranke();
            List<Stranka> mandatorne = new List<Stranka>();
			if (BrojIzlazaka == 0) return mandatorne;
		foreach(Stranka stranka in Stranke)
				if (stranka.ProcenatGlasova > 2)
					mandatorne.Add(stranka);
			return mandatorne;
	
		}


		public void izracunajProcenteGlasovaZaKandidate() 
		{  foreach(Stranka stranka in Stranke)
			{
				foreach(Kandidat kandidat in stranka.Kandidati)
				{  if(stranka.BrojGlasova != 0) { 
					kandidat.ProcenatGlasova = (kandidat.BrojGlasova / (double)stranka.BrojGlasova)*100; 

					}
				}

			}
		}
		


		public List<Kandidat> dajKandidateSaMandatom() 
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
		

		public bool identificirajGlasaca(string id) 
		{ bool pronadjen = false;
			foreach(Glasac glasac in Glasaci)
			{
				if (String.Equals(glasac.ID, id) && glasac.Glasao == false)
				{
					pronadjen = true;
					glasac.Glasao = true;
					break; 
				}
			}
			return pronadjen;
		}

		//FUNKCIONALNOST 5 -EMA MEKIC
		public Glasac dajGlasacaPodIDem(string id)
        {
			foreach(Glasac glasac in Glasaci)
            {
				if (glasac.ID == id)
					return glasac;
            }
			return null;
        }

		public void prikaziStranke() 
		{ int i = 1;
			foreach(Stranka stranka in Stranke)
			{ Console.WriteLine(i + ". " + stranka.Naziv + Environment.NewLine);
				i++;
			}
		}


		public void prikaziKandidateIzStranke(int brojStranke) 
		{
			if (brojStranke < 0 || brojStranke >= Stranke.Count)
				throw new Exception("Nevalidan broj stranke.");
            Stranka odabrana = Stranke[brojStranke - 1];
			int i = 1;
			foreach(Kandidat kandidat in odabrana.Kandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + " " + kandidat.JMBG.Substring(4, 3) + "\n");
				i++;
			}

		}


		public void prikaziNezavisneKandidate() 
		{ int i = 1;
			foreach(Kandidat kandidat in NezavisniKandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n"); 
				i++;
			}
		}


		public void ispisiMandatorneStranke() 
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			foreach(Stranka stranka in mandatorne)
				Console.WriteLine(stranka.Naziv + " sa " + stranka.BrojGlasova + " glasova.\n");
		}


		public void ispisiKandidateSaMandatima() 
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
		//FUNKCIONALNOST 2 -  Merjem Bećirović
		public string prikaziProsleStrankeZaKandidata(int odabirStranke, int noviKandidat)
		{   if (odabirStranke < 1 || odabirStranke > Stranke.Count || noviKandidat < 1 || noviKandidat > Stranke[odabirStranke - 1].Kandidati.Count)
				throw new Exception("Nevalidan odabir.");
			string rez = Stranke[odabirStranke - 1].Kandidati[noviKandidat - 1].prikaziProsleStranke();
            Console.WriteLine(rez);
			return rez;
		}

        public string prikaziProsleStrankeZaNezavisnogKandidata(int noviKandidat)
        {
            if (noviKandidat < 1 || noviKandidat > NezavisniKandidati.Count)
                throw new Exception("Nevalidan odabir.");
			string rez = NezavisniKandidati[noviKandidat - 1].prikaziProsleStranke();
            Console.WriteLine(rez);
			return rez;
        }

        

        //FUNKCIONALNOST 3 - Mirza Hadžić
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

		//FUNKCIONALNOST 4 - Bakir Bajrovic
		public string prikaziRezultateRukovodstvaZaStranku(int odabirStranke)
        {
			if (odabirStranke < 1 || odabirStranke > Stranke.Count)
				throw new Exception("Nevalidan odabir.");  
			return Stranke[odabirStranke - 1].prikaziGlasoveKandidataURukovodstvu();
		}

		public void resetujGlasoveZaGlasaca(string id)
        {
			Glasac glasac = dajGlasacaPodIDem(id);
			if(glasac.OdabranaStranka != 0 && glasac.OdabraniKandidati == null)
            {
				Stranke[glasac.OdabranaStranka - 1].OduzmiGlasStranciISvimKandidatima();
			}
			else if(glasac.OdabranaStranka != 0 && glasac.OdabraniKandidati != null)
            {
				oduzmiGlasoveZaKandidateIzStranke(glasac.OdabranaStranka, glasac.OdabraniKandidati);
            }
			else if(glasac.OdabranaStranka == 0 && glasac.OdabraniKandidati != null)
            {
                oduzmiGlasZaNezavisnog(glasac.OdabraniKandidati[0]);
            }


			glasac.resetujGlasove();

		}
	}
}

