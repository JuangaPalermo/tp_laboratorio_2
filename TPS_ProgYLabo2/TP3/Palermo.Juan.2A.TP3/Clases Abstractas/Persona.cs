using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region ATRIBUTOS

        string apellido;        
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        #endregion

        #region PROPIEDADES

        public string Apellido
        {
            get 
            { 
                return this.apellido; 
            }
            set 
            { 
                this.apellido = ValidarNombreApellido(value); 
            }
        }
        public int DNI
        {
            get 
            { 
                return this.dni; 
            }
            set 
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        #endregion

        #region CONSTRUCTORES

        public Persona()
        {
            this.apellido = "";
            this.dni = -1;
            this.nacionalidad = ENacionalidad.Argentino;
            this.nombre = "";
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
            : this()
        {
            this.nombre = ValidarNombreApellido(nombre);
            this.apellido = ValidarNombreApellido(apellido);
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region METODOS

        int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int returnValue;

            if (nacionalidad == ENacionalidad.Argentino && dato > 1 && dato < 89999999)
            {
                returnValue = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato <= 99999999)
            {
                returnValue = dato;
            }
            else if (dato > 99999999 || dato <1)
            {
                throw new DniInvalidoException("El numero del DNI es incorrecto");
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }

            return returnValue;
        }

        string ValidarNombreApellido(string dato)
        {
            bool aux = true;

            for(int i = 0; i < dato.Length; i++)
            {
                if(char.IsLetter(dato, i) == false)
                {
                    aux = false;
                    break;
                }
            }
            if(aux == false)
            {
                dato = "";
            }

            return dato;
        }

        #endregion

        #region SOBRECARGAS

        int ValidarDni (ENacionalidad nacionalidad, string dato)
        {
            int auxDato;
            int returnValue;
            bool ok;

            ok = Int32.TryParse(dato, out auxDato);

            if(ok)
            {
                returnValue = auxDato;
            }
            else
            {
                throw new DniInvalidoException("DNI con formato erroneo");
            }

            return returnValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\nNACIONALIDAD: {this.nacionalidad}\n");

            return sb.ToString();
        }
        #endregion

        #region ENUMERADOS

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
