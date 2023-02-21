using StorageCRUDApplication.Models;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;
using StorageCRUDApplication.Interfaces;


namespace StorageCRUDApplication.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private readonly CloudBlobContainer _container;

        public BlobRepository(IConfiguration configuration)
        {
            var connectionString = configuration["Storage:ConnectionString"];
            var containerName = configuration.GetValue<string>("Storage:ContainerName");
            var blobClient = CloudStorageAccount.Parse(connectionString).CreateCloudBlobClient();
            _container = blobClient.GetContainerReference(containerName);
        }

        public async Task<IEnumerable<Blob>> GetFileAsync()
        {
            var blobs = await _container.ListBlobsSegmentedAsync(null);
            return blobs.Results.Select(b => new Blob { BlobName = b.Uri.Segments.Last(), BlobUrl = b.Uri.AbsoluteUri });
        }

        public async Task<Blob> GetFileAsync(string blobfileName)
        {
            var blob = _container.GetBlockBlobReference(blobfileName);
            if (await blob.ExistsAsync())
            {
                return new Blob
                {
                    BlobName = blobfileName,
                    BlobUrl = blob.Uri.AbsoluteUri
                };
            }
            return null;
        }

        public async Task<Blob> AddFileAsync(Stream stream, string blobfileName)
        {
            var blob = _container.GetBlockBlobReference(blobfileName);
            await blob.UploadFromStreamAsync(stream);
            return new Blob
            {
                BlobName = blobfileName,
                BlobUrl = blob.Uri.AbsoluteUri
            };
        }

        public async Task DeleteFileAsync(string blobfileName)
        {
            var blob = _container.GetBlockBlobReference(blobfileName);
            await blob.DeleteAsync();
        }
    }
}
