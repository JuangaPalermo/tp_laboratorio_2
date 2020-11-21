using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Teclado : Periferico
    {

        #region propiedades
        public override bool Garantia
        {
            get { return true; }
        }

        public string Tipo
        {
            get { return this.GetType().Name; }
        }


        #endregion

        #region constructores
        public Teclado(Marca marca, float precio, string nombre)
            : base(marca, precio, nombre)
        {

        }
        
        public Teclado(Marca marca, string precio, string nombre)
            : base(marca, precio, nombre)
        {

        }

        public Teclado()
            : base()
        {
        }

        #endregion

        #region metodos


        #endregion

        #region sobrecargas

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"PRODUCTO {this.GetType()}");
            sb.Append(base.ToString());

            return sb.ToString();
        }

        #endregion
    }
}
