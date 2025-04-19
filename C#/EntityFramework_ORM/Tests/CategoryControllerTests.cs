using System.Text;
using API.Models.CategoyModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class CategoryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CategoryControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Category_Returns_Success()
        {
            // Arrange
            var categoryId = 1; // Use an existing valid category ID for testing
            var requestUri = $"/Categories/{categoryId}";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();  // Checks if status code is 2xx
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("CategoryID", responseString);  // Ensures the response contains expected data (e.g., "CategoryID")
        }

        [Fact]
        public async Task Get_All_Categories_Returns_Success()
        {
            // Arrange
            var requestUri = "/Categories";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("CategoryID", responseString);  // Check for at least one CategoryID in response
        }

        [Fact]
        public async Task Add_Category_Returns_Success()
        {
            // Arrange
            var requestUri = "/Categories";
            var newCategory = new AddCategoryModel
            {
                CategoryName = "New Category",
                Description = "A description for the new category.",
                //Picture = "picture_url_here"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(newCategory),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PostAsync(requestUri, content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("New Category", responseString);  // Ensure the new category is included in the response
        }

        [Fact]
        public async Task Update_Category_Returns_Success()
        {
            // Arrange
            var categoryId = 1; // Use an existing valid category ID for testing
            var requestUri = $"/Categories/{categoryId}";
            var updatedCategory = new UpdateCategoryModel
            {
                CategoryName = "Updated Category Name",
                Description = "Updated description.",
                //Picture = "updated_picture_url"
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(updatedCategory),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await _client.PutAsync(requestUri, content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Updated Category Name", responseString);  // Ensure updated category name is in the response
        }

        [Fact]
        public async Task Delete_Category_Returns_Success()
        {
            // Arrange
            var categoryId = 1; // Use an existing valid category ID for testing
            var requestUri = $"/Categories/{categoryId}";

            // Act
            var response = await _client.DeleteAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("true", responseString);  // Assuming the API returns a "true" or similar success response on successful delete
        }
    }
}
