using Microsoft.AspNetCore.Mvc;
using NopClone.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers
{
    [Route("api/files")]
    public class FileController : Controller
    {
        private string _imagesPath;

        public FileController(IWebHostEnvironment env)
        {
             _imagesPath = Path.Combine(env.WebRootPath, "images");
        }

        [HttpGet("{fileName}/{type}")]
        public IActionResult GetFile(string fileName, string type)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(type))
            {
                return BadRequest();
            }
            
            string fullPath = "";
            if(type == ImageTypes.Product)
            {
                fullPath = Path.Combine(_imagesPath, "products", fileName);
            }
            else
            {
                fullPath = Path.Combine(_imagesPath, "categories", fileName);
            }

            return new FileStreamResult(new FileStream(fullPath, FileMode.Open, FileAccess.Read), "image/*");
        }
    }
}
