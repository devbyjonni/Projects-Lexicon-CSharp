using System;

using ProductList.Controllers;

namespace ProductList
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