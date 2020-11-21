using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Producto
    {
        #region atributos

        string nombre;
        float precio;

        #endregion

        #region Propiedades

        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value.ToUpper(); }
        }

        public abstract bool Garantia
        {
            get;
        }

        #endregion

        #region constructores

        public Producto()
        {

        }

        public Producto(float precio, string nombre)
        {
            this.precio = precio;
            this.nombre = nombre;
        }

        public Producto(string precio, string nombre)
        {
            float.TryParse(precio, out this.precio);
            this.nombre = nombre;
        }

        #endregion

        #region metodos

        #endregion

        #region sobrecargas

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"NOMBRE: {this.nombre} - PRECIO: {this.precio}");

            return sb.ToString();
        }

        #endregion

    }
}
