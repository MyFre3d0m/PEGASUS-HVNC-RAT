using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Server.Properties;

namespace PEGASUS.Design
{
    public class FrmWebHookSPM : Form
    {
        public bool IsOK;

        private IContainer components;

        private Guna2GradientButton btnExec;

        private Guna2Panel guna2Panel1;

        private Label label1;

        private Guna2PictureBox guna2PictureBox7;

        private Guna2Separator guna2Separator1;

        private PictureBox pictureBox1;

        private Label label4;

        private Label label3;

        private Label label2;

        private Guna2ShadowForm guna2ShadowForm1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        public Guna2TextBox txtMessage;

        public Guna2TextBox txtTimes;

        public Guna2TextBox txtHook;

        public FrmWebHookSPM()
        {
            InitializeComponent();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        [DllImport("user32.DLL")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL")]
        private static extern void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(base.Handle, 274, 61458, 0);
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtHook.Text) && !string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                base.DialogResult = DialogResult.OK;
                global::Server.Properties.Settings.Default.hook = txtHook.Text;
                global::Server.Properties.Settings.Default.message = txtMessage.Text;
                global::Server.Properties.Settings.Default.times = Convert.ToInt32(txtTimes.Text);
                global::Server.Properties.Settings.Default.Save();
                IsOK = false;
                Hide();
            }
        }

