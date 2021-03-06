using System;
using System.IO;
using System.Reflection;

namespace TesteDiaADia.Tools.Malet
{
    internal class FileTools : BaseTools
    {
        internal string Root
        {
            get
            {
                return GetRoot();
            }

        }
        internal string ProjectRoot
        {
            get
            {
                return GetProjectRoot();
            }
        }

        private string GetProjectRoot()
        {
            return $@"{Root}\TesteDiaADia";
        }

        private string GetRoot()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;

            FileInfo assemblyFileInfo = new FileInfo(assemblyLocation);

            string assemblyDirectoryPath = assemblyFileInfo.DirectoryName;

            string upperDirectoryPath = Directory.GetParent(assemblyDirectoryPath).FullName;

            for (int i = 0; i < 3; i++)
            {
                upperDirectoryPath = Directory.GetParent(upperDirectoryPath).FullName;
            }

            return upperDirectoryPath;
        }
    }
}
