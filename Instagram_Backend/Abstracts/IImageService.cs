using Instagram_Backend.Models;


namespace Instagram_Backend.Abstracts; 
public interface IImageService {
    Task<List<Image>> UploadImages(List<IFormFile> images ,Guid postId ); 

    Task DeleteImageAsync(Guid imageId);

}