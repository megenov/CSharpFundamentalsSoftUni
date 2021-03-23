using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Deamon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            Regex healthRegex = new Regex(@"[^0-9\+\-\*\/\.]");
            Regex damageRegex = new Regex(@"\+?\-?\d*\.?\d+");
            Regex mathRegex = new Regex(@"[\*\/]");

            List<Deamon> deamons = new List<Deamon>();

            for (int i = 0; i < input.Length; i++)
            {
                var matchedHealth = healthRegex.Matches(input[i]);
                int deamonHealth = 0;
                foreach (Match item in matchedHealth)
                {
                    deamonHealth += Convert.ToChar(item.Value);
                }

                var matchedDamage = damageRegex.Matches(input[i]);
                double deamonDamage = 0;
                foreach (Match item in matchedDamage)
                {
                    deamonDamage += double.Parse(item.Value);
                }

                var matchedMath = mathRegex.Matches(input[i]);
                foreach (Match item in matchedMath)
                {
                    if (item.Value == "*")
                    {
                        deamonDamage *= 2;
                    }
                    else
                    {
                        deamonDamage /= 2;
                    }
                }

                Deamon deamon = new Deamon
                {
                    Name = input[i],
                    Health = deamonHealth,
                    Damage = deamonDamage
                };

                deamons.Add(deamon);
            }

            deamons = deamons.OrderBy(o => o.Name).ToList();

            foreach (var deamon in deamons)
            {
                Console.WriteLine($"{deamon.Name} - {deamon.Health} health, {deamon.Damage:f2} damage");
            }
        }
    }
}