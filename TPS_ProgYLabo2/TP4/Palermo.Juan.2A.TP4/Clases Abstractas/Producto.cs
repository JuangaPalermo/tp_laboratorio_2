using System.Text;

namespace Clases_Abstractas
{
    public abstract class Producto
    {
        #region atributos

        string nombre;
        float precio;

        #endregion

        #region Propiedades

        
        /// <summary>
        /// Propiedad de lectura de precio
        /// </summary>
        public float Precio
        {
            get { return this.precio; }
        }

        /// <summary>
        /// Setea el precio ingresado para el producto. Si es un valor no valido como numero, entonces asigna 0;
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.precio = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura de nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
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
            this.SetNumero = precio;
            this.nombre = nombre;
        }

        #endregion

        #region metodos

        /// <summary>
        /// Metodo que me permite validad que el string recibido como parametro sea un numero. En caso de no poder castearlo, devolvera 0
        /// </summary>
        /// <param name="strNumero">string a validar como numero</param>
        /// <returns>numero que contiene el string, o si no, un 0 en caso de error en el parseo</returns>
        private float ValidarNumero(string strNumero)
        {
            float validatedNumber;

            if (float.TryParse(strNumero, out validatedNumber))
            {
                return validatedNumber;
            }
            else
            {
                return 0;
            }
        }


        #endregion

        #region sobrecargas

        /// <summary>
        /// Sobrecarga del ToString, mostrara los datos del producto.
        /// </summary>
        /// <returns>string con los datos del producto</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"NOMBRE: {this.nombre} - PRECIO: {this.precio}");

            return sb.ToString();
        }

        #endregion

    }
}
