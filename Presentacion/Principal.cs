using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
   public class Principal
    {
        public void MenuPrincipal()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(5,5); Console.WriteLine("**************************** BANCO - MENU PRINCIPAL********************");
                Console.SetCursorPosition(5,6); Console.WriteLine("*                                                                     *");
                Console.SetCursorPosition(5,7); Console.WriteLine("*        1. CLIENTES                                                  *");
                Console.SetCursorPosition(5,8); Console.WriteLine("*        2. CUENTAS                                                   *");
                Console.SetCursorPosition(5,9); Console.WriteLine("*        3. TRANSACCIONES                                             *");
                Console.SetCursorPosition(5,10); Console.WriteLine("*        4. SALIR                                                     *");
                Console.SetCursorPosition(5,11); Console.WriteLine("***********************************************************************");
                Console.SetCursorPosition(5,12); Console.Write("Digite Una Opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        new PresentacionCliente().MenuClientes();
                        break;
                    case 2:
                        new PresentacionCuenta().MenuCuentas();
                        break;
                    case 3:
                        new PresentacionTransaccion().MenuTransaccion();
                            
                    break;
                    case 4:
                        break;
                }
            } while (opcion != 4);

        }
    }
}
