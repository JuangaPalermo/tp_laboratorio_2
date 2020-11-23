using System.Text;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public class Periferico : Producto
    {
        #region enumerado

        /// <summary>
        /// enumerado de la marca de los perifericos
        /// </summary>
        public enum Marca
        {
            HyperX,
            Gigabyte,
            Razer,
            Logitech,
            OtraMarca
        }

        #endregion

        #region atributos

        Marca marca;

        #endregion

        #region propiedades

        /// <summary>
        /// Me permite obtener el string equivalente a la marca del objeto
        /// </summary>
        public string MarcaProducto
        {
            get 
            {
                switch (marca)
                {
                    case Marca.HyperX:
                        return "HyperX";
                    case Marca.Gigabyte:
                        return "Gigabyte";
                    case Marca.Razer:
                        return "Razer";
                    case Marca.Logitech:
                        return "Logitech";
                    default:
                        return "Otra Marca";
                }
            }
        }


        /// <summary>
        /// por defecto, los productos tendran todos garantia
        /// </summary>
        public virtual bool Garantia
        {
            get { return true; }
        }

        #endregion

        #region constructores

        public Periferico()
            :base()
        {

        }

        public Periferico(Marca marca, float precio, string nombre)
            :base(precio,nombre)
        {
            this.marca = marca;
        }
        
        public Periferico(Marca marca, string precio, string nombre)
            :base(precio,nombre)
        {
            this.marca = marca;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Me permite matchear el string recibido con el enumerado de la marca
        /// </summary>
        /// <param name="aux">string recibido</param>
        /// <returns>enumerado equivalente a la marca. Si no hay matcheos, devuelve por default OtraMarca</returns>
        public static Marca MapeoTipoMarca(string aux)
        {
            switch (aux)
            {
                case "HyperX":
                    return Marca.HyperX;
                case "Gigabyte":
                    return Marca.Gigabyte;
                case "Razer":
                    return Marca.Razer;
                case "Logitech":
                    return Marca.Logitech;
                default:
                    return Marca.OtraMarca;
            }
        }

        #endregion

        #region sobrecargas

        /// <summary>
        /// sobrescritura del metodo ToString, para que muestre todos los datos del objeto
        /// </summary>
        /// <returns>todos los datos del Periferico, en formato string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString() + $" - MARCA: {this.marca}");

            return sb.ToString();
        }

        #endregion

    }
}
