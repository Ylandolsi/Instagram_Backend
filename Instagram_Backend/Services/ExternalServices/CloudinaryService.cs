using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Exceptions;

namespace Instagram_Backend.Services.ExternalServices;
public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;
    private readonly ILogger<CloudinaryService> _logger;    
    public CloudinaryService(Cloudinary cloudinary , ILogger<CloudinaryService> logger)
    {
        _logger = logger;
        _cloudinary = cloudinary;
    }

    public async Task<DeletionResult> DeleteFileAsync(string  fileUrl )
    {

        _logger.LogInformation("deleting file from cloudinary");
        var uri = new Uri(fileUrl);
        var pathSegments = uri.AbsolutePath.Split('/');
        var filename = pathSegments[pathSegments.Length - 1];
        var publicId = filename ; // if the file dosent have extension (exp:  .png ) 
        if ( filename.Contains('.'))
            publicId = filename.Substring(0, filename.LastIndexOf('.'));
                
        _logger.LogInformation("public id : = {publicId}" , publicId);
            
        var deleteParams = new DeletionParams(publicId);
        var destroyed =  await _cloudinary.DestroyAsync(deleteParams);

        if ( destroyed == null ){
            throw new InvalidOpException("Error occured when deleting the file from cloudinary");
        }

        _logger.LogInformation("File deleted from cloudinary");

        return destroyed;
    }
    public async Task<UploadResult> UploadFileAsync(IFormFile file)
    {
        
        var fileDescription = new FileDescription(file.FileName, file.OpenReadStream());
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        RawUploadParams uploadParams;
        switch (fileExtension)
        {
            case ".jpg":
            case ".jpeg":
            case ".png":
            case ".gif":
                uploadParams = new ImageUploadParams
                {
                    File = fileDescription,
                    UseFilename = true,
                    Overwrite = false
                };
                break;
            case ".mp4":
            case ".avi":
            case ".mov":
                uploadParams = new VideoUploadParams
                {
                    File = fileDescription,
                    UseFilename = true,
                    Overwrite = false
                };
                break;
            default:
                uploadParams = new RawUploadParams
                {
                    File = fileDescription,
                    UseFilename = true,
                    Overwrite = false
                };
                break;
        }
        _logger.LogInformation("Uploading file: {FileName} ", file.FileName);

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        if (uploadResult.Error != null)
        {
            throw new InvalidOpException($"Error occured when uploading the file ,ErrorMessage = { uploadResult.Error.Message} " );
        }

        _logger.LogInformation("File uploaded successfully: {FileName}", file.FileName );

        return uploadResult;
    }

   
}