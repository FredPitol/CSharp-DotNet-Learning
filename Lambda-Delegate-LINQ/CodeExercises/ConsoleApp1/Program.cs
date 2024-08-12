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
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));


            //Action<Product> act = p => { p.Price += p.Price * 0.1; };

            //list.ForEach(act);

            // lambda Inline
            list.ForEach(p => { p.Price += p.Price * 0.1; });

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

        }
    }
}
