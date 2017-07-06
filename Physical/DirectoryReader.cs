using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Physical
{
    public sealed class DirectoryReader
    {
        public List<string> GetFiles(string path)
        {
            return Directory.GetFiles(path).ToList();
        }

        public List<string> GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern).ToList();
        }

        public List<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption).ToList();
        }

        public List<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).ToList();
        }

        public List<string> GetDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern).ToList();
        }

        public List<string> GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption).ToList();
        }
    }
}