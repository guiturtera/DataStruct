using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Employee
    {
        public string Nome { get; private set; }
        public double Salario { get; private set; }

        public Employee(string nome, double salario)
        {
            this.Nome = nome;
            this.Salario = salario;
        }

        public override string ToString()
        {
            string text = "Nome: " + Nome + "\n";
            text += "Salário: " + Salario.ToString("0.000");
            return text;
        }
    }
}
