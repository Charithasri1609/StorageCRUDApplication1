using StorageCRUDApplication.Models;

namespace StorageCRUDApplication.Interfaces
{
    public interface IQueueRepository
    {
        Task AddMessageAsync(QueueMessage message);
        Task<QueueMessage> DequeueMessageAsync();
        Task UpdateMessageAsync(QueueMessage message);
        Task ClearQueueAsync();
    }
}
