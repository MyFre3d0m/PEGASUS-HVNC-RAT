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
    public class FrmEmailer : Form
    {
        private IContainer components;

        private Guna2Panel guna2Panel1;

        private Guna2PictureBox guna2PictureBox1;

        private Guna2Separator guna2Separator1;

        private PictureBox pictureBox1;

        private Label label15;

        private Guna2ShadowForm guna2ShadowForm1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        public Guna2GradientButton btnSend;

        private Label label4;

        private Label label3;

        private Label label2;

        private Label label1;

        private Label label8;

        private Label label7;

        private Label label6;

        private Label label5;

        public Guna2TextBox txtBody;

        public Guna2TextBox txtHost;

        public Guna2TextBox txtPassword;

        public Guna2TextBox txttoEmail;

        public Guna2TextBox txtsubject;

        public Guna2TextBox txtfromEmail;

        public Guna2TextBox txtEmailPort;

        public Guna2TextBox guna2TextBox2;

        public FrmEmailer()
        {
            InitializeComponent();
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

        private void FrmEmailer_Load(object sender, EventArgs e)
        {
            txtfromEmail.Text = global::Server.Properties.Settings.Default.txtfromEmail;
            txttoEmail.Text = global::Server.Properties.Settings.Default.txttoEmail;
            txtPassword.Text = global::Server.Properties.Settings.Default.txtemailPass;
            txtBody.Text = global::Server.Properties.Settings.Default.txtBody;
            txtsubject.Text = global::Server.Properties.Settings.Default.txtSubject;
            txtEmailPort.Text = global::Server.Properties.Settings.Default.emailport;
            txtHost.Text = global::Server.Properties.Settings.Default.Host;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtfromEmail.Text) && !string.IsNullOrWhiteSpace(txttoEmail.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtsubject.Text) && !string.IsNullOrWhiteSpace(txtBody.Text) && !string.IsNullOrWhiteSpace(txtEmailPort.Text) && !string.IsNullOrWhiteSpace(txtHost.Text))
            {
                base.DialogResult = DialogResult.OK;
                global::Server.Properties.Settings.Default.txtfromEmail = txtfromEmail.Text;
                global::Server.Properties.Settings.Default.txttoEmail = txttoEmail.Text;
                global::Server.Properties.Settings.Default.txtemailPass = txtPassword.Text;
                global::Server.Properties.Settings.Default.txtBody = txtBody.Text;
                global::Server.Properties.Settings.Default.txtSubject = txtsubject.Text;
                global::Server.Properties.Settings.Default.emailport = txtEmailPort.Text;
                global::Server.Properties.Settings.Default.Host = txtHost.Text;
                global::Server.Properties.Settings.Default.Save();
                Hide();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.txtBody = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSend = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtEmailPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtfromEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtsubject = new Guna.UI2.WinForms.Guna2TextBox();
            this.txttoEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHost = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.label15);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(973, 78);
            this.guna2Panel1.TabIndex = 140;
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(932, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(29, 29);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 114;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2Separator1.Location = new System.Drawing.Point(-198, 71);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1370, 12);
            this.guna2Separator1.TabIndex = 13;
            this.guna2Separator1.UseTransparentBackground = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.LightGray;
            this.label15.Location = new System.Drawing.Point(416, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 20);
            this.label15.TabIndex = 11;
            this.label15.Text = "EMAIL SENDER";
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            // 
            // txtBody
            // 
            this.txtBody.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBody.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBody.DefaultText = "<a href=\"YOUR LINK HERE\" DOWNLOAD>";
            this.txtBody.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txtBody.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtBody.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBody.DisabledState.Parent = this.txtBody;
            this.txtBody.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBody.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtBody.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtBody.FocusedState.Parent = this.txtBody;
            this.txtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtBody.HoverState.Parent = this.txtBody;
            this.txtBody.Location = new System.Drawing.Point(56, 207);
            this.txtBody.Name = "txtBody";
            this.txtBody.PasswordChar = '\0';
            this.txtBody.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBody.PlaceholderText = "Body";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.SelectedText = "";
            this.txtBody.SelectionStart = 34;
            this.txtBody.ShadowDecoration.Parent = this.txtBody;
            this.txtBody.Size = new System.Drawing.Size(865, 191);
            this.txtBody.TabIndex = 155;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnSend.BorderThickness = 1;
            this.btnSend.CheckedState.Parent = this.btnSend;
            this.btnSend.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.CustomImages.Parent = this.btnSend;
            this.btnSend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSend.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSend.DisabledState.Parent = this.btnSend;
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnSend.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnSend.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnSend.HoverState.ForeColor = System.Drawing.Color.LightGray;
            this.btnSend.HoverState.Parent = this.btnSend;
            this.btnSend.Location = new System.Drawing.Point(785, 583);
            this.btnSend.Name = "btnSend";
            this.btnSend.ShadowDecoration.Parent = this.btnSend;
            this.btnSend.Size = new System.Drawing.Size(136, 32);
            this.btnSend.TabIndex = 153;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtEmailPort
            // 
            this.txtEmailPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmailPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmailPort.DefaultText = "587";
            this.txtEmailPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txtEmailPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtEmailPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmailPort.DisabledState.Parent = this.txtEmailPort;
            this.txtEmailPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmailPort.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtEmailPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtEmailPort.FocusedState.Parent = this.txtEmailPort;
            this.txtEmailPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtEmailPort.HoverState.Parent = this.txtEmailPort;
            this.txtEmailPort.Location = new System.Drawing.Point(56, 405);
            this.txtEmailPort.Name = "txtEmailPort";
            this.txtEmailPort.PasswordChar = '\0';
            this.txtEmailPort.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmailPort.PlaceholderText = "Port";
            this.txtEmailPort.SelectedText = "";
            this.txtEmailPort.SelectionStart = 3;
            this.txtEmailPort.ShadowDecoration.Parent = this.txtEmailPort;
            this.txtEmailPort.Size = new System.Drawing.Size(865, 22);
            this.txtEmailPort.TabIndex = 158;
            // 
            // txtfromEmail
            // 
            this.txtfromEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfromEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfromEmail.DefaultText = "";
            this.txtfromEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txtfromEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtfromEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfromEmail.DisabledState.Parent = this.txtfromEmail;
            this.txtfromEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfromEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtfromEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtfromEmail.FocusedState.Parent = this.txtfromEmail;
            this.txtfromEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfromEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtfromEmail.HoverState.Parent = this.txtfromEmail;
            this.txtfromEmail.Location = new System.Drawing.Point(56, 434);
            this.txtfromEmail.Name = "txtfromEmail";
            this.txtfromEmail.PasswordChar = '\0';
            this.txtfromEmail.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfromEmail.PlaceholderText = "Email";
            this.txtfromEmail.SelectedText = "";
            this.txtfromEmail.ShadowDecoration.Parent = this.txtfromEmail;
            this.txtfromEmail.Size = new System.Drawing.Size(865, 22);
            this.txtfromEmail.TabIndex = 159;
            // 
            // txtsubject
            // 
            this.txtsubject.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsubject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsubject.DefaultText = "";
            this.txtsubject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txtsubject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtsubject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsubject.DisabledState.Parent = this.txtsubject;
            this.txtsubject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsubject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtsubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtsubject.FocusedState.Parent = this.txtsubject;
            this.txtsubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubject.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtsubject.HoverState.Parent = this.txtsubject;
            this.txtsubject.Location = new System.Drawing.Point(56, 178);
            this.txtsubject.Name = "txtsubject";
            this.txtsubject.PasswordChar = '\0';
            this.txtsubject.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsubject.PlaceholderText = "Subject";
            this.txtsubject.SelectedText = "";
            this.txtsubject.ShadowDecoration.Parent = this.txtsubject;
            this.txtsubject.Size = new System.Drawing.Size(865, 22);
            this.txtsubject.TabIndex = 160;
            // 
            // txttoEmail
            // 
            this.txttoEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttoEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttoEmail.DefaultText = "";
            this.txttoEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txttoEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txttoEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttoEmail.DisabledState.Parent = this.txttoEmail;
            this.txttoEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttoEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txttoEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txttoEmail.FocusedState.Parent = this.txttoEmail;
            this.txttoEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttoEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txttoEmail.HoverState.Parent = this.txttoEmail;
            this.txttoEmail.Location = new System.Drawing.Point(56, 149);
            this.txttoEmail.Name = "txttoEmail";
            this.txttoEmail.PasswordChar = '\0';
            this.txttoEmail.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttoEmail.PlaceholderText = "To";
            this.txttoEmail.SelectedText = "";
            this.txttoEmail.ShadowDecoration.Parent = this.txttoEmail;
            this.txttoEmail.Size = new System.Drawing.Size(865, 22);
            this.txttoEmail.TabIndex = 161;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.Location = new System.Drawing.Point(56, 463);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new System.Drawing.Size(865, 22);
            this.txtPassword.TabIndex = 162;
            // 
            // txtHost
            // 
            this.txtHost.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHost.DefaultText = "smtp.gmail.com";
            this.txtHost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.txtHost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtHost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHost.DisabledState.Parent = this.txtHost;
            this.txtHost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHost.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtHost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtHost.FocusedState.Parent = this.txtHost;
            this.txtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.txtHost.HoverState.Parent = this.txtHost;
            this.txtHost.Location = new System.Drawing.Point(56, 492);
            this.txtHost.Name = "txtHost";
            this.txtHost.PasswordChar = '\0';
            this.txtHost.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHost.PlaceholderText = "Smtp Host";
            this.txtHost.SelectedText = "";
            this.txtHost.SelectionStart = 14;
            this.txtHost.ShadowDecoration.Parent = this.txtHost;
            this.txtHost.Size = new System.Drawing.Size(865, 22);
            this.txtHost.TabIndex = 163;
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Location = new System.Drawing.Point(56, 521);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.PlaceholderText = "Number of emails to send";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Size = new System.Drawing.Size(865, 22);
            this.guna2TextBox2.TabIndex = 164;
            this.guna2TextBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(27, 571);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 169;
            this.label1.Text = "Port 587: ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(27, 587);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 170;
            this.label2.Text = "Port 2525: ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(27, 603);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 171;
            this.label3.Text = "Port 465: ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(27, 619);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 172;
            this.label4.Text = "Port 25: ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 571);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 173;
            this.label5.Text = "The standard secure SMTP port";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 13);
            this.label6.TabIndex = 174;
            this.label6.Text = "A common alternate SMTP port";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 603);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 13);
            this.label7.TabIndex = 175;
            this.label7.Text = "Deprecated and out-of-date SMTP port";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 619);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 13);
            this.label8.TabIndex = 176;
            this.label8.Text = "The original standard SMTP port";
            // 
            // FrmEmailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(973, 659);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2TextBox2);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txttoEmail);
            this.Controls.Add(this.txtsubject);
            this.Controls.Add(this.txtfromEmail);
            this.Controls.Add(this.txtEmailPort);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEmailer";
            this.Text = "FrmEmailer";
            this.Load += new System.EventHandler(this.FrmEmailer_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
