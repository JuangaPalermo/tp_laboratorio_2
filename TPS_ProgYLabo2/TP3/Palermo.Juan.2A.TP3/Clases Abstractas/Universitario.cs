using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region atributos

        int legajo;

        #endregion

        #region constructores

        /// <summary>
        /// Constructor de la clase Universitario.
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Constructor de la clase Universitario.
        /// </summary>
        public Universitario()
            :base()
        {
            this.legajo = default;
        }

        #endregion

        #region metodos

        /// <summary>
        /// Muestra los datos del objeto univarsitario en formato string.
        /// </summary>
        /// <returns>datos en formato string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat($"LEGAJO NÚMERO: {this.legajo}\n");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region sobrecargas

        /// <summary>
        /// Sobrecarga de Equals, compara objetos de tipo Universitario
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>true si son iguales, de lo contrario, false</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario && (Universitario)obj == this;
        }

        /// <summary>
        /// Sobrecarga del ==, compara a dos objetos de clase universitario por su tipo y legajo o su tipo y dni.
        /// </summary>
        /// <param name="pg1">primer objeto a comparar</param>
        /// <param name="pg2">segundo objeto a comparar</param>
        /// <returns>true si son iguales, false si son diferentes</returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            return pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Sobrecarga del !=, compara a dos objetos de clase universitario por su tipo y legajo o su tipo y dni.
        /// </summary>
        /// <param name="pg1">primer objeto a comparar</param>
        /// <param name="pg2">segundo objeto a comparar</param>
        /// <returns>true si son diferentes, false si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
