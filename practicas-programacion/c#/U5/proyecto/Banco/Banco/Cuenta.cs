using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    public abstract class Cuenta
    {
        protected Cliente cliente;
        protected string numero;
        protected double saldo;
        protected string nip;
        protected string tipo;
        protected List<Operacion> operaciones;
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Nip { get => nip; set => nip = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public List<Operacion> Operaciones { get => operaciones; set => operaciones = value; }

        public Cuenta(string numero, Cliente cliente, string nip)
        {
            this.numero = numero;
            this.cliente = cliente;
            Operaciones = new List<Operacion>();
            this.nip = nip;
            tipo = "Cuenta";
        }
        public abstract void Estado();
        public abstract double Depositar(double cantidad);
        public abstract double Retirar(double cantidad);
        public abstract double PagoServicio(double cantidad, string servicio);
    }
}
