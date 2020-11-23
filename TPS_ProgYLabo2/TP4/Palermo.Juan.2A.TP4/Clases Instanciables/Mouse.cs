using System.Text;

namespace Clases_Instanciables
{
    public class Mouse : Periferico
    {

        #region propiedades

        /// <summary>
        /// Propiedad de solo lectura, me devuelve el nombre de la clase (Mouse)
        /// </summary>
        public string Tipo
        {
            get { return this.GetType().Name; }
        }

        #endregion

        #region constructores

        public Mouse()
            :base()
        {

        }

        public Mouse(Marca marca, float precio, string nombre)
            :base(marca,precio,nombre)
        {

        }
        
        public Mouse(Marca marca, string precio, string nombre)
            :base(marca,precio,nombre)
        {

        }

        #endregion

        #region sobrecargas

        /// <summary>
        /// sobrescritura del metodo ToString, para que muestre todos los datos del objeto
        /// </summary>
        /// <returns>todos los datos del mouse, en formato string</returns>
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
