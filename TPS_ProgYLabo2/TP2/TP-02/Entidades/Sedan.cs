using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {

        #region Enumerados

        public enum ETipo 
        { 
            CuatroPuertas, 
            CincoPuertas
        }

        #endregion

        #region Atributos

        ETipo tipo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas (modificacion charla via Slack)
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Llama al constructor por defecto y el de base. Luego, asigna el tipo indicado como parametro.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) 
            : base (chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Genera un StringBuilder con los datos de la SEDAN y lo transforma en String
        /// </summary>
        /// <returns>Devuelve el string con los datos</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
