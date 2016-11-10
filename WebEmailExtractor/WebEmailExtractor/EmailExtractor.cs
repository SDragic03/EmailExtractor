using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebEmailExtractor
{
    public class EmailExtractor
    {
        public static List<string> GetEmails(string url)
        {
            var webCLient = new WebClient();
            var data = webCLient.DownloadData(url);
            var download = Encoding.ASCII.GetString(data);

            download = download.Replace("<em>", "");
            download = download.Replace("</em>", "");
            download = download.Replace("<b>", "");
            download = download.Replace("</b>", "");

            System.Diagnostics.Debug.WriteLine(download);

            var collection = Regex.Matches(download, EmailRegex());

            var distinct = collection.OfType<Match>().Select(m => m.Value).Distinct();
            var foundEmails = distinct.Select(x => x.ToString()).ToList();

            return foundEmails;
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