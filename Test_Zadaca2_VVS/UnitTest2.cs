using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Zadaca1;


namespace Test_Zadaca2_VVS
{
    [TestClass]
    public class UnitTest2 //testirala Merjem Becirovic
    {
        Izbori izbori;
        Kandidat kandidat1_1;
        Kandidat kandidat1_2;
        Kandidat kandidat2_1;
        Kandidat kandidat2_2;
        Kandidat kandidat3_1;
        Kandidat kandidat3_2;
        Kandidat kandidat4_1;
        Kandidat kandidat4_2;
        static Stranka stranka1;
        static Stranka stranka2;
        static Stranka stranka3;
        static Stranka stranka4;

        [TestInitialize]
        public void setUp()
        {
             stranka1 = new Stranka("SDA");
             stranka2 = new Stranka("SDP");
             stranka3 = new Stranka("NIP");
             stranka4 = new Stranka("DF");

             kandidat1_1 = new Kandidat("Elma", "Elmic", "adresa4", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka1, true);
             kandidat1_2 = new Kandidat("Husein", "Husic", "adresa5", new DateTime(1997, 6, 23), "345K907", "2306997000000", stranka1, false);
             kandidat2_1 = new Kandidat("Bakir", "Semic", "adresa6", new DateTime(1990, 5, 3), "111J967", "0305990000000", stranka2, true);
             kandidat2_2 = new Kandidat("Selma", "Suljic", "adresa7", new DateTime(1991, 1, 3), "111J967", "0301991000000", stranka2, false);
             kandidat3_1 = new Kandidat("Adnan", "Adic", "adresa8", new DateTime(1992, 2, 5), "987K543", "0502992000000", stranka3, true);
             kandidat3_2 = new Kandidat("Toni", "Senic", "adresa9", new DateTime(1993, 3, 6), "111J961", "0603993000000", stranka3, false);
             kandidat4_1 = new Kandidat("Mia", "Santic", "adresa10", new DateTime(1994, 11, 6), "111J962", "0611994000000", stranka4, true);
             kandidat4_2 = new Kandidat("Mijo", "Mijic", "adresa11", new DateTime(1995, 12, 14), "111J963", "1412995000000", stranka4, false);


            stranka1.Kandidati = new List<Kandidat> { kandidat1_1, kandidat1_2 };
            stranka2.Kandidati = new List<Kandidat> { kandidat2_1, kandidat2_2 };
            stranka3.Kandidati = new List<Kandidat> { kandidat3_1, kandidat3_2 };
            stranka4.Kandidati = new List<Kandidat> { kandidat4_1, kandidat4_2 };
            List<Stranka> stranke = new List<Stranka> { stranka1, stranka2, stranka3, stranka4 };
            List<Kandidat> nezavisniKandidati = new List<Kandidat>{
                                                new Kandidat("Samir", "Prusac", "adresa12", new DateTime(1995, 5, 8), "111J967", "0805995000000"),
                                                new Kandidat("Sanela", "Emic", "adresa13", new DateTime(1996, 8, 10), "112K967", "1008996000000"),
                                                new Kandidat("Antonela", "Maric", "adresa14", new DateTime(1997, 9, 9), "114M967", "0909997000000")};

            kandidat1_1.ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>>
            { new Tuple<Stranka, DateTime, DateTime>(stranka3, new DateTime(2000, 3, 1), new DateTime(2004, 4, 2)),
                new Tuple<Stranka, DateTime, DateTime>(stranka2, new DateTime(2005, 3, 1), new DateTime(2007, 4, 2))
            };


           

             izbori = new Izbori(stranke, nezavisniKandidati, null);


        }
        //metoda_scenarij_ocekivaniRezultat
        [TestMethod, ExpectedException(typeof(Exception))]
        public void prikaziProsleStrankeZaKandidata_nevalidanIndeks_bacaIzuzetak()
        {
            izbori.prikaziProsleStrankeZaKandidata(2, -10);

        }

