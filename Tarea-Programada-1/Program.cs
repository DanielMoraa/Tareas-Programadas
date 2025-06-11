using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_FI23030542
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un entero entre 2 y 45: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int n) || n < 2 || n > 45)
            {
                Console.WriteLine("El valor está fuera de rango!");
                return;
            }

            double phi = (1 + Math.Sqrt(5)) / 2;
            Console.WriteLine($"Phi ~ {phi}");

            int[] fibonacci = new int[n + 1];
            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                double division = (double)fibonacci[i] / fibonacci[i - 1];
                double diferencia = Math.Abs(division - phi);
                Console.WriteLine($"Fib({i}) / Fib({i - 1}) ~ {division} [+- {diferencia}]");
            }
            
            // 3. Mostrar Fib(n) y Fib(n-1)
            Console.WriteLine($"Fib({n}) = {fibonacci[n]}");
            Console.WriteLine($"Fib({n - 1}) = {fibonacci[n - 1]}");

        }
    }
}
