using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;
namespace LiquidacionUI
{
    class Program
    {
        static Bebidas bebidas;
        static LiquidacionService liquidacionService = new LiquidacionService();
        static List<Bebidas> lBebidas = new List<Bebidas>();
        static int z = 0;
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {

            int respuesta;
            do
            {
                Console.WriteLine("*** MENU ***");
                Console.WriteLine("1. Registrar Licores");
                Console.WriteLine("2. Registrar Vino");
                Console.WriteLine("3. Consultar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. SALIR");
                respuesta = Convert.ToInt32(Console.ReadLine());
                switch (respuesta)
                {
                    case 1:
                        z = 1;
                        Guardar();
                        break;
                    case 2:
                        z = 2;
                        Guardar();
                        break;
                    case 3:
                        Consultar();
                        break;
                    case 4:
                        Eliminar();
                        break;
                    case 5:
                        Console.WriteLine("Gracias por usarnos ");
                        break;
                    
                    default:
                        Console.WriteLine("Opcion incorrecta, intente una opcion valida");
                        break;
                }
            } while (respuesta != 5);
        }
        public static void Guardar()
        {
            if (z == 1)
            {
                bebidas = new Licores();
            }
            else if (z == 2)
            {
                bebidas = new Vinos();
            }
            
            Console.Clear();
            Console.WriteLine("Digite numero de liquidacion");
            bebidas.NumeroLiquidacion = Console.ReadLine();
            Console.WriteLine("Digite Nit del contribuyente");
            bebidas.NitContribuyente = Console.ReadLine();
            Console.WriteLine("Digite razon social del contribuyente");
            bebidas.RazonSocialContribuyente = Console.ReadLine();
            Console.WriteLine("Digite tipo impuesto");
            bebidas.TipoImpuesto = Console.ReadLine();
            Console.WriteLine("Digite base gravable");
            bebidas.BaseGravable = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Digite cantidad del producto");
            bebidas.CantidadProducto = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Digite precio de venta");
            bebidas.PrecioVenta = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine($"Tarifa Especifica: {bebidas.CalcularTarifaEspecifica()}");

            Console.WriteLine($"Tarifa Ad Valoren: {bebidas.CalcularTarifaAdValorem()}");

            Console.WriteLine($"Valor Especifico: {bebidas.CalcularValorEspecifico()}");

            Console.WriteLine($"Valor Ad Valoren: {bebidas.CalcularValorAdValorem()}");

            Console.WriteLine($"Valor Al Consumo: {bebidas.CalcularValorConsumo()}");

            liquidacionService.Guardar(bebidas);

        }
        public static void Consultar()
        {
            lBebidas = liquidacionService.Consultar();
            foreach (Bebidas bebidas in lBebidas)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Numero de liquidacion: {bebidas.NumeroLiquidacion}");
                Console.WriteLine($"Nit del contribuyente: {bebidas.NitContribuyente}");
                Console.WriteLine($"Razon social: {bebidas.RazonSocialContribuyente}");
                Console.WriteLine($"Tipo de impuesto: {bebidas.TipoImpuesto}");
                Console.WriteLine($"Base Gravable: {bebidas.BaseGravable}");
                Console.WriteLine($"Cantiadad del producto: {bebidas.CantidadProducto}");
                Console.WriteLine($"Precio Venta: {bebidas.PrecioVenta}");
                Console.WriteLine($"Tarifa Especifica: {bebidas.CalcularTarifaEspecifica()}");
                Console.WriteLine($"Tarifa Ad Valoren: {bebidas.CalcularTarifaAdValorem()}");
                Console.WriteLine($"Valor Especifico: {bebidas.CalcularValorEspecifico()}");
                Console.WriteLine($"Valor Ad Valoren: {bebidas.CalcularValorAdValorem()}");
                Console.WriteLine($"Valor Al Consumo: {bebidas.CalcularValorConsumo()}");
            }
            Console.ReadKey();
        }

        public static void Eliminar()
        {
            lBebidas = liquidacionService.Consultar();
            string numeroLiquidacion;
            int z = 0;
            Console.WriteLine("Digite el numero de liquidacion que desea eliminar");
            numeroLiquidacion = Console.ReadLine();
            foreach (Bebidas bebidas in lBebidas)
            {
                if (bebidas.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    liquidacionService.Eliminar(numeroLiquidacion);
                    z = 1;
                }
            }
            if (z == 0)
            {
                Console.WriteLine("*Esta numero de liquidacion no existe*");
            }
            else
            {
                Console.WriteLine("*Eliminado correctamente*");
            }

        }
    }
}
