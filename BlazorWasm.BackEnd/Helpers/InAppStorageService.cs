using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmServer.Server.Helpers
{
    public class InAppStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InAppStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor ) {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

      

        public Task DeleteFile(string fileRoute, string folderName)
        {
            var nomeArquivo = Path.GetFileName(fileRoute);
            string fileUrl = Path.Combine(env.WebRootPath, folderName, nomeArquivo);
            string folder = Path.Combine(env.WebRootPath, folderName);

            if (File.Exists(fileUrl))
                File.Delete(fileUrl);

            return Task.FromResult(0);

        }

        public async Task<string> EditFile(byte[] content, string extension, string folderName, string fileRoute)
        {
            if (!string.IsNullOrEmpty(fileRoute))
                await DeleteFile(fileRoute, folderName);

            return await SaveFile(content, extension, folderName);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string folderName)
        {
            var nomeArquivo = $"{Guid.NewGuid()}.{extension}";
            string folder = Path.Combine(env.WebRootPath, folderName);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string savePath = Path.Combine(folder, nomeArquivo);
            await File.WriteAllBytesAsync(savePath, content);

            //pega endereco do site
            var currentUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var pathForDatabase = Path.Combine(currentUrl, folderName, nomeArquivo);

            return pathForDatabase;
        }
    }
}
