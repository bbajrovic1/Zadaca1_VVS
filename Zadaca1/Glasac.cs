using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Zadaca1
{
	public class Glasac : IProvjera
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
		public bool VjerodostojnostGlasaca(IProvjera sigurnosnaProvjera)
		{
			if (sigurnosnaProvjera.DaLiJeVecGlasao(ID))
				throw new Exception("Glasač je već izvršio glasanje!");
			return true;
		}

		public bool validirajString(string s)
        {
			for (int i = 0; i < s.Length; i++)
			{
				if (!((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z') || s[i] == '-')) return false;
			}
			return true;
        }

		public bool validirajLicnu(string licna)
        {
			for (int i = 0; i < 3; i++)
			{
				if (!(licna[i] >= '0' && licna[i] <= '9')) return false;
			}
			if (licna[3] != 'E' && licna[3] != 'J' && licna[3] != 'K' && licna[3] != 'M' && licna[3] != 'T') return false;

			for (int i = 4; i < 7; i++)
			{
				if (!(licna[i] >= '0' && licna[i] <= '9')) return false;
			}
			return true;
		}


        private bool validiraj(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni)
		{
			//FUNKCIONALNOST PISALA STEFANI KECMAN
			int brojSlovaIme = ime.ToCharArray().Count(c => Char.IsLetter(c));
			int brojSlovaPrezime = prezime.ToCharArray().Count(c => Char.IsLetter(c));

			
            if (brojSlovaIme < 2 || brojSlovaIme > 40 || brojSlovaPrezime < 3 || brojSlovaPrezime > 50)
				return false;
			//proci petljom i provjeriti karaktere za ime i prezime

			if (!validirajString(ime))
				return false;

			if (!validirajString(prezime))
				return false;


            DateTime datum18 = DateTime.Now.AddYears(-18);
			if (datumRodjenja > DateTime.Now || datumRodjenja > datum18) 
				return false;
			
			if (licna.Length!=7)
				return false;

			//proci petljom i provjeriti karaktere licne

			if(!validirajLicnu(licna))
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

		//FUNKCIONALNOST 5 -EMA MEKIC
        public void resetujGlasove()
        {
            OdabranaStranka = 0;
			OdabraniKandidati = null;
			Glasao = false;
        }

		public void glasajZa(Kandidat kandidat)
		{
			kandidat.dodajGlas();
			kandidat.Stranka.BrojGlasova++;
		}

		bool IProvjera.DaLiJeVecGlasao(string IDBroj)
		{
			return String.Equals(ID, IDBroj) && Glasao == true;

        }
	}
}
