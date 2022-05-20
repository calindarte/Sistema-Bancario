using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class RepositorioClientes
    {
        string ruta = "Clientes.txt";
        public string Guardar(Cliente cliente)
        {
            try
            {
                
                StreamWriter escritor = new StreamWriter(ruta, true);

               
                escritor.WriteLine(cliente.ToString());
                
                
                escritor.Close();
                                
                return "Se Guardaron Los Datos";
            }
            catch (Exception)
            {
                return "No Se Guardaron Los Datos";
            }

        }
        public string Modificar(List<Cliente> clientes)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                return "Se Modificaron Los Datos";

               
            }
            catch (Exception)
            {

                return "No Se Guardaron Los Datos";
            }

        }
        public string Modificar2(List<Entidades.Cliente> clientes)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt", true);
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                File.Delete(ruta); 
                File.Move("tmp.txt", ruta);

                return "Se Modificaron Los Datos";
                               
            }
            catch (Exception)
            {

                return "No Se Guardaron Los Datos";
            }

        }
        public List<Cliente> Consultar()
        {
            try
            {
               
                StreamReader lector = new StreamReader(ruta);
                List<Entidades.Cliente> clientes = new List<Entidades.Cliente>();   
                // 2. operaciones
                string linea= string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();

                    Cliente cliente = new Entidades.Cliente();
                    cliente.IdCliente= linea.Split(';')[0];
                    cliente.Nombre = linea.Split(';')[1];
                    clientes.Add(cliente);

                    
                }

                
                lector.Close();

                return clientes;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Entidades.Cliente buscarId(string id)
        {
            foreach (var item in Consultar())
            {
                if (item.IdCliente== id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
