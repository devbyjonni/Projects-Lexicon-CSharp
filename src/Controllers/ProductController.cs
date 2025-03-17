using System;
using System.Text.RegularExpressions;

namespace ProductList.Controllers
{
    public class ProductController
    {
        private readonly Regex productRegex;
        private string[] products;
        private int productCount;

        // Constructor
        public ProductController(int initialSize = 10)
        {
            Console.Title = "Produktlista";

            // Initialize the regex for product format validation
            // Regular expression for validation
            /*
               Validation Rules:
               - The name part (4 letters) must only contain uppercase or lowercase letters (A-Z, a-z).
               - The number part (3 digits) must be between 200 and 500.
               - The format must be NAME-XXX (e.g., "ABCD-250").
            */
            productRegex = new Regex(@"^[A-Za-z]{4}-[2-5][0-9]{2}$");
            products = new string[initialSize];
            productCount = 0;
        }

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

        public bool IsValidProduct(string input)
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
            // Only resize when the array is full (resize when productCount reaches the array's length)
            if (productCount >= products.Length)
            {
                Array.Resize(ref products, products.Length * 2);  // Double the size when the array is full
            }

            products[productCount] = product.ToUpper();
            productCount++;
        }

        private void DisplaySortedProducts()
        {
            Array.Sort(products, 0, productCount);  // Sort only the populated portion of the array
            PrintMessage("\nDu angav följande produkter (sorterade):", ConsoleColor.Green);
            for (int i = 0; i < productCount; i++)  // Only display the products that have been added
            {
                PrintMessage($"* {products[i]}", ConsoleColor.Green);
            }
        }

        private void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private void PrintError(string message)
        {
            PrintMessage(message, ConsoleColor.Red);
        }
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