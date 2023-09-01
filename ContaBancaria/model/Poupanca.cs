using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.model
{
    public class Poupanca : Conta
    {
        private int aniversario;

        public Poupanca(
            int numero, int agencia, int tipo, string titular, decimal saldo, int aniversario) : 
            base(numero, agencia, tipo, titular, saldo)
        {
            this.aniversario = aniversario;
        }

        public int GetAniversario() 
        {
            return this.aniversario;
        }

        public void SetAniversario(int aniversario) { this.aniversario = aniversario; }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine($"Aniversário da Conta: Dia {this.aniversario}");
        }
    }
}
