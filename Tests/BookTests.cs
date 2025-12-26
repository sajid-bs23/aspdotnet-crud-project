using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using AspDotNetCrudProject.Models;
using Xunit;

namespace AspDotNetCrudProject.Tests
{
    public class BookTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public BookTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetBooks_ReturnsEmptyList_WhenNoBooksExist()
        {
            var response = await _client.GetAsync("/api/books");
            response.EnsureSuccessStatusCode();
            var books = await response.Content.ReadFromJsonAsync<List<Book>>();
            Assert.Empty(books!);
        }

        [Fact]
        public async Task PostBook_CreatesNewBook()
        {
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                ISBN = "1234567890",
                PublishedDate = DateTime.Now,
                Pages = 100
            };

            var response = await _client.PostAsJsonAsync("/api/books", newBook);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var createdBook = await response.Content.ReadFromJsonAsync<Book>();
            Assert.NotNull(createdBook);
            Assert.Equal(newBook.Title, createdBook.Title);
        }

        [Fact]
        public async Task GetBook_ReturnsNotFound_ForInvalidId()
        {
            var response = await _client.GetAsync("/api/books/999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
