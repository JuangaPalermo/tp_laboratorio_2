using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region ATRIBUTOS

        private double numero;

        #endregion


        #region PROPIEDADES

        /// <summary>
        /// Setter de numero, realiza validacion.
        /// </summary>
        public string SetNumero {
            set
            {
                numero = ValidarNumero(value);
            }
            
        }

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor por defecto de Numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        #endregion


        #region METODOS

        /// <summary>
        /// Comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">Numero recibido como parametro (str format)</param>
        /// <returns>Retornara el numero en formato double. Error: retornara 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double validatedNumber;

            if(double.TryParse(strNumero, out validatedNumber))
            {
                return validatedNumber;
            }
            else
            {
                return 0;
            }            
        }

        /// <summary>
        /// Valida que la cadena de caracteres este compuesta SOLAMENTE por caracteres '0' y '1'
        /// </summary>
        /// <param name="binario">Numero a validar (en formato string)</param>
        /// <returns>True si es binario, False si no es binario.</returns>
        private static bool EsBinario(string binario)
        {
            char[] arrayBinario = binario.ToCharArray();

            for(int i = 0; i<arrayBinario.Length; i++)
            {
                if (arrayBinario[i] != '1' && arrayBinario[i] != '0')
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Convierte el numero que se le pasa como parametro de Decimal a Binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Resultado de la conversion</returns>
        public static string DecimalBinario(double numero)
        {

            if(numero < 0)
            {
                return "Valor invalido";
            }
            else
            {
                string castedNumber = Math.Abs(numero).ToString();

                return Convert.ToString(Convert.ToInt32(castedNumber), 2);
            }  
            
        }

        /// <summary>
        /// Convierte el numero que se le pasa como parametro de binario a decimal
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>Resultado de la conversion</returns>
        public static string BinarioDecimal(string binario)
        {

            if(!EsBinario(binario))
            {
                return "Valor invalido";
            }
            else
            {
                return Convert.ToString(Convert.ToInt32(binario, 2), 10);                
            }
        }

        #endregion


        #region SOBRECARGAS
        
        /// <summary>
        /// Constructor por parametro.
        /// </summary>
        /// <param name="numero">Double recibido como parametro.</param>
        public Numero (double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor por parametro.
        /// </summary>
        /// <param name="strNumero">String recibido como parametro.</param>
        public Numero (string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Suma los dos numeros que se le pasan como parametro
        /// </summary>
        /// <param name="n1">Primer numero a sumar</param>
        /// <param name="n2">Segundo numero a sumar</param>
        /// <returns>Suma de ambos valores</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta los dos numeros que se le pasan como parametro
        /// </summary>
        /// <param name="n1">Numero al que se le resta la cantidad</param>
        /// <param name="n2">Cantidad a restar al primer numero</param>
        /// <returns>El resultado de la resta del primer numero con el segundo</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Divide los dos numeros que se le pasan como parametro
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Retorna el resultado de la division. Error: si el divisor es (0) devuelve double.MinValue.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Multiplica los dos numeros que se le pasan como parametro
        /// </summary>
        /// <param name="n1">Primer numero a multiplicar</param>
        /// <param name="n2">Segundo numero a multiplicar</param>
        /// <returns>Resultado de la multiplicacion entre ambos numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Convierte el numero que se le pasa como parametro de Decimal a Binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Resultado de la conversion</returns>
        public static string DecimalBinario(string numero)
        {
            double numeroCasteado;

            if(double.TryParse(numero, out numeroCasteado))
            {
                return DecimalBinario(numeroCasteado);
            }
            else
            {
                return "Valor invalido";
            }
        }



        #endregion


    }
}
