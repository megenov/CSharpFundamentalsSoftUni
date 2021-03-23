using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = new Dictionary<string, int>();

            string[] participants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in participants)
            {
                racers.Add(item, 0);
            }

            Regex letters = new Regex(@"[A-Za-z]");
            Regex numbers = new Regex(@"\d");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                var name = letters.Matches(input);
                var score = numbers.Matches(input);

                StringBuilder currName = new StringBuilder();
                foreach (Match item in name)
                {
                    currName.Append(item.Value);
                }

                int currScore = 0;
                foreach (Match item in score)
                {
                    currScore += int.Parse(item.Value);
                }

                if (racers.ContainsKey(currName.ToString()))
                {
                    racers[currName.ToString()] += currScore;
                }
            }

            racers = racers.OrderByDescending(o => o.Value)
                .Take(3)
                .ToDictionary(t => t.Key, t => t.Value);

            Console.WriteLine($"1st place: {racers.Keys.ElementAt(0)}");
            Console.WriteLine($"2nd place: {racers.Keys.ElementAt(1)}");
            Console.WriteLine($"3rd place: {racers.Keys.ElementAt(2)}");
        }
    }
}