using Microsoft.AspNetCore.Mvc;
using StorageCRUDApplication.Models;
using StorageCRUDApplication.Interfaces;

namespace StorageCRUDApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobRepository _repository;

        public BlobController(IBlobRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Retrive")]
        public async Task<IActionResult> GetAsync()
        {
            var blobs = await _repository.GetFileAsync();
            return Ok(blobs);
        }

        [HttpGet("Retrive/{blobfileName}")]
        public async Task<ActionResult<Blob>> GetAsync(string blobfileName)
        {
            var blob = await _repository.GetFileAsync(blobfileName);
            if (blob == null)
            {
                return NotFound();
            }
            return blob;
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<Blob>> AddAsync(IFormFile file, string blobfileName)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }
            var blob = await _repository.AddFileAsync(file.OpenReadStream(), blobfileName);
            return blob;
        }

        [HttpDelete("Delete/{blobfileName}")]
        public async Task<IActionResult> DeleteAsync(string blobfileName)
        {
            await _repository.DeleteFileAsync(blobfileName);
            return NoContent();
        }
    }
}
