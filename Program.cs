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

        }

        static bool TryConvertPositiveNumbers(string input, out double number)
        {

        }

        static List<double> NewInputSeries()
        {

        }

        // Menu Handling
        static void DisplayMenu()
        {

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