using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    abstract class BaseObject: ICollision
    {
        protected Point Pos { get; set; }//X,Y
        protected Point Dir { get; set; }//X,Y
        protected Size Size { get; set; }

        public Rectangle Rect => new Rectangle(Pos,Size);

        public BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }

        public abstract void Draw();
        //{
        //    Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        //}

        public abstract void Update();
        //{
        //    Pos = new Point(Pos.X - Dir.X, Pos.Y);
        //    if (Pos.X < 0 || Pos.X > Game.Width)
        //        Dir = new Point(-Dir.X, -Dir.Y);
        //    if (Pos.Y < 0 || Pos.Y > Game.Height)
        //        Dir = new Point(Dir.X, -Dir.Y);
        //}        

        public bool Collision(ICollision obj)
        {
            return this.Rect.IntersectsWith(obj.Rect);
        }
    }   
    
    class Star: BaseObject
    {
        #region
        //public Star(Point pos, Point dir, Size size)
        //{
        //    this.Pos = pos;
        //    this.Dir = dir;
        //    this.Size = size;
        //}
        #endregion
        static Image Image { get; } = Image.FromFile("Images\\star.png");

        public Star(Point pos, Point dir, Size size):base(pos,dir,size)
        {
          
        }

        public override void Draw()
        {
            // Game.Buffer.Graphics.DrawImage(Image, Pos);
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, 10, 10);
        }       

         public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X < -Size.Width)
                Pos = new Point(Game.Width + Game.Random.Next(1, 100), Game.Random.Next(0, Game.Height));

        }
    }

    class Asteroid : BaseObject
    {
        // public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        //      Power = 1;
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawImage(Image, Pos);
            Game.Buffer.Graphics.FillEllipse(Brushes.Blue, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X < -Size.Width)
                Pos = new Point(Game.Width + Game.Random.Next(1, 100), Game.Random.Next(0, Game.Height));
        }
    }

    class Bullet: BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public static Action<Bullet> OverScreen { get; internal set; }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            //if (Pos.X > Game.Width)
            //    Pos = new Point(0, Game.Random.Next(0, Game.Height));
        }
    }

    class Ship : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\ship.png");
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos);
           // Game.Buffer.Graphics.FillEllipse(Brushes.Red, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X > Game.Width)
                Pos = new Point(0, Game.Random.Next(0, Game.Height));
        }

        public void Up()
        {
            Pos = new Point(Pos.X,Pos.Y - Dir.Y);
        }

        public void Down()
        {
            Pos = new Point(Pos.X, Pos.Y + Dir.Y);
        }

        public void SetPos(Point pos)
        {
            Pos = pos;
        }

        public Point GetPos => Pos;
    }

    class HealthBox : BaseObject
    {        
        public HealthBox(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
    
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawImage(Image, Pos);
            Game.Buffer.Graphics.FillRectangle(Brushes.Cyan, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X - Dir.X, Pos.Y);
            if (Pos.X < -Size.Width)
                Pos = new Point(Game.Width + Game.Random.Next(1, 100), Game.Random.Next(0, Game.Height));
        }
    }
}
