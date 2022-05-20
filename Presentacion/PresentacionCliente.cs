using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Logica;

namespace Presentacion
{
    public class PresentacionCliente
    {
        ServicioClientes servico = new ServicioClientes();
        public void MenuClientes()
        {
            int opcion;
            do
            {
                Console.Clear();

                Console.SetCursorPosition(5,5); Console.WriteLine("******************** BANCO - MENU CLIENTES ****************************");
                Console.SetCursorPosition(5,6); Console.WriteLine("*                                                                     *");
                Console.SetCursorPosition(5,7); Console.WriteLine("*        1. Agregar Cliente                                           *");
                Console.SetCursorPosition(5,8); Console.WriteLine("*        2. Consultar Cliente                                         *");
                Console.SetCursorPosition(5,9); Console.WriteLine("*        3. Modificar                                                 *");
                Console.SetCursorPosition(5,10);Console.WriteLine("*        4. Eliminar                                                  *");
                Console.SetCursorPosition(5,11);Console.WriteLine("*        5. Volver                                                    *");
                Console.SetCursorPosition(5,12);Console.WriteLine("*                                                                     *");
                Console.SetCursorPosition(5,13);Console.WriteLine("***********************************************************************");
                Console.SetCursorPosition(5,14);Console.Write("Digite Una Opcion:  ");
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
            Cliente cliente = new Cliente();
            
            Console.Clear();
            Console.SetCursorPosition(5, 5);Console.Write("ID Cliente : "); cliente.IdCliente = Console.ReadLine();
            Console.SetCursorPosition(5, 6); Console.Write("Nombre Cliente : "); cliente.Nombre = Console.ReadLine();
            Console.WriteLine(servico.Guardar(cliente));
            Console.ReadKey();
        }
        void MenuConsultar()
        {
            
            
            int fila = 7;
            Console.Clear();
            Console.SetCursorPosition(5, 5); Console.WriteLine("ID Cliente   -   Nombre Cliente  \n");
            foreach (var item in servico.Consultar())
            {
                Console.SetCursorPosition(5,fila); Console.WriteLine(item.IdCliente + "      ----->    " + item.Nombre);
                fila++;
            }

            Console.ReadKey();
        }
         void MenuEliminar()
        {
            Entidades.Cliente cliente;
            string id_cliente;
            Logica.ServicioClientes servicio = new Logica.ServicioClientes();
            Console.Clear();

            Console.SetCursorPosition(5, 5); Console.Write("ID Cliente : ");
            Console.SetCursorPosition(5, 6); Console.Write("Nombre Cliente : ");

            Console.SetCursorPosition(18, 5); id_cliente = Console.ReadLine();

            cliente = servicio.BuscarId(id_cliente);
            if (cliente == null)
            {
                Console.Clear();
                Console.SetCursorPosition(10,5); Console.WriteLine("Cliente No Existe");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(23,6); Console.WriteLine(cliente.Nombre);

            string op = string.Empty;
            Console.SetCursorPosition(5,9); Console.Write("Desea Eliminar el Cliente s/n:");
            Console.SetCursorPosition(36,9); op = Console.ReadLine();
            if (op.ToUpper() == "S")
            {
                Console.SetCursorPosition(5,10); Console.Write(servicio.Eliminar(id_cliente));

            }
            else
            {
                return;
            }
            Console.ReadKey();
        }
        void MenuModificar()
        {
            Cliente cliente = new Cliente();
            string id_cliente;
           
            Console.Clear();
          
            Console.Write("Escriba el ID Cliente Que Desea Modificar: ");
            id_cliente = Console.ReadLine();

            cliente = servico.BuscarId(id_cliente);
            if (cliente == null)
            {
                Console.Clear();
                Console.WriteLine("Cliente no Existe");
                Console.ReadKey();
                return;
            }
            Console.Write("Nombre Cliente : ");
            Console.Write(cliente.Nombre);
            string op = string.Empty;
            Console.Write("\nDesea Modificar el Cliente s/n: ");
            op = Console.ReadLine();
            if (op.ToUpper() == "S")
            {
                Console.Write("\nEscriba el Nuevo ID: ");
                cliente.IdCliente = Console.ReadLine();
                Console.Write("\nEscriba el Nuevo Nombre: ");
                cliente.Nombre = Console.ReadLine();
                Console.Write(servico.Modificar(cliente));

            }
            else
            {
                return;
            }
            Console.ReadKey();
          

        }
    }
}
