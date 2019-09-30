using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {

            int opcion = 0;

            Console.WriteLine("Elija una acción:");
            Console.WriteLine("1) Crear un archivo");
            Console.WriteLine("2) Leer un archivo");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion==1)
            {
                string modelo = "";
                double costo = 0;

                Console.WriteLine("Ingrese el modelo:");
                modelo = Console.ReadLine();

                Console.WriteLine("Ingrese el costo:");
                costo = Convert.ToInt32(Console.ReadLine());

                CAuto miAuto = new CAuto(modelo, costo);

                //Variables extra
                int numero = 5;
                bool acceso = false;
                byte conteo = 120;

                //Creamos el stream
                FileStream fs = new FileStream("MiArchivo.arc", FileMode.Create, FileAccess.Write, FileShare.None);

                //Creamos el escritor
                BinaryWriter writer = new BinaryWriter(fs);

                writer.Write(miAuto.modelo);
                writer.Write(miAuto.costo);

                writer.Write(numero);
                writer.Write(acceso);
                writer.Write(conteo);

                fs.Close();

                miAuto.muestraInformacion();

            } else if (opcion == 2)
            {
                Stream fs = new FileStream("MiArchivo.arc", FileMode.Open, FileAccess.Read, FileShare.None);

                BinaryReader lector = new BinaryReader(fs);

                string modelo = "";
                double costo = 0;
                int numero = 0;
                bool acceso = true;
                byte conteo = 0;

                modelo = lector.ReadString();
                costo = lector.ReadDouble();
                CAuto miAuto = new CAuto(modelo, costo);
                numero = lector.ReadInt32();
                acceso = lector.ReadBoolean();
                conteo = lector.ReadByte();

                fs.Close();

                miAuto.muestraInformacion();
                Console.WriteLine("Número {0}", numero);
                Console.WriteLine("Acceso {0}", acceso);
                Console.WriteLine("Conteo {0}", conteo);
            }
            Console.ReadKey();

           
        }
    }
}
