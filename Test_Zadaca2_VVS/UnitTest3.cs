using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Xml;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    [TestClass]
    public class UnitTest3
    {
        static Izbori izbori;
        static Kandidat kandidat1_1;
        static Kandidat kandidat1_2;
        static Kandidat kandidat2_1;
        static Kandidat kandidat2_2;
        static Kandidat kandidat3_1;
        static Kandidat kandidat3_2;
        static Stranka stranka1;
        static Stranka stranka2;
        static Stranka stranka3;

        [TestInitialize]
        public void Initialize()
        {
            stranka1 = new Stranka("SDA");
            stranka2 = new Stranka("SDP");
            stranka3 = new Stranka("NIP");

            kandidat1_1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            kandidat1_2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            kandidat2_1 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka2, true);
            kandidat2_2 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);
            kandidat3_1 = new Kandidat("Adnan", "Adic", "adresa8", new DateTime(1992, 2, 5), "987K543", "0502992000000", stranka3, true);
            kandidat3_2 = new Kandidat("Toni", "Senic", "adresa9", new DateTime(1993, 3, 6), "111J961", "0603993000000", stranka3, false);


            stranka1.Kandidati = new List<Kandidat> { kandidat1_1, kandidat1_2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat2_1, kandidat2_2 };
            stranka3.Kandidati = new List<Kandidat> { kandidat3_1, kandidat3_2 };
            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2, stranka3};
            List<Kandidat> nezavisniKandidati = new List<Kandidat>{
                                                new Kandidat("Samir", "Prusac", "adresa12", new DateTime(1995, 5, 8), "111J967", "0805995000000"),
                                                new Kandidat("Sanela", "Emic", "adresa13", new DateTime(1996, 8, 10), "112K967", "1008996000000"),
                                                new Kandidat("Antonela", "Maric", "adresa14", new DateTime(1997, 9, 9), "114M967", "0909997000000")};

            List<Glasac> glasaci = new List<Glasac>{
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333")
           };

            izbori = new Izbori(stranke, nezavisniKandidati, glasaci);
        }

        [TestMethod]
        public void TestBezMandatornih()
        {
            List<Kandidat> mandatorni = izbori.dajKandidateSaMandatom();
            Assert.AreEqual(mandatorni.Count, 0);
        }

        [TestMethod]
        public void TestIspisaBrojaMandatornih()
        {
            kandidat1_1.BrojGlasova = 10;
            kandidat1_2.BrojGlasova = 20;
            kandidat2_1.BrojGlasova = 5;

            stranka1.BrojGlasova = 30;
            stranka2.BrojGlasova = 5;

            List<Kandidat> mandatorni = izbori.dajKandidateSaMandatom();
            Assert.AreEqual(mandatorni.Count, 3);
        }

        [TestMethod]
        public void TestRacunanjaProcentaGlasova()
        {
            kandidat1_1.BrojGlasova = 5;
            kandidat1_2.BrojGlasova = 5;
            kandidat2_1.BrojGlasova = 10;

            stranka1.BrojGlasova = 10;
            stranka2.BrojGlasova = 10;

            izbori.izracunajProcenteGlasovaZaKandidate();
            Assert.AreEqual(kandidat1_1.ProcenatGlasova, 50);
            Assert.AreEqual(kandidat1_2.ProcenatGlasova, 50);
            Assert.AreEqual(kandidat2_1.ProcenatGlasova, 100);
        }

        [TestMethod]
        public void TestUkupnogBrojaGlasova()
        {
            kandidat1_1.BrojGlasova = 100;
            kandidat1_2.BrojGlasova = 250;
            kandidat2_1.BrojGlasova = 330;
            kandidat2_2.BrojGlasova = 450;

            Assert.AreEqual(stranka1.BrojGlasova, 350);
            Assert.AreEqual(stranka2.BrojGlasova, 780);
        }


        [TestMethod]
        public void TestProcentaGlasovaZaStranku()
        {
            izbori.BrojIzlazaka = 1000;
            stranka1.BrojGlasova = 200;
            stranka2.BrojGlasova = 500;

            izbori.izracunajProcenteGlasovaZaStranke();

            Assert.AreEqual(stranka1.ProcenatGlasova, 20);
            Assert.AreEqual(stranka2.ProcenatGlasova, 50);
        }

    }
}
