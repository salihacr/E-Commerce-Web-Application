using E_Commerce_App.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Helpers
{
    public static class ImageHelper
    {
        public static async Task<string> SaveImage(IFormFile formFile, string path = "")
        {
            string filename = "";
            if (formFile != null)
            {
                filename = Guid.NewGuid().ToString();
                filename += Path.GetExtension(formFile.FileName);
                if (path == "")
                {
                    path = Directory.GetCurrentDirectory() + $"/wwwroot/img/{filename}";
                    string imagePath = Path.Combine(path);
                    using var stream = new FileStream(imagePath, FileMode.Create);
                    await formFile.CopyToAsync(stream);
                }
            }
            return filename;
        }
    }
}
