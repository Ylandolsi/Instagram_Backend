using CloudinaryDotNet;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Models;
using Instagram_Backend.Services.ExternalServices;
using Microsoft.EntityFrameworkCore;
namespace Instagram_Backend.Services ;

public class ImageService : IImageService
{
    private readonly CloudinaryService _cloudinaryService;
    private readonly ApplicationDbContext _context ; 
    private readonly ILogger<ImageService> _logger ; 
    public ImageService(CloudinaryService cloudinaryService , ApplicationDbContext context , ILogger<ImageService> logger){
        _context = context ; 
        _cloudinaryService = cloudinaryService ; 
        _logger = logger ; 
    } 

    private bool VerifyFileImage ( IFormFile image ){
        _logger.LogInformation("Verifying if the file uploaded is an image ");

        var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

        if ( fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".gif"){
            _logger.LogWarning("The file uploaded is not an image") ; 
            return false; 
        }
        _logger.LogInformation("the file uploaded is an image ") ; 
        return true ; 
    }

    public async Task<List<Image>> UploadImages(List<IFormFile> images ,Guid postId )
    {
        // verify all uploaded files are images first 
        foreach (var image in images){
            if (!VerifyFileImage(image) ) {
                throw new BadRequestException("File Uploaded is Not an Image") ; 
            }
            if (image.Length > 5 * 1024 * 1024) // 5MB 
            {
                throw new BadRequestException("File size exceeds maximum allowed (5MB)");
            }

        }

        List<Image> imagesUploaded = new List<Image>();
        int order = 1 ; 
        foreach (var image in images){

            _logger.LogInformation($"Uploading Image To PostId (Post Is Not Created Yet)") ; 

            var uploadResult = await _cloudinaryService.UploadFileAsync(image);

            
            var ImageItem = new Image
            {
                Id = Guid.NewGuid() , 
                Url = uploadResult.SecureUrl.ToString(),
                PostId = postId,
                Order = order 
            };

            _context.Images.Add(ImageItem);

            imagesUploaded.Add(ImageItem ) ;
            order++ ; 

        }
        // save the changes when creating the post , await _context.SaveChangesAsync();

        return imagesUploaded ; 


                
    }

    public async Task DeleteImageAsync ( Guid ImageId ){
        _logger.LogInformation("deleting imgage with {ImageId} ." , ImageId ) ;

        var image = await _context.Images
            .FirstOrDefaultAsync(f => f.Id == ImageId );


        if (image == null)
        {
            throw new NotFoundException("Iamge not found.");
        }

        if (!string.IsNullOrEmpty(image.Url))
        {
            await _cloudinaryService.DeleteFileAsync(image.Url);
        }
        else {
            throw new InvalidOperationException("File URL is null or empty.");
        }
        
        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
        
    }
}