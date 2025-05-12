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
            string input = Console.ReadLine()!.ToLower();
            return (input.Length == 1 && input[0] >= 'a' && input[0] <= 'z') ? input[0] : GetMenuOption();
        }

        static (bool, List<double>) ProcessOption(char option, List<double> series)
        {
            switch (option)
            {
                case 'a': return (false, NewInputSeries());
                case 'b': ShowSeries(series, "Original"); break;
                case 'c': ShowSeries(GetReversed(series), "Reversed"); break;
                case 'd': ShowSeries(GetSorted(series), "Sorted"); break;
                case 'e': Console.WriteLine($"Max: {GetMax(series)}"); break;
                case 'f': Console.WriteLine($"Min: {GetMin(series)}"); break;
                case 'g': Console.WriteLine($"Average: {GetAverage(series)}"); break;
                case 'h': Console.WriteLine($"Count: {series.Count}"); break;
                case 'i': Console.WriteLine($"Sum: {GetSum(series)}"); break;
                case 'j': return (true, null);
            }
            return (false, null);
        }

        // Display
        static void ShowSeries(List<double> series, string label)
        {
            Console.WriteLine($"\n{label} Series: ");
            Console.Write("[ " + string.Join(", ", series) + " ]\n");
        }

        // Series Operations
        static List<double> GetReversed(List<double> series)
        {
            List<double> reversed = new List<double>();
            for (int i = series.Count - 1; i >= 0; i--) reversed.Add(series[i]);
            return reversed;
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