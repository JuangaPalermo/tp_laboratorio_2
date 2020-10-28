using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor de SinProfesorException
        /// </summary>
        public SinProfesorException()
            : base("Ha ocurrido un error con el Profesor")
        {

        }

        /// <summary>
        /// Constructor parametrizado de SinProfesorException
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar por la excepcion que se produjo.</param>
        public SinProfesorException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
