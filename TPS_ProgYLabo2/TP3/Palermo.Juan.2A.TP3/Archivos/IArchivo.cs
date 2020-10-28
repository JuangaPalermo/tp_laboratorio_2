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
        /// firma de la funcion Guardar
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// firma de la funcion Leer
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">datos a leer</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
