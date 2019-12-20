using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{
    class Program
    {
        static double func;
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите уравнение: \n 1) x^4 - 14*x^3 + 60*x^2 - 70*x \n 2) 2*x^2 + 3*e^-x \n 3) 2*x^2 - e^x \n ");
            func = double.Parse(Console.ReadLine());
            primer1();
            Console.ReadKey();
        }

        static void primer1()
        {
            double z = 0, x, x1, x2, x3, x4, f2, f4, k;
            Console.WriteLine("Задайте N");
            int n = int.Parse(Console.ReadLine());
            int[] f = new int[n];
            f[0] = 1;
            f[1] = 1;
            for (int i = 2; i < n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            Console.WriteLine("Задайте эпсилон");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("Задайте интервал A, B");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            x1 = a;
            x3 = b;
            x2 = a + ((b - a) * f[n - 2] + e * Math.Pow((-1), n)) / f[n - 1];
            x = x2;
            if (func == 1)
            {
                z = Function1(x);
            }
            else if (func == 2)
            {
                z = Function2(x);
            }
            else if (func == 3)
            {
                z = Function3(x);
            }
            f2 = z;
            Console.WriteLine("Текущий интервал");
            k = 1;
            Console.WriteLine($"x1 = {x1}  x3 = {x3}");
            while (true)
            {
                x4 = x1 - x2 + x3;
                x = x4;
                if (func == 1)
                {
                    z = Function1(x);
                }
                else if (func == 2)
                {
                    z = Function2(x);
                }
                else if (func == 3)
                {
                    z = Function3(x);
                }

                f4 = z;
                if (f4 > f2)
                {
                    if (x2 < x4)
                    {
                        x3 = x4;
                        Console.WriteLine($"x1 = {x1}  x3 = {x3}");
                        k = k + 1;
                        if (k <= n)
                        {
                            continue;
                        }
                        else break;
                    }
                    else
                    {
                        x1 = x4;
                        Console.WriteLine($"x1 = {x1}  x3 = {x3}");
                        k = k + 1;
                        if (k <= n)
                        {
                            continue;
                        }
                        else break;
                    }
                }
                else if (x2 < x4)
                {
                    x1 = x2;
                    x2 = x4;
                    f2 = f4;
                    Console.WriteLine($"x1 = {x1}  x3 = {x3}");
                    k = k + 1;
                    if (k <= n)
                    {
                        continue;
                    }
                    else break;
                }
                else
                {
                    x3 = x2;
                    x2 = x4;
                    f2 = f4;
                    Console.WriteLine($"x1 = {x1}  x3 = {x3}");
                    k = k + 1;
                    if (k <= n)
                    {
                        continue;
                    }
                    else break;
                }

            }

            Console.WriteLine($"Конечный интервал: x1 = {x1}  x3 = {x3}");
            Console.WriteLine($"Значение функции равно: F = {f2}");

        }



        static double Function1(double x)
        {
            return Math.Pow(x, 4) - 14 * Math.Pow(x, 3) + 60 * Math.Pow(x, 2) - 70 * x;
        }

        static double Function2(double x)
        {
            return 2 * Math.Pow(x, 2) + 3 * Math.Exp(-x);

        }

        static double Function3(double x)
        {
            return 2 * Math.Pow(x, 2) - Math.Exp(x);
        }

    }
}
