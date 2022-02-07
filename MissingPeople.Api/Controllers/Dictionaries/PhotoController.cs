using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using MissingPeople.Core.Entities.Peoples;

namespace MissingPeople.Api.Controllers.Dictionaries
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        const string FILE_PATH = @"C:\Samples\";

        [HttpPost("PostPhoto")]
        public IActionResult Post([FromBody] Picture theFile)
        {
            return Ok();
        }
    }
}
