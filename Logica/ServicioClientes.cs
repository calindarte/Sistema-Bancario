using System;
using System.Collections.Generic;
using Entidades;
using Datos;
namespace Logica
{
    public class ServicioClientes
    {
        RepositorioClientes repositorio = new RepositorioClientes(); 
        List<Cliente> ListaClientes;
        public ServicioClientes()
        {
            ListaClientes = repositorio.Consultar(); 
        }
        void Actualizar()
        {
            ListaClientes = repositorio.Consultar();
        }
        public string Guardar(Cliente cliente)
        {
            
            return repositorio.Guardar(cliente); 

        }
        public List<Cliente> Consultar()
        {
            Actualizar();
            return ListaClientes;
        }
        public Cliente BuscarId(string id)
        {
            foreach (var item in ListaClientes)
            {
                if (item.IdCliente==id)
                {
                    return item;
                }
            }
            return null;
        }
        public string Eliminar(string identificacion)
        {
            Cliente cliente = BuscarId(identificacion);
            if (cliente == null)
            {
                return "Cliente No Existe";
            }
            else
            {
                ListaClientes.Remove(cliente);

                repositorio.Modificar2(ListaClientes);
                return "Cliente Eliminado";
            }
        }

        public string Modificar(Cliente cliente_New)
        {
            Cliente cliente_actual = BuscarId(cliente_New.IdCliente);
            if (cliente_actual == null)
            {
                return Guardar(cliente_New);

            }
            else
            {
                cliente_actual.Nombre = cliente_New.Nombre;
                return repositorio.Modificar2(ListaClientes);
            }


        }
    }
}
