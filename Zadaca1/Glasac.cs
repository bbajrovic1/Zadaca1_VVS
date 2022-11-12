using System;

namespace Zadaca1
{
	public class Glasac
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Adresa { get; set; }
		public DateTime DatumRodjenja { get; set; }
		public string LicnaKarta { get; set; }
		public string MaticniBroj { get; set; }
		public string ID { get; }
		public bool Glasao { get; set; }

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
			ID = ime.Substring(0, 2) + prezime.Substring(0, 2) +
				adresa.Substring(0, 2) + licna.Substring(0, 2) + maticni.Substring(0, 2);

		}



	}
}
