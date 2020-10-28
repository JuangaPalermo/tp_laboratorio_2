using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor de ArchivosException
        /// </summary>
        public ArchivosException()
            :base()
        {

        }
        
        /// <summary>
        /// Constructor parametrizado de ArchivosException, recibe innerException
        /// </summary>
        /// <param name="innerException">innerException producida</param>
        public ArchivosException(Exception innerException)
            :base(innerException.Message)
        {

        }
    }
}
