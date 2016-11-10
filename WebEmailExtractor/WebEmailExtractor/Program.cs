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
            const string url = "http://lgsdlgapk6.ss7.sharpschool.com/our_school/staff_directory";

            EmailExtractor.ExtractEmails(url);
        }
    }
}
