using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Server;
using Server.Connection;
using Server.MessagePack;


namespace PEGASUS.Design
{
    public class FormPowerShell : Form
    {
        private IContainer components;

        public System.Windows.Forms.Timer timer1;

        private PictureBox pictureBox8;

        private Panel panel1;

        public RichTextBox richTextBox1;

        private PictureBox pictureBox1;

        private Label label1;

        private Guna2TextBox textBox1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Guna2ShadowForm guna2ShadowForm1;

        public Form1 F { get; set; }

        internal Clients Client { get; set; }

        public FormPowerShell()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL")]
        private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormPowerShell_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitShell();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Client.TcpClient.Connected)
                {
                    Close();
                }
            }
            catch
            {
                Close();
            }
        }

        private void ExitShell()
        {
            try
            {
                Client?.Disconnected();
            }
            catch
            {
            }
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(base.Handle, 274, 61458, 0);
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Client == null || e.KeyData != Keys.Return || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }
            if (textBox1.Text == "cls".ToLower())
            {
                richTextBox1.Clear();
                textBox1.Clear();
                return;
            }
            if (textBox1.Text == "exit".ToLower())
            {
                ExitShell();
                Close();
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "powershellWriteInput";
            msgPack.ForcePathObject("WriteInput").AsString = textBox1.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            textBox1.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::Server.Properties.Resources.icons8_удалить_24;
            this.pictureBox8.Location = new System.Drawing.Point(777, 22);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(27, 23);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 29;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 70);
            this.panel1.TabIndex = 34;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(347, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "POWERSHELL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(242)))));
            this.richTextBox1.Location = new System.Drawing.Point(0, 70);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(816, 436);
            this.richTextBox1.TabIndex = 40;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "";
            this.textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.textBox1.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(38)))), ((int)(((byte)(33)))));
            this.textBox1.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.textBox1.FocusedState.ForeColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(38)))), ((int)(((byte)(33)))));
            this.textBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.textBox1.HoverState.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 506);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderText = "";
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(816, 36);
            this.textBox1.TabIndex = 41;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // FormPowerShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(816, 542);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPowerShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Shell";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPowerShell_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
