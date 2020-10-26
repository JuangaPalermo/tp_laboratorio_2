using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region atributos

        Queue<Universidad.EClases> claseDelDia;
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


        #endregion

        #region metodos

        private void _randomClases()
        {
            //this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0,4).ToString());
        }

        #endregion
    }
}
