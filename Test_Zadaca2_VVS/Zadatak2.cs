using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    [TestClass]
    public class Zadatak2
    {
        [TestMethod, ExpectedException(typeof (Exception))]
        public void TestZamjenskiObjekat()
        {
            Glasac glasac = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");
            Spy spy = new Spy();

            spy.Opcija = 1; 
            bool rez = glasac.VjerodostojnostGlasaca(spy);
            Assert.IsTrue(rez);

            spy.Opcija = 2;
            rez = glasac.VjerodostojnostGlasaca(spy);
            Assert.IsTrue(rez);

            spy.Opcija = 3;
            rez = glasac.VjerodostojnostGlasaca(spy);
            Assert.IsTrue(rez);

            spy.Opcija = 4;
            rez = glasac.VjerodostojnostGlasaca(spy);
            //exception
            
        }
    }
}
