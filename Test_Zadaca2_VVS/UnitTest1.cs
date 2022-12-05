using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Xml;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    

    [TestClass]
    public class Funkcionalnost1Test
    {
        //TESTOVE PISALA STEFANI KECMAN

        [TestMethod]
        
        public void TestSveOk()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "999E999", "0902000144036");
            Assert.IsTrue(g1.Glasao == false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPraznoIme()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac(" ", "prezime", "adresa 123", dt1, "999E999", "0902000144036");
            Assert.IsTrue(g1.Glasao == false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPraznoPrezime()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "   ", "adresa 123", dt1, "999E999", "0902000144036");
            Assert.IsTrue(g1.Glasao == false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPogresniKarakteriIme()
        {
            //popraviti regex
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac(".ime12", "prezime", "adresa 123", dt1, "999E999", "0902000144036");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPogresniKarakteriPrezime()
        {
            //popraviti regex
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", ".prezime12", "adresa 123", dt1, "999E999", "0902000144036");

        }



        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestKratkoIme()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("i", "prezime", "adresa 123", dt1, "999E999", "0902000144036");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDugoIme()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("SvelièneinformacijeoglasaèimatrebajubitivalidiraneImeiprezimesmijusadržavatisamoslova", "prezime", "adresa 123", dt1, "999E999", "0902000144036");
        }
        /*
         * OVO TESTIRAM U NASTAVKU KROZ XML DDT, inace prolaze
         * 
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestKratkoPrezime()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "pr", "adresa 123", dt1, "999E999", "0902000144036");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDugoPrezime()
        {
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "SvelièneinformacijeoglasaèimatrebajubitivalidiraneImeiprezimesmijusadržavatisamoslova", "adresa 123", dt1, "999E999", "0902000144036");
        }

        */
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDatumRodjenja()
        {
            DateTime dt1 = new DateTime(2050, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "999E999", "0902000144036");
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLicnaKarta1()
        {
            //pogresno slovo
            DateTime dt1 = new DateTime(2050, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "999A999", "0902000144036");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLicnaKarta2()
        {
            //visak brojeva
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "9999E999", "0902000144036");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLicnaKarta3()
        {
            //manjak brojeva
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "9E999", "0902000144036");
        }

        /*
         * //OVE CU TESTOVE NAPISATI KAO INLINE DDT, inace prolaze
         * 
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj1()
        {
            //pogresan broj dana
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "999E999", "0802000144036");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj2()
        {
            //pogresan broj mjeseca
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "999E999", "0904000144036");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMaticniBroj3()
        {
            //pogresan broj godine
            DateTime dt1 = new DateTime(2000, 02, 09);
            Glasac g1 = new Glasac("ime", "prezime", "adresa 123", dt1, "999E999", "0902010144036");
        }
        */

        //DATA-DRIVEN TESTOVI:

        static IEnumerable<object[]> Glasaci
        {
            get
            {
                return new[]
                {
                    new object[] {"ime", "prezime", "adresa 123", DateTime.Parse("01/01/1996"), "999E999", "0902010144036"},
                    new object[] {"ime", "prezime", "adresa 123", DateTime.Parse("01/01/1996"), "999E999", "0904000144036"},
                    new object[] {"ime", "prezime", "adresa 123", DateTime.Parse("01/01/1996"), "999E999", "0802000144036"}
                 };


            }
        }

        [TestMethod]
        [DynamicData("Glasaci")]
        [ExpectedException(typeof(Exception))]
        public void TestMaticnihInline(string ime, string prezime, string adresa, DateTime datumRodjenja, string licna, string maticni)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, licna, maticni);
        }


        public static IEnumerable<object[]> UèitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0], elements[1], elements[2],DateTime.Parse(elements[3]), elements[4], elements[5] };
            }
        }


        static IEnumerable<object[]> GlasaciXML
        {
            get
            {
                return UèitajPodatkeXML();
            }
        }


        [TestMethod]
        [DynamicData("GlasaciXML")]
        [ExpectedException(typeof(Exception))]
        public void TestKonstruktoraGlasacaXML(string ime, string prezime,string adresa, DateTime datumRodjenja, string licna, string maticni)
        {
            Glasac glasac = new Glasac(ime, prezime, adresa, datumRodjenja, licna, maticni);
        }

    }
}
