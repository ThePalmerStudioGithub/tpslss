namespace Control_Panel
{
    partial class OutputManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputManager));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.allscenes = new System.Windows.Forms.TreeView();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.updateliveduration = new System.Windows.Forms.Timer(this.components);
            this.streamstatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.systeminfotext = new System.Windows.Forms.Label();
            this.gettestresults = new System.Windows.Forms.Button();
            this.logtitle = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1048, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 39);
            this.button2.TabIndex = 0;
            this.button2.Text = "Start or Stop Streaming";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1237, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start or Stop Recording";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Change Scenes:";
            // 
            // allscenes
            // 
            this.allscenes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.allscenes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allscenes.Location = new System.Drawing.Point(12, 43);
            this.allscenes.Name = "allscenes";
            this.allscenes.Size = new System.Drawing.Size(488, 360);
            this.allscenes.TabIndex = 3;
            this.allscenes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // update
            // 
            this.update.Interval = 1000;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // updateliveduration
            // 
            this.updateliveduration.Interval = 1000;
            this.updateliveduration.Tick += new System.EventHandler(this.updateliveduration_Tick);
            // 
            // streamstatus
            // 
            this.streamstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.streamstatus.AutoSize = true;
            this.streamstatus.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streamstatus.ForeColor = System.Drawing.Color.Red;
            this.streamstatus.Location = new System.Drawing.Point(12, 404);
            this.streamstatus.Name = "streamstatus";
            this.streamstatus.Size = new System.Drawing.Size(125, 37);
            this.streamstatus.TabIndex = 11;
            this.streamstatus.Text = "Not Live";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1145, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 40);
            this.label2.TabIndex = 12;
            this.label2.Text = "System Info:";
            // 
            // systeminfotext
            // 
            this.systeminfotext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.systeminfotext.AutoSize = true;
            this.systeminfotext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systeminfotext.Location = new System.Drawing.Point(1148, 49);
            this.systeminfotext.Name = "systeminfotext";
            this.systeminfotext.Size = new System.Drawing.Size(120, 21);
            this.systeminfotext.TabIndex = 13;
            this.systeminfotext.Text = "Not streaming";
            // 
            // gettestresults
            // 
            this.gettestresults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gettestresults.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gettestresults.Location = new System.Drawing.Point(911, 409);
            this.gettestresults.Name = "gettestresults";
            this.gettestresults.Size = new System.Drawing.Size(131, 39);
            this.gettestresults.TabIndex = 14;
            this.gettestresults.Text = "Get Test Results";
            this.gettestresults.UseVisualStyleBackColor = true;
            this.gettestresults.Click += new System.EventHandler(this.button3_Click);
            // 
            // logtitle
            // 
            this.logtitle.AutoSize = true;
            this.logtitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logtitle.Location = new System.Drawing.Point(499, 0);
            this.logtitle.Name = "logtitle";
            this.logtitle.Size = new System.Drawing.Size(76, 40);
            this.logtitle.TabIndex = 16;
            this.logtitle.Text = "Log:";
            // 
            // log
            // 
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.log.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(506, 43);
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(623, 360);
            this.log.TabIndex = 17;
            this.log.Text = "";
            this.log.TextChanged += new System.EventHandler(this.log_TextChanged);
            // 
            // OutputManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 450);
            this.Controls.Add(this.log);
            this.Controls.Add(this.logtitle);
            this.Controls.Add(this.gettestresults);
            this.Controls.Add(this.systeminfotext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.streamstatus);
            this.Controls.Add(this.allscenes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutputManager";
            this.Text = "Output Manager - TPSLSS Backend";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OutputManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView allscenes;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.Timer updateliveduration;
        private System.Windows.Forms.Label streamstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label systeminfotext;
        private System.Windows.Forms.Button gettestresults;
        private System.Windows.Forms.Label logtitle;
        private System.Windows.Forms.RichTextBox log;
    }
}