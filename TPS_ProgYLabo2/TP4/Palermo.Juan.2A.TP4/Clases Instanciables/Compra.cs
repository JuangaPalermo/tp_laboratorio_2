using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;


namespace Clases_Instanciables
{
    public class Compra<T> where T : Producto
    {
        #region atributos

        protected List<T> elementos;

        #endregion

        #region propiedades

        public List<T> Elementos
        {
            get { return this.elementos; }
        }

        public double PrecioTotal
        {
            get
            {
                //double total = 0;

                //foreach (T item in elementos)
                //{
                //    total += item.Precio;
                //} (si no meter el acumulador en el return)

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

        public float ObtenerPrecio(Compra<T> l)
        {
            float acumulador = 0;

            foreach(T item in l.elementos)
            {
                acumulador += item.Precio;
            }

            return acumulador;
        }

        private string MostrarCompra(Compra<T> l)
        {
            //ACA HACER UN FOREACH CON LAS SOBRECARGAS DEL TOSTRING DE LAS OTRAS CLASES
            //Y QUE AL FINAL DE ESE FOREACH, MUESTRE EL PRECIO TOTAL DE LA COMPRA, CON
            //LOS ELEMENTOS QUE ESTAN AGREGADAS A LA MISMA

            //ESTE METODO DEBERIA LLAMARSE A TRAVES DE UN EVENTO, PARA QUE SE ACTUALICE
            //AUTOMATICAMENTE EN LA PANTALLA

            StringBuilder sb = new StringBuilder();

            ///sb.AppendLine($"LISTADO DE PRODUCTOS DE LA LISTA: ");

            foreach (T item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public bool Agregar (T p)
        {
            return (this + p);
        }


        #endregion

        #region sobrecargas

        public static bool operator +(Compra<T> l, T producto)
        {
            l.elementos.Add(producto);
            
            return true;
        }

        #endregion
    }
}
