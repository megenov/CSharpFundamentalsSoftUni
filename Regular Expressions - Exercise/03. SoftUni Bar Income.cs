using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Custumer
    {
        public string name { get; set; }

        public string product { get; set; }

        public int count { get; set; }

        public double price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Regex productsRegex = new Regex(@"^[^\|\$\%\.]*\%(?<name>[A-Z][a-z]+)\%[^\|\$\%\.]*\<(?<product>\w+)\>[^\|\$\%\.]*\|(?<count>\d+)\|[^\|\$\%\.]*?(?<price>\d+.?\d+)\$$");

            List<Custumer> customers = new List<Custumer>();

            double totalPrice = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                var matchedProducts = productsRegex.Match(input);

                if (!matchedProducts.Success)
                {
                    continue;
                }

                string names = matchedProducts.Groups["name"].Value;
                string products = matchedProducts.Groups["product"].Value;
                int counts = int.Parse(matchedProducts.Groups["count"].Value);
                double prices = double.Parse(matchedProducts.Groups["price"].Value);

                Custumer customer = new Custumer
                {
                    name = names,
                    product = products,
                    count = counts,
                    price = prices
                };

                customers.Add(customer);

                totalPrice += (counts * prices);

                //Console.WriteLine($"{names}: {products} - {(counts * prices):f2}");
            }

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.name}: {customer.product} - {customer.count * customer.price :f2}");
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}