using Xunit;
using ProductList.Controllers;

namespace ProductList.Tests
{
    public class ProductControllerTests
    {
        private ProductController _controller;

        public ProductControllerTests()
        {
            _controller = new ProductController();
        }

        // Valid product cases
        [Fact]
        public void TestIsValidProduct_ValidProduct1_ReturnsTrue()
        {
            // Arrange
            string validProduct = "ABCD-200";

            // Act
            bool result = _controller.IsValidProduct(validProduct);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestIsValidProduct_ValidProduct2_ReturnsTrue()
        {
            // Arrange
            string validProduct = "XYZW-450";

            // Act
            bool result = _controller.IsValidProduct(validProduct);

            // Assert
            Assert.True(result);
        }

        // Invalid product cases
        [Fact]
        public void TestIsValidProduct_InvalidProductTooManyLetters_ReturnsFalse()
        {
            // Arrange
            string invalidProduct = "ABCDE-200";

            // Act
            bool result = _controller.IsValidProduct(invalidProduct);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidProduct_InvalidProductNumberBelow200_ReturnsFalse()
        {
            // Arrange
            string invalidProduct = "XYZ-199";

            // Act
            bool result = _controller.IsValidProduct(invalidProduct);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidProduct_InvalidProductNameContainsNumbers_ReturnsFalse()
        {
            // Arrange
            string invalidProduct = "A1B2-300";

            // Act
            bool result = _controller.IsValidProduct(invalidProduct);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidProduct_InvalidProductNumberTooLong_ReturnsFalse()
        {
            // Arrange
            string invalidProduct = "ABC-4000";

            // Act
            bool result = _controller.IsValidProduct(invalidProduct);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidProduct_InvalidProductInvalidFormat_ReturnsFalse()
        {
            // Arrange
            string invalidProduct = "--";

            // Act
            bool result = _controller.IsValidProduct(invalidProduct);

            // Assert
            Assert.False(result);
        }
    }
}