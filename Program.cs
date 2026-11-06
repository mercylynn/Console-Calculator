public class Calculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Console Calculator & Unit Converter\n");

        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Kilometres <-> Miles");
            Console.WriteLine("3. Celsius <-> Fahrenheit");
            Console.WriteLine("4. GHS to USD");
            Console.Write("Choose 1, 2, 3 or 4: ");
            string? choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    RunCalculator();
                    break;
                case "2":
                    ConvertDistance();
                    break;
                case "3":
                    ConvertTemperature();
                    break;
                case "4":
                    ConvertGhsToUsd();
                    break;
                default:
                    Console.WriteLine("Error: Invalid choice. Please type 1, 2, 3 or 4.");
                    break;
            }

            Console.Write("\nDo you want to perform another calculation? (y to continue, n to exit): ");
            string? response = Console.ReadLine()?.Trim().ToLower();

            if (response != "y")
            {
                Console.WriteLine("Thank you for using the calculator");
                continueRunning = false;
            }
        }
    }

    // Validate number
    static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double value) && double.IsFinite(value))
            {
                return value;
            }
            Console.WriteLine("That is not a valid number. Please try again.");
        }
    }

    static void RunCalculator()
    {
        double number1 = ReadNumber("Enter Num1: ");

        string operation;
        while (true)
        {
            Console.WriteLine("Operators: *, -, *, /");
            Console.Write("Enter Operator: ");
            operation = (Console.ReadLine() ?? "").Trim().ToLower();

            if (operation == "+" || operation == "-" ||
                operation == "*" || operation == "/")
            {
                break;
            }
            Console.WriteLine("Error: Unsupported operator. Please try again.");
        }

        double number2 = ReadNumber("Enter Num2: ");

        switch (operation)
        {
            case "+":
                Console.WriteLine($"Result: {Math.Round(number1 + number2, 2)}");
                break;
            case "-":
                Console.WriteLine($"Result: {Math.Round(number1 - number2, 2)}");
                break;
            case "*":
                Console.WriteLine($"Result: {Math.Round(number1 * number2, 2)}");
                break;
            case "/":
                if (number2 != 0)
                    Console.WriteLine($"Result: {Math.Round(number1 / number2, 2)}");
                else
                    Console.WriteLine("Error: Division by zero is not allowed.");
                break;
        }
    }

    static void ConvertDistance()
    {
        Console.Write("Convert from (km or miles): ");
        string from = (Console.ReadLine() ?? "").Trim().ToLower();

        if (from == "km")
        {
            double km = ReadNumber("Enter the distance in kilometres: ");
            Console.WriteLine($"Result: {km} km = {Math.Round(km * 0.621371, 2)} miles");
        }
        else if (from == "miles")
        {
            double miles = ReadNumber("Enter the distance in miles: ");
            Console.WriteLine($"Result: {miles} miles = {Math.Round(miles * 1.609344, 2)} km");
        }
        else
        {
            Console.WriteLine("Error: Please type km or miles.");
        }
    }

    static void ConvertTemperature()
    {
        Console.Write("Convert from (c or f): ");
        string from = (Console.ReadLine() ?? "").Trim().ToLower();

        if (from == "c")
        {
            double celsius = ReadNumber("Enter the temperature in Celsius: ");
            Console.WriteLine($"Result: {celsius} C = {Math.Round(celsius * 9 / 5 + 32, 2)} F");
        }
        else if (from == "f")
        {
            double fahrenheit = ReadNumber("Enter the temperature in Fahrenheit: ");
            Console.WriteLine($"Result: {fahrenheit} F = {Math.Round((fahrenheit - 32) * 5 / 9, 2)} C");
        }
        else
        {
            Console.WriteLine("Error: Please type c or f.");
        }
    }

    static void ConvertGhsToUsd()
    {
        double rate = ReadNumber("Enter the rate (how many GHS equal 1 USD): ");
        if (rate <= 0)
        {
            Console.WriteLine("Error: The rate must be greater than zero.");
            return;
        }

        double ghs = ReadNumber("Enter the amount in GHS: ");
        Console.WriteLine($"Result: GHS {ghs} = USD {Math.Round(ghs / rate, 2)}");
    }
}