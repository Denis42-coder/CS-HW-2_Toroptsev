using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space
{
    class Splash : BaseObject1
    {
        public Splash(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        static Image Image { get; } = Image.FromFile("Images\\ship.png");

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image, Pos);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X - Dir.X, Pos.Y);
            if (Pos.X < -SplashScreen.Width)
                Dir = new Point(SplashScreen.Width + SplashScreen.Random.Next(1, 100), SplashScreen.Random.Next(0, SplashScreen.Height));
        }

    }

    class BaseObject1 : BaseObject
    {
        public BaseObject1(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X - Dir.X, Pos.Y);
            if (Pos.X < 0 || Pos.X > SplashScreen.Width)
                Dir = new Point(-Dir.X, -Dir.Y);
            if (Pos.Y < 0 || Pos.Y > SplashScreen.Height)
                Dir = new Point(Dir.X, -Dir.Y);
        }
    }

    class SplashScreen
    {
        static public ulong Timer { get; private set; } = 0;
        static BufferedGraphicsContext context;
        static public BufferedGraphics Buffer { get; private set; }
        static public Random Random { get; } = new Random();
        static public int Width { get; private set; }
        static public int Height { get; private set; }
        static public Image background = Image.FromFile("Images\\fon.jpg");

        static public BaseObject1[] objs;

        static Timer timer1 = new Timer();

        public SplashScreen()
        {

        }

        static public void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            timer1.Interval = 100;
            timer1.Tick += Timer_Tick1;
            timer1.Start();
            Load1();
            form.FormClosing += Form_FormClosing;
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private static void Timer_Tick1(object sender, EventArgs e)
        {
            SplashScreen.Draw();
            SplashScreen.Update();
        }

        static void Load1()
        {
            objs = new BaseObject1[100];

            //for (int i = 0; i < 100; i++)
            //    objs[i] = new Splash(new Point(SplashScreen.Width, SplashScreen.Random.Next(0, SplashScreen.Height)), new Point(-i, 0), new Size(20, 20));
            for (int i = 0; i < 100; i++)
                objs[i] = new Splash(new Point(SplashScreen.Width, SplashScreen.Random.Next(0, SplashScreen.Height)), new Point(-i, 0), new Size(20, 20));

        }

        static public void Draw()
        {
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (var obj in objs)
            {
                obj.Draw();
            }
            Buffer.Render();
        }

        static public void Update()
        {
            foreach (var obj in objs)
                obj.Update();
        }
    }
}
