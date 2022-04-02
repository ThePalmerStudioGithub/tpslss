using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
namespace Control_Panel
{
    public partial class DiscordManagement : Form
    {
        public DiscordManagement()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var responseString = await textBox1.Text.ToString()
        .PostUrlEncodedAsync(new { content = textBox2.Text})
        .ReceiveString();
        }

        private void DiscordManagement_Load(object sender, EventArgs e)
        {
          
        }

        private void DiscordManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.client.UpdateDetails("In Control Panel");
            form1.client.UpdateState("Waiting for an action");
           
        }
    }
}
