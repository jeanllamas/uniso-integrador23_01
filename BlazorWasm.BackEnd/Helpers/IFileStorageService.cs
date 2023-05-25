using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmServer.Server.Helpers
{
    public interface IFileStorageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="extension"></param>
        /// <param name="containerName">Pasta Onde Salva o Arquivo</param>
        /// <returns></returns>
        Task<string> SaveFile(byte[] content, string extension, string folderName);
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> EditFile(byte[] content, string extension, string folderName, string fileRoute);

    }
}
