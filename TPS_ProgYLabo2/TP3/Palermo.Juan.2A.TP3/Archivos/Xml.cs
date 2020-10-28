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
                throw new ArchivosException(e);
            }

            return resultado;
        }

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
                throw new ArchivosException(e);
            }

            return resultado;
            
        }
    }
}
