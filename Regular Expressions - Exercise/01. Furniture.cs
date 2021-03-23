using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex furnitureRegex = new Regex(@">>(?<furniture>[A-Z]{1,2}[a-z]*)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)");

            List<string> furniture = new List<string>();
            double totalMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                var machedFurnitures = furnitureRegex.Match(input);

                if (!machedFurnitures.Success)
                {
                    continue;
                }

                string currFurniture = machedFurnitures.Groups["furniture"].Value;
                string currPrice = machedFurnitures.Groups["price"].Value;
                string currQuantity = machedFurnitures.Groups["quantity"].Value;

                totalMoney += double.Parse(currPrice) * double.Parse(currQuantity);

                furniture.Add(currFurniture);
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}