using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;

namespace DAL
{
    public class LiquidacionRepository
    {
        Bebida bebidas;
        string ruta = "ParcialBebidas.txt";
        public void Guardar(Bebida bebidas)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{bebidas.NumeroLiquidacion};{bebidas.NitContribuyente};{bebidas.RazonSocialContribuyente};{bebidas.TipoImpuesto};{bebidas.BaseGravable};" +
                $"{bebidas.CantidadProducto};{bebidas.PrecioVenta};{bebidas.TarifaEspecifica};{bebidas.TarifaAdValorem};{bebidas.ValorEspecifico};{bebidas.ValorAdValorem};" +
                $"{bebidas.ValorConsumo}");
            escritor.Close();
           file.Close();
        }
        public List<Bebida> Consultar()
        {
            List<Bebida> lBebidas = new List<Bebida>();
            string linea;

            TextReader lector;
            lector = new StreamReader(ruta);
            while ((linea = lector.ReadLine()) != null)
            {
                bebidas = new Licor();
                string[] arrayBebidas = linea.Split(';');

                bebidas.NumeroLiquidacion = arrayBebidas[0];
                bebidas.NitContribuyente = arrayBebidas[1];
                bebidas.RazonSocialContribuyente = arrayBebidas[2];
                bebidas.TipoImpuesto = arrayBebidas[3];
                bebidas.BaseGravable = Convert.ToSingle(arrayBebidas[4]);
                bebidas.CantidadProducto = Convert.ToSingle(arrayBebidas[5]);
                bebidas.PrecioVenta = Convert.ToSingle(arrayBebidas[6]);
                bebidas.TarifaEspecifica = Convert.ToSingle(arrayBebidas[7]);
                bebidas.TarifaAdValorem = Convert.ToSingle(arrayBebidas[8]);
                bebidas.ValorEspecifico = Convert.ToSingle(arrayBebidas[9]);
                bebidas.ValorAdValorem = Convert.ToSingle(arrayBebidas[10]);
                bebidas.ValorConsumo = Convert.ToSingle(arrayBebidas[11]);
                lBebidas.Add(bebidas);
            }
            lector.Close();
            return lBebidas;
        }
        public void Eliminar(string numeroLiquidacion)
        {
            List<Bebida> lBebidas = new List<Bebida>();
            lBebidas = Consultar();

            FileStream file = new FileStream(ruta, FileMode.Create);
            StreamWriter escritor = new StreamWriter(file);

            foreach (Bebida bebidas in lBebidas)
            {
                if (bebidas.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    lBebidas.Remove(bebidas);
                    break;
                }                
            }
            foreach (Bebida bebidas in lBebidas)
            {
                escritor.WriteLine($"{bebidas.NumeroLiquidacion};{bebidas.NitContribuyente};{bebidas.RazonSocialContribuyente};{bebidas.TipoImpuesto};{bebidas.BaseGravable};" +
                $"{bebidas.CantidadProducto};{bebidas.PrecioVenta};{bebidas.TarifaEspecifica};{bebidas.TarifaAdValorem};{bebidas.ValorEspecifico};{bebidas.ValorAdValorem};" +
                $"{bebidas.ValorConsumo}");
            }
            escritor.Close();
            file.Close();
        }
        public void Modificar(string numeroLiquidacionModificar,Bebida bebida)
        {
            Eliminar(numeroLiquidacionModificar);
            Guardar(bebida);
        }


    }
}
