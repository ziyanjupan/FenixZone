using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FeinxZone.Helper
{
    public class IOHelper
    {
        public static void CopyFile(string fileFullPath, string destination, bool isDeleteSourceFile = false, string fileName = "")
        {
            if (string.IsNullOrWhiteSpace(fileFullPath))
            {
                throw new ArgumentNullException("fileFullPath", "源文件全路径不能为空");
            }
            if (File.Exists(fileFullPath))
            {
                //throw new FileNotFoundException("找不到源文件", fileFullPath);
                if (Directory.Exists(destination))
                {

                    try
                    {
                        fileName = (string.IsNullOrWhiteSpace(fileName) ? Path.GetFileName(fileFullPath) : fileName);
                        File.Delete(Path.Combine(destination, fileName));
                        File.Copy(fileFullPath, Path.Combine(destination, fileName), true);
                        if (isDeleteSourceFile)
                        {
                            File.Delete(fileFullPath);
                        }
                    }
                    catch (Exception exception)
                    {
                        throw;
                    }

                    //throw new DirectoryNotFoundException(string.Concat("找不到目标目录 ", destination));
                }
            }
        }

        public static long GetDirectoryLength(string dirPath)
        {
            long num;
            if (Directory.Exists(dirPath))
            {
                long length = (long)0;
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                FileInfo[] files = directoryInfo.GetFiles();
                for (int i = 0; i < (int)files.Length; i++)
                {
                    length = length + files[i].Length;
                }
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                if ((int)directories.Length > 0)
                {
                    for (int j = 0; j < (int)directories.Length; j++)
                    {
                        length = length + IOHelper.GetDirectoryLength(directories[j].FullName);
                    }
                }
                num = length;
            }
            else
            {
                num = (long)0;
            }
            return num;
        }


        public static string GetMapPath(string path)
        {
            string str;
            if (HttpContext.Current == null)
            {
                string applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (!string.IsNullOrWhiteSpace(path))
                {
                    path = path.Replace("/", "\\");
                    if (!path.StartsWith("\\"))
                    {
                        path = string.Concat("\\", path);
                    }
                    path = path.Substring(path.IndexOf('\\') + (applicationBase.EndsWith("\\") ? 1 : 0));
                }
                str = string.Concat(applicationBase, path);
            }
            else
            {

                if (!path.Trim().Contains("/"))
                { str = path; }

                else
                { str = HttpContext.Current.Server.MapPath(path); }
            }
            return str;
        }

    }
}