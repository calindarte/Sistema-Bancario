using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Logica;
namespace Presentacion
{
    public class PresentacionCuenta
    {
        public void MenuCuentas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO - MENU CUENTAS********************************");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("*        1. Agregar Cuenta                                                         *");
                Console.WriteLine("*        2. Consultar Cuenta                                                       *");
                Console.WriteLine("*        3. Modificar                                                              *");
                Console.WriteLine("*        4. Eliminar                                                               *");
                Console.WriteLine("*        5. Volver                                                                 *");
                Console.WriteLine("*                                                                                  *");
                Console.WriteLine("************************************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1: 
                        MenuAgregar();
                        break;
                    case 2:
                        MenuConsultar();
                        break;
                    case 3:
                        MenuModificar();
                        break;
                    case 4:
                        MenuEliminar();
                        break;
                    case 5:

                        break;
                }
            } while (opcion != 5);
        }
        void MenuAgregar()
        {
            Cliente cliente;
            Cuenta cuenta;
            string numCuenta; 
            double saldo;
            string id;
            Logica.ServicioCuentas servicoCuenta = new Logica.ServicioCuentas();
            ServicioClientes servicioCliente = new ServicioClientes();
            Console.Clear();
            Console.Write("id Cliente : "); id = Console.ReadLine();

            cliente = servicioCliente.BuscarId(id);
            if (cliente == null)
            {
                Console.Clear();
                Console.WriteLine("cliente no existe ... debe crearlo primero");
                Console.ReadKey();
                return;
            }

            Console.Write("Numero de cuenta : "); numCuenta =Console.ReadLine();
            Console.Write("saldo inicial : "); saldo = double.Parse(Console.ReadLine());
            cuenta = new Cuenta(numCuenta, cliente, saldo);

            Console.WriteLine(servicoCuenta.Guardar(cuenta));
            Console.ReadKey();
        }
        void MenuConsultar()
        {

            Logica.ServicioCuentas servicioCuenta = new Logica.ServicioCuentas();
            int fila = 7;
            Console.Clear();
            Console.SetCursorPosition(5,5); Console.WriteLine(" Numero   -   Nombre Cliente   -   Saldo  ");
            foreach (var item in servicioCuenta.Consultar())
            {

             Console.SetCursorPosition(5,fila); Console.WriteLine(item.NumeroCuenta + " ");
             Console.SetCursorPosition(21,fila);Console.WriteLine(item.Cliente.Nombre + "  ");
             Console.SetCursorPosition(39,fila);Console.WriteLine(item.getSaldo());
                fila++;
            }

            Console.ReadKey();
        }

        void MenuEliminar()
        {
            Entidades.Cuenta cuenta;
            string numero_cuenta;
            Logica.ServicioCuentas servicio = new Logica.ServicioCuentas();
            Console.Clear();

            Console.SetCursorPosition(5, 5); Console.Write("Numero cuenta : ");
            Console.SetCursorPosition(5, 6); Console.Write("Nombre Cliente : ");
            
            Console.SetCursorPosition(21, 5); numero_cuenta = Console.ReadLine();

            cuenta = servicio.BuscarId(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(10, 5); Console.WriteLine("Cuenta No Existe");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(21, 6); Console.WriteLine(cuenta.Cliente.Nombre);

            string op = string.Empty;
            Console.SetCursorPosition(5, 9); Console.Write("Desea Eliminar La cuenta s/n:");
            Console.SetCursorPosition(36, 9); op = Console.ReadLine();
            if (op.ToUpper() == "S")
            {
                Console.SetCursorPosition(5, 10); Console.Write(servicio.Eliminar(numero_cuenta));

            }
            else
            {
                return;
            }
            Console.ReadKey();
        }

        void MenuModificar()
        {
            Cuenta cuenta = new Cuenta();
            string numero_cuenta;
            Logica.ServicioCuentas servicio = new Logica.ServicioCuentas();

            Console.Clear();

            Console.Write("Escriba el Numero de Cuenta Que Desea Modificar: ");
            numero_cuenta = Console.ReadLine();

            cuenta = servicio.BuscarId(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.WriteLine("Cuenta no Existe");
                Console.ReadKey();
                return;
            }
            Console.Write("Nombre Cliente : ");
            Console.Write(cuenta.Cliente.Nombre);
            string op = string.Empty;
            Console.Write("\nDesea Modificar la Cuenta s/n: ");
            op = Console.ReadLine();
            if (op.ToUpper() == "S")
                {
                Console.Write("\nEscriba el Nuevo numero de cuenta: ");
                cuenta.NumeroCuenta = Console.ReadLine();
                Console.Write(servicio.Modificar(cuenta));
                

                }
            else
               {
                return;
              }
              Console.ReadKey();
 

        }
    }
}
