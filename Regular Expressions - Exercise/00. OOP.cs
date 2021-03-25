using System;

namespace _00._OOP
{
    class Car
    {
        public string Model { get; set; }

        public string Color { get; set; }

        public int Year { get; set; }

        //public Car(string modelName, string modelColor, int modelYear)
        //{
        //    Model = modelName;
        //    Color = modelColor;
        //    Year = modelYear;
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Car ford = new Car();
            //ford.Model = "Mustang";

            //Car ford = new Car("Mustang", "Red", 1488);

            Car ford = new Car { Model = "Mustang", Color = "Red", Year = 1488 };

            Console.WriteLine(ford.Model);
        }
    }
}