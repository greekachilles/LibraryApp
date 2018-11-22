using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BooksUnitTest()
        {
            //Arrange
            BooksUnitTestController bookController = new BooksUnitTestController();

            //Act
            IActionResult result = bookController.Index() as IActionResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BorrowersUnitTest()
        {
            //Arrange
            BorrowersUnitTestController borrowerController = new BorrowersUnitTestController();

            //Act
            IActionResult result = borrowerController.Index() as IActionResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