        private void FrmWebHookSPM_Load(object sender, EventArgs e)
        {
            try
            {
                txtHook.Text = global::Server.Properties.Settings.Default.hook;
                txtMessage.Text = global::Server.Properties.Settings.Default.message;
                txtTimes.Text = Convert.ToString(global::Server.Properties.Settings.Default.times);
            }
            catch
            {
            }
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWebHookSPM));
            btnExec = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new System.Windows.Forms.Label();
            guna2PictureBox7 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            txtHook = new Guna.UI2.WinForms.Guna2TextBox();
            txtTimes = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            btnExec.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            btnExec.BorderThickness = 1;
            btnExec.CheckedState.Parent = btnExec;
            btnExec.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnExec.CustomImages.Parent = btnExec;
            btnExec.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            btnExec.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(30, 30, 30);
            btnExec.DisabledState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            btnExec.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            btnExec.DisabledState.ForeColor = System.Drawing.Color.DimGray;
            btnExec.DisabledState.Parent = btnExec;
            btnExec.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            btnExec.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            btnExec.Font = new System.Drawing.Font("Electrolize", 9f);
            btnExec.ForeColor = System.Drawing.Color.White;
            btnExec.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnExec.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            btnExec.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            btnExec.HoverState.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            btnExec.HoverState.ForeColor = System.Drawing.Color.FromArgb(191, 37, 33);
            btnExec.HoverState.Parent = btnExec;
            btnExec.Location = new System.Drawing.Point(555, 413);
            btnExec.Name = "btnExec";
            btnExec.ShadowDecoration.Parent = btnExec;
            btnExec.Size = new System.Drawing.Size(182, 30);
            btnExec.TabIndex = 126;
            btnExec.Text = "Execute";
            btnExec.Click += new System.EventHandler(btnExec_Click);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(guna2PictureBox7);
            guna2Panel1.Controls.Add(guna2Separator1);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            guna2Panel1.Location = new System.Drawing.Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
            guna2Panel1.Size = new System.Drawing.Size(800, 67);
            guna2Panel1.TabIndex = 127;
            guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.LightGray;
            label1.Location = new System.Drawing.Point(306, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(191, 19);
            label1.TabIndex = 15;
            label1.Text = "WEBHOOK SPAMMER";
            guna2PictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            guna2PictureBox7.BackColor = System.Drawing.Color.Transparent;
            guna2PictureBox7.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox7.Image");
            guna2PictureBox7.ImageRotate = 0f;
            guna2PictureBox7.Location = new System.Drawing.Point(759, 12);
            guna2PictureBox7.Name = "guna2PictureBox7";
            guna2PictureBox7.ShadowDecoration.Parent = guna2PictureBox7;
            guna2PictureBox7.Size = new System.Drawing.Size(29, 27);
            guna2PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            guna2PictureBox7.TabIndex = 14;
            guna2PictureBox7.TabStop = false;
            guna2PictureBox7.UseTransparentBackground = true;
            guna2PictureBox7.Click += new System.EventHandler(guna2PictureBox7_Click);
            guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
            guna2Separator1.Location = new System.Drawing.Point(-250, 61);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new System.Drawing.Size(1300, 10);
            guna2Separator1.TabIndex = 13;
            guna2Separator1.UseTransparentBackground = true;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(40, 42);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(63, 120);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 14);
            label2.TabIndex = 128;
            label2.Text = "Webhook:";
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(63, 161);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 14);
            label3.TabIndex = 131;
            label3.Text = "Message:";
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(63, 332);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 14);
            label4.TabIndex = 132;
            label4.Text = "Times:";
            guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
            guna2ShadowForm1.TargetForm = this;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtMessage.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtMessage.DefaultText = "";
            txtMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            txtMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            txtMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtMessage.DisabledState.Parent = txtMessage;
            txtMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtMessage.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtMessage.FocusedState.Parent = txtMessage;
            txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtMessage.HoverState.Parent = txtMessage;
            txtMessage.Location = new System.Drawing.Point(63, 178);
            txtMessage.Name = "txtMessage";
            txtMessage.PasswordChar = '\0';
            txtMessage.PlaceholderText = "";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.Parent = txtMessage;
            txtMessage.Size = new System.Drawing.Size(674, 151);
            txtMessage.TabIndex = 153;
            txtHook.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtHook.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtHook.DefaultText = "";
            txtHook.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            txtHook.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            txtHook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtHook.DisabledState.Parent = txtHook;
            txtHook.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtHook.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtHook.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtHook.FocusedState.Parent = txtHook;
            txtHook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtHook.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtHook.HoverState.Parent = txtHook;
            txtHook.Location = new System.Drawing.Point(63, 137);
            txtHook.Name = "txtHook";
            txtHook.PasswordChar = '\0';
            txtHook.PlaceholderText = "";
            txtHook.SelectedText = "";
            txtHook.ShadowDecoration.Parent = txtHook;
            txtHook.Size = new System.Drawing.Size(674, 21);
            txtHook.TabIndex = 154;
            txtTimes.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtTimes.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtTimes.DefaultText = "";
            txtTimes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            txtTimes.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            txtTimes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtTimes.DisabledState.Parent = txtTimes;
            txtTimes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtTimes.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtTimes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtTimes.FocusedState.Parent = txtTimes;
            txtTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtTimes.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtTimes.HoverState.Parent = txtTimes;
            txtTimes.Location = new System.Drawing.Point(63, 349);
            txtTimes.Name = "txtTimes";
            txtTimes.PasswordChar = '\0';
            txtTimes.PlaceholderText = "";
            txtTimes.SelectedText = "";
            txtTimes.ShadowDecoration.Parent = txtTimes;
            txtTimes.Size = new System.Drawing.Size(149, 21);
            txtTimes.TabIndex = 155;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            base.ClientSize = new System.Drawing.Size(800, 485);
            base.Controls.Add(txtTimes);
            base.Controls.Add(txtHook);
            base.Controls.Add(txtMessage);
            base.Controls.Add(label4);
            base.Controls.Add(label3);
            base.Controls.Add(label2);
            base.Controls.Add(guna2Panel1);
            base.Controls.Add(btnExec);
            Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ForeColor = System.Drawing.Color.LightGray;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "FrmWebHookSPM";
            Text = "WebHook Spamer";
            base.Load += new System.EventHandler(FrmWebHookSPM_Load);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
