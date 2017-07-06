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

        private List<string> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption).ToList();
        }

        public List<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).ToList();
        }

        public List<string> GetAllFiles(string path)
        {
            return this.GetFiles(path, "*", SearchOption.AllDirectories);
        }

        public List<string> GetAllFiles(string path, string searchPattern)
        {
            return this.GetFiles(path, searchPattern, SearchOption.AllDirectories);
        }
    }
}