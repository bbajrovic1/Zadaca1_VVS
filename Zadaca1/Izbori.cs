using System;

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
		public Izbori(List<Stranka> stranke, List<Kandidat> nezavisniKandidati, List<Glas> glasaci)
		{ Stranke = stranke;
			NezavisniKandidati = nezavisniKandidati;
			Glasaci = glasaci;
			BrojIzlazaka = 0;
		}
		public void glasajZaStranku(int brojStranke)
		{ //ovdje ce biti greska ako brojStranke bude veci od broja stranki ili negativan broj
			Stranke[brojStranke - 1].dodajGlas();


		}
		public void glasajZaKandidateIzStranke(int brojStranke, List<int> odabraniKandidati)
		{  //ovdje ce biti greska ako brojStranke bude veci od broja stranki ili negativan broj
			Stranke[brojStranke - 1].dodajGlasSamoStranci();
	
		for(int i in odabraniKandidati)
			{
				Stranke[brojStranke - 1].Kandidati[i - 1].dodajGlas(); //isto greska ako je niz kandidata s losim brojevima
			}
		}
		public void glasajZaNezavisnog(int odabraniNezavisniKandidat)
		{
			NezavisniKandidati[odabraniNezavisniKandidat - 1].dodajGlas(); //greska ako je los broj

		}
		public double dajIzlaznost()
		{
			foreach (Glasac glasac in Glasaci)
			{
				if (glasac.Glasao == true)
					BrojIzlazaka++;
			}

			return ((double)BrojIzlazaka / Glasaci.Count) * 100;

		}
		public void izracunajProcenteGlasovaZaStranke()
		{
		for(Stranka stranka in Stranke)
			{
				stranka.ProcenatGlasova = (stranka.BrojGlasova / (double)BrojIzlazaka) * 100;
			}
		}
		public List<Stranka> dajStrankeSaMandatom()
		{
			List<Stranka> mandatorne = new List<Stranka>();
		for(Stranka stranka in Stranke)
				if (stranka.procenatGlasova > 2)
					mandatorne.Add(stranka);
			return mandatorne
	
	}
		public void izracunajProcenteGlasovaZaKandidate()
		{  for(Stranka stranka in Stranke) {
		for(Kandidat kandidat in stranka.Kandidati)
				{
					kandidat.ProcenatGlasova = kandidat.BrojGlasova / (double)stranka.BrojGlasova;
				}

			}
		}
		public List<Kandidat> dajKandidateSaMandatom()
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			List<Kandidat> kandidatiSaMandatom = new List<Kandidat>();
			for(Stranka stranka in mandatorne)
			{ for(Kandidat kandidat in stranka.Kandidati) {
					if (kandidat.ProcenatGlasova > 20)
						kandidatiSaMandatom.Add(kandidat);
				}
			}
			return kandidatiSaMandatom;
		}

		public bool identificirajGlasaca(string id)
		{ bool pronadjen = false;
			for(Glasac glasac in Glasaci)
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

		public void prikaziStranke()
		{ int i = 1;
			for(Stranka stranka in Stranke)
			{ Console.WriteLine(i + ". " + stranka.Naziv + "\n");
				i++;
			}
		}

		public void prikaziKandidateIzStranke(int brojStranke)
		{ //ovdje ce biti greska ako brojStranke bude veci od broja stranki ili negativan broj
			Stranka odabrana = Stranke[brojStranke - 1];
			int i = 1;
			for(Kandidat kandidat in odabrana.Kandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n"); //ako se neko isto zove greska jer glasac ne zna kojeg ce
				i++;
			}

		}
		public void prikaziNezavisneKandidate()
		{ int i = 1;
			for(Kandidat kandidat in NezavisniKandidati)
			{
				Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime + "\n"); //ako se neko isto zove greska jer glasac ne zna kojeg ce
				i++;
			}
		}
		public void ispisiMandatorneStranke()
		{
			List<Stranka> mandatorne = dajStrankeSaMandatom();
			for(Stranka stranka in mandatorne)
				Console.WriteLine(stranka.Naziv + " sa " + stranka.BrojGlasova + " glasova.\n");
		}
		public void ispisiKandidateSaMandatima()
		{
			List<Kandidat> mandatorni = dajKandidateSaMandatom();
			for(Kandidat kandidat in mandatorni)
				Console.WriteLine(kandidat.Ime + " " + kandidat.Prezime + " sa " + kandidat.BrojGlasova + " glasova.\n");
		}




	}
}

