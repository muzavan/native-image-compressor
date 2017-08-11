using ImageResizer.Business.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer.Business.Populator
{
    public class ImagePopulator
    {
        private List<string> _ImageExtensions;
        private string _FolderPath;
        private List<string> _FilePathList;

        public ImagePopulator(string folderPath)
        {
            _FolderPath = folderPath;
            _FilePathList = new List<string>();
            _ImageExtensions = ConfigUtil.GetAllowedExtensions();
        }

        public List<string> FilePathList
        {
            get
            {
                _Populate();
                return _FilePathList;
            }
        }

        private void _Populate()
        {
            if (_FilePathList.Count == 0)
            {
                _FilePathList.AddRange(_GetFilesFromDirectory(_FolderPath));
            }
        }

        private List<string> _GetFilesFromDirectory(string folderPath)
        {
            var files = new List<string>();
            var currentFolder = new DirectoryInfo(folderPath);

            foreach (var folder in currentFolder.GetDirectories())
            {
                files.AddRange(_GetFilesFromDirectory(folder.FullName));
            }

            files.AddRange(currentFolder.GetFiles().Where(x => _ImageExtensions.Contains(x.Extension.ToLower())).Select(x => x.FullName));
            return files;
        }
    }
}
