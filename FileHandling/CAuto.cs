using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    class CAuto
    {
        public string modelo { get; set; }
        public double costo { get; set; }

        public CAuto (string modelo, double costo)
        {
            this.modelo = modelo;
            this.costo = costo;
        }

        public void muestraInformacion()
        {
            Console.WriteLine("El modelo del auto es {0} y el costo es {1}", modelo, this.costo);
        }
    }
}
