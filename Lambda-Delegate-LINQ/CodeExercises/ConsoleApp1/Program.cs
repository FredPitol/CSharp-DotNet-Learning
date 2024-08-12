using System;
using ConsoleApp1.Services;
namespace ConsoleApp1
{
    delegate void BinaryNumericOperation(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            BinaryNumericOperation op = CalculationService.ShowSum;

            //double result = op.Invoke(a, b);
            op += CalculationService.ShowMax;
            op(a, b);
        }
    }
}