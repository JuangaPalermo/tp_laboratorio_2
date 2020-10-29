using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region enumerados

        /// <summary>
        /// Enumerado de clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion

        #region atributos

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #endregion

        #region propiedades
        
        /// <summary>
        /// Propiedad de lectura y escritura de Alumnos
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
        /// Propiedad de lectura y escritura de Instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador para jornadas
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                jornada[i] = value;
            }
        }

        #endregion

        #region constructores

        /// <summary>
        /// Constructor de clase Universidad
        /// </summary>
        public Universidad ()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion

        #region metodos

        /// <summary>
        /// Muestra los datos de la universidad en formato de String
        /// </summary>
        /// <param name="uni">Universidad a mostrar</param>
        /// <returns>string con los datos del parametro recibido</returns>
        private string MostrarDatos (Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda el archivo de objetos Universidad en formato xml
        /// </summary>
        /// <param name="uni">Universidad a guardar</param>
        /// <returns>true si se guardo correctamente; si no, false</returns>
        public static bool Guardar(Universidad uni)
        {
            bool resultado;

            Xml<Universidad> xmlaux = new Xml<Universidad>();

            resultado = xmlaux.Guardar("Universidad.xml", uni);

            return resultado;
        }

        /// <summary>
        /// Lee el archivo de objetos Universidad en formato xml
        /// </summary>
        /// <returns>el objeto leido, de tipo universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xmlaux = new Xml<Universidad>();
            Universidad auxUni = new Universidad();

            try
            {
                xmlaux.Leer("Universidad.xml", out auxUni);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            
            return auxUni;
        }

        #endregion

        #region sobrecargas
        
        /// <summary>
        /// Sobrecarga de ==, una universidad y un alumno seran iguales, si este ultimo esta inscripto dentro de la universidad
        /// </summary>
        /// <param name="g">Universidad a revisar</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>True si el alumno esta inscripto, de lo contrario, false.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool resultado = false;

            foreach(Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    resultado = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Sobrecarga de !=, una universidad y un alumno seran diferentes, si este ultimo no esta inscripto dentro de la universidad
        /// </summary>
        /// <param name="g">Universidad a revisar</param>
        /// <param name="a">Alumno a buscar</param>
        /// <returns>True si el alumno no esta inscripto, de lo contrario, false.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga de ==, una universidad y un profesor seran iguales, si este ultimo esta dando clases dentro de la universidad
        /// </summary>
        /// <param name="g">Universidad a revisar</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>True si el profesor esta dando clases, de lo contrario, false.</returns>
        public static bool operator == (Universidad g, Profesor i)
        {
            bool resultado = false;

            foreach (Profesor item in g.profesores)
            {
                if(item == i)
                {
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Sobrecarga de !=, una universidad y un profesor seran diferentes, si este ultimo no esta dando clases dentro de la universidad
        /// </summary>
        /// <param name="g">Universidad a revisar</param>
        /// <param name="i">Profesor a buscar</param>
        /// <returns>True si el profesor no esta dando clases, de lo contrario, false.</returns>
        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga de ==, una universidad y una clase seran iguales, si hay al menos un profesor que pueda dar dicha clase
        /// </summary>
        /// <param name="u">Universidad a revisar</param>
        /// <param name="clase">Clase a validar</param>
        /// <returns>El primer profesor que puede dar la clase, de lo contrario, arroja mensaje de excepcion</returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor auxProf = null;

            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    auxProf = item;
                }
            }

            if(auxProf is null)
            {
                throw new SinProfesorException("No hay profesor para la clase.");
            }

            return auxProf;
        }

        /// <summary>
        /// Sobrecarga de !=, una universidad y una clase seran distintos, si hay al menos un profesor que no pueda dar dicha clase
        /// </summary>
        /// <param name="u">Universidad a revisar</param>
        /// <param name="clase">Clase a validar</param>
        /// <returns>Al primer profesor que no pueda dar la clase, de lo contrario, arroja mensaje de excepcion.</returns>
        public static Profesor operator != (Universidad u, EClases clase)
        {
            Profesor auxProf = null;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    auxProf = item;
                    break;
                }
            }

            if (auxProf is null)
            {
                throw new SinProfesorException("Todos los profesores pueden dar la clase.");
            }

            return auxProf;
        }

        /// <summary>
        /// Se genera y agrega una nueva jornada, con la clase, el profesor que puede darla, y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g">Universidad a la que se le agregara la jornada con la clase</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Universidad con la nueva jornada cargada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {

            Jornada auxJor = new Jornada(clase, (g == clase));

            foreach(Alumno item in g.alumnos)
            {
               if(item == clase)
               {
                    auxJor += item;
               }
            }

            g.jornada.Add(auxJor);

            return g;
        }

        /// <summary>
        /// Si el alumno no se encuentra en la universidad, se agregara a la misma.
        /// </summary>
        /// <param name="u">Universidad en la que se buscara y/o cargara el alumno</param>
        /// <param name="a">Alumno a cargar</param>
        /// <returns>Universidad actualizada en caso de que el alumno se cargue, de lo contrario, mensaje de excepcion.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido.");
            }

            return u;
        }

        /// <summary>
        /// Si el profesor no esta cargado en la Universidad, se agregara a la misma
        /// </summary>
        /// <param name="u">Universidad en la que se buscara y/o cargara el profesor</param>
        /// <param name="i">Profesor a cargar</param>
        /// <returns>Universidad actualizada con el profesor (en caso de que no estuviera)</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Muestra los datos de la Universidad en formato string
        /// </summary>
        /// <returns>string con los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion
    }
}
