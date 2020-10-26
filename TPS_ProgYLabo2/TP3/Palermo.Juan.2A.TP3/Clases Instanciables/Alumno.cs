using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region atributos

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #endregion

        #region constructores

        /// <summary>
        /// Constructor de la clase Alumno
        /// </summary>
        public Alumno()
            :base()
        { }

        /// <summary>
        /// Constructor de la clase Alumno
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de la clase Alumno
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region metodos
        
        /// <summary>
        /// Muestra los datos del objeto Alumno en formato string.
        /// </summary>
        /// <returns>datos en formato string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Indica en un string las clases en las que participa el alumno
        /// </summary>
        /// <returns>string con la informacion</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE: " + this.claseQueToma);
        }

        #endregion

        #region sobrecargas

        /// <summary>
        /// Muestra en formato string todos los datos del Alumno
        /// </summary>
        /// <returns>string con la informacion</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara un alumno con una clase, segun si el primero toma la segunda, y no es deudor (enum)
        /// </summary>
        /// <param name="a">Alumno para comparar</param>
        /// <param name="clase">Clase para comparar</param>
        /// <returns>true si el alumno toma la clase y no es deudor; de lo contrario, false.</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Compara un alumno con una clase, segun si el primero toma la segunda
        /// </summary>
        /// <param name="a">Alumno para comparar</param>
        /// <param name="clase">Clase para comparar</param>
        /// <returns>true si el alumno no toma la clase; de lo contrario, false.</returns>
        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        #endregion

        #region enumerados

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion
    }
}
