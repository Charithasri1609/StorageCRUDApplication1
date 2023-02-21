using Microsoft.AspNetCore.Mvc;
using StorageCRUDApplication.Interfaces;
using StorageCRUDApplication.Models;

namespace StorageCRUDApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileShareController : ControllerBase
    {
        private readonly IFileShareRepository _repository;

        public FileShareController(IFileShareRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] FileShareModel file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.UploadFile(file.FileDetail);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("Download/{fileName}")]

        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var file = await _repository.DownloadFile(fileName);

            if (file == null)
            {
                return NotFound();
            }

            return File(file, "application/octet-stream", fileName);
        }


        [HttpDelete("Delete/{fileName}")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            await _repository.DeleteFileAsync(fileName);
            return NoContent();
        }
    }
}
