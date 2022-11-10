using System;

public class Glasac
{
	private string Ime { get; set; }
	private string Prezime { get; set; }
	private string Adresa { get; set; }
	private DateTime DatumRodjenja { get; set; }
	private string LicnaKarta { get; set; }
	private string MaticniBroj { get; set; }
	private string ID { get; }
	private bool Glasao { get; set; }

	public Glasac()
	{
		Glasao = false;
		
	}
	public Glasac(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni)
	{
		Ime = ime;
		Prezime = prezime;
		Adresa = adresa;
		DatumRodjenja = datumRodjenja;
		LicnaKarta = licna;
		MaticniBroj = maticni;
        Glasao = false;
		ID = ime.Substring(0,2)+ prezime.Substring(0, 2)+
			adresa.Substring(0, 2)+licna.Substring(0, 2) +maticni.Substring(0, 2);

    }

	

}
