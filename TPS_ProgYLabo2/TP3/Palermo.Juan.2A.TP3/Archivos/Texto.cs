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

        public bool Guardar(string archivo, string dato)
        {
            bool resultado = true;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false))
                {
                    sw.WriteLine(dato);
                }
            }
            catch (Exception e)
            {
                resultado = false;
                throw new ArchivosException(e);
            }

            return resultado;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool resultado = true;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                resultado = false;
                throw new ArchivosException(e);
            }

            return resultado;
        }

    }
}
