using System;

namespace Zadaca1
{
    public class Kandidat
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string MaticniBroj { get; set; }
        public Stranka Stranka { get; set; }
        public int BrojGlasova { get; set; }
        public double ProcenatGlasova { get; set; }
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
            ProcenatGlasova = 0;

        }
        public Kandidat(string ime, string prezime, string maticni)
        {
            Ime = ime;
            Prezime = prezime;
            MaticniBroj = maticni;
            BrojGlasova = 0;
        }
        public void dodajGlas()
        {
            BrojGlasova++;

        }

    }
}
