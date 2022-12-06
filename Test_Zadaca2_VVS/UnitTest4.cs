using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Xml;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    [TestClass]
    public class Funkcionalnost4Test //testirao Bakir Bajrovic
    {
        [TestMethod]
        public void TestImaLiKandidatID()
        {
            Stranka stranka1 = new Stranka("SDA");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Assert.AreEqual("ElElad1103", kandidat1.ID);
        }

        [TestMethod]
        public void TestRukovodstoFalseZaNezavisnog()
        {
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000");
            Assert.IsFalse(kandidat1.Rukovodstvo);
        }

        [TestMethod]
        public void TestprikaziGlasoveKandidataURukovodstvu()
        {
            Stranka stranka1 = new Stranka("SDA");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka1, false);
            kandidat1.BrojGlasova = 5;
            kandidat2.BrojGlasova = 3;
            kandidat3.BrojGlasova = 4;
            kandidat4.BrojGlasova = 5;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2, kandidat3, kandidat4 };

            Assert.AreEqual("Ukupan broj glasova: 9\nKandidati:\nID: ElElad1103\nID: BaSead1103\n", stranka1.prikaziGlasoveKandidataURukovodstvu());
        }

        [TestMethod]
        public void TestprikaziRezultateRukovodstvaZaStranku()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka1, false);
            Kandidat kandidat5 = new Kandidat("Adnan", "Adic", "adresa8", new DateTime(1992, 2, 5), "987K543", "0502992000000", stranka2, true);
            Kandidat kandidat6 = new Kandidat("Toni", "Senic", "adresa9", new DateTime(1993, 3, 6), "111J961", "0603993000000", stranka2, false);
            kandidat1.BrojGlasova = 5;
            kandidat2.BrojGlasova = 3;
            kandidat3.BrojGlasova = 4;
            kandidat4.BrojGlasova = 5;
            kandidat5.BrojGlasova = 2;
            kandidat6.BrojGlasova = 4;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2, kandidat3, kandidat4 };
            stranka2.Kandidati = new List<Kandidat> { kandidat5, kandidat6 };

            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            Izbori izbori = new Izbori(stranke, null, null);

            
            Assert.AreEqual("Ukupan broj glasova: 9\nKandidati:\nID: ElElad1103\nID: BaSead1103\n", izbori.prikaziRezultateRukovodstvaZaStranku(1));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]

        public void TestprikaziRezultateRukovodstvaZaStrankuIzuzetak()
        {
            Stranka stranka1 = new Stranka("SDA");
            Stranka stranka2 = new Stranka("SDP");
            Kandidat kandidat1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka1, false);
            Kandidat kandidat5 = new Kandidat("Adnan", "Adic", "adresa8", new DateTime(1992, 2, 5), "987K543", "0502992000000", stranka2, true);
            Kandidat kandidat6 = new Kandidat("Toni", "Senic", "adresa9", new DateTime(1993, 3, 6), "111J961", "0603993000000", stranka2, false);
            kandidat1.BrojGlasova = 5;
            kandidat2.BrojGlasova = 3;
            kandidat3.BrojGlasova = 4;
            kandidat4.BrojGlasova = 5;
            kandidat5.BrojGlasova = 2;
            kandidat6.BrojGlasova = 4;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2, kandidat3, kandidat4 };
            stranka2.Kandidati = new List<Kandidat> { kandidat5, kandidat6 };

            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2 };

            Izbori izbori = new Izbori(stranke, null, null);

            izbori.prikaziRezultateRukovodstvaZaStranku(-3);
        }



            //Data driven testovi

            static IEnumerable<object[]> Glasaci
        {
            get
            {
                return new[]
                {
                    new object[] {"Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000" },
                    new object[] {"Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000" }
                 };


            }
        }

        [TestMethod]
        [DynamicData("Glasaci")]
        public void TestprikaziRezultateRukovodstvaZaStrankuInline(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni)
        {
            Kandidat kandidat = new Kandidat();
            Assert.IsFalse(kandidat.Rukovodstvo);
        }




        //eksterni podaci
        public static IEnumerable<object[]> UcitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile3.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }

                yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5], elements[6], elements[7] };
            }
        }


        static IEnumerable<object[]> KandidatiXML
        {
            get
            {
                return UcitajPodatkeXML();
            }
        }



        [TestMethod]
        [DynamicData("KandidatiXML")]
        public void TestprikaziGlasoveKandidataURukovodstvu(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, string stranka, string rukovodstvo)
        {
            Stranka stranka1 = new Stranka(stranka);
            bool uRukovodstvu;
            if (rukovodstvo == "1") uRukovodstvu = true;
            else uRukovodstvu=false;
            Kandidat kandidat1 = new Kandidat(ime, prezime, adresa, datumRodjenja, licna, maticni, stranka1, uRukovodstvu);
            Kandidat kandidat2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
            Kandidat kandidat3 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
            Kandidat kandidat4 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka1, false);
            kandidat1.BrojGlasova = 5;
            kandidat2.BrojGlasova = 3;
            kandidat3.BrojGlasova = 4;
            kandidat4.BrojGlasova = 5;

            stranka1.Kandidati = new List<Kandidat> { kandidat1, kandidat2, kandidat3, kandidat4 };

            Assert.AreEqual("Ukupan broj glasova: 9\nKandidati:\nID: ElElad1103\nID: BaSead1103\n", stranka1.prikaziGlasoveKandidataURukovodstvu());
        }

    }


}
