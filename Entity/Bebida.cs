using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Bebida
    {
        public string NumeroLiquidacion { get; set; }
        public string NitContribuyente { get; set; }
        public string RazonSocialContribuyente { get; set; }
        public string TipoImpuesto { get; set; }
        public float BaseGravable { get; set; }
        public float CantidadProducto { get; set; }
        public float PrecioVenta { get; set; }
        public float TarifaEspecifica { get; set; }
        public float TarifaAdValorem { get; set; }
        public float ValorEspecifico { get; set; }
        public float ValorAdValorem { get; set; }
        public float ValorConsumo { get; set; }

        public abstract float CalcularTarifaEspecifica();
        public abstract float CalcularTarifaAdValorem();

        public float CalcularValorEspecifico()
        {
            return ValorEspecifico = (BaseGravable * TarifaEspecifica * CantidadProducto);
        }
        public float CalcularValorAdValorem()
        {
            return ValorAdValorem = (PrecioVenta * TarifaAdValorem * CantidadProducto);
        }
        public float CalcularValorConsumo()
        {
            return ValorConsumo = (ValorAdValorem + ValorEspecifico);
        }

    }
}
