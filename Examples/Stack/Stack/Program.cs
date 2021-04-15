using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linear_data_struct;

namespace Stack
{
    // This example will use StaticStack, although it should will work with any other class with IStack implemented.
    // It's not focused on SOLID patterns, so don't follow this as a base design project!!
    class Program
    {
        static StaticStack<Employee> employee;
        static void Main(string[] args)
        {
            employee = new StaticStack<Employee>();
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("Type: ");
                Console.WriteLine("A- Add new employee");
                Console.WriteLine("B- List employee");
                Console.WriteLine("C- Show wages sum");
                Console.WriteLine("D- Delete stack base");
                Console.WriteLine("E- Exit");

                key = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine();

                if (key == ConsoleKey.A)
                    employee.Push(AddNewEmployee());
                else if (key == ConsoleKey.B)
                {
                    ListStackData<Employee>(employee);
                    Console.ReadKey();
                }
                else if (key == ConsoleKey.C)
                {
                    ShowSumOfWages(employee);
                    Console.ReadKey();
                }
                else if (key == ConsoleKey.D)
                    RemoveStackBottom<Employee>(employee);

            } while (key != ConsoleKey.E);

        }

        static void ListStackData<T>(StaticStack<T> stack)
        {
            int initialCounter = stack.Count;
            T[] aux = new T[initialCounter];
            for (int i = 0; i < initialCounter; i++)
            {
                aux[i] = stack.Pop();
                Console.WriteLine(aux[i].ToString());
                Console.WriteLine();
            }

            for (int i = initialCounter - 1; i >= 0; i--)
            {
                Console.WriteLine();
                stack.Push(aux[i]);
            }
        }

        static public void ShowSumOfWages(StaticStack<Employee> employees)
        {
            int initialCounter = employees.Count;
            double sum = 0;
            Employee[] aux = new Employee[initialCounter];
            for (int i = 0; i < initialCounter; i++)
            {
                aux[i] = employees.Pop();
                sum += aux[i].Salario;
            }

            for (int i = initialCounter - 1; i >= 0; i--)
            {
                employees.Push(aux[i]);
            }

            Console.WriteLine(sum.ToString());
        }

        static public void RemoveStackBottom<T>(StaticStack<T> stack)
        {
            int initialCounter = stack.Count;
            T[] aux = new T[initialCounter];
            for (int i = 0; i < initialCounter; i++)
            {
                aux[i] = stack.Pop();
            }

            for (int i = initialCounter - 2; i >= 0; i--)
            {
                stack.Push(aux[i]);
            }
        }

        static Employee AddNewEmployee()
        {
            string name;
            double wage;

            do
            {
                Console.WriteLine("Escreva o nome do funcionário: ");
                name = Console.ReadLine();
            } while (name == "");

            string salarioAux;
            do
            {
                Console.WriteLine("Escreva o salário do funcionário: ");
                salarioAux = Console.ReadLine();
            } while (!double.TryParse(salarioAux, out wage));

            return new Employee(name, wage);
        }
    }
}
