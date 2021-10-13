using System;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void CustomersShouldCreate()
        {

            Customers test = new Customers();

            Assert.NotNull(test);
        }

        [Fact]
        public void CustomersShouldSetValidData()
        {
            //Arrange
            Customers test = new Customers();
            string testFirstName = "test customers";

            //Act
            test.FirstName = testFirstName;

            //Assert
            Assert.Equal(testFirstName, test.FirstName);
        }

        [Fact]
        public void ProductsShouldSetValidData()
        {
            //Arrange
            Products test = new Products();
            string testName = "test products";

            //Act
            test.Name = testName;

            //Assert
            Assert.Equal(testName, test.Name);
        }


        [Fact]
        public void InventoryShouldCreate()
        {

            Inventory test = new Inventory();

            Assert.NotNull(test);
        }


        [Fact]
        public void ProductsShouldSetValidDataAlways()
        {
            //Arrange
            Products test = new Products();
            string testDescription = "test products";

            //Act
            test.Description = testDescription;

            //Assert
            Assert.Equal(testDescription, test.Description);
        }

        [Fact]
        public void LocationsShouldSetValidData()
        {
            //Arrange
            VendorBranches test = new VendorBranches();
            string testName = "test locations";

            //Act
            test.Name = testName;

            //Assert
            Assert.Equal(testName, test.Name);
        }
        [Fact]
        public void OrdersShouldCreate()
        {
            //Arrange & Act
            Orders test = new Orders();

            Assert.NotNull(test);
        }

        [Theory]
        [InlineData("")]
        [InlineData("123567890")]
        [InlineData("%$@^^")]


        [Theory]
        [InlineData("")]
        [InlineData("123567890")]
        [InlineData("%$@^^")]


    }
}

