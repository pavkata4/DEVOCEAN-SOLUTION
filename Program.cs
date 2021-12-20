using System;

namespace DevoceanSolutions
{
    class Program
    {
        public static double grossSalary;
        public static double netSalary;
        public static void inputGrossSalary() 
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    grossSalary = double.Parse(Console.ReadLine());
                    if (grossSalary <= 0)
                    {
                        throw new Exception("The gross salary must be > 0!");
                    }
                    isCorrect = true;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Invalid gross salary! {e.Message} Please enter a valid gross salary: ");
                    isCorrect = false;
                }
            }
            netSalary = grossSalary;
        }
        public static double incomeTax(double sum)
        {
            if (grossSalary > 1000)
            {
            double tax = (10.0 / 100.0) * (sum - 1000);
                Console.WriteLine($"Your income tax is {tax} IDR.");
                return tax;
            }
            Console.WriteLine($"You would not pay taxes, your net salary is {netSalary} IDR.");
            return 0;
               
        }
        public static double socialContributions(double sum)
        {
            if (grossSalary > 1000)
            {
                double tax;
                if (grossSalary >= 3000)
                {
                    tax = (15.0 / 100.0) * 2000;
                    Console.WriteLine($"Your social contributions are {tax} IDR.");
                    return tax;
                }
                tax = (15.0 / 100.0) * sum;
                Console.WriteLine($"Your social contributions are {tax} IDR.");
                return tax;
            }
            return 0;
        }
        public static void calculateNetSalary()
        {
            netSalary -= incomeTax(grossSalary);
            netSalary -= socialContributions(grossSalary);
            
        }
        static void Main(string[] args)
        {
            Console.Write("Please enter a gross salary: ");
            inputGrossSalary();
            calculateNetSalary();
        Console.WriteLine($"In total your tax is {grossSalary - netSalary} IDR. Your net salary is {netSalary} IDR.");
            
        }
    }
}
