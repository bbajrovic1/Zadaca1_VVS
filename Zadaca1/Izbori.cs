using System;

public class Izbori
{
	private List<Stranka> Stranke { get; set; }
	private List<Kandidat> NezavisniKandidati { get; set; }
	private List<Glasac> Glasaci { get; set; }
	private int BrojIzlazaka { get; set; }

	public Izbori()
	{
		BrojIzlazaka = 0;
	}
    public Izbori(List<Stranka> stranke, List<Kandidat> kandidati, List<Glas> glasaci)
    {   Stranke = stranke; 
		Kandidati = kandidati;
		Glasaci = glasaci;
    }
	public void Glasaj(int brojStranke)
	{
		Stranke[brojStranke - 1].dodajGlas();


	}
    public void Glasaj(int brojStranke, List<int> odabraniKandidati)
    {  Stranke[brojStranke - 1].dodajGlasSamoStranci();
	
		for(int i in odabraniKandidati)
		{
			Stranke[brojStranke-1].Kandidati[i - 1].dodajGlas();
		}
    }
    public void Glasaj(bool nezavisni, int odabraniNezavisniKandidat)
	{
		NezavisniKandidati[odabraniNezavisniKandidat - 1].dodajGlas();

    }
	public double DajIzlaznost()
	{ 
		foreach(Glasac glasac in Glasaci)
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
			if(stranka.procenatGlasova > 2)
				mandatorne.Add(stranka);
		return mandatorne
    }
	public void izracunajProcenteGlasovaZaKandidate()
	{  for(Stranka stranka in Stranke) {
		for(Kandidat kandidat in stranka.Kandidati)
			{
				kandidat.ProcenatGlasova = kandidat.BrojGlasova/(double)stranka.BrojGlasova;
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



}
