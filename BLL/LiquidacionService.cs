using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class LiquidacionService
    {
        LiquidacionRepository liquidacionRepository = new LiquidacionRepository();
        public void Guardar(Bebidas bebidas)
        {
            liquidacionRepository.Guardar(bebidas);
        }
        public List<Bebidas> Consultar()
        {
            return liquidacionRepository.Consultar();
        }
        public void Eliminar(string numeroLiquidacion)
        {
            liquidacionRepository.Eliminar(numeroLiquidacion);
        }
    }
}
