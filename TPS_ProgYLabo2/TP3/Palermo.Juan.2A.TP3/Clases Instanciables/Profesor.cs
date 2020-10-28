using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos

        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #endregion

        #region constructores

        /// <summary>
        /// Constructor estatico de la clase Profesor
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de la clase Profesor
        /// </summary>
        public Profesor()
            :base()
        {
           
        }

        /// <summary>
        /// Constructor parametrizado de la clase Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }


        #endregion

        #region metodos

        /// <summary>
        /// Obtiene un valor random del enumerado Universidad.EClases, y se lo asigna a la cola clasesDelDia.
        /// </summary>
        private void _randomClases()
        {
            for(int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Enum.Parse(typeof(Universidad.EClases), random.Next(0, 3).ToString()));
            }            
        }

        /// <summary>
        /// Genera un string con todos los datos del profesor
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Genera un string con todas las clases que el profesor tiene asignadas en su Queue clasesDelDia
        /// </summary>
        /// <returns>string con las clases del profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region sobrecargas

        /// <summary>
        /// Retorna todos los datos del profesor en formato string
        /// </summary>
        /// <returns>string con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobrecarga del ==, un profesor y una clase seran iguales si el profesor da esa clase. Los compara y devuelve true o false segun corresponda
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a buscar dentro de la Queue de Profesor</param>
        /// <returns>True en caso de que la Queue de profesor contenga la clase especificada, de lo contrario, false</returns>
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            bool resultado = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Sobrecarga del !=, un profesor y una clase seran distintos si el profesor no da esa clase. Los compara y devuelve true o false segun corresponda
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a buscar dentro de la Queue de Profesor</param>
        /// <returns>True en caso de que la Queue de profesor no contenga la clase especificada, de lo contrario, false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
