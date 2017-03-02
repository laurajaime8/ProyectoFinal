using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Avatar
    {
        int apetito, diversion, energia;
        /// <summary>
        /// Constructor de la clase Avatar
        /// </summary>
        /// <param name="apetito"></param>
        /// <param name="diversion"></param>
        /// <param name="energia"></param>
        public Avatar(int apetito, int diversion, int energia)
        {
            this.apetito = apetito;
            this.diversion = diversion;
            this.energia = energia;
        }

        public int Apetito
        {
            get
            {
                return apetito;
            }

            set
            {
                apetito = value;
            }
        }

        public int Diversion
        {
            get
            {
                return diversion;
            }

            set
            {
                diversion = value;
            }
        }

        public int Energia
        {
            get
            {
                return energia;
            }

            set
            {
                energia = value;
            }
        }
    }
}
