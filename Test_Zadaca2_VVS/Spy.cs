using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca1;

namespace Test_Zadaca2_VVS
{
    public class Spy : IProvjera
    {
        public int Opcija { get; set; }
        bool IProvjera.DaLiJeVecGlasao(string IDBroj)
        {
            //(id, glasao)
            if (Opcija == 1 || Opcija == 2 || Opcija == 3)
                return false;
            return true;

        }
        //glasac je vjerodostojan samo ako jos nije glasao
        /*
          opcija 1: ID je ispravan, nije glasao
          opcija 2: ID je neispravan, nije glasao
          opcija 3: ID neispravan, ali je glasao
          opcija 4: ID ispravan, glasao je
        */

    }
}
