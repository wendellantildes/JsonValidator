using System;
using System.IO;

namespace JsonValidatorTool.Tests
{
    public static class JsonUtils
    {
        private const string _filesFolder = "Files";
        public const string ValidJsonFileName = "ValidJson.txt";
        /*
         * The error is the number 010: octal number is not allowed
        */
        public const string InvalidJsonFileName = "InvalidJson.txt";


        private static string GetFullPath(string filename)
        {
            return Path.GetFullPath($"{_filesFolder}/{filename}");
        }

        public static string ReadText(string filename)
        {
            var path = GetFullPath(filename);
            return File.ReadAllText(path);
        }
    }
}
