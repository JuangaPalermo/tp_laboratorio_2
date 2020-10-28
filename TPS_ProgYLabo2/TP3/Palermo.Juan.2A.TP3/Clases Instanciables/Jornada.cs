using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region atributos

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region propiedades

        /// <summary>
        /// Propiedad de lectura y escritura de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set 
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de Clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de Instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region constructores

        /// <summary>
        /// Constructor privado de Jornada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado de Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region metodos


        /// <summary>
        /// Guarda el archivo de objetos Jornada en formato txt
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>true si se guardo correctamente; si no, false</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool resultado;

            Texto aux = new Texto();

            resultado = aux.Guardar("Jornada.txt", jornada.ToString());
            
            return resultado;
        }

        /// <summary>
        /// Lee el archivo de objetos Jornada en formato txt
        /// </summary>
        /// <returns>Lo leido en el archivo, en forma de string</returns>
        public static string Leer()
        {
            string resultado;

            Texto aux = new Texto();
            try
            {
                aux.Leer("Jornada.txt", out resultado);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e.InnerException); 
            }
            

            return resultado;
        }

        #endregion

        #region sobrecargas

        /// <summary>
        /// Una jornada sera igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno participa de la jornada, de lo contrario, false</returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool resultado = false;
            
            foreach(Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Una jornada sera distinta a un alumno si no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno no participa de la jornada, de lo contrario, false</returns>
        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Valida que el alumno no se encuentre en la jornada. Si es asi, lo agrega.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>La jornada actualizada (con el alumno agregado si antes no estaba)</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Devuelve todos los datos de la jornada en formato de string
        /// </summary>
        /// <returns>string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.AppendFormat($"CLASE DE {this.clase.ToString()} POR {this.instructor.ToString()}\n");

            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno item in this.alumnos)
            {
                sb.Append(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        #endregion

    }
}
