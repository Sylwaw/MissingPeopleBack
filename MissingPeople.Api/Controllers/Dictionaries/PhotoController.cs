using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MissingPeople.Core.Entities.Peoples;
using System.Net.Http.Headers;
using MissingPeople.Core.Interfaces;
using MissingPeople.Core.Dtos.Peoples;

namespace MissingPeople.Api.Controllers.Dictionaries
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        const string FILE_PATH = @"C:\Samples\";
        private readonly IPictureService pictureService;

        public PhotoController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }

        //[HttpPost("PostPhoto")]
        //public IActionResult Post([FromBody] Picture theFile)
        //{
        //    return Ok();
        //}

        [HttpPost("AddPhoto"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpGet("GetBase64photo/{name}")]
        public ActionResult<string> getPhotoFile([FromRoute] string name)
        {
            var picture = pictureService.GetPictureBase64ByName(name);
            return new JsonResult(picture);
        }


    }
}
