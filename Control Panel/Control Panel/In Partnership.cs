using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Panel
{
    public partial class In_Partnership : Form
    {
        public In_Partnership()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Applies the text to a file that will be displayed on TPSLSS Layout
            File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\inpartnershiptitle.txt", title.Text);
            File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\inpartnershipwith.txt", with.Text);

        }
    }
}
