using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region metodos

        public static bool Guardar(Jornada jornada)
        {
            bool resultado;

            Texto aux = new Texto();

            resultado = aux.Guardar("Jornada.txt", jornada.ToString());

            return resultado;
        }

        public static string Leer()
        {
            string resultado;

            Texto aux = new Texto();

            aux.Leer("Jornada.txt", out resultado);

            return resultado;
        }

        #endregion

        #region sobrecargas

        public static bool operator == (Jornada j, Alumno a)
        {
            return a == j.clase;
        }

        public static bool operator != (Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if((!j.alumnos.Contains(a)) && a == j.Clase)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.AppendFormat($"CLASE DE {this.clase.ToString()} POR {this.instructor.ToString()}\n\n");

            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        #endregion

    }
}
