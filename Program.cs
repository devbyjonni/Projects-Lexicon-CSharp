using System;

// Level 1: Simple product list without classes or error handling

string[] products = new string[0];
int count = 0;

Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'\n");

while (true)
{
    Console.Write("> ");
    string input = Console.ReadLine();

    if (input.ToLower() == "exit")
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
Console.WriteLine("\nDu angav följande produkter:");
foreach (var product in products)
{
    Console.WriteLine($"* {product}");
}