        [TestMethod]
        public void prikaziProsleStrankeZaKandidata_validanIndeks_vracaStrankeNIPiSDP()
        {
            
            string rez = izbori.prikaziProsleStrankeZaKandidata(1, 1);
            Assert.IsTrue(kandidat1_1.ProsleStranke.Count == 2);
            Assert.AreEqual("Stranka: NIP, Članstvo od: 01.03.2000, Članstvo do: 02.04.2004\nStranka: SDP, Članstvo od: 01.03.2005, Članstvo do: 02.04.2007\n", rez);

        }
        [TestMethod, ExpectedException(typeof(Exception))]
        public void prikaziProsleStrankeZaNezavisnogKandidata_nevalidanIndeks_bacaIzuzetak()
        {
            izbori.prikaziProsleStrankeZaNezavisnogKandidata(299);
        }
        [TestMethod]
        public void prikaziProsleStrankeZaNezavisnogKandidata_validanIndeks_vracaDF()
        {
            Kandidat nezavisni = new Kandidat("Esma", "Mijic", "adresa12", new DateTime(1995, 12, 14), "111J964", "1412995000008", null, false);
            nezavisni.ProsleStranke = new List<Tuple<Stranka, DateTime, DateTime>>
                { new Tuple<Stranka, DateTime, DateTime>(stranka4, new DateTime(2010, 3, 1), new DateTime(2012, 4, 2))};
            izbori.NezavisniKandidati = new List<Kandidat> { nezavisni };
            string rez = izbori.prikaziProsleStrankeZaNezavisnogKandidata(1);
            Assert.AreEqual("Stranka: DF, Članstvo od: 01.03.2010, Članstvo do: 02.04.2012\n", rez);

        }
        public void prikaziProsleStrankeZaKandidata_nemaProslih_vracaPorukuDaNemaProslih()
        {
            string rez = izbori.prikaziProsleStrankeZaKandidata(1, 2);
            Assert.IsTrue(kandidat1_1.ProsleStranke.Count == 0);
            Assert.AreEqual("Kandidat nije bio ni u jednoj stranci u proslosti.", rez);

        }

        //DATA-DRIVEN TESTOVI:

        static IEnumerable<object[]> Kandidati
        {
            get
            {
                return new[]
                {
                    new object[] {"ime", "prezime", "adresa 123", DateTime.Parse("01/01/1996"), "999E991", "0101996111111", null, new List<Tuple<Stranka, DateTime, DateTime>>
                                                            { new Tuple<Stranka, DateTime, DateTime>(new Stranka("SDU", null), new DateTime(2000, 3, 1), new DateTime(2004, 4, 2)),
                                                            }
                                 },
                    new object[] {"ime", "prezime", "adresa 123", DateTime.Parse("01/01/1996"), "999E996", "0101996111112", null,  new List<Tuple<Stranka, DateTime, DateTime>>
                                                            { new Tuple<Stranka, DateTime, DateTime>(new Stranka("SDU", null), new DateTime(2000, 3, 1), new DateTime(2004, 4, 2)),
                                                            }
                                },
                    new object[] {"ime", "prezime", "adresa 123", DateTime.Parse("01/01/1996"), "999E993", "0101996111113", null,  new List<Tuple<Stranka, DateTime, DateTime>>
                                                            { new Tuple<Stranka, DateTime, DateTime>(new Stranka("SDU", null), new DateTime(2000, 3, 1), new DateTime(2004, 4, 2)),
                                                            } 
                                  }
                 };


            }
        }

        [TestMethod]
        [DynamicData("Kandidati")]
        public void TestKandidatJednaProslaStrankaInline(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, Stranka stranka, List<Tuple<Stranka, DateTime, DateTime>> prosleStranke)
        {
            Kandidat kandidat = new Kandidat(ime, prezime, adresa, datumRodjenja, licna, maticni, stranka, prosleStranke);
            Assert.IsNotNull(kandidat);
            Assert.AreEqual(1, kandidat.ProsleStranke.Count);
            Assert.AreEqual("SDU", kandidat.ProsleStranke[0].Item1.Naziv);

        }

        
        public static IEnumerable<object[]> UcitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile5.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                string[] prosleString = elements[7].Split('|');
                List<Tuple<Stranka, DateTime, DateTime>> prosleStranke = new List<Tuple<Stranka, DateTime, DateTime>>();
                for(int i = 0; i+2 < prosleString.Length; i += 3)
                {
                    prosleStranke.Add(new Tuple<Stranka, DateTime, DateTime>(new Stranka(prosleString[i], null), DateTime.Parse(prosleString[i + 1]), DateTime.Parse(prosleString[i + 2])));
                }
                
                yield return new object[] { elements[0], elements[1], elements[2], DateTime.Parse(elements[3]), elements[4], elements[5], new Stranka(elements[6], null), prosleStranke };
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
        public void TestProsleStrankeGlasacaXML(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni, Stranka stranka, List<Tuple<Stranka, DateTime, DateTime>> prosleStranke)
        {
            
            Kandidat kandidat = new Kandidat(ime, prezime, adresa, datumRodjenja, licna, maticni, stranka, prosleStranke);
            Assert.IsNotNull(kandidat);
            Assert.AreEqual(2, kandidat.ProsleStranke.Count);
            Assert.AreEqual("SDA", kandidat.Stranka.Naziv);
            Assert.AreEqual("SDP", prosleStranke[0].Item1.Naziv);
            Assert.AreEqual("NIP", prosleStranke[1].Item1.Naziv);
        }
        

    }
}
