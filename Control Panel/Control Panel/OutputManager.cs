using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBSWebsocketDotNet;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Control_Panel
{
    public partial class OutputManager : Form
    {
        public OutputManager()
        {
            InitializeComponent();
        }
        public OBSWebsocket socket = new OBSWebsocket();

        public int seconds = 0;
        private static readonly HttpClient client = new HttpClient();
        private void button2_Click(object sender, EventArgs e)
        {
            update.Start();
            socket.StartStopStreaming();
           if(socket.GetStreamingStatus().IsStreaming == false)
            {
                var url = "https://discord.com/api/webhooks/942003398155333692/u9RZ_KoD0O3ukh8Y5EFczbZO5ca_jnYd8cGLYxQu-CHNTaPJEogNqaPdSCRagxan1z2J";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/json";

                var data = @"{
""content"": """",
  ""embeds"": [
    {
      ""title"": ""🔔Live Stream Notification🔔"",
      ""description"": ""** 🔴LIVE NOW AT:\nhttps://www.youtube.com/channel/UCxGzR9gyqcZ7Pck2hMDFbdg **"",
      ""color"": 16712965,
      ""footer"": {
        ""text"": ""This is an automated message. ©2022 TPS™ Enterprises Inc. All Rights Reserved."",
        ""icon_url"": ""https://cdn.discordapp.com/avatars/942003398155333692/c7d3cedce2e2f58f23c8a6f9119643cb.png""
      },
      ""thumbnail"": {
        ""url"": ""https://cdn.discordapp.com/avatars/942003398155333692/c7d3cedce2e2f58f23c8a6f9119643cb.png""
      }
    }
  ]
}";

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                Console.WriteLine(httpResponse.StatusCode);
                log.AppendText("[TPSLSS.Backend] Start Streaming");
                

            }
        }

        private void OutputManager_Load(object sender, EventArgs e)
        {
            try
            {
                socket.Connect(url: "ws://localhost:4444", password: "#Lockdown21");
                var scenes = socket.ListScenes();
                allscenes.Nodes.Clear();
                foreach (var scene in scenes)
                {
                    var node = new TreeNode(scene.Name);
                    foreach (var item in scene.Items)
                    {
                        node.Nodes.Add(item.SourceName);
                    }

                    allscenes.Nodes.Add(node);
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                this.Close();
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            socket.StartStopRecording();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            socket.SetCurrentScene(allscenes.SelectedNode.Text);
        }

        private void update_Tick(object sender, EventArgs e)
        {
            if (socket.IsConnected == true)
            {
                if (socket.GetStreamingStatus().IsStreaming == true)
                {
                    string systeminfo = System.IO.File.ReadAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Snaz\TextFiles\SystemInfo.txt");
                    systeminfotext.Text = systeminfo;
                    updateliveduration.Start();
               
                    streamstatus.ForeColor = Color.Lime;
                    streamstatus.Text = "🔴LIVE";
                if(socket.GetStats().OutputSkippedFrames > 120)
                    {


                        socket.StopStreaming();
                        
                        
                    }
                }
                else
                {
                    updateliveduration.Stop();
                    int seconds = 0;
                    systeminfotext.Text = "Not streaming";
                    log.Text = "[TPSLSS.Backend] Stop Streaming";
                    streamstatus.Text = "Not Live";
                    streamstatus.ForeColor = Color.Red;

                }
            }
        }

        private void updateliveduration_Tick(object sender, EventArgs e)
        {

            seconds++;
            
            log.Text = "[TPSLSS.Backend] LIVE FOR " + seconds.ToString() + " seconds, Frames Rendered: " + socket.GetStats().OutputTotalFrames.ToString() + ", FPS: " + socket.GetStats().FPS.ToString() + " and Frames Skipped:" + socket.GetStats().OutputSkippedFrames.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string welcomestate = File.ReadAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\welcomestate.txt");
            string systeminfo = File.ReadAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Snaz\TextFiles\SystemInfo.txt");
            if (welcomestate == "The stream start process can now continue.")
            {
                File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Control Panel\Control Panel\Resources\Test Overview.txt", "Internet Connection Test:\n✔Passed\n Everything's good.");
            }
            else
            {
                socket.SetCurrentScene("TPSLSS.Scene.Error");
            }
        }

        private void log_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

