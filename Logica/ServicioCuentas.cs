using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
namespace Logica
{
    public class ServicioCuentas
    {
        Datos.RepositorioCuenta repositorio = new Datos.RepositorioCuenta();
        List<Cuenta> ListaCuentas;
        public ServicioCuentas()
        {
            ListaCuentas = repositorio.Consultar();
        }
        void Actualizar()
        {
            ListaCuentas = repositorio.Consultar();
        }
        public string Guardar(Cuenta cuenta)
        {
           
            return repositorio.Guardar(cuenta);

        }
        public List<Cuenta> Consultar()
        {
            Actualizar();
            return ListaCuentas;
        }

        public Cuenta BuscarId(string id)
        {
            foreach (var item in ListaCuentas)
            {
                if (item.NumeroCuenta == id)
                {
                    return item;
                }
            }
            return null;
        }
        public string Eliminar (string id)
        {
            Entidades.Cuenta cuenta = BuscarId(id);
            if (cuenta == null)
            {
                return "Cuenta No Existe";
            }


            else
            {
                ListaCuentas.Remove(cuenta);

                repositorio.Modificar2(ListaCuentas);
                return "Cuenta Eliminada";
            }
        }

        public string Modificar (Cuenta cuenta_New)
        {
            Cuenta cuenta_actual = BuscarId(cuenta_New.NumeroCuenta);
            if (cuenta_actual == null)
            {
                return Guardar(cuenta_New);

            }
            else
            {
                cuenta_actual.Cliente = cuenta_New.Cliente;
                return repositorio.Modificar2(ListaCuentas);
            }


        }
    }

}
