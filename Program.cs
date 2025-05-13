

namespace SeriesAnalyzerProgram
{

    // Main class for analyzing number series with multiple operations
    class SeriesAnalyzerProgram
    {
        // Static variable accessible for any function
        static List<double> numberSeries = new List<double>();
        static void Main(string[] args)
        {
            // Program manager, handling input, looping over menu
            Console.WriteLine("Welcome to the Series Analyzer!");

            // Initialize series from args
            if (args.Length > 0) numberSeries = ConvertArgsToSeries(args);

            // Ensure minimum element are 3
            if (numberSeries.Count < 3)
            {
                Console.WriteLine("Not enough numbers. Please enter a new series. ");
                numberSeries = NewInputSeries();
            }

            bool exit = false;

            // Main program loop
            while (!exit)
            {
                DisplayMenu();
                char option = GetMenuOption();
                // Process user selection and update series if neccessary
                exit = ProcessOption(option);

            }
            Console.WriteLine("Thanks for using Series Analyzer!");
        }

        // Input & Validation
        // Converts arfs to a list of positive numbers
        static List<double> ConvertArgsToSeries(string[] args)
        {
            List<double> series = new List<double>();
            foreach (string arg in args)
            {
                if (TryConvertPositiveNumbers(arg, out double number)) series.Add(number);
            }
            return series;
        }

        // Validates and parses input to ensure it's a positive number
        static bool TryConvertPositiveNumbers(string input, out double number)
        {
            bool valid = double.TryParse(input, out number) && number > 0;
            if (!valid) Console.WriteLine($"Invalid input {input}");
            return valid;
        }

        // Collects a new series of at least 3 positive numbers
        static List<double> NewInputSeries()
        {
            List<double> series = new List<double>();
            Console.WriteLine("Enter at least 3 positive numbers (Press ENTER or enter a non-number to stop)");

            // Collects numbers until user enters invalid input
            while (true)
            {
                Console.WriteLine($"Number {series.Count + 1}: ");
                string input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input) || !TryConvertPositiveNumbers(input, out double number))
                    break;
                series.Add(number);
            }

            // Ensure minimum element are 3
            while (series.Count < 3)
            {
                Console.WriteLine("Need at least 3 positive numbers. ");
                if (TryConvertPositiveNumbers(Console.ReadLine()!, out double number)) series.Add(number);
            }
            return series;
        }

        // Menu Handling
        // Displays the available operations menu
        static void DisplayMenu()
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("a. Input new series");
            Console.WriteLine("b. Show original");
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

        // Gets and validates a menu selection from the user
        static char GetMenuOption()
        {
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid option (a-j).");
                return GetMenuOption();
            }

            char option = input.ToLower()[0];
            if (option >= 'a' && option <= 'j')
            {
                return option;
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a letter between a and j.");
                return GetMenuOption();
            }
        }

        // Processes the user's menu selection and performs the right operation
        // Returns (exitMark, new series if exists)
        static bool ProcessOption(char option)
        {
            switch (option)
            {
                case 'a': numberSeries = NewInputSeries(); break;
                case 'b': ShowSeries(numberSeries, "Original"); break;
                case 'c': ShowSeries(GetReversed(numberSeries), "Reversed"); break;
                case 'd': ShowSeries(GetSorted(numberSeries), "Sorted"); break;
                case 'e': Console.WriteLine($"Max: {GetMax(numberSeries)}"); break;
                case 'f': Console.WriteLine($"Min: {GetMin(numberSeries)}"); break;
                case 'g': Console.WriteLine($"Average: {GetAverage(numberSeries)}"); break;
                case 'h': Console.WriteLine($"Count: {numberSeries.Count}"); break;
                case 'i': Console.WriteLine($"Sum: {GetSum(numberSeries)}"); break;
                case 'j': return true;
            }
            return false;
        }

        // Display
        // Formats and display a number series with a description
        static void ShowSeries(List<double> series, string label)
        {
            Console.WriteLine($"\n{label} Series: ");
            Console.Write("[ " + string.Join(", ", series) + " ]\n");
        }

        // Series Operations

        // Creates a new list with numbers in reversed order
        static List<double> GetReversed(List<double> series)
        {
            List<double> reversed = new List<double>();
            for (int i = series.Count - 1; i >= 0; i--) reversed.Add(series[i]);
            return reversed;
        }

        // Creates a new sorted list using bubble sort algorithm
        static List<double> GetSorted(List<double> series)
        {
            List<double> sorted = new List<double>(series);
            for (int i = 0; i < sorted.Count - 1; i++)
                for (int j = i + 1; j < sorted.Count; j++)
                    if (sorted[i] > sorted[j])
                        (sorted[i], sorted[j]) = (sorted[j], sorted[i]);
            return sorted;
        }

        // Returns max value in the series
        static double GetMax(List<double> series)
        {
            double max = series[0];
            foreach (var num in series) if (num > max) max = num;
            return max;
        }

        // Retuens min value in the series
        static double GetMin(List<double> series)
        {
            double min = series[0];
            foreach (var num in series) if (num < min) min = num;
            return min;
        }

        // Retuens average value in the series
        static double GetAverage(List<double> series) => GetSum(series) / series.Count;

        // Retuens sum of all values in the series
        static double GetSum(List<double> series)
        {
            double sum = 0;
            foreach (var num in series) sum += num;
            return sum;

        }

    }
}