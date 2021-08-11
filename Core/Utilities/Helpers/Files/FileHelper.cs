﻿using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public static string Upload(IFormFile file, string root)
        {
            if (file.Length < 0) return null;
            if (!Directory.Exists(root)) Directory.CreateDirectory(root);       
            string extension = Path.GetExtension(file.FileName);
            string guid = Guid.NewGuid().ToString();
            string newPath = guid + extension;
            using (FileStream fileStream = File.Create(root + newPath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return newPath;
            }
        }
    }
}
