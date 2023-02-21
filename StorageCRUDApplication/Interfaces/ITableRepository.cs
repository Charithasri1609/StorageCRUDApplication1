using StorageCRUDApplication.Models;

namespace StorageCRUDApplication.Interfaces
{
    public interface ITableRepository
    {
        Task Insert(TableEntity entity);
        Task<IEnumerable<TableEntity>> GetAll();
        Task<TableEntity> Get(string partitionKey, string rowKey);
        Task Update(TableEntity entity);
        Task Delete(string partitionKey, string rowKey);
    }
}
