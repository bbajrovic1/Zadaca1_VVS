using System;
using System.Collections.Generic;

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
        public List<Tuple<Stranka, DateTime, DateTime>> ProsleStranke { get; set; }


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
            ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>>();
        }


        public Kandidat(string ime, string prezime, string maticni)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = maticni;
            BrojGlasova = 0;
            ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>>();
        }


        public void dodajGlas()
        {
            BrojGlasova++;


        }

        public void prikaziProsleStranke()
        {
            //„Stranka: X, Članstvo od: Y, Članstvo do: Z“.
            if (ProsleStranke.Count == 0)
                Console.WriteLine("Kandidat nije bio ni u jednoj stranci u proslosti.");

            foreach(Tuple<Stranka, DateTime, DateTime> tup in ProsleStranke)
            {
                Console.WriteLine("Stranka: " + tup.Item1.Naziv + ", Članstvo od: " + tup.Item2.ToString("dd.MM.yyyy") + ", Članstvo do: " + tup.Item3.ToString("dd.MM.yyyy") + "\n");
            }
        }

    }
}
