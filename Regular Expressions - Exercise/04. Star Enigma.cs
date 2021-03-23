using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex lettersRegex = new Regex(@"[STARstar]");
            Regex messageRegex = new Regex(@"^[^\@\-\!\:\>]*\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>\d+)[^\@\-\!\:\>]*!(?<attack>[AD])![^\@\-\!\:\>]*\-\>(?<soldiers>\d+)[^\@\-\!\:\>]*$");

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                var matchedLetters = lettersRegex.Matches(input);

                int count = matchedLetters.Count;

                StringBuilder decryptMessages = new StringBuilder();

                foreach (var letter in input)
                {
                    decryptMessages.Append((char)(letter - count));
                }

                var matchedMessage = messageRegex.Match(decryptMessages.ToString());
                
                if (!matchedMessage.Success)
                {
                    continue;
                }

                if (matchedMessage.Groups["attack"].Value == "A")
                {
                    attackedPlanets.Add(matchedMessage.Groups["planet"].Value);
                }

                else
                {
                    destroyedPlanets.Add(matchedMessage.Groups["planet"].Value);
                }
            }

            attackedPlanets = attackedPlanets.OrderBy(o => o).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(o => o).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}