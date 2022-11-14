using System;

namespace Zadaca1
{
    public class Kandidat
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public Stranka Stranka { get; set; }
        public int BrojGlasova { get; set; }
        public double ProcenatGlasova { get; set; }

        public Kandidat()
        {
        }


        public Kandidat(string ime, string prezime, string maticni, Stranka stranka) // resolved - Bakir
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = maticni;
            Stranka = stranka;
            ProcenatGlasova = 0;
            BrojGlasova = 0;
        }


        public Kandidat(string ime, string prezime, string maticni)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = maticni;
            BrojGlasova = 0;
        }


        public void dodajGlas()
        {
            BrojGlasova++;

        }

    }
}
