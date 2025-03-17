using System;

using ProductList.Controllers;

namespace ProductList.App
{
    class Program
    {
        static void Main()
        {
            ProductController productController = new ProductController();
            productController.Run();
        }
    }
}