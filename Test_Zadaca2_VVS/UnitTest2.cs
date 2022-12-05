using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Xml;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    [TestClass]
    public class Funkcionalnost5Test
    {



        [TestMethod]
        public void TestDodavanjaStrankeGlasacu()
        {
            Glasac glasac = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");
            glasac.dodajStranku(1);
            Assert.AreEqual(glasac.OdabranaStranka, 1);
        }

        [TestMethod]
        public void TestDodavanjaKandidataGlasacu()
        {
            Glasac glasac = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");
            glasac.dodajKandidate(new List<int>() { 1, 2, 3 });
            Assert.AreEqual(glasac.OdabraniKandidati[0], 1);
            Assert.AreEqual(glasac.OdabraniKandidati[1], 2);
            Assert.AreEqual(glasac.OdabraniKandidati[2], 3);
            Assert.AreEqual(glasac.OdabraniKandidati.Count, 3);
        }

        [TestMethod]
        public void TestResetovanjaGlasovaGlasacu()
        {
            Glasac glasac = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");
            glasac.OdabranaStranka = 1;
            glasac.OdabraniKandidati = new List<int>() { 1, 2, 3 };
            glasac.Glasao = true;
            glasac.resetujGlasove();
            Assert.AreEqual(glasac.OdabranaStranka, 0);
            Assert.IsNull(glasac.OdabraniKandidati);
            Assert.IsFalse(glasac.Glasao);
        }

        [TestMethod]
        public void TestOduzimanjaGlasaKandidatu()
        {
            Stranka stranka1 = new Stranka("SDA");
            Kandidat kandidat = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            kandidat.BrojGlasova = 5;
            kandidat.oduzmiGlas();
            Assert.AreEqual(kandidat.BrojGlasova, 4);
        }



        [TestMethod]
        public void TestOduzmanjeGlasovaStranciISvimKandidatima()
        {
            Stranka stranka1 = new Stranka("SDA");
            Kandidat kandidat = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            stranka1.Kandidati = new List<Kandidat>() { kandidat, kandidat2 };
            kandidat.BrojGlasova = 2;
            kandidat2.BrojGlasova = 3;

            stranka1.BrojGlasova = 5;
            stranka1.OduzmiGlasStranciISvimKandidatima();

            Assert.AreEqual(stranka1.BrojGlasova, 4);
            Assert.AreEqual(kandidat.BrojGlasova, 1);
            Assert.AreEqual(kandidat2.BrojGlasova, 2);
        }

        [TestMethod]
        public void TestOduzmanjeGlasovaSamoStranci()
        {
            Stranka stranka1 = new Stranka("SDA");
            Kandidat kandidat = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            stranka1.Kandidati = new List<Kandidat>() { kandidat, kandidat2 };
            kandidat.BrojGlasova = 3;
            kandidat2.BrojGlasova = 3;

            stranka1.BrojGlasova = 5;
            stranka1.oduzmiGlasSamoStranci();

            Assert.AreEqual(stranka1.BrojGlasova, 4);
            Assert.AreEqual(kandidat.BrojGlasova, 3);
            Assert.AreEqual(kandidat2.BrojGlasova, 3);
        }

        [TestMethod]
        public void TestOduzmiGlasoveZaKandidateIzStranke()
        {
            Izbori izbori = new Izbori();
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("NIP");

            Kandidat kandidat = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            stranka1.Kandidati = new List<Kandidat>() { kandidat, kandidat2 };
            izbori.Stranke = new List<Stranka> { stranka1, stranka2 };

            kandidat.BrojGlasova = 3;
            kandidat2.BrojGlasova = 3;
            stranka1.BrojGlasova = 5;
            izbori.oduzmiGlasoveZaKandidateIzStranke(1,new List<int>() { 1});

            Assert.AreEqual(stranka1.BrojGlasova, 4);
            Assert.AreEqual(kandidat.BrojGlasova, 2);
            Assert.AreEqual(kandidat2.BrojGlasova, 3);
        }

        [TestMethod]
        public void TestOduzmiGlasZaNezavisnog()
        {
            Izbori izbori = new Izbori();

            Kandidat kandidat = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000");
            Kandidat kandidat2 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000");
            izbori.NezavisniKandidati = new List<Kandidat> { kandidat, kandidat2 };

            kandidat.BrojGlasova = 3;
            kandidat2.BrojGlasova = 3;

            izbori.oduzmiGlasZaNezavisnog(1);
            Assert.AreEqual(kandidat.BrojGlasova, 2);
            Assert.AreEqual(kandidat2.BrojGlasova, 3);

            izbori.oduzmiGlasZaNezavisnog(2);
            Assert.AreEqual(kandidat.BrojGlasova, 2);
            Assert.AreEqual(kandidat2.BrojGlasova, 2);
        }

        [TestMethod]
        public void TestDajGlasacaPodIDem()
        {
            Izbori izbori = new Izbori();
            Glasac glasac = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");
            Glasac glasac2 = new Glasac("Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111");
            izbori.Glasaci = new List<Glasac>() { glasac, glasac2 };
            Glasac odabrani = izbori.dajGlasacaPodIDem("DiDiad1104");
            Assert.AreEqual(odabrani.Ime, "Dino");
            Assert.AreEqual(odabrani.JMBG, "0412988000000");

            Glasac odabraniNull = izbori.dajGlasacaPodIDem("AnAn");
            Assert.IsNull(odabraniNull);

        }

        [TestMethod]
        public void TestResetujGlasoveZaGlasaca()
        {
            Izbori izbori = new Izbori();
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("NIP");

            Kandidat kandidat = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            stranka1.Kandidati = new List<Kandidat>() { kandidat, kandidat2 };
            izbori.Stranke = new List<Stranka> { stranka1, stranka2 };

            Glasac glasac = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");
            izbori.Glasaci = new List<Glasac>() { glasac };

            List<Kandidat> nezavisniKandidati = new List<Kandidat>{
                                                new Kandidat("Samir", "Prusac", "adresa12", new DateTime(1995, 5, 8), "111J967", "0805995000000"),
                                                new Kandidat("Sanela", "Emic", "adresa13", new DateTime(1996, 8, 10), "112K967", "1008996000000")};
            izbori.NezavisniKandidati = nezavisniKandidati;

            glasac.OdabranaStranka = 2;
            glasac.OdabraniKandidati = null;
            stranka2.BrojGlasova = 6;
            izbori.resetujGlasoveZaGlasaca("DiDiad1104");
            Assert.AreEqual(stranka2.BrojGlasova, 5);
            Assert.IsNull(glasac.OdabraniKandidati);

            glasac.OdabranaStranka = 1;
            glasac.OdabraniKandidati = new List<int>() { 1 };
            stranka1.BrojGlasova = 4;
            kandidat.BrojGlasova = 3;
            izbori.resetujGlasoveZaGlasaca("DiDiad1104");
            Assert.AreEqual(stranka1.BrojGlasova, 3);
            Assert.AreEqual(kandidat.BrojGlasova, 2);
            Assert.IsFalse(glasac.Glasao);

            glasac.OdabranaStranka = 0;
            glasac.OdabraniKandidati = new List<int>() { 1, 2 };
            izbori.glasajZaNezavisnog("DiDiad1104", 1);
            Assert.AreEqual(izbori.NezavisniKandidati[0].BrojGlasova, 1);

            izbori.resetujGlasoveZaGlasaca("DiDiad1104");
            Assert.AreEqual(izbori.NezavisniKandidati[0].BrojGlasova, 0);
            Assert.IsFalse(glasac.Glasao);
        }

        //Data driven testovi

        static IEnumerable<object[]> Glasaci
        {
            get
            {
                return new[]
                {
                    new object[] {"Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000", 2, new List<int> (){ 1, 2 } },
                    new object[] {"Anela", "Anic", "adresa2", new DateTime(1990, 4, 2), "123E222", "0204990111111", 3, new List<int>() { 1, 2, 3, 4 } }
                 };


            }
        }

        [TestMethod]
        [DynamicData("Glasaci")]
        public void TestResetovanjaGlasovaGlasacuInline(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, int odabranaStranka, List<int> odabraniKandidati)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, licna, maticni);
            glasac.OdabranaStranka = odabranaStranka;
            glasac.OdabraniKandidati = odabraniKandidati;
            glasac.Glasao = true;
            glasac.resetujGlasove();
            Assert.AreEqual(glasac.OdabranaStranka, 0);
            Assert.IsNull(glasac.OdabraniKandidati);
            Assert.IsFalse(glasac.Glasao);
        }


        /*
        //eksterni podaci
        public static IEnumerable<object[]> UcitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile2.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }

                yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5], elements[6],  };
            }
        }


        static IEnumerable<object[]> GlasaciXML
        {
            get
            {
                return UcitajPodatkeXML();
            }
        }


        [TestMethod]
        [DynamicData("GlasaciXML")]
        [ExpectedException(typeof(Exception))]
        public void TestKonstruktoraGlasacaXML(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, int odabranaStranka, List<int> odabraniKandidati)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, licna, maticni);
            glasac.OdabranaStranka = odabranaStranka;
            glasac.OdabraniKandidati = odabraniKandidati;
            glasac.Glasao = true;
            glasac.resetujGlasove();
            Assert.AreEqual(glasac.OdabranaStranka, 0);
            Assert.IsNull(glasac.OdabraniKandidati);
            Assert.IsFalse(glasac.Glasao);
        }
        */
    }
        
}
