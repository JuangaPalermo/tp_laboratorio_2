﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {

        #region Propiedades

        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructos de Suv, llama al constructor de base.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Genera un StringBuilder con los datos de la Suv y lo transforma en String
        /// </summary>
        /// <returns>Devuelve el string con los datos</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
