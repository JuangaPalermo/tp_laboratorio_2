
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {

        /// <summary>
        /// Firma del metodo para guardar archivos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

    }
}
