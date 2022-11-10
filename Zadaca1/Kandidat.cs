using System;

public class Kandidat
{
    private string Ime { get; set; }
    private string Prezime { get; set; }
    private string MaticniBroj { get; set; }
    private Stranka Stranka { get; set; }
    private int BrojGlasova { get; }
    private double procenatGlasova { get; set; }
    public Kandidat()
	{
	}
    public Kandidat(string ime, string prezime, string maticni, Stranka stranka)
    {
        Ime = ime;
        Prezime = prezime;
        MaticniBroj = maticni;
        Stranka = stranka;
        BrojGlasova = 0;
        procenatGlasova = 0;

    }
    public Kandidat(string ime, string prezime, string maticni)
    {
        Ime = ime;
        Prezime = prezime;
        MaticniBroj = maticni;
        BrojGlasova = 0;
    }
    public void DodajGlas()
    {
        BrojGlasova++;

    }

}
