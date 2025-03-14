/*
ProductList Console Application
2025-03-13
Jonni Akesson

This program allows users to enter product names in the format `NAME-XXX`. 
It validates the input based on predefined rules:
    - `NAME` must contain only letters and be a maximum of 4 characters long.
    - `XXX` must be a three-digit number between 200 and 500.
Invalid inputs display specific error messages, while valid entries are dynamically stored, sorted, and displayed at the end.
*/

using System;

class ProductList
{
    private string[] products = []; // Initialize an empty array
    private int productCount = 0; // Track the number of products

    // Configurable validation parameters
    private const int MAX_NAME_LENGTH = 4; // Maximum length for the name part
    private const int NUMBER_LENGTH = 3; // Exact length of the number part
    private const int MIN_NUMBER = 200; // Minimum allowed number
    private const int MAX_NUMBER = 500; // Maximum allowed number

    // Method to start the program logic
    public void Run()
    {
        PrintMessage("Skriv in produkter. Avsluta med att skriva 'exit'\n", ConsoleColor.Cyan);

        while (true)
        {
            string input = GetUserInput("Ange produkt (FORMAT: NAMN-XXX, t.ex. ABCD-400): ");

            if (string.IsNullOrEmpty(input))
            {
                PrintError("Fel: Produktnamnet får inte vara tomt.");
                continue;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (IsValidProduct(input))
            {
                AddProduct(input);
            }
        }

        DisplaySortedProducts();
    }

    // Get user input with a prompt
    private string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? "";
    }

    // Validate product format, length, and number range
    private bool IsValidProduct(string input)
    {
        string[] parts = input.Split('-');

        if (parts.Length != 2 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]))
        {
            PrintError("Fel: Produktnamnet måste innehålla exakt ett '-' och både namn och siffror måste vara ifyllda.");
            return false;
        }

        if (!IsValidNamePart(parts[0]) || !IsValidNumberPart(parts[1]))
        {
            return false;
        }

        int number = int.Parse(parts[1]);
        if (!IsNumberWithinRange(number))
        {
            PrintError($"Fel: Sifferdelen måste vara mellan {MIN_NUMBER} och {MAX_NUMBER}.");
            return false;
        }

        return true;
    }

    // Validate name part (only letters and max length)
    private bool IsValidNamePart(string name)
    {
        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH || !IsOnlyLetters(name))
        {
            PrintError($"Fel: Namndelen av produktnamnet får vara max {MAX_NAME_LENGTH} tecken lång och endast innehålla bokstäver.");
            return false;
        }
        return true;
    }

    // Validate number part (only digits and exact length)
    private bool IsValidNumberPart(string number)
    {
        if (!IsOnlyNumbers(number, NUMBER_LENGTH))
        {
            PrintError($"Fel: Sifferdelen av produktnamnet måste vara exakt {NUMBER_LENGTH} siffror lång.");
            return false;
        }
        return true;
    }

    // Ensure the number is within the valid range
    private bool IsNumberWithinRange(int number)
    {
        return number >= MIN_NUMBER && number <= MAX_NUMBER;
    }

    // Add a product to the list
    private void AddProduct(string product)
    {
        Array.Resize(ref products, productCount + 1);
        products[productCount] = product.ToUpper();
        productCount++;
    }

    // Check if a string contains only letters
    private static bool IsOnlyLetters(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }
        return true;
    }

    // Check if a string contains only numbers and has a required length
    private static bool IsOnlyNumbers(string input, int requiredLength)
    {
        return input.Length == requiredLength && int.TryParse(input, out _);
    }

    // Display sorted product list
    private void DisplaySortedProducts()
    {
        Array.Sort(products);
        PrintMessage("\nDu angav följande produkter (sorterade):", ConsoleColor.Green);
        foreach (var product in products)
        {
            PrintMessage($"* {product}", ConsoleColor.Green);
        }
    }

    // Print a message in a specific color
    private static void PrintMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    // Print an error message
    private static void PrintError(string message)
    {
        PrintMessage(message, ConsoleColor.Red);
    }
}

// Main program entry point
class Program
{
    static void Main()
    {
        ProductList productList = new ProductList();
        productList.Run();
    }
}
