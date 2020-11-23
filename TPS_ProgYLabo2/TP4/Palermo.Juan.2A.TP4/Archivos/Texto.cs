using System;
using System.IO;
using System.Text;
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
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return resultado;
        }

    }
}
