using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GreenDiamond.Application.Interface.File
{
    public interface IImageStorageService
    {
        public bool IsImage(IFormFile file);

        public Task<string> SaveImage(IFormFile file , string path);

        public bool DeleteImage(string filename, string path);

        public string GetImage(string filename, string path);
    }
}
