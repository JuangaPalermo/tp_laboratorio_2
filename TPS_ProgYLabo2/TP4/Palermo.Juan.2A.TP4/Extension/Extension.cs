using System.Text;
using Clases_Instanciables;

namespace Extension
{
    public static class Extension
    {
        /// <summary>
        /// Metodo de extension que me permitira traer los datos que devuelve el ToString del objeto que le paso como parametro.
        /// Ademas, le agrega la informacion de la garantia.
        /// </summary>
        /// <param name="p">Objeto del que se obtendran los datos</param>
        /// <returns>string con los datos del objeto, y la Garantia</returns>
        public static string ObtenerInfoExtendida(this Periferico p)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(p.ToString());
            sb.AppendLine("Cuenta con garantia? -> " + p.Garantia.ToString());

            return sb.ToString();
        }

    }
}
