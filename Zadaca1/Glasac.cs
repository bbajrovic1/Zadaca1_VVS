using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Zadaca1
{
	public class Glasac
	{
      
        public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Adresa { get; set; }
		public DateTime DatumRodjenja { get; set; }
		public string LicnaKarta { get; set; }
		public string JMBG { get; set; }
		public string ID { get; }
		public bool Glasao { get; set; }
		public int OdabranaStranka { get; set; }
		public List<int> OdabraniKandidati { get; set; }

		public Glasac() 
		{

			Glasao = false;
			OdabranaStranka = 0;
			OdabraniKandidati = new List<int>();
		}

		private bool validiraj(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni)
		{
			int brojSlovaIme = ime.ToCharArray().Count(c => Char.IsLetter(c));
			int brojSlovaPrezime = prezime.ToCharArray().Count(c => Char.IsLetter(c));

            if (!Regex.IsMatch(ime, "[a-z|A-Z|-]+") || !Regex.IsMatch(prezime, "[a-z|A-Z|-]+") ||
                brojSlovaIme < 2 || brojSlovaIme > 40 || brojSlovaPrezime < 3 || brojSlovaPrezime > 50)
				return false;
			DateTime datum18 = DateTime.Now.AddYears(-18);
			if (datumRodjenja > DateTime.Now || datumRodjenja > datum18) 
				return false;
			if (licna.Length != 7 || !Regex.IsMatch(licna, "[0-9]{3}E|J|K|M|T[0-9]{3}"))
				return false;
			string dan = datumRodjenja.Day.ToString();
			if (dan.Length == 1) dan = "0" + dan;

			string mjesec = datumRodjenja.Month.ToString();
			if(mjesec.Length == 1) mjesec = "0" + mjesec;

			if (maticni.Length != 13 || maticni.Substring(0, 2) != dan || maticni.Substring(2, 2) != mjesec 
				|| maticni.Substring(4, 3) != datumRodjenja.Year.ToString().Substring(1, 3))
				return false;

			return true;
		}
		public Glasac(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni)
		{
			if (!validiraj(ime, prezime, adresa, datumRodjenja, licna, maticni))
				throw new Exception("Neispravni ulazni podaci");
			Ime = ime;
			Prezime = prezime;
			Adresa = adresa;
			DatumRodjenja = datumRodjenja;
			LicnaKarta = licna;
			JMBG = maticni;
			ID = ime.Substring(0, 2) + prezime.Substring(0, 2) +
				adresa.Substring(0, 2) + licna.Substring(0, 2) + maticni.Substring(0, 2);

			Glasao= false;
			OdabranaStranka = 0;
			OdabraniKandidati = new List<int>();
		}


		public void dodajStranku(int stranka)
        {
			OdabranaStranka = stranka;
        }

		public void dodajKandidate(List<int> kandidati)
        {
			OdabraniKandidati = kandidati;
        }

        public void resetujGlasove()
        {
            OdabranaStranka = 0;
			OdabraniKandidati = null;
			Glasao = false;
        }
    }
}
