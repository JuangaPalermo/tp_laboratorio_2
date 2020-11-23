using System;
using System.Collections.Generic;
using System.Text;


namespace Clases_Instanciables
{
    public class Compra<T> where T : Periferico
    {
        #region atributos

        protected List<T> elementos;

        public delegate void EventoDescuento(object sender, EventArgs e);
        public EventoDescuento PremioAlcanzado;

        #endregion

        #region propiedades

        /// <summary>
        /// Propiedad de solo lectura de los elementos que contiene la lista generica de la clase.
        /// </summary>
        public List<T> Elementos
        {
            get { return this.elementos; }
            set { this.elementos = value; }
        }

        /// <summary>
        /// Propiedad de solo lectura, devuelve el precio total de la compra. Lo hace a traves del metodo ObtenerPrecio.
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(this);
            }
        }

        #endregion

        #region constructor

        public Compra()
        {
            elementos = new List<T>();
        }

        #endregion

        #region metodos

        /// <summary>
        /// Metodo que me permite acumular obtener el total de los precios acumulados en la lista de la compra
        /// </summary>
        /// <param name="l">compra de la que se sacara el total del precio</param>
        /// <returns></returns>
        public static float ObtenerPrecio(Compra<T> l)
        {
            float acumulador = 0;

            foreach(T item in l.elementos)
            {
                acumulador += item.Precio;
            }

            return acumulador;
        }

        /// <summary>
        /// Me mostrara el detalle de cada uno de los productos que se encuentran en la compra
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public string MostrarCompra(Compra<T> l)
        {

            StringBuilder sb = new StringBuilder();

            foreach (T item in l.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("------------------------------");
            sb.AppendLine("TOTAL: " + this.PrecioTotal);
            sb.AppendLine("------------------------------");
            


            return sb.ToString();
        }

        /// <summary>
        /// Metodo que me permite agregar un producto a la compra
        /// </summary>
        /// <param name="p">producto a agregar</param>
        /// <returns> la compra con el producto agregado </returns>
        public Compra<T> Agregar (T p)
        {
            return (this + p);
        }


        #endregion

        #region sobrecargas

        /// <summary>
        /// Sobrecarga del operador +, para que se pueda sumar una compra y un producto (y que este ultimo se 
        /// adicione al listado de productos del primero)
        /// </summary>
        /// <param name="l">compra a la que se le agregara el producto</param>
        /// <param name="producto">producto a agregar a la compra</param>
        /// <returns>la lista que recibe como primer parametro pero actualizada con la adicion. Si no puede
        /// agregarlo, retorna la lista tal como la recibio</returns>
        public static Compra<T> operator +(Compra<T> l, T producto)
        {

            if (l != null && producto != null)
            {
                l.elementos.Add(producto);
            }
            
            return l;
        }

        #endregion
    }
}
