using System;
using ConsoleApp1.Services;
using ConsoleApp1.Entities;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;



namespace ConsoleApp1
{
    // delegate void BinaryNumericOperation(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            //double a = 10;
            //double b = 12;

            //BinaryNumericOperation op = CalculationService.ShowSum;

            ////double result = op.Invoke(a, b);
            //op += CalculationService.ShowMax;
            //op(a, b);

            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            list.RemoveAll(ProductTest);
            //list.RemoveAll(p => p.Price >= 100.0);
            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }


        }
        public static bool ProductTest(Product p)
        {
            return p.Price >= 100.0;
        }
    }
}
