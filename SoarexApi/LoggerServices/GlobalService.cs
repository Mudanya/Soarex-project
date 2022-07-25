using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Services
{
    public class GlobalService
    {
        public string UploadFile(IFormFile? file)
        {
            string dbPath = string.Empty;
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file?.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fileWithNoExt = Path.GetFileNameWithoutExtension(fileName);
                var fileExt = Path.GetExtension(fileName);
                fileName = $"{fileWithNoExt}_{file.Name}{fileExt}";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPartialPath = Path.Combine(folderName, fileName);
                dbPath = dbPartialPath.Replace("\\", "/");
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return dbPath;
        }
    }
}
