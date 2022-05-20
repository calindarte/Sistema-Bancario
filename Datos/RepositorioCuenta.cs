using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Datos
{
    public class RepositorioCuenta
    {
        string ruta = "Cuentas.txt";
        RepositorioClientes repositorioCliente = new RepositorioClientes();
        public string Guardar(Entidades.Cuenta cuenta)
        {
            try
            {
                
                StreamWriter escritor = new StreamWriter(ruta, true);

                
                escritor.WriteLine(cuenta.ToString());

                
                escritor.Close();

                return "Se guardaron los datos";
            }
            catch (Exception)
            {
                return "NO Se guardaron los datos";
            }

        }
        public string Modificar(List<Entidades.Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    
                }

                escritor.Close();

                return "Se modificaron los datos los datos";

                
            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        public string Modificar2(List<Entidades.Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt", true);
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                File.Delete(ruta);  
                File.Move("tmp.txt", ruta);

                return "Se modificaron los datos los datos";

            }
            catch (Exception)
            {

                return "NO Se guardaron los datos";
            }

        }
        public List<Entidades.Cuenta> Consultar()
        {
            try
            {
                
                StreamReader lector = new StreamReader(ruta);
                List<Entidades.Cuenta> cuentas = new List<Entidades.Cuenta>();
                
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();

                    string numCuenta = linea.Split(';')[0];
                    Entidades.Cliente cliente = repositorioCliente.buscarId(linea.Split(';')[1]);
                    
                    
                    double saldo = double.Parse( linea.Split(';')[2]);

                    Entidades.Cuenta cuenta = new Entidades.Cuenta(numCuenta, cliente, saldo);
                    cuentas.Add(cuenta);

                }

               
                lector.Close();

                return cuentas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Entidades.Cuenta buscarId(string id)
        {
            foreach (var item in Consultar())
            {
                if (item.NumeroCuenta == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
