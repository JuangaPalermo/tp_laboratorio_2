using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region enumerados

        /// <summary>
        /// Enumerado de Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region atributos

        string apellido;        
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        #endregion

        #region propiedades

        /// <summary>
        /// Propiedad de lectura y escritura: Apellido
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura: DNI
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura: Nacionalidad
        /// </summary>
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

        /// <summary>
        /// Propiedad de lectura y escritura: Nombre
        /// </summary>
        public string Nombre
        {
            get
            { 
                return this.nombre; 
            }
            set 
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de escritura: StringToDNI
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        #endregion

        #region constructores

        /// <summary>
        /// Constructor de la clase persona.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado de la clase Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado de la clase persona, con dni de tipo entero.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado de la clase persona, con dni tipo string.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region metodos

        /// <summary>
        /// Valida el dato recibido en el segundo parametro, con respecto a su formato y a la nacionalidad que se indica
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">numero de DNI en formato int</param>
        /// <returns>DNI validado en formato int, de lo contrario, mensaje de error</returns>
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

        /// <summary>
        /// Valida la cadena de caracteres que recibe, chequeando que pertenezca a alguna categoria de letras Unicode
        /// </summary>
        /// <param name="dato">cadena de caracteres a validar</param>
        /// <returns>La cadena validada. En caso de que tenga caracteres incorrectos, entonces devuelve una cadena vacia.</returns>
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

        #region sobrecargas

        /// <summary>
        /// Valida el dato recibido en el segundo parametro, con respecto a su formato y a la nacionalidad que se indica
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">numero de DNI en formato string</param>
        /// <returns>DNI validado en formato int, de lo contrario, mensaje de error</returns>
        int ValidarDni (ENacionalidad nacionalidad, string dato)
        {
            int auxDato;
            int returnValue;
            bool ok;

            ok = Int32.TryParse(dato, out auxDato);

            if(ok)
            {
                returnValue = ValidarDni(nacionalidad, auxDato);
            }
            else
            {
                throw new DniInvalidoException("DNI con formato erroneo");
            }

            return returnValue;
        }

        /// <summary>
        /// Sobrecarga del ToString(), devuelve el nombre, apellido, y nacionalidad de la Persona en formato string
        /// </summary>
        /// <returns>Datos de la persona (nombre apellido y nacionalidad) como string.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\nNACIONALIDAD: {this.nacionalidad}\n");

            return sb.ToString();
        }
        #endregion


    }
}
