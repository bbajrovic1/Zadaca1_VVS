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
		public void glasajZaStranku(int brojStranke)//Merjem
		{ //ovdje ce biti greska ako brojStranke bude veci od broja stranki ili negativan broj
			Stranke[brojStranke - 1].dodajGlas();


		}


		public void glasajZaKandidateIzStranke(int brojStranke, List<int> odabraniKandidati)//Merjem
		{  //ovdje ce biti greska ako brojStranke bude veci od broja stranki ili negativan broj
			Stranke[brojStranke - 1].dodajGlasSamoStranci();
	
			foreach(int i in odabraniKandidati)
			{
				Stranke[brojStranke - 1].Kandidati[i - 1].dodajGlas(); //isto greska ako je niz kandidata s losim brojevima
			}
		}


		public void glasajZaNezavisnog(int odabraniNezavisniKandidat)//Merjem
		{
			NezavisniKandidati[odabraniNezavisniKandidat - 1].dodajGlas(); //greska ako je los broj

		}

		
		public double dajIzlaznost() //lose imenovana motoda: treba izracunajIzlaznost() Bakir
		{
            //BrojIzlazaka = 0; bez ovog je greska jer se svaki put broji ispocetka i dodaje na vec izbrojane
            foreach (Glasac glasac in Glasaci)
			{
				if (glasac.Glasao == true)
					BrojIzlazaka++;
			}

			return ((double)BrojIzlazaka / Glasaci.Count) * 100; //ovdje ce biti neka greska jer prikazuje 133% pri testiranju

        }


        public void izracunajProcenteGlasovaZaStranke() // Ema
        { //izracunajIzlaznost(); ovo treba pozvati! u suprotnom brojIzlazaka je 0!
			//[komentar od Stefani]: Kada sam ja kucala issue za metodu ispod, pisala sam da je greska u racunu jer nemamo izracunajIzlaznost() u tom momentu (gornja zakomentarisana linija)
            foreach (Stranka stranka in Stranke)
			{
				stranka.ProcenatGlasova = (stranka.BrojGlasova / (double)BrojIzlazaka) * 100;
			}
		}


		public List<Stranka> dajStrankeSaMandatom() //Stefani
		{
			izracunajProcenteGlasovaZaStranke();
            List<Stranka> mandatorne = new List<Stranka>();
		foreach(Stranka stranka in Stranke)
				if (stranka.ProcenatGlasova > 2)
					mandatorne.Add(stranka);
			return mandatorne;
	
		}


		public void izracunajProcenteGlasovaZaKandidate() //Mirza
		{  foreach(Stranka stranka in Stranke)
			{
				foreach(Kandidat kandidat in stranka.Kandidati)
				{
					kandidat.ProcenatGlasova = kandidat.BrojGlasova / (double)stranka.BrojGlasova; //ovdje kao zaboravili cast u double
				}

			}
		}


		public List<Kandidat> dajKandidateSaMandatom() //Bakir
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			izracunajProcenteGlasovaZaKandidate();
            List<Kandidat> kandidatiSaMandatom = new List<Kandidat>();
			foreach(Stranka stranka in mandatorne)
			{ foreach(Kandidat kandidat in stranka.Kandidati) {
					if (kandidat.ProcenatGlasova > 20)
						kandidatiSaMandatom.Add(kandidat);
				}
			}
			return kandidatiSaMandatom;
		}

		public bool identificirajGlasaca(string id) //Ema
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

		public void prikaziStranke() //Stefani
		{ int i = 1;
			foreach(Stranka stranka in Stranke)
			{ Console.WriteLine(i + ". " + stranka.Naziv + "\n");
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
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n"); //ako se neko isto zove greska jer glasac ne zna kojeg ce
				i++;
			}
		}


		public void ispisiMandatorneStranke() //Bakir
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			foreach(Stranka stranka in mandatorne)
				Console.WriteLine(stranka.Naziv + " sa " + stranka.BrojGlasova + " glasova.\n");
		}


		public void ispisiKandidateSaMandatima() //Ema
		{
			List<Kandidat> mandatorni = dajKandidateSaMandatom();
			foreach(Kandidat kandidat in mandatorni)
				Console.WriteLine(kandidat.Ime + " " + kandidat.Prezime + " sa " + kandidat.BrojGlasova + " glasova.\n");
		}




	}
}

