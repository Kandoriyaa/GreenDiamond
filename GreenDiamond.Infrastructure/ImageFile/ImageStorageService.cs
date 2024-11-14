using GreenDiamond.Application.Interface.File;
using Microsoft.AspNetCore.Http;

namespace GreenDiamond.Infrastructure.ImageFile
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageStorageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool DeleteImage(string filename, string path)
        {
            try
            {
                var paths = Path.Combine(Directory.GetCurrentDirectory(), string.Format("Upload\\{0}", path), path);
                if (System.IO.File.Exists(paths))
                {
                    System.IO.File.Delete(paths);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetImage(string fileName, string path)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
                return string.Format(baseUrl + "/Upload/{0}/{1}", path, fileName);
            }
            else { return string.Empty; }
        }


        public bool IsImage(IFormFile file)
        {
            if (file == null) return false; // Check for null
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            return (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".gif");
        }

        //public string SaveImage(IFormFile file, string destinationPath)
        //{
        //    string filename;
        //    try
        //    {
        //        var Ext = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        //        filename = DateTime.Now.Ticks + Ext;

        //        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), string.Format("Upload\\{0}", destinationPath));

        //        if (!Directory.Exists(pathBuilt))
        //        {
        //            Directory.CreateDirectory(pathBuilt);
        //        }

        //        string paths = Path.Combine(pathBuilt, filename);

        //        using (var stream = new FileStream(paths, FileMode.Create))
        //        {
        //            file.CopyToAsync(stream);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return filename;
        //}

        public async Task<string> SaveImage(IFormFile file, string destinationPath)
        {
            string filename;
            try
            {
                var ext = Path.GetExtension(file.FileName);
                filename = DateTime.Now.Ticks + ext;

                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), $"Upload\\{destinationPath}");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                string paths = Path.Combine(pathBuilt, filename);

                using (var stream = new FileStream(paths, FileMode.Create))
                {
                    await file.CopyToAsync(stream); // Await the asynchronous method
                }
            }
            catch (Exception ex)
            {
                throw ex; // Consider logging the error instead of just rethrowing
            }
            return filename;
        }
    }
}
