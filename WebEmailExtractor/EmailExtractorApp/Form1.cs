using System;
using System.Windows.Forms;
using WebEmailExtractor;

namespace EmailExtractorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            btnGetEmails.Enabled = false;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listBox1.Items.Add("Oops, looks like you forgot to paste in a URL =P!");
                btnGetEmails.Enabled = true;

            }
            else if (EmailExtractorExtensions.GetEmails(textBox1.Text).Count > 0)
            {
                listBox1.Items.Add("OOOHHH Baby! We got something!!!");
                listBox1.Items.Add("\r\n");

                var emailCollection = EmailExtractorExtensions.GetEmails(textBox1.Text);

                EmailToFileWriter.WriteEmailsToFile(emailCollection);
                foreach (var email in emailCollection)
                {
                    listBox1.Items.Add(email);
                }

                listBox1.Items.Add("\r\n");
                listBox1.Items.Add("Give it to me!");

                btnGetEmails.Enabled = true;
            }
            else
            {
                listBox1.Items.Add("Sorry, Couldn't find them =[. Try another link please!");
                btnGetEmails.Enabled = true;
            }
        }

    }
}
