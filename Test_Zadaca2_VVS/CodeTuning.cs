using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Xml;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    [TestClass]
    public class TestProjekat
    {
        [TestMethod]
        public void testTuning()
        {
            int x = 0; 
            Console.WriteLine("x je: " + x);
            for(int i = 0; i < 30000000; i++)
            {
                Glasac g = new Glasac("Dino", "Dinic", "adresa1", new DateTime(1988, 12, 4), "111E222", "0412988000000");

            }
            int z = 0;
            Console.WriteLine("z je: " + z);
            Assert.IsTrue(true);
        }
    }
}
