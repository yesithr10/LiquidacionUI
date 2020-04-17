using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Vinos : Bebidas
    {
        public override float CalcularTarifaEspecifica()
        {
               return TarifaEspecifica = 150;
        }
        public override float CalcularTarifaAdValorem()
        {
            return TarifaAdValorem =  0.2f;
        }

        
    }
}
