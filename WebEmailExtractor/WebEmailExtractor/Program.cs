using System;
using System.Collections.Generic;
using System.IO;

namespace WebEmailExtractor
{
    class Program
    {
        private static void Main()
        {
            // Copy the website link and paste it in between quotes!
            // If the program crashes, just hold Ctrl + z and the code will go back to a working state.
            var _url = "http://lgsdlgapk6.ss7.sharpschool.com/our_school/staff_directory";

            ExtractEmails(_url);
        }

        private static void ExtractEmails(string url)
        {
            if (GetEmails(url).Count > 0)
            {
                Console.WriteLine("OOOHHH Baby! We got something!!!");
                Console.WriteLine();

                WriteEmailsToFile(GetEmails(url));
            }
            else
            {
                Console.WriteLine("Sorry, Couldn't find them =[. Try another link please!");
                Console.ReadLine();
            }
        }

        private static List<string> GetEmails(string url)
        {
            return EmailExtractor.GetEmails(url);
        }

        private static void WriteEmailsToFile(IEnumerable<string> emails)
        {
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

        private static void WriteFooterWithExit()
        {
            Console.WriteLine();
            Console.WriteLine("BAH HA HA HA, BAH HA HA HA, BAH HA HA HA, BAH HA HA HA");
            Console.WriteLine("Give it to me!");

            Console.ReadLine();
        }
    }
}
