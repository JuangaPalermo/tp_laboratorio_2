using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor de DniInvalidoException
        /// </summary>
        public DniInvalidoException() : base("Ha ocurrido un error")
        { }

        /// <summary>
        /// Constructor parametrizado de DniInvalidoException, recibe string
        /// </summary>
        /// <param name="mensaje"> mensaje a mostrar de la excepcion </param>
        public DniInvalidoException(string mensaje) : base(mensaje)
        { }

        /// <summary>
        /// constructor parametrizado de DniInvalidoException, recibe Exception
        /// </summary>
        /// <param name="e"> excepcion a mostrar que se produjo </param>
        public DniInvalidoException(Exception e) : base(e.Message)
        { }

        /// <summary>
        /// constructor parametrizado de DniInvalidoException, recibe mensaje a mostrar y Exception generada
        /// </summary>
        /// <param name="mensaje">string a mostrar</param>
        /// <param name="e">Exception a mostrar que se produjo</param>
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje + e.Message)
        { }

    }
}
