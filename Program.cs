using System;
using System.Collections.Generic;

namespace SeriesAnalyzerProgram
{
    class SeriesAnalyzerProgram
    {
        static void Main(string[] args)
        {
            // Program manager, handling input, looping over menu
            Console.WriteLine("Welcome to the Series Analyzer!");
            List<double> numberSeries = args.Length > 0 ? ConvertArgsToSeries(args) : new List<double>();

            if (numberSeries.Count < 3)
            {
                Console.WriteLine("Not enough numbers. Please enter a new series. ");
                numberSeries = NewInputSeries();
            }

            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                char option = GetMenuOption();
                (exit, List<double> newSeries) = ProcessOption(option, numberSeries);
                if (newSeries != null) numberSeries = newSeries;
            }
            Console.WriteLine("Thanks for using Series Analyzer!");
        }

        // Input & Validation
        static List<double> ConvertArgsToSeries(string[] args)
        {
            List<double> series = new List<double>();
            foreach (string arg in args)
            {
                if (TryConvertPositiveNumbers(arg, out double number)) series.Add(number);
            }
            return series;
        }

        static bool TryConvertPositiveNumbers(string input, out double number)
        {
            bool valid = double.TryParse(input, out number) && number > 0;
            if (!valid) Console.WriteLine($"Invalid input {input}");
            return valid;
        }

        static List<double> NewInputSeries()
        {
            List<double> series = new List<double>();
            Console.WriteLine("Enter at least 3 positive numbers (Press ENTER or enter a non-number to stop)");

            while (true)
            {
                Console.WriteLine($"Number {series.Count + 1}: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !TryConvertPositiveNumbers(input, out double number))
                    break;
                series.Add(number);
            }

            while (series.Count < 3)
            {
                Console.WriteLine("Need at least 3 positive numbers. ");
                if (TryConvertPositiveNumbers(Console.ReadLine()!, out double number)) series.Add(number);
            }
            return series;
        }

        // Menu Handling
        static void DisplayMenu()
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("a. Input new series");
            Console.WriteLine("b. Show oringinal");
            Console.WriteLine("c. Show reversed");
            Console.WriteLine("d. Show sorted");
            Console.WriteLine("e. Max value");
            Console.WriteLine("f. Min value");
            Console.WriteLine("g. Average");
            Console.WriteLine("h. Count");
            Console.WriteLine("i. Sum");
            Console.WriteLine("j. Exit");
            Console.WriteLine("Choose option (a-j)");
        }

        static char GetMenuOption()
        {

        }

        static (bool, List<double>) ProcessOption(char option, List<double> series)
        {

        }

        // Display
        static void ShowSeries(List<double> series, string label)
        {

        }

        // Series Operations
        static List<double> GetReversed(List<double> series)
        {

        }

        static List<double> GetSorted(List<double> series)
        {

        }

        static double GetMax(List<double> series)
        {

        }

        static double GetMin(List<double> series)
        {

        }

        static double GetAverage(List<double> series)
        {

        }

        static double GetSum(List<double> series)
        {

        }

    }
}