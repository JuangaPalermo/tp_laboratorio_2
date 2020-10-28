using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
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
            catch (Exception e)
            {
                resultado = false;
                throw new ArchivosException(e.InnerException);
            }

            return resultado;
        }

        /// <summary>
        /// Lee el archivo que e le pasa como parametro (en formato xml)
        /// </summary>
        /// <param name="archivo">Archivo a leer</param>
        /// <param name="datos">Contenido</param>
        /// <returns>True si se leyo correctamente, de lo contrario, false.</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool resultado = true;

            try 
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(T));

                    datos = (T)xmlser.Deserialize(reader);
                }
            }
            catch(Exception e)
            {
                resultado = false;
                throw new ArchivosException(e.InnerException);
            }

            return resultado;
            
        }
    }
}
