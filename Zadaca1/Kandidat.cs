﻿using System;
using System.Collections.Generic;

namespace Zadaca1
{
    public class Kandidat : Glasac //kandidat naslijedjen iz glasaca u svrhu funkcionalnosti 4 - Bakir Bajrovic
    {
        public Stranka Stranka { get; set; }
        public int BrojGlasova { get; set; }
        public double ProcenatGlasova { get; set; }
        public List<Tuple<Stranka, DateTime, DateTime>> ProsleStranke { get; set; }
        public bool Rukovodstvo { get; set; }

        public Kandidat()
        {
            Glasao = false;
        }
        
        //dodana varijabla rukovodstvo za obicnog kandidata i za nezavisnog za kojeg je uvijek false - funkcionalnost 4, Bakir Bajrovic
        public Kandidat(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, Stranka stranka, bool rukovodstvo) : base(ime, prezime, adresa, datumRodjenja, licna, maticni)
        {
            Stranka = stranka;
            ProcenatGlasova = 0;
            BrojGlasova = 0;
            ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>>();
            Rukovodstvo = rukovodstvo;
        }
        public Kandidat(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, Stranka stranka, List<Tuple<Stranka, DateTime, DateTime>> prosleStranke ) : base(ime, prezime, adresa, datumRodjenja, licna, maticni)
        {
            Stranka = stranka;
            ProcenatGlasova = 0;
            BrojGlasova = 0;
            ProsleStranke = prosleStranke;
            Rukovodstvo = false;
        }

        public Kandidat(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni) : base(ime, prezime, adresa, datumRodjenja, licna, maticni)
        {
            ProcenatGlasova = 0;
            BrojGlasova = 0;
            ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>>();
            Rukovodstvo = false;

        }



        public void dodajGlas()
        {
            BrojGlasova++;
        }
        //FUNKCIONALNOST 5 - EMA MEKIC
        public void oduzmiGlas()
        {
            BrojGlasova--;
        }

        public string prikaziKandidata()
        {
            return "Broj osvojenih glasova za kandidata: " + Ime + " " + Prezime + " je: " + BrojGlasova + ", a procenat osvojenih glasova je: " + ProcenatGlasova + "%.";
        }

        
        //FUNKCIONALNOST 2 - Merjem Becirovic

        public string prikaziProsleStranke()
        {
            
            if (ProsleStranke.Count == 0)
                return  "Kandidat nije bio ni u jednoj stranci u proslosti.";
            string rez = "";
            foreach (Tuple<Stranka, DateTime, DateTime> tup in ProsleStranke)
            {
                rez += "Stranka: " + tup.Item1.Naziv + ", Članstvo od: " + tup.Item2.ToString("dd.MM.yyyy") + ", Članstvo do: " + tup.Item3.ToString("dd.MM.yyyy") + "\n";
            }
            return rez;
        }
        

    }
}
