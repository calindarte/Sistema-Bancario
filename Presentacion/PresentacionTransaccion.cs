using Logica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class PresentacionTransaccion
    {
        ServicioCuentas servicioCuentas = new ServicioCuentas();
        Cuenta cuenta = new Cuenta();
        public void MenuTransaccion()
        {
            Console.Clear();
            string NumCuenta;
            Console.WriteLine("TRANSACCIONES");
            Console.Write("Digite el Numero de la Cuenta: ");
            NumCuenta = Console.ReadLine();

            cuenta = servicioCuentas.BuscarId(NumCuenta);
            if (cuenta == null)
            {

                Console.WriteLine("La Cuenta no Existe");
                Console.ReadKey();
                return;
            }
            SubMenu();
        }
        public void SubMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("*******************************SUBMENU TRANSACCIONES********************************");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("*        1. Consignar                                                              *");
                Console.WriteLine("*        2. Retirar                                                                *");
                Console.WriteLine("*        3. Volver                                                                 *");
                Console.WriteLine("************************************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Consignar();

                        break;
                    case 2:
                        Retirar();
                        break;
                    case 3:
                        new Principal().MenuPrincipal();
                        break;

                }
            } while (opcion != 3);
        }
        public void Consignar()
        {
            Console.Clear();
            double valorConsigar;
            Console.SetCursorPosition(5, 5); Console.Write("Ingrese el Valor a Consignar: ");
            valorConsigar = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(cuenta.Consignar(valorConsigar));
            servicioCuentas.Modificar(cuenta);
            Console.ReadKey();


        }
        public void Retirar()
        {
            Console.Clear();
            double valorRetirar;
            Console.SetCursorPosition(5, 5); Console.Write("Ingrese el Valor a retirar: ");
            valorRetirar = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(cuenta.Retirar(valorRetirar));
            servicioCuentas.Modificar(cuenta);
            Console.ReadKey();


        }
    }
}
