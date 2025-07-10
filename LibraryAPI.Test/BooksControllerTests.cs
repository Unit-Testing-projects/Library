using Library.API.Controllers;
using Library.API.Data.Models;
using Library.API.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Test
{
    public class BooksControllerTests
    {
        readonly BooksController _controller;
        readonly IBookService _service;

        public BooksControllerTests()
        {
            _service = new BookService();
            _controller = new BooksController(_service);
        }

        [Fact]
        public void GetAllTest()
        {
            //arrange
            //act
            var result = _controller.GetAll();
            
            //assert
            Assert.IsType<OkObjectResult>(result.Result);
            
            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Book>>(list.Value);

            var listBooks = list.Value as List<Book>;
            Assert.Equal(5, listBooks.Count);
        }

        [Theory]
        [InlineData(1, 25)]
        public void GetBookByIdTest(int id1, int id2)
        {
            //arrange
            var existId = id1;
            var notExistId = id2;

            //act
            var notFoundResult = _controller.Get(notExistId);
            var okResult = _controller.Get(existId);
            
            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
            Assert.IsType<OkObjectResult>(okResult.Result);

            var item = okResult.Result as OkObjectResult;
            Assert.IsType<Book>(item.Value);

            var bookItem = item.Value as Book;
            Assert.Equal(id1, bookItem.Id);
            Assert.Equal("Managing Oneself", bookItem.Title);
        }

        [Theory]
        [InlineData(1, 25)]
        public  void RemoveBookTest(int id1, int id2)
        {
            //arrange
            var existId = id1;
            var notExistId = id2;

            //act
            var notFoundResult = _controller.Delete(notExistId);

            //assert
            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.Equal(5, _service.GetAll().Count());

            //act
            var okResult = _controller.Delete(existId);

            //assert
            Assert.IsType<OkResult>(okResult);
            Assert.Equal(4, _service.GetAll().Count());
        }
    }
}