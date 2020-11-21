using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Periferico : Producto
    {
        #region enumerado

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
            //set { this.marca = value; }
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

        #region metodos


        #endregion

        #region sobrecargas

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString() + $" - MARCA: {this.marca}");

            return sb.ToString();
        }

        #endregion


    }
}
