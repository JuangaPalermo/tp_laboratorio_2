using System;
using Archivos;
using Bases_de_Datos;
using Clases_Instanciables;
using Extension;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se prueba la creacion de un teclado
            Teclado teclado = new Teclado(Periferico.Marca.Gigabyte, 123, "Prueba Teclado");
            try
            {
                Console.WriteLine(teclado.ToString());

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Se prueba la creacion de un mouse
            Mouse mouse = new Mouse(Periferico.Marca.Gigabyte, 456, "Prueba Mouse");
            try
            {
                Console.WriteLine(mouse.ToString());

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Se crea una compra y se le agregan el mouse y el teclado
            Compra<Periferico> c_perif = new Compra<Periferico>();
            try
            {
                c_perif.Agregar(teclado);
                c_perif.Agregar(mouse);

                Console.WriteLine("Se agregaron los perifericos a la compra");

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Se imprime la informacion de la compra
            try
            {
                Console.WriteLine(c_perif.MostrarCompra(c_perif));

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Se guarda el archivo de tecto con la informacion de la compra
            try
            {

                Texto aux = new Texto();
                aux.Guardar("TicketTest.txt", c_perif.MostrarCompra(c_perif));
                Console.WriteLine("Se guardo el archivo de texto");

                Console.ReadLine();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Se obtiene la info del teclado a traves del metodo de extension
            try
            {
                Console.WriteLine(teclado.ObtenerInfoExtendida());

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Se traen los datos de la BBDD y se almacenan en una lista de perifericos
            c_perif.Elementos = ConexionBD<Periferico>.GetProductos();
            try
            {
                Console.WriteLine(c_perif.MostrarCompra(c_perif));

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
