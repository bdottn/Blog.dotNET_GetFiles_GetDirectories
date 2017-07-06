using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Physical
{
    public sealed class DirectoryInfoReader
    {
        public List<FileInfo> GetFiles(string path)
        {
            return new DirectoryInfo(path).GetFiles().ToList();
        }

        public List<FileInfo> GetFiles(string path, string searchPattern)
        {
            return new DirectoryInfo(path).GetFiles(searchPattern).ToList();
        }

        public List<FileInfo> GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return new DirectoryInfo(path).GetFiles(searchPattern, searchOption).ToList();
        }

        public List<DirectoryInfo> GetDirectories(string path)
        {
            return new DirectoryInfo(path).GetDirectories().ToList();
        }

        public List<DirectoryInfo> GetDirectories(string path, string searchPattern)
        {
            return new DirectoryInfo(path).GetDirectories(searchPattern).ToList();
        }

        public List<DirectoryInfo> GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return new DirectoryInfo(path).GetDirectories(searchPattern, searchOption).ToList();
        }
    }
}