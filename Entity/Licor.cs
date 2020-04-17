using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Licor : Bebida
    {
        public override float CalcularTarifaEspecifica()
        {
            if (BaseGravable < 31)
            {
                return TarifaEspecifica = 220f;
            }
            else
            {
                    return TarifaEspecifica = 250f;
            }

        }
        public override float CalcularTarifaAdValorem()
        {
            if (BaseGravable < 31)
            {
                return TarifaAdValorem =  0.25f;
            }
            else
            {
                return TarifaAdValorem = 0.30f;
            }
        }

        
    }
}
