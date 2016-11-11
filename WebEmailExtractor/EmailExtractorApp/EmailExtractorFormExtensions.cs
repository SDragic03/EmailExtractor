using System.Collections.Generic;
using WebEmailExtractor;

namespace EmailExtractorApp
{
    public class EmailExtractorFormExtensions
    {
        private readonly Form1 _form1;
        private int _emailCount;

        public EmailExtractorFormExtensions(Form1 form1)
        {
            _form1 = form1;
        }

        public void HandleReceivedEmails()
        {
            if (TextBoxIsNullOrEmpty())
                HandleEmptyUrlEvent();
            else if (GetEmailCount() > 0)
            {
                HandleSuccessEvent();
                WriteEmailsToFileAndList();
                WriteEmailCountToFile();
                DisplayTotalEmailCount();
                EnableGetEmailsButton();
            }
            else
                HandleFailureEvent();
        }

        private bool TextBoxIsNullOrEmpty()
        {
            return string.IsNullOrWhiteSpace(_form1.textBox1.Text);
        }

        private void HandleSuccessEvent()
        {
            _form1.listBox1.Items.Add("OOOHHH Baby! We got something!!!");
            _form1.listBox1.Items.Add("\r\n");
        }

        private void WriteEmailsToFileAndList()
        {
            var emailCollection = EmailExtractorExtensions.GetEmails(_form1.textBox1.Text);

            FileWriter.WriteEmailsToFile(emailCollection);
            WriteEmailsToList(emailCollection);
        }

        private void WriteEmailsToList(IEnumerable<string> emailCollection)
        {
            foreach (var email in emailCollection)
            {
                _form1.listBox1.Items.Add(email);
            }

            _form1.listBox1.Items.Add("\r\n");
            _form1.listBox1.Items.Add("Give it to me!");
        }

        private void WriteEmailCountToFile()
        {
            FileWriter.WriteEmailCountToFile(GetTotalEmailCount());
        }

        private void DisplayTotalEmailCount()
        {
            _form1.label3.Text = _emailCount.ToString();
            _form1.label3.Visible = true;
        }

        private void EnableGetEmailsButton()
        {
            _form1.btnGetEmails.Enabled = true;
        }

        private void HandleEmptyUrlEvent()
        {
            _form1.listBox1.Items.Add("Oops, looks like you forgot to paste in a URL =P!");
            _form1.btnGetEmails.Enabled = true;
        }

        private int GetEmailCount()
        {
            return EmailExtractorExtensions.GetEmails(_form1.textBox1.Text).Count;
        }

        public int GetTotalEmailCount()
        {
            return _emailCount = _emailCount + GetEmailCount();
        }

        private void HandleFailureEvent()
        {
            _form1.listBox1.Items.Add("Sorry, Couldn't find them or the URL is broken.");
            _form1.listBox1.Items.Add("Try another link please!");
            _form1.btnGetEmails.Enabled = true;
        }
    }
}