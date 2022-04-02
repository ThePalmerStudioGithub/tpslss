using DiscordRPC;
using DiscordRPC.Logging;
using Microsoft.WindowsAPICodePack.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBSWebsocketDotNet;

namespace Control_Panel
{
	public partial class Form1 : Form
	{
		public Form1()

		{
			InitializeComponent();
		}
		public OBSWebsocket socket = new OBSWebsocket();
		public DiscordRpcClient client;
		public int countdownseconds = 62;
		public string streamstarted = "false";
		void InitializeRPC()
		{
			/*
			Create a Discord client
			NOTE: 	If you are using Unity3D, you must use the full constructor and define
					 the pipe connection.
			*/
			client = new DiscordRpcClient("782873960932835338");

			//Set the logger
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};
			
			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				Details = "Idle",
				State = "Version " + Application.ProductVersion,
				Assets = new Assets()
                {
					LargeImageKey = "icon",
					LargeImageText = "TPSLSS Backend Ver " + Application.ProductVersion,
					SmallImageKey = "moon",
					SmallImageText = "Idle"
                },
				Buttons = new DiscordRPC.Button[]
				{
					new DiscordRPC.Button() {Label = "Website", Url = "https://thepalmerstudio.net"},
					new DiscordRPC.Button() {Label = "Learn more about TPSLSS", Url = "https://www.thepalmerstudio.net/tpslss"}
				}

			});

		}
		private void Form1_Load(object sender, EventArgs e)
        {
			socket.Connect(url: "ws://localhost:4444", password: "#Lockdown21");
			log.AppendText("[TPSLSS.Backend] Backend-Started \n Ver " + Application.ProductVersion + " \n ©2022 TPS™ Enterprises Inc. All Rights Reserved.");
			
		}



		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				InitializeRPC();
				log.AppendText("\n[Discord RPC] RPC-Initialized");
				

			}
			if (checkBox1.Checked == false)
			{
				client.Deinitialize();
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				log.AppendText("\n[Discord RPC] Details Changed To '" + textBox1.Text + "'");
				client.UpdateDetails(textBox1.Text);
			}
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				log.AppendText("\n[Discord RPC] State Changed To '" + textBox2.Text + "'");
				client.UpdateState(textBox2.Text);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			client.UpdateDetails("In OBS");
			client.UpdateState("Waiting...");
			System.Diagnostics.Process.Start(@"C:\Users\Blaine Palmer\Desktop\Recording");

		}

		private void button2_Click(object sender, EventArgs e)
		{
			client.UpdateDetails("In GIMP");
			client.UpdateState("Making a thumbnail");
			System.Diagnostics.Process.Start(@"E:\Program Files\GIMP 2\bin\gimp-2.10.exe");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://studio.youtube.com/?ref=tpslss");
		}

		private void button4_Click(object sender, EventArgs e)
		{

			log.AppendText("\n[Discord RPC] RPC-Premade-Presence-Set.Named[Ready]");
		
			client.SetPresence(new RichPresence()
			{
				Details = "Ready",
				State = "Version " + Application.ProductVersion,
				Assets = new Assets()
				{
					LargeImageKey = "icon",
					LargeImageText = "TPSLSS Backend Ver " + Application.ProductVersion,
					SmallImageKey = "check",
					SmallImageText = "Ready"
				},
					Buttons = new DiscordRPC.Button[]
				{
					new DiscordRPC.Button() {Label = "Learn more about TPSLSS", Url = "https://www.thepalmerstudio.net/tpslss"}
				}
			});
		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click_1(object sender, EventArgs e)
		{
			try {
				if (socket.GetStreamingStatus().IsStreaming == true)
				{
					client.SetPresence(new RichPresence()
					{
						Details = "Live now!",
						Timestamps = Timestamps.Now,
						Assets = new Assets()
						{
							LargeImageKey = "icon",
							LargeImageText = "The Palmer Studio Live Streaming System",
							SmallImageKey = "clapping",
							SmallImageText = "Live"
						},
						Buttons = new DiscordRPC.Button[]
					{
					new DiscordRPC.Button() {Label = "View Live Stream", Url = "https://www.youtube.com/channel/UCxGzR9gyqcZ7Pck2hMDFbdg"},
					new DiscordRPC.Button() {Label = "Learn more about TPSLSS", Url = "https://www.thepalmerstudio.net/tpslss"}
					}
					});
					notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
					notifyIcon1.BalloonTipTitle = "Important:";
					notifyIcon1.BalloonTipText = "Remember to press the streaming statuses button again after you're done streaming.";
					notifyIcon1.ShowBalloonTip(5000);
				}
				else
				{
					MessageBox.Show("Sorry you're not streaming!", "Message");
					

				}


			
			}
			catch (Exception ex)
			{

				if (ex.ToString().Contains("System.InvalidOperationException: The current state of the connection is not Open.") == true)
				{
					log.AppendText("\n[Discord RPC.Statuses.Premade] Error occurred:\n" + "The OBS Websocket Is Not Open.\n" + "Error Code [001-Socket]");
				}
				else
				{
					log.AppendText("\n[Discord RPC.Statuses.Premade] Error occurred:\n" + ex.ToString());

				}
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DiscordManagement managementweb = new DiscordManagement();
			managementweb.Show();
		}
		
		private void update_Tick(object sender, EventArgs e)
		{
			try  {
				string scenename = socket.GetCurrentScene().Name;
				if (scenename == "TPSLSS.Scene.Welcome")
				{
					client.UpdateState("Stream is starting soon.");
				}
				else if (scenename == "TPSLSS.Scene.In Partnership")
				{
					client.UpdateState("Displaying who the stream is in partnership with.");
				}
				else if (scenename == "TPSLSS.Scene.Countdown")
				{
					client.UpdateState("Counting down");
				}
				else if (scenename == "TPSLSS.Scene.Content")
				{
					client.UpdateState("Displaying content");
				}
				else if (scenename == "TPSLSS.Scene.End")
				{
					client.UpdateState("Stream is ending soon.");
				}
				else if (scenename == "TPSLSS.Scene.Test")
				{
					client.UpdateState("Doing test");


				}
				else if (scenename == "TPSLSS.Scene.Test.Overview")
				{
					client.UpdateState("Viewing test results");
				}
			}
			catch (Exception ex)
			{

			
				UpdateSceneSocketError(ex);
				update.Stop();
			}
		
		}
		public void UpdateSceneSocketError(Exception ex)
		{
			if (ex.ToString().Contains("System.InvalidOperationException: The current state of the connection is not Open."))
			{
				log.AppendText("\n[Discord RPC.Statuses.Premade] Error occurred:\n" + "The OBS Websocket Is Not Open.\n" + "Error Code [002-Socket]");
			}
		}





		private void button6_Click(object sender, EventArgs e)
		{
	
		}

		private void button7_Click(object sender, EventArgs e)
		{
			

			
		}

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
			if(e.KeyCode == Keys.Enter)
            {
				log.AppendText("\n[Discord RPC] Small Image Key Changed To '" + textBox3.Text + "'");
				client.UpdateSmallAsset(textBox3.Text);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
		
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
			this.Hide();
			client.UpdateDetails("Running in background");
			client.UpdateState("Idle");
		  
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			this.Show();
			client.UpdateDetails("Control Panel Window State:");

        }

        private void button9_Click(object sender, EventArgs e)
        {
	
			savetofilenetwork savetofilenetwork = new savetofilenetwork();
			savetofilenetwork.DoIt();
		   



		}

        private void button10_Click(object sender, EventArgs e)
        {
		
        }

        private void bytesreceived_Tick(object sender, EventArgs e)
        {
		
		}

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
			log.AppendText("\n[TPSLSS.Backend] Backend-Connection-Test-Started");
			// start welcome state
        
		
			File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\welcomestate.txt", "Starting internet connection test...");
			savetofilenetwork savetofilenetwork = new savetofilenetwork();
			savetofilenetwork.DoIt();
		

			
		}

        private void button2_Click_1(object sender, EventArgs e)
        {
			In_Partnership in_Partnership = new In_Partnership();
			in_Partnership.ShowDialog();
        }

        private void countdown_Click(object sender, EventArgs e)
        {
			log.AppendText("\n[TPSLSS.Backend] Backend-Countdown-Executed");
			countdowntimer.Start();
        }

        private void credits_Click(object sender, EventArgs e)
        {
			Credits credits = new Credits();
			credits.Start();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
		
        }

        private void state_Tick(object sender, EventArgs e)
        {
		   
			
		
		}

        private void button2_Click_3(object sender, EventArgs e)
        {
		
		
       
		
        }

		private void button3_Click_1(object sender, EventArgs e)
		{
			try
			{
				update.Start();
			}
            catch(Exception ex)
            {
				MessageBox.Show("An error occured: \n " + ex, "Message");
            }
        }

        private void button2_Click_4(object sender, EventArgs e)
        {
			try
			{
				log.AppendText("\n[TPSLSS.Backend] Backend-Output-Manager-Started");
				OutputManager outputManager = new OutputManager();
				outputManager.Show();
			}
			catch(Exception ex)
            {
				log.AppendText("\n[TPSLSS.Backend] Backend-Output-Manager-Failed\n Error Info:\n" + ex);
            }
        }

        private void clearlog_Click(object sender, EventArgs e)
        {
			log.Clear();
			log.AppendText("[TPSLSS.Backend] Backend-Refreshed-Log");

		}

        private void viewcodes_Click(object sender, EventArgs e)
        {
			Codes codes = new Codes();
			codes.ShowDialog();
        }

        private void countdowntimer_Tick(object sender, EventArgs e)
        {
			countdownseconds--;
			File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\countdown.txt", countdownseconds.ToString());
			if(countdownseconds == 0)
            {
				File.WriteAllText(@"E:\The Palmer Studio Live Streaming System(TPSLSS)\Resources\countdown.txt", countdownseconds.ToString());
				countdownseconds = 62;
				countdowntimer.Stop();

            }
	
        }
    }
}
