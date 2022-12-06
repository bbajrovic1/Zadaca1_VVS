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

        [TestMethod]
        public void TestBezMandatornih()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat3, kandidat4 };


            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            List<Glasac> glasaci = new List<Glasac>{
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333"),
               new Glasac("Dina", "Dinic", "adresa4", new DateTime(1988, 12, 4), "111E333", "0412988000000"),
               new Glasac("Amela", "Anic", "adresa5", new DateTime(1990, 4, 2), "123E444", "0204990111110"),
               new Glasac("Sanina", "Sabic", "adresa6", new DateTime(1979, 2, 8), "333E555", "0802979333330")
           };
            

            Izbori izbori = new Izbori(stranke, null, glasaci);

            List<Kandidat> mandatorni = izbori.dajKandidateSaMandatom();
            Assert.AreEqual(mandatorni.Count, 0);
        }

        [TestMethod]
        public void TestIspisaBrojaMandatornih()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);

            kandidat1.BrojGlasova = 3;
            kandidat2.BrojGlasova = 2;
            kandidat3.BrojGlasova = 0;
            kandidat4.BrojGlasova = 1;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat3, kandidat4 };
            stranka1.BrojGlasova = 6;
            stranka2.BrojGlasova = 1;

            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            List<Glasac> glasaci = new List<Glasac>{
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333"),
               new Glasac("Dina", "Dinic", "adresa4", new DateTime(1988, 12, 4), "111E333", "0412988000000"),
               new Glasac("Amela", "Anic", "adresa5", new DateTime(1990, 4, 2), "123E444", "0204990111110"),
               new Glasac("Sanina", "Sabic", "adresa6", new DateTime(1979, 2, 8), "333E555", "0802979333330")
           };
            glasaci[0].Glasao = true; glasaci[1].Glasao = true; glasaci[2].Glasao = true; glasaci[3].Glasao = true; glasaci[4].Glasao = true; glasaci[5].Glasao = true;

            Izbori izbori = new Izbori(stranke, null, glasaci);

            List<Kandidat> mandatorni = izbori.dajKandidateSaMandatom();
            Assert.AreEqual(mandatorni.Count, 3);
        }

        [TestMethod]
        public void TestRacunanjaProcentaGlasova()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);

            kandidat1.BrojGlasova = 3;
            kandidat2.BrojGlasova = 1;
            kandidat3.BrojGlasova = 0;
            kandidat4.BrojGlasova = 1;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat3, kandidat4 };
            stranka1.BrojGlasova = 4;
            stranka2.BrojGlasova = 1;

            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            List<Glasac> glasaci = new List<Glasac>{
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333"),
               new Glasac("Dina", "Dinic", "adresa4", new DateTime(1988, 12, 4), "111E333", "0412988000000"),
               new Glasac("Amela", "Anic", "adresa5", new DateTime(1990, 4, 2), "123E444", "0204990111110"),
               new Glasac("Sanina", "Sabic", "adresa6", new DateTime(1979, 2, 8), "333E555", "0802979333330")
           };
            glasaci[0].Glasao = true; glasaci[1].Glasao = true; glasaci[2].Glasao = true; glasaci[3].Glasao = true; glasaci[4].Glasao = true;

            Izbori izbori = new Izbori(stranke, null, glasaci);

            izbori.izracunajProcenteGlasovaZaKandidate();
            Assert.AreEqual(kandidat1.ProcenatGlasova, 75);
            Assert.AreEqual(kandidat2.ProcenatGlasova, 25);
            Assert.AreEqual(kandidat3.ProcenatGlasova, 0);
            Assert.AreEqual(kandidat4.ProcenatGlasova, 100);
        }

        [TestMethod]
        public void TestUkupnogBrojaGlasova()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka2, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat3, kandidat4 };

            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            List<Glasac> glasaci = new List<Glasac>{
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333"),
               new Glasac("Dina", "Dinic", "adresa4", new DateTime(1988, 12, 4), "111E333", "0412988000000"),
               new Glasac("Amela", "Anic", "adresa5", new DateTime(1990, 4, 2), "123E444", "0204990111110"),
               new Glasac("Sanina", "Sabic", "adresa6", new DateTime(1979, 2, 8), "333E555", "0802979333330")
           };
            glasaci[0].Glasao = true; glasaci[1].Glasao = true; glasaci[2].Glasao = true; glasaci[3].Glasao = true; glasaci[4].Glasao = true; glasaci[5].Glasao = true;

            glasaci[0].glasajZa(kandidat1);
            glasaci[1].glasajZa(kandidat1);
            glasaci[2].glasajZa(kandidat2);
            glasaci[3].glasajZa(kandidat3);
            glasaci[4].glasajZa(kandidat3);
            glasaci[5].glasajZa(kandidat1);


            Izbori izbori = new Izbori(stranke, null, glasaci);

            Assert.AreEqual(stranka1.BrojGlasova, 4);
            Assert.AreEqual(stranka2.BrojGlasova, 2);
        }


        [TestMethod]
        public void TestProcentaGlasovaZaStranku()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);

            kandidat1.BrojGlasova = 3;
            kandidat2.BrojGlasova = 1;
            kandidat3.BrojGlasova = 0;
            kandidat4.BrojGlasova = 1;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat3, kandidat4 };

            stranka1.BrojGlasova = 4;
            stranka2.BrojGlasova = 1;

            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            List<Glasac> glasaci = new List<Glasac>{
               new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000"),
               new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111"),
               new Glasac("Sabina", "Sabic", "adresa3", new DateTime(1979, 2, 8), "333E222", "0802979333333"),
               new Glasac("Dina", "Dinic", "adresa4", new DateTime(1988, 12, 4), "111E333", "0412988000000"),
               new Glasac("Amela", "Anic", "adresa5", new DateTime(1990, 4, 2), "123E444", "0204990111110"),
               new Glasac("Sanina", "Sabic", "adresa6", new DateTime(1979, 2, 8), "333E555", "0802979333330")
           };
            glasaci[0].Glasao = true; glasaci[1].Glasao = true; glasaci[2].Glasao = true; glasaci[3].Glasao = true; glasaci[4].Glasao = true;

            Izbori izbori = new Izbori(stranke, null, glasaci);
            izbori.izracunajProcenteGlasovaZaStranke();

            Assert.AreEqual(stranka1.ProcenatGlasova, 80);
            Assert.AreEqual(stranka2.ProcenatGlasova, 20);
        }

    }
}
