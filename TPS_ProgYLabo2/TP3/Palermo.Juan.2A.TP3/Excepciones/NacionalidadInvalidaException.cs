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
        public NacionalidadInvalidaException() : base("Ha ocurrido un error")
        { }

        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        { }

        public NacionalidadInvalidaException(Exception e) : base(e.Message)
        { }

        public NacionalidadInvalidaException(string mensaje, Exception e) : base(mensaje + e.Message)
        { }
    }
}
