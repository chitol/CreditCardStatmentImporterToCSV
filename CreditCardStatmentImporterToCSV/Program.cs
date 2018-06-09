using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CreditCardStatmentImporterToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Usage: Use filename as argument");

                string[] lines = File.ReadAllLines(args[0]);
                string[] newLines = new string[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    char[] sep = { ' ' };
                    string[] token = lines[i].Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    newLines[i] = token[0] + ",";
                    for (int j = 1; j < token.Length - 1; j++)
                    {
                        newLines[i] += token[j];
                        newLines[i] += " ";
                    }
                    newLines[i] += ",-";
                    newLines[i] += token[token.Length - 1];
                }

                string fileNameNoExt = System.IO.Path.GetFileNameWithoutExtension(args[0]);
                string csvPath = Path.Combine(System.IO.Path.GetDirectoryName(args[0]), fileNameNoExt + ".csv");
                File.WriteAllLines(csvPath, newLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
