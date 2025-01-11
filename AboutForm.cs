using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backsolate
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TryOpenLink(string link)
        {
            try
            {
                // Open the URL in the default web browser
                Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to open the link '{link}': {ex.Message}", "Unable to open link", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblGitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TryOpenLink("https://github.com/theonlyasdk/backsolate-win");
        }
    }
}
