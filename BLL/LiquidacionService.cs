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
        public void Guardar(Bebida bebidas)
        {
            liquidacionRepository.Guardar(bebidas);
        }
        public List<Bebida> Consultar()
        {
            return liquidacionRepository.Consultar();
        }
        public void Eliminar(string numeroLiquidacion)
        {
            liquidacionRepository.Eliminar(numeroLiquidacion);
        }
        public void Modificar(string numeroLiquidacionModificar,Bebida bebidas)
        {
            liquidacionRepository.Modificar(numeroLiquidacionModificar,bebidas);
        }
    }
}
