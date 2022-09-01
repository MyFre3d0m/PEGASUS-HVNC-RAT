using System;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;

namespace Server.MessagePack
{
    internal class Client
    {
        public TcpClient desktopClient;

        public TcpClient inputClient;

        public object Server;

        public long uhid;

        public IntPtr hWnd;

        public ManualResetEvent minEvent;

        public byte[] pixels;

        public int pixelsWidth;

        public int pixelsHeight;

        public int screenWidth;

        public int screenHeight;

        public Image Bitmap;

        public bool fullScreen;

        public int wndLeft;

        public int wndTop;

        public int wndRight;

        public int wndBottom;
    }
}
