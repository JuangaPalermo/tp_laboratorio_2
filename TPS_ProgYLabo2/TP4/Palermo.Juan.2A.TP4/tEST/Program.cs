using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Instanciables;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Teclado teclado = new Teclado(Clases_Abstractas.Periferico.Marca.Gigabyte, 123, "holis");

            Console.WriteLine(teclado.ToString());

            Console.ReadLine();


        }
    }
}
