using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor sin parametros de AlumnoRepetidoException
        /// </summary>
        public AlumnoRepetidoException()
            : base("Ha ocurrido un error con el Alumno.")
        {

        }

        /// <summary>
        /// Constructor parametrizado de AlumnoRepetidoException, recibe el mensaje a imprimir
        /// </summary>
        /// <param name="mensaje">mensaje a imprimir de la excepcion</param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {

        }

    }
}
