using System;
using System.Collections.Generic;
using System.IO;

namespace WebEmailExtractor
{
    public class EmailExtractor
    {
        public static void ExtractEmails(string url)
        {
            if (GetEmails(url).Count > 0)
            {
                WriteSuccessMessage();
                WriteEmailsToFile(GetEmails(url));
            }
            else
                WriteRejectionMessage();
        }

        private static void WriteSuccessMessage()
        {
            Console.WriteLine("OOOHHH Baby! We got something!!!");
            Console.WriteLine();
        }

        private static List<string> GetEmails(string url)
        {
            return EmailExtractorExtensions.GetEmails(url);
        }

        private static void WriteEmailsToFile(IEnumerable<string> emails)
        {
            HandleDirectory(@"C:\emails");

            using (var file = new StreamWriter($@"C:\emails\emails{DateTime.Now:yyyy-MM-dd HH.mm.ss}.txt"))
            {
                foreach (var email in emails)
                {
                    Console.WriteLine(email);
                    file.Write(email);
                    file.Write("\r\n");
                }
                WriteFooterWithExit();
            }
        }

        private static void HandleDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        private static void WriteFooterWithExit()
        {
            Console.WriteLine();
            Console.WriteLine("BAH HA HA HA, BAH HA HA HA, BAH HA HA HA, BAH HA HA HA");
            Console.WriteLine("Give it to me!");

            Console.ReadLine();
        }

        private static void WriteRejectionMessage()
        {
            Console.WriteLine("Sorry, Couldn't find them =[. Try another link please!");
            Console.ReadLine();
        }
    }
}