using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Panel
{
    public class savetofilenetwork
    {
        public void DoIt()
        {


            
       

   
            try
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    // Network does not available.
                    return;
                }
                Uri uri = new Uri("https://thepalmerstudio.net/");
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(uri.Host);
                if (pingReply.Status == IPStatus.Success)
                {
                    File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\welcomestate.txt", "The stream start process can now continue.");
                }

            }
            catch (Exception ex)
            {
                File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\welcomestate.txt", "An error occurred.");
                MessageBox.Show(ex.ToString(), "Internet Connection Test Error");
            }
           
         

        }
    }
    }

