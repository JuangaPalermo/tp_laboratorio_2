using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Guarda el archivo que se le pasa como parametro en formato de texto
        /// </summary>
        /// <param name="archivo">archivo a guardar</param>
        /// <param name="dato">contenido</param>
        /// <returns>true si se guarda correctamente, de lo contrario, false</returns>
        public bool Guardar(string archivo, string dato)
        {
            bool resultado = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.WriteLine(dato);
                }
                resultado = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException);
            }

            return resultado;
        }

        /// <summary>
        /// Lee el archivo que se le pasa (en formato de texto)
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="datos">datos leidos del archivo</param>
        /// <returns>true si se leyo correctamente, de lo contrario, false.</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool resultado = true;

            try
            {
                using (StreamReader sr = new StreamReader(archivo, Encoding.UTF8))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                resultado = false;
                throw new ArchivosException(e.InnerException);
            }

            return resultado;
        }

    }
}
