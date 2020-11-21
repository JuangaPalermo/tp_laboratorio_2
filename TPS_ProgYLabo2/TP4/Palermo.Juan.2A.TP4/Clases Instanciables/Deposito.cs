using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Deposito<T>
    {
        
        List<T> productos;

        public Deposito()
        {
            productos = new List<T>();
        }


    }
}
