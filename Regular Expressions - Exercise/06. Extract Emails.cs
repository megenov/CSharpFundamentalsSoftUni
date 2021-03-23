using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex emailRegex = new Regex(@"(^|\ )(?<email>[A-Za-z\d]+[\.\-_]?[A-Za-z\d]+\@[A-Za-z]+[\.\-]?[A-Za-z]+\.[A-Za-z]+[\.]?[A-Za-z]+)");

            var matchedEmails = emailRegex.Matches(text);

            foreach (Match item in matchedEmails)
            {
                Console.WriteLine(item.Groups["email"].Value);
            }
        }
    }
}