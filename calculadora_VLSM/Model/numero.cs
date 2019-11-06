using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadora_VLSM.Model
{
    class numero
    {
        private int numeros {get; set;}
        private int enderecoUtil {get; set;}
        private int potencia {get; set;}

        public int Hosts{
            get{
                return numeros;
            }
            set
            {
                numeros = value;
            }
        }
        public int Mais2
        {
            get
            {
                return enderecoUtil;
            }
            set
            {
                enderecoUtil = value;
            }
        }
        public int PotenciaProx
        {
            get
            {
                return potencia;
            }
            set
            {
                potencia = value;
            }
        }
    }
}
