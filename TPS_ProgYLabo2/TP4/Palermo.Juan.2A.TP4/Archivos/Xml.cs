using System;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el archivo que se le pasa por parametro en formato xml
        /// </summary>
        /// <param name="archivo">archivo a guardar</param>
        /// <param name="datos">contenido</param>
        /// <returns>true si se guardo correctamente, de lo contrario, false</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool resultado = true;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(T));

                    xmlser.Serialize(writer, datos);
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Console.WriteLine(ex.Message);
            }

            return resultado;
        }
       
    }
}
