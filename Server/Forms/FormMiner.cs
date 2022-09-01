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
    public class FormMiner : Form
    {
        private IContainer components;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Guna2Panel guna2Panel1;

        private Guna2PictureBox guna2PictureBox1;

        private Guna2Separator guna2Separator1;

        private PictureBox pictureBox1;

        private Label label15;

        private Guna2GroupBox GroupDisc;

        private Label label2;

        public Guna2GradientButton button3;

        public Guna2GradientButton button2;

        public Guna2TextBox txtPool;

        public Guna2ComboBox comboInjection;

        public Guna2TextBox txtPass;

        public Guna2TextBox txtWallet;

        public Guna2TextBox txtThreads;

        private Guna2ShadowForm guna2ShadowForm1;

        public FormMiner()
        {
            InitializeComponent();
        }

        private void FormMiner_Load(object sender, EventArgs e)
        {
            try
            {
                comboInjection.SelectedIndex = 1;
                txtPool.Text = global::Server.Properties.Settings.Default.pool;
                txtWallet.Text = global::Server.Properties.Settings.Default.wallet;
                txtPass.Text = global::Server.Properties.Settings.Default.password;
                comboInjection.Text = global::Server.Properties.Settings.Default.algo;
                txtThreads.Text = global::Server.Properties.Settings.Default.threads;
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPool.Text) && !string.IsNullOrWhiteSpace(txtWallet.Text) && !string.IsNullOrWhiteSpace(txtPass.Text) && !string.IsNullOrWhiteSpace(comboInjection.Text) && !string.IsNullOrWhiteSpace(txtThreads.Text))
            {
                base.DialogResult = DialogResult.OK;
                global::Server.Properties.Settings.Default.pool = txtPool.Text;
                global::Server.Properties.Settings.Default.wallet = txtWallet.Text;
                global::Server.Properties.Settings.Default.password = txtPass.Text;
                global::Server.Properties.Settings.Default.algo = comboInjection.Text;
                global::Server.Properties.Settings.Default.threads = txtThreads.Text;
                global::Server.Properties.Settings.Default.Save();
                Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMiner));
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label15 = new System.Windows.Forms.Label();
            GroupDisc = new Guna.UI2.WinForms.Guna2GroupBox();
            txtThreads = new Guna.UI2.WinForms.Guna2TextBox();
            comboInjection = new Guna.UI2.WinForms.Guna2ComboBox();
            txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            txtWallet = new Guna.UI2.WinForms.Guna2TextBox();
            txtPool = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new System.Windows.Forms.Label();
            button3 = new Guna.UI2.WinForms.Guna2GradientButton();
            button2 = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GroupDisc.SuspendLayout();
            SuspendLayout();
            guna2BorderlessForm1.ContainerControl = this;
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.Controls.Add(guna2Separator1);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(label15);
            guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            guna2Panel1.Location = new System.Drawing.Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
            guna2Panel1.Size = new System.Drawing.Size(800, 78);
            guna2Panel1.TabIndex = 138;
            guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
            guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0f;
            guna2PictureBox1.Location = new System.Drawing.Point(759, 13);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
            guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
            guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 114;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
            guna2Separator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            guna2Separator1.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
            guna2Separator1.Location = new System.Drawing.Point(-198, 71);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new System.Drawing.Size(1197, 12);
            guna2Separator1.TabIndex = 13;
            guna2Separator1.UseTransparentBackground = true;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(12, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(40, 50);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label15.Location = new System.Drawing.Point(352, 27);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(67, 19);
            label15.TabIndex = 11;
            label15.Text = "MINER";
            GroupDisc.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
            GroupDisc.Controls.Add(txtThreads);
            GroupDisc.Controls.Add(comboInjection);
            GroupDisc.Controls.Add(txtPass);
            GroupDisc.Controls.Add(txtWallet);
            GroupDisc.Controls.Add(txtPool);
            GroupDisc.Controls.Add(label2);
            GroupDisc.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
            GroupDisc.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            GroupDisc.Font = new System.Drawing.Font("Electrolize", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            GroupDisc.ForeColor = System.Drawing.Color.LightGray;
            GroupDisc.Location = new System.Drawing.Point(35, 107);
            GroupDisc.Name = "GroupDisc";
            GroupDisc.ShadowDecoration.Parent = GroupDisc;
            GroupDisc.Size = new System.Drawing.Size(731, 289);
            GroupDisc.TabIndex = 153;
            GroupDisc.Text = "Miner Options";
            txtThreads.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtThreads.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtThreads.DefaultText = "";
            txtThreads.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            txtThreads.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
            txtThreads.DisabledState.ForeColor = System.Drawing.Color.DimGray;
            txtThreads.DisabledState.Parent = txtThreads;
            txtThreads.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
            txtThreads.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtThreads.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtThreads.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtThreads.FocusedState.ForeColor = System.Drawing.Color.LightGray;
            txtThreads.FocusedState.Parent = txtThreads;
            txtThreads.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtThreads.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtThreads.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtThreads.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtThreads.HoverState.ForeColor = System.Drawing.Color.LightGray;
            txtThreads.HoverState.Parent = txtThreads;
            txtThreads.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtThreads.Location = new System.Drawing.Point(15, 246);
            txtThreads.Name = "txtThreads";
            txtThreads.PasswordChar = '\0';
            txtThreads.PlaceholderText = "Threads";
            txtThreads.SelectedText = "";
            txtThreads.ShadowDecoration.Parent = txtThreads;
            txtThreads.Size = new System.Drawing.Size(121, 32);
            txtThreads.TabIndex = 155;
            comboInjection.BackColor = System.Drawing.Color.Transparent;
            comboInjection.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            comboInjection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboInjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboInjection.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            comboInjection.FocusedColor = System.Drawing.Color.FromArgb(191, 37, 33);
            comboInjection.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            comboInjection.FocusedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            comboInjection.FocusedState.ForeColor = System.Drawing.Color.WhiteSmoke;
            comboInjection.FocusedState.Parent = comboInjection;
            comboInjection.Font = new System.Drawing.Font("Electrolize", 9.749999f);
            comboInjection.ForeColor = System.Drawing.Color.LightGray;
            comboInjection.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            comboInjection.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            comboInjection.HoverState.ForeColor = System.Drawing.Color.DarkGray;
            comboInjection.HoverState.Parent = comboInjection;
            comboInjection.ItemHeight = 30;
            comboInjection.Items.AddRange(new object[10] { "cryptonight", "scrypt", "sha256d", "keccak", "quark", "heavy", "skein", "shavite3", "blake", "x11" });
            comboInjection.ItemsAppearance.Parent = comboInjection;
            comboInjection.Location = new System.Drawing.Point(14, 204);
            comboInjection.Name = "comboInjection";
            comboInjection.ShadowDecoration.Parent = comboInjection;
            comboInjection.Size = new System.Drawing.Size(122, 36);
            comboInjection.TabIndex = 154;
            txtPass.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtPass.DefaultText = "";
            txtPass.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
            txtPass.DisabledState.ForeColor = System.Drawing.Color.DimGray;
            txtPass.DisabledState.Parent = txtPass;
            txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
            txtPass.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtPass.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtPass.FocusedState.ForeColor = System.Drawing.Color.LightGray;
            txtPass.FocusedState.Parent = txtPass;
            txtPass.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtPass.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtPass.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtPass.HoverState.ForeColor = System.Drawing.Color.LightGray;
            txtPass.HoverState.Parent = txtPass;
            txtPass.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtPass.Location = new System.Drawing.Point(14, 168);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '\0';
            txtPass.PlaceholderText = "Password";
            txtPass.SelectedText = "";
            txtPass.ShadowDecoration.Parent = txtPass;
            txtPass.Size = new System.Drawing.Size(702, 32);
            txtPass.TabIndex = 153;
            txtWallet.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtWallet.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtWallet.DefaultText = "";
            txtWallet.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            txtWallet.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
            txtWallet.DisabledState.ForeColor = System.Drawing.Color.DimGray;
            txtWallet.DisabledState.Parent = txtWallet;
            txtWallet.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
            txtWallet.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtWallet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtWallet.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtWallet.FocusedState.ForeColor = System.Drawing.Color.LightGray;
            txtWallet.FocusedState.Parent = txtWallet;
            txtWallet.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtWallet.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtWallet.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtWallet.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtWallet.HoverState.ForeColor = System.Drawing.Color.LightGray;
            txtWallet.HoverState.Parent = txtWallet;
            txtWallet.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtWallet.Location = new System.Drawing.Point(14, 132);
            txtWallet.Name = "txtWallet";
            txtWallet.PasswordChar = '\0';
            txtWallet.PlaceholderText = "Wallet";
            txtWallet.SelectedText = "";
            txtWallet.ShadowDecoration.Parent = txtWallet;
            txtWallet.Size = new System.Drawing.Size(702, 32);
            txtWallet.TabIndex = 152;
            txtPool.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            txtPool.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtPool.DefaultText = "";
            txtPool.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            txtPool.DisabledState.FillColor = System.Drawing.Color.FromArgb(20, 20, 20);
            txtPool.DisabledState.ForeColor = System.Drawing.Color.DimGray;
            txtPool.DisabledState.Parent = txtPool;
            txtPool.DisabledState.PlaceholderForeColor = System.Drawing.Color.DimGray;
            txtPool.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtPool.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtPool.FocusedState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtPool.FocusedState.ForeColor = System.Drawing.Color.LightGray;
            txtPool.FocusedState.Parent = txtPool;
            txtPool.FocusedState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtPool.Font = new System.Drawing.Font("Segoe UI", 9f);
            txtPool.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            txtPool.HoverState.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            txtPool.HoverState.ForeColor = System.Drawing.Color.LightGray;
            txtPool.HoverState.Parent = txtPool;
            txtPool.HoverState.PlaceholderForeColor = System.Drawing.Color.Gray;
            txtPool.Location = new System.Drawing.Point(14, 97);
            txtPool.Name = "txtPool";
            txtPool.PasswordChar = '\0';
            txtPool.PlaceholderText = "Pool:Port";
            txtPool.SelectedText = "";
            txtPool.ShadowDecoration.Parent = txtPool;
            txtPool.Size = new System.Drawing.Size(702, 32);
            txtPool.TabIndex = 151;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.LightGray;
            label2.Location = new System.Drawing.Point(12, 78);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 147;
            label2.Text = "Input:";
            button3.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            button3.BorderThickness = 1;
            button3.CheckedState.Parent = button3;
            button3.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button3.CustomImages.Parent = button3;
            button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            button3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            button3.DisabledState.Parent = button3;
            button3.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            button3.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            button3.Font = new System.Drawing.Font("Electrolize", 9f);
            button3.ForeColor = System.Drawing.Color.White;
            button3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            button3.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button3.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            button3.HoverState.ForeColor = System.Drawing.Color.LightGray;
            button3.HoverState.Parent = button3;
            button3.Location = new System.Drawing.Point(630, 425);
            button3.Name = "button3";
            button3.ShadowDecoration.Parent = button3;
            button3.Size = new System.Drawing.Size(136, 32);
            button3.TabIndex = 155;
            button3.Text = "Cancel";
            button3.Click += new System.EventHandler(button3_Click);
            button2.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            button2.BorderThickness = 1;
            button2.CheckedState.Parent = button2;
            button2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button2.CustomImages.Parent = button2;
            button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            button2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            button2.DisabledState.Parent = button2;
            button2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            button2.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            button2.Font = new System.Drawing.Font("Electrolize", 9f);
            button2.ForeColor = System.Drawing.Color.White;
            button2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button2.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            button2.HoverState.ForeColor = System.Drawing.Color.LightGray;
            button2.HoverState.Parent = button2;
            button2.Location = new System.Drawing.Point(35, 425);
            button2.Name = "button2";
            button2.ShadowDecoration.Parent = button2;
            button2.Size = new System.Drawing.Size(136, 32);
            button2.TabIndex = 154;
            button2.Text = "Ok";
            button2.Click += new System.EventHandler(button2_Click);
            guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
            guna2ShadowForm1.TargetForm = this;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            base.ClientSize = new System.Drawing.Size(800, 485);
            base.Controls.Add(button3);
            base.Controls.Add(button2);
            base.Controls.Add(GroupDisc);
            base.Controls.Add(guna2Panel1);
            Font = new System.Drawing.Font("Electrolize", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ForeColor = System.Drawing.Color.LightGray;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "FormMiner";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormMiner";
            base.Load += new System.EventHandler(FormMiner_Load);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            GroupDisc.ResumeLayout(false);
            GroupDisc.PerformLayout();
            ResumeLayout(false);
        }
    }
}
