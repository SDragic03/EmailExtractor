using System;
using System.Collections.Generic;
using System.IO;

namespace WebEmailExtractor
{
    public class EmailToFileWriter
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

        private static void HandleDirectory(string directory)
        {
                Directory.CreateDirectory(directory);
        }
    }
}