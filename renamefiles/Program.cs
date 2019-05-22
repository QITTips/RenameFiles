using System;
using System.IO;

namespace renamefiles
{
    class Program
    {
        public static string Startpath = @"C:\myFolder";

        public static string pattern = "*.no_more_ransom";  // all files that end with *.no_more_ransom
        static void Main(string[] args)
        {
            try
            {
                // methods than remane all file in directory 
                RenameFiles(Startpath);
                string[] dirs = Directory.GetDirectories(Startpath, "*", SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);

                    RenameFiles(dir);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            Console.WriteLine("Hello World!");
        }

        public static void RenameFiles(string dir)
        {

            string[] filePaths = Directory.GetFiles(dir, pattern); // get files to rename
            foreach (string path in filePaths)
            {
                try
                {
                    FileInfo fi = new FileInfo(path);
                    Console.WriteLine($"File that should be renamed: { path}");
                    string endname = pattern.Replace("*", ""); ;
                
                    string newName = path.Replace(endname, "");
                    string extention = newName.Split('.')[newName.Split('.').Length - 1]; // get file extention
                    if (fi.Exists)
                    {
                        fi.MoveTo(newName);
                        var result = Path.ChangeExtension(newName, "." + extention);
                        Console.WriteLine($"ChangeExtension:  {newName} + .{extention}");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
