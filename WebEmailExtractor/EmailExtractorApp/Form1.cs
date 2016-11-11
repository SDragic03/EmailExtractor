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
            EmailExtractorFormExtensions = new EmailExtractorFormExtensions(this);
        }

        public EmailExtractorFormExtensions EmailExtractorFormExtensions { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            btnGetEmails.Enabled = false;
            label3.Visible = false;
            EmailExtractorFormExtensions.HandleReceivedEmails();
        }
    }
}
