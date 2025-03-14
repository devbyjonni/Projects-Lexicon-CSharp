using System;
using System.Text.RegularExpressions;

class ProductList
{
    // Regular expression for validation
    /*
       Validation Rules:
       - The name part (4 letters) must only contain uppercase or lowercase letters (A-Z, a-z).
       - The number part (3 digits) must be between 200 and 500.
       - The format must be NAME-XXX (e.g., "ABCD-250").
    */
    private static readonly Regex productRegex = new(@"^[A-Za-z]{4}-[2-5][0-9]{2}$");

    private string[] products = [];
    private int productCount = 0;

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

    private string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? "";
    }

    private bool IsValidProduct(string input)
    {
        if (!productRegex.IsMatch(input))
        {
            PrintError("Fel: Ogiltigt format. Exempel på korrekt format: ABCD-250.");
            return false;
        }
        return true;
    }

    private void AddProduct(string product)
    {
        Array.Resize(ref products, productCount + 1);
        products[productCount] = product.ToUpper();
        productCount++;
    }

    private void DisplaySortedProducts()
    {
        Array.Sort(products);
        PrintMessage("\nDu angav följande produkter (sorterade):", ConsoleColor.Green);
        foreach (var product in products)
        {
            PrintMessage($"* {product}", ConsoleColor.Green);
        }
    }

    private static void PrintMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void PrintError(string message)
    {
        PrintMessage(message, ConsoleColor.Red);
    }
}

class Program
{
    static void Main()
    {
        ProductList productList = new ProductList();
        productList.Run();
    }
}

// Test Cases for Product Validation
// ---------------------------------
// ✅ Valid cases:
//   ABCD-200   -> ✅ Valid (4 letters, 3 digits between 200-500)
//   XYZW-450   -> ✅ Valid (4 letters, 3 digits between 200-500)
// ❌ Invalid cases:
//   ABCDE-200  -> ❌ Too many letters
//   XYZ-199    -> ❌ Number below 200
//   A1B2-300   -> ❌ Name contains numbers
//   ABC-4000   -> ❌ Number too long
//   --         -> ❌ Invalid format
