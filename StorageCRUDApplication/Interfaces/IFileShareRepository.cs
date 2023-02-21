namespace StorageCRUDApplication.Interfaces
{
    public interface IFileShareRepository
    {
        Task<bool> UploadFile(IFormFile file);
        Task<byte[]> DownloadFile(string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
