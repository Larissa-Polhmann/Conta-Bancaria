using Banco.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Classes
{
    public class Conta
    {
        //ATRIBUTOS
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        //CONSTRUTOR
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *- 1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo = this.Saldo - valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1} ", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1} ", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo conta: " + this.TipoConta; 
            retorno += "\nNome: " + this.Nome;
            retorno += "\nSaldo: " + this.Saldo;
            retorno += "\nCrédito: " + this.Credito;
            return retorno;
        }
    }
}
