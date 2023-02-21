using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageCRUDApplication.Interfaces;
using StorageCRUDApplication.Models;

namespace StorageCRUDApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _repository;

        public TableController(ITableRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Insert")]
        public async Task Insert(TableEntity entity)
        {
            await _repository.Insert(entity);
        }

        [HttpGet("All")]
        public async Task<IEnumerable<TableEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{partitionKey}/{rowKey}")]
        public async Task<TableEntity> Get(string partitionKey, string rowKey)
        {
            return await _repository.Get(partitionKey, rowKey);
        }

        [HttpPut("Update")]
        public async Task Update(TableEntity entity)
        {
            await _repository.Update(entity);
        }

        [HttpDelete("{partitionKey}/{rowKey}")]
        public async Task Delete(string partitionKey, string rowKey)
        {
            await _repository.Delete(partitionKey, rowKey);
        }
    }
}
