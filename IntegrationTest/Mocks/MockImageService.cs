using Instagram_Backend.Abstracts;
using Instagram_Backend.Models;
using Microsoft.AspNetCore.Http;

namespace IntegrationTest.Mocks;

public class MockImageService : IImageService
{
    public Task<List<Image>> UploadImages(List<IFormFile> images, Guid postId)
    {
        var mockImages = images.Select((image, index) => new Image
        {
            Id = Guid.NewGuid(),
            PostId = postId,
            Order = index + 1,
            Url = $"https://mock-cloudinary.com/{Guid.NewGuid()}/{image.FileName}"
        }).ToList();
        
        return Task.FromResult(mockImages);
    }
    
    public Task DeleteImageAsync(Guid imageId)
    {
        // Just pretend to delete an image
        return Task.CompletedTask;
    }
}