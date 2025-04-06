using CloudinaryDotNet.Actions;

namespace Instagram_Backend.Abstracts;
public interface ICloudinaryService
{
    Task<UploadResult> UploadFileAsync(IFormFile file);
    Task<DeletionResult> DeleteFileAsync(string fileUrl);

}