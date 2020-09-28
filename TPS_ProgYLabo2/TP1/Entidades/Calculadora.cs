using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region METODOS

        /// <summary>
        /// Valida y realiza la operacion pedida entre ambos numeros
        /// </summary>
        /// <param name="num1">Primer dato de tipo Numero recibido</param>
        /// <param name="num2">Segundo dato de tipo Numero recibido</param>
        /// <param name="operador">Dato de tipo string, define la operacion a realizar</param>
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string validatedOperator;
            double result = 0;

            if (operador.Length > 1)
            {
                validatedOperator = "+";
            }
            else
            {
                validatedOperator = ValidarOperador(Convert.ToChar(operador));
            }         

            switch (validatedOperator)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
            }
            
            return result;
        }

        /// <summary>
        /// Valida que el operador recibido sea (+) (-) (/) (*)
        /// </summary>
        /// <param name="operador">Operador recibido como parametro</param>
        /// <returns>Devuelve el operador validado. Error: devuelve (+)</returns>
        private static string ValidarOperador(char operador)
        {
            string returnValue;

            if(operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                returnValue = Convert.ToString(operador);
            }
            else
            {
                returnValue = "+";
            }

            return returnValue;
            
        }

        #endregion
    }
}
