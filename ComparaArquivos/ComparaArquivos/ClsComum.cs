using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ComparaArquivos
{
    public class clsComum
    {

        //APAGA DIRETÓRIOS
        public void DeleteDirectory(string sTmpPath)
        {




            try
            {
                if (Directory.Exists(sTmpPath))
                {
                    //Delete all files from the Directory
                    foreach (string file in Directory.GetFiles(sTmpPath))
                    {
                        var di = new DirectoryInfo(sTmpPath);
                        di.Attributes &= ~FileAttributes.ReadOnly;
                        var di1 = new DirectoryInfo(file);
                        di1.Attributes &= ~FileAttributes.ReadOnly;
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }
                    //Delete all child Directories
                    foreach (string directory in Directory.GetDirectories(sTmpPath))
                    {
                        DeleteDirectory(directory);
                    }
                    //Delete a Directory
                    Directory.Delete(sTmpPath, true);
                }
            }
            catch (Exception e)
            {
                //  Geralog("Erro: " + "DeleteDirectory " + DateTime.Now.ToString() + " Comum.DeleteDirectory ", e.Message.ToString() + " ", e.Source.ToString());

                // Console.WriteLine("An error occurred: '{0}'", e);
            }
        }


        //APAGA DIRETÓRIOS
        public void DeleteDirectoryEspecificFile(string sTmpPath, string filenotdelete)
        {

            string files = sTmpPath + "\\" + filenotdelete;


            try
            {
                if (Directory.Exists(sTmpPath))
                {
                    //Delete all files from the Directory
                    foreach (string file in Directory.GetFiles(sTmpPath))
                    {
                        var di = new DirectoryInfo(sTmpPath);
                        di.Attributes &= ~FileAttributes.ReadOnly;
                        var di1 = new DirectoryInfo(file);
                        di1.Attributes &= ~FileAttributes.ReadOnly;
                        File.SetAttributes(file, FileAttributes.Normal);
                        if (file != files)
                        { File.Delete(file); }
                    }
                    //Delete all child Directories
                    foreach (string directory in Directory.GetDirectories(sTmpPath))
                    {
                        DeleteDirectoryEspecificFile(directory, files);
                    }
                    //Delete a Directory
                    //  Directory.Delete(sTmpPath, true);
                }
            }
            catch (Exception e)
            {
                //  Geralog("Erro: " + "DeleteDirectory " + DateTime.Now.ToString() + " Comum.DeleteDirectory ", e.Message.ToString() + " ", e.Source.ToString());

                // Console.WriteLine("An error occurred: '{0}'", e);
            }
        }
    }
}
