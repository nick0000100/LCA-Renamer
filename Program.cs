// Renames files with a letter at the end of the file name.

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LCA_Renamer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the directory and the files to rename
            System.Console.WriteLine("Enter folder path.");
            String FilePath = System.Console.ReadLine();
            DirectoryInfo dir = new DirectoryInfo(@FilePath);

            System.Console.WriteLine("Enter LCA code.");
            String LCACode = System.Console.ReadLine();

            // Get the files in the directory
            FileInfo[] Files = dir.GetFiles();
            foreach(FileInfo CurrentFile in Files)
            {
                String FileName = Path.GetFileNameWithoutExtension(CurrentFile.FullName);
                String Ex =  Path.GetExtension(CurrentFile.FullName);

                // Rename files with a letter at the end
                if(Regex.IsMatch(FileName, @"[a-zA-Z]+$"))
                {
                    File.Move(CurrentFile.FullName, CurrentFile.FullName.Replace(CurrentFile.Name, $"{LCACode}{CurrentFile.Name.Substring(0, FileName.Length - 1)} Signed Posting Attestation{Ex}"));
                }
                else
                {
                    File.Move(CurrentFile.FullName, CurrentFile.FullName.Replace(CurrentFile.Name, ($"C {LCACode}{CurrentFile.Name}")));
                }
            }
        }
    }
}
