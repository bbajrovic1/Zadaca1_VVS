using System;

public class Stranka
{
	private string Naziv { get; set; }
	private List<Kandidat> Kandidati { get; set; }
	private int BrojGlasova { get; }
	private double procenatGlasova { get; set; }

	public Stranka(string naziv, List<Kandidat> kandidati) 
	{
		Naziv = naziv;
		Kandidati = kandidati;
		BrojGlasova= 0;
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
