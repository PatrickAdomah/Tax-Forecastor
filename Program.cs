using System;

namespace TaxForecastor2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to the 2020/21 Tax Forecaster ");
            Console.Write("Enter your income: ");
            double income = double.Parse(Console.ReadLine());

            double IncomeTax = income_tax(income);
            double NI = ni_tax(income);

            Console.WriteLine("Your predicted tax bill is £{0} per year or £{1} per month",IncomeTax.ToString("#.##"),(IncomeTax/12).ToString("#.##"));
            Console.WriteLine("Your predicted national insurance payment is £{0} per year or £{1} per month", NI.ToString("#.##"), (NI/ 12).ToString("#.##"));
            Console.WriteLine("Your predicted total tax bill is £{0} per year or £{1} per month", (IncomeTax + NI).ToString("#.##"), ((IncomeTax + NI) / 12).ToString("#.##"));

        }

        static double income_tax(double income) {
            const int personal = 12500;
            double taxable = income - personal;

            if (income < personal)
            {
                return 0;
            }
            else if (income > personal + 1 && income <= 50000)
            {
                double tax = taxable * 0.2;
                return tax;
            }
            else if (income > 50001 && income < 150000)
            {
                double basic = 37500 * 0.2;
                double high = (income - (37500 + personal)) * 0.4;
                double total = basic + high;
                return total;

            }
            else if (income > 150001)
            {
                double basic = 37500 * 0.2;
                double high = 100000 * 0.4;
                double highhigh_tax = (income - 150000) * 0.45;
                double total = basic + high + highhigh_tax;;
                return total;
            }
            else {
                return 0;
            }
        }

        static double ni_tax(double income) {
            if (income >= 8628 && income <= 49512)
            {
                double ni_tax = (income - 8628) * 0.12;
                return ni_tax;
            }
            else if (income > 49512)
            {
                double ni_tax = 40884 * 0.12;
                double higher_tax = (income - (40884 + 8628)) * 0.02;
                double total = ni_tax + higher_tax;
                return total;
            }
            else {
                return 0;
            }
        }
    }
}
