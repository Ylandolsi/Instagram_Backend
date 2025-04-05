// using System.Net;
// using System.Net.Http.Headers;
// using Instagram_Backend.Dtos.Posts;
// using Microsoft.AspNetCore.Mvc.Testing;

// namespace TestProject.IntegrationTests;

// public class PostIntegrationTests : IntegrationTestBase
// {
//     public PostIntegrationTests(WebApplicationFactory<Program> factory) : base(factory)
//     {
//     }

//     [Fact]
//     public async Task CreateAndRetrievePost_ReturnsSuccessAndCorrectData()
//     {
//         // Arrange
//         await AuthenticateAsync();
        
//         // Create a new post with a test image
//         var imageContent = new ByteArrayContent(File.ReadAllBytes("TestFiles/test-image.jpg"));
//         imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
        
//         using var formData = new MultipartFormDataContent();
//         formData.Add(imageContent, "images", "test-image.jpg");
//         formData.Add(new StringContent("Test post caption"), "Caption");
        
//         // Act - Create post
//         var postResponse = await _client.PostAsync("/api/posts", formData);
        
//         // Assert - Post created successfully
//         postResponse.EnsureSuccessStatusCode();
//         var postContent = await postResponse.Content.ReadFromJsonAsync<PostDto>();
//         Assert.NotNull(postContent);
//         Assert.Equal("Test post caption", postContent.Caption);
//         Assert.NotEmpty(postContent.Images);
        
//         // Act - Retrieve post
//         var getResponse = await _client.GetAsync($"/api/posts/{postContent.Id}");
        
//         // Assert - Retrieved post matches created post
//         getResponse.EnsureSuccessStatusCode();
//         var retrievedPost = await getResponse.Content.ReadFromJsonAsync<PostDto>();
//         Assert.NotNull(retrievedPost);
//         Assert.Equal(postContent.Id, retrievedPost.Id);
//         Assert.Equal("Test post caption", retrievedPost.Caption);
//         Assert.Equal(postContent.Images.Count, retrievedPost.Images.Count);
//     }
// }