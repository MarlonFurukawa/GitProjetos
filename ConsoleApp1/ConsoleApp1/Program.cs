using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] v = { 5, 1, 4, 2, 7, 8, 3, 6 };
            //int aux;
            //for (int i = 7; i >= 4; i--)
            //{
            //    aux = v[i];
            //    v[i] = v[7 - i];
            //    v[7 - i] = aux;
            //}

            //v[2] = v[0];
            //v[v[2]] = v[v[1]];
            //Console.WriteLine(v);
            int[] a = { 1, 3, 2, 4, 5 };
            int[] b = { 2, 4, 2, 4, 3 };
            int[] c = { 3, 5, 4, 4, 3 };

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < b[i] + c[i] && (b[i] < a[i] + c[i]) && (c[i] < a[i] + b[i]))
                {
                    if ((a[i] == b[i]) && (b[i] == c[i]))
                    {
                        Console.WriteLine("Triângulo Equilátero");
                    }
                    else if ((a[i] == b[i]) || (b[i] == c[i]) || (a[i] == c[i]))
                    {
                        Console.WriteLine("Triângulo Isósceles");
                    }
                    else
                    {
                        Console.WriteLine("Triângulo Escaleno");
                    }
                }
                else
                {
                    Console.WriteLine("Não é possível formar um triângulo");
                }
            }
        }
    }
}
