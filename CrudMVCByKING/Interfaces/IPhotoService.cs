using CloudinaryDotNet.Actions;

namespace CrudMVCByKING.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicUrl);

    }
}
