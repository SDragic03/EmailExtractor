using System;
using System.Collections.Generic;
using System.IO;

namespace EmailExtractorApp
{
    public class FileWriter
    {
        public static void WriteEmailsToFile(IEnumerable<string> emails)
        {
            HandleDirectory(@"C:\emails");

            using (var file = new StreamWriter($@"C:\emails\emails{DateTime.Now:yyyy-MM-dd HH.mm.ss}.txt"))
            {
                foreach (var email in emails)
                {
                    file.Write(email);
                    file.Write("\r\n");
                }
            }
        }

        public static void WriteEmailCountToFile(int emailCount)
        {
            using (var file = new StreamWriter(@"C:\emails\emailCount.txt"))
                file.Write("Total Email Count: " + emailCount);
        }

        private static void HandleDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
        }
    }
}
