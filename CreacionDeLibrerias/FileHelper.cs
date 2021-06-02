using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;
namespace CreacionDeLibrerias
{
    class FileHelper
    {
        public List<FileObjectInformation> getFilesSystemObject(string path)
        {
            WriteLine(path);
            DirectoryInfo di = new DirectoryInfo(path);
            var listaInfo = di.EnumerateFileSystemInfos();

            var fileObjects = new List<FileObjectInformation>();
            foreach(var item in listaInfo)
            {
                FileObjectType tipo=FileObjectType.Directory;
                if(item.Attributes == FileAttributes.Archive)
                    tipo = FileObjectType.File;

                fileObjects.Add(new FileObjectInformation() { path=item.FullName,name=item.Name, FileType=tipo});
            }
            //Console.WriteLine(di.);
            return fileObjects;
        }//Fin de funcion
    }//Fin de claser
}
