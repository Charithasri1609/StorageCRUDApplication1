using StorageCRUDApplication.Models;

namespace StorageCRUDApplication.Interfaces
{
    public interface IBlobRepository
    {
        Task<Blob> AddFileAsync(Stream stream, string blobfileName);
        Task<IEnumerable<Blob>> GetFileAsync();
        Task<Blob> GetFileAsync(string blobfileName);
        Task DeleteFileAsync(string blobfileName);
    }
}
