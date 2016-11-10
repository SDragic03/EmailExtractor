using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WebEmailExtractor
{
    public class EmailExtractorExtensions
    {
        public static List<string> GetEmails(string url)
        {
            try
            {
                var webCLient = new WebClient();
                var data = webCLient.DownloadData(url);
                var download = Encoding.ASCII.GetString(data);

                download = download.Replace("<em>", "");
                download = download.Replace("</em>", "");
                download = download.Replace("<b>", "");
                download = download.Replace("</b>", "");

                Debug.WriteLine(download);

                var collection = Regex.Matches(download, EmailRegex());
                var distinct = collection.OfType<Match>().Select(m => m.Value).Distinct();
                var foundEmails = distinct.Select(x => x.ToString()).ToList();

                return foundEmails;
            }
            catch (Exception)
            {
                MessageBox.Show("The URL seems to be broken! Please try again or use another URL.");
                if (Form.ActiveForm != null) Form.ActiveForm.Close();
            }
            return null;
        }

        private static string EmailRegex()
        {
            return @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                   + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                   + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                   + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
        }
    }
}