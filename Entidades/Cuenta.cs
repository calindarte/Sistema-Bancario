using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cuenta
    {
        public Cuenta(string numeroCuenta, Cliente cliente, double saldo)
        {
            NumeroCuenta = numeroCuenta;
            Cliente = cliente;
            Saldo = saldo;
        }
        public Cuenta()
        {

        }

        public string NumeroCuenta { get; set; }
        public Cliente Cliente { get; set; }
        private double Saldo;
        public double  getSaldo()
        {
            return Saldo;
        }
        
        public string Consignar(double valor)
        {
            Saldo += valor;
            return "Consignacion exitosa";
        }
        public string Retirar(double valor)
        {
            if (Saldo < valor)
            {
                return "Fondos insuficiente";
            }
            Saldo -= valor;
            return "Retiro exitoso";
        }
        public override string ToString()
        {
            return NumeroCuenta.ToString() + ";" + Cliente.IdCliente + ";" + Saldo.ToString();
        }
    }
}
