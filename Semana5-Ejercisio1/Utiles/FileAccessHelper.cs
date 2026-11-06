using System;
using System.Collections.Generic;
using System.Text;

namespace Semana5_Ejercisio1.Utiles
{
    public class FileAccessHelper
    {
        public static string GetFilePath(string fileName)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = System.IO.Path.Combine(currentDirectory, fileName);
            return filePath;
        }
    }
}
