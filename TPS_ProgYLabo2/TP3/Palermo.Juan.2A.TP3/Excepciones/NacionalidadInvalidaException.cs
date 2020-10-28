using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor de NacionalidadInvalidaException
        /// </summary>
        public NacionalidadInvalidaException() 
            : base("Ha ocurrido un error")
        { }

        /// <summary>
        /// constructor parametrizado de NacionalidadInvalidaException
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar por la excepcion que se produjo</param>
        public NacionalidadInvalidaException(string mensaje) 
            : base(mensaje)
        { }

    }
}
