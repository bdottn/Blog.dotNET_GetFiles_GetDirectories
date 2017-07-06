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

        public List<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).ToList();
        }

        public List<string> GetAllFiles(string path)
        {
            var files = this.GetFiles(path);

            foreach (var directory in this.GetDirectories(path))
            {
                var subDirectoryFiles = this.GetAllFiles(directory);

                files.AddRange(subDirectoryFiles);
            }

            return files;
        }

        public List<string> GetAllFiles(string path, string searchPattern)
        {
            var files = this.GetFiles(path, searchPattern);

            foreach (var directory in this.GetDirectories(path))
            {
                var subDirectoryFiles = this.GetAllFiles(directory, searchPattern);

                files.AddRange(subDirectoryFiles);
            }

            return files;
        }
    }
}