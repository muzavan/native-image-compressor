using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer.Business.Util
{
    public class ConfigUtil
    {
        public static int GetThreadNumber()
        {
            var thread = 1;
            Int32.TryParse(_GetConfig(ConfigConstant.NUM_THREAD), out thread);
            return thread;
        }

        public static string GetFolderPath()
        {
            var path = string.IsNullOrEmpty(_GetConfig(ConfigConstant.FOLDER_PATH)) ? @"D:\My Toy\C#\ImageResizer\ImageResizer.Business.Test\UnitTest\TestFiles\" : _GetConfig(ConfigConstant.FOLDER_PATH);
            return path;
        }

        public static List<string> GetAllowedExtensions()
        {
            var extensions = new List<string>();
            var strExts = string.IsNullOrEmpty(_GetConfig(ConfigConstant.ALLOW_EXT)) ?  ".jpg,.png,.ico" : _GetConfig(ConfigConstant.ALLOW_EXT);
            foreach (var str in strExts.ToLower().Split(','))
            {
                extensions.Add(str.Trim());
            }
            return extensions;
        }

        private static string _GetConfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings.Get(key);
            }
            catch (Exception ex)
            {
                // do nothing
            }
            return "";
        }
    }

    public static class ConfigConstant
    {
        public static string NUM_THREAD = "Num_Thread";
        public static string FOLDER_PATH = "Folder_Path";
        public static string ALLOW_EXT = "Allowed_Extensions";
    }
}
