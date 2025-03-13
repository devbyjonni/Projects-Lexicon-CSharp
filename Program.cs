using System;

// Level 2: Improved input handling (case insensitivity, trimming)

string[] products = new string[0];
int count = 0;

Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'\n");

while (true)
{
    Console.Write("Ange produkt: ");
    string input = Console.ReadLine()?.Trim() ?? ""; // Trim spaces and handle null input

    // Allow 'exit' in any case
    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    // Increase array size after valid input
    Array.Resize(ref products, count + 1);
    products[count] = input;
    count++;
}

// Sort the array alphabetically
Array.Sort(products);

// Display the entered products
Console.WriteLine("\nDu angav följande produkter (sorterade):");
foreach (var product in products)
{
    Console.WriteLine($"* {product}");
}
