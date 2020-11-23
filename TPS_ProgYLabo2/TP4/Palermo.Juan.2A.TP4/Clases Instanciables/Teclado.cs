using System.Text;

namespace Clases_Instanciables
{
    public class Teclado : Periferico
    {

        #region propiedades

        /// <summary>
        /// Propiedad de solo lectura, me devuelve el nombre de la clase (Teclado)
        /// </summary>
        public string Tipo
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// sobrescribe la propiedad Garantia de periferico, asignandole false.
        /// </summary>
        public override bool Garantia
        {
            get { return false; }
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

        #region sobrecargas

        /// <summary>
        /// Sobrescritura del ToString. Devuelve todos los datos del teclado en formato string
        /// </summary>
        /// <returns>los datos del teclado en formato string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"PRODUCTO {this.Tipo}");
            sb.Append(base.ToString());

            return sb.ToString();
        }

        #endregion
    }
}
