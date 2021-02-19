using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Space
{
    abstract class Game
    {
        static public ulong Timer { get; private set; } = 0;
        static Timer timer = new Timer();
        static public Random Random { get; } = new Random();
        static public int CountA = 5;
        static public int remained;

        static BufferedGraphicsContext context;
        static public BufferedGraphics Buffer { get; private set; }
        static public int Width { get; private set; }   // Ширина игрового поля
        static public int Height { get; private set; }  // Высота игрового поля
        static public Image background = Image.FromFile("Images\\fon.jpg");
        #region
        //static public BaseObject[] objs;
        //static public Bullet bullet;// = new Bullet(new Point(0, 400), new Point(5, 0), new Size(20, 2));
        #endregion
        static public List<Star> stars;
        static public List<Asteroid> asteroids;
        static public List<Bullet> bullets;
        static public List<HealthBox> health;
        static public Ship ship;

        static public int Health { get; private set; } = 100;
        static public int Hit { get; private set; } = 0;

        static Game()
        {

        }

        static public void Init(Form form)
        {                  
            Graphics g;                                // Графическое устройство для вывода графики                 
            context = BufferedGraphicsManager.Current; // предоставляет доступ к главному буферу графического контекста для текущего приложения
            g = form.CreateGraphics();                 // Создаём объект - поверхность рисования и связываем его с формой                                      
            try                                        // Запоминаем размеры формы
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
                WindowSize x = new WindowSize(Height, Width);
            }
            catch (WindowExeption e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Что то не то\n" + e);
            }
            finally
            {
                Console.WriteLine("Ладно и так сойдет!");
            }            
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height)); // Связываем буфер в памяти с графическим объектом. для того, чтобы рисовать в буфере
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            Load();
            form.FormClosing += Form_FormClosing;
            form.KeyDown += Form_KeyDown;
            form.MouseMove += Form_MouseMove;
            form.MouseClick += Form_MouseClick;
        }

        private static void Form_MouseClick(object sender, MouseEventArgs e)
        {
            bullets.Add(new Bullet(new Point(ship.GetPos.X + 40, ship.GetPos.Y + 20), new Point(5, 0), new Size(20, 2)));
        }

        private static void Form_MouseMove(object sender, MouseEventArgs e)
        {
            ship.SetPos(e.Location);
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
            if (e.KeyCode==Keys.Space) bullets.Add(new Bullet(new Point(ship.GetPos.X + 40, ship.GetPos.Y + 20), new Point(5, 0), new Size(20, 2)));
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Game.Draw();
            Game.Update();
        }

        static void Load()
        {
            #region старый код
            //objs = new BaseObject[200];

            //for (int i = 0; i < 2; i++)
            //    objs[i] = new HealthBox(new Point(Game.Width, Game.Random.Next(0, Game.Height)), new Point(-i, 0), new Size(20, 20));

            //for (int i = 2; i < 25; i++)
            //    objs[i] = new Asteroid(new Point(Game.Width, Game.Random.Next(0,Game.Height)), new Point(-i, 0), new Size(20, 20));

            //for (int i = 25; i < 200; i++)
            //    objs[i] = new Star(new Point(Game.Width, Game.Random.Next(0, Game.Height)), new Point(-i, 0), new Size(20, 20));
            #endregion

            health = new List<HealthBox>();
            for (int i = 0; i < 15; i++)
                health.Add(new HealthBox(new Point(Game.Width, Game.Random.Next(0, Game.Height)), new Point(-i, 0), new Size(20, 20))); 
            
            LoadAsteroids();

            stars = new List<Star>();
            for (int i = 0; i < 200; i++)
                stars.Add(new Star(new Point(Game.Width, Game.Random.Next(0, Game.Height)), new Point(-i, 0), new Size(20, 20)));

            ship = new Ship(new Point(0, 400), new Point(4, 4), new Size(40, 40));
            bullets = new List<Bullet>();
            Bullet.OverScreen += Bullet_OverScreen;            
        }

        static void LoadAsteroids()
        {
            CountA++;
            asteroids = new List<Asteroid>();
            for (int i = 0; i < CountA; i++)
                asteroids.Add(new Asteroid(new Point(Game.Width, Game.Random.Next(0, Game.Height)), new Point(-i, 0), new Size(20, 20)));       
        }

        private static void Bullet_OverScreen(Bullet bullet)
        {
            bullets.Remove(bullet);
        }

        static public void Draw()
        {
            #region старый код
            ////Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawImage(background, 0, 0);            
            ////Buffer.Graphics.DrawRectangle(Pens.White, 10, 10, 100, 200);
            //foreach (var obj in objs)
            //{
            //    obj.Draw();              
            //}
            //Buffer.Graphics.DrawString("Health: " + Health.ToString(), SystemFonts.DefaultFont, Brushes.Aqua, 0, 0);
            //Buffer.Graphics.DrawString("Hit: " + Hit.ToString(), SystemFonts.DefaultFont, Brushes.Red, 100, 0);
            //bullet?.Draw();
            //ship.Draw();
            //Buffer.Render();
            #endregion

            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (var obj in health)
            {
                obj.Draw();
            }
            
            foreach (var obj in stars)
            {
                obj.Draw();
            }
            
            foreach (var obj in asteroids)
            {
                obj.Draw();
            }            
            
            Buffer.Graphics.DrawString("Health: " + Health.ToString(), SystemFonts.DefaultFont, Brushes.Aqua, 0, 0);
            Buffer.Graphics.DrawString("Hit: " + Hit.ToString(), SystemFonts.DefaultFont, Brushes.Red, 100, 0);
            Buffer.Graphics.DrawString("Asteroids Count: " + (CountA-1).ToString(), SystemFonts.DefaultFont, Brushes.Yellow, 200, 0);
            Buffer.Graphics.DrawString("Asteroids remained: " + remained.ToString(), SystemFonts.DefaultFont, Brushes.Coral, 350, 0);
            foreach (Bullet bullet in bullets)
                bullet.Draw();
            ship.Draw();
            Buffer.Render();
        }

        static public void Update()
        {
            #region старый код
            //foreach (var obj in objs)
            //{
            //    obj.Update();
            //    if (bullet != null && obj is Asteroid && obj.Collision(bullet))
            //    {
            //        Console.WriteLine("Есть пробитие!");
            //        Hit++;
            //    }
            //    if (ship != null && obj is Asteroid && obj.Collision(ship))
            //    {
            //        Console.WriteLine("нас подбили есть повреждения!");
            //        Health--;
            //    }
            //    if (ship != null && obj is HealthBox && obj.Collision(ship))
            //    {
            //        Console.WriteLine("Нас подлатали!");
            //        Health++;
            //    }
            //}
            //bullet?.Update();
            #endregion
            foreach (Star star in stars)
                star.Update();
            
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Update();
                for (int j = 0; j < bullets.Count; j++)
                {
                    if (i >= 0 && asteroids[i].Collision(bullets[j]))
                    {
                        Console.WriteLine("Есть пробитие!");
                        Hit++;
                        asteroids.RemoveAt(i);
                        i--;
                        bullets.RemoveAt(j);
                        j--;
                    }                    
                }
                if (i >= 0 && asteroids[i].Collision(ship))
                {
                    Console.WriteLine("нас подбили есть повреждения!");
                    Health--;
                    asteroids.RemoveAt(i);
                    i--;                   
                }
                remained = asteroids.Count - 1;
            }

            if (remained == 0)//обновляем астероиды
            {
                LoadAsteroids();
            }

            for (int i = 0; i < health.Count; i++)
            {
                if (i >= 0 && health[i].Collision(ship))
                {
                    Console.WriteLine("Нас подлатали!");
                    Health++;
                }
            }

            for (int i = 0; i < bullets.Count; i++)
               bullets[i].Update();
        }        
    }

    //Исключения
    class WindowExeption : ApplicationException
    {
        public WindowExeption(string message) : base(message)
        {
        }
    }

    class WindowSize
    {
        const int max_heigt = 1000, max_width = 500;

        public WindowSize(int height, int width)
        {
            if (height > max_heigt) throw new WindowExeption("Превышена максимальная высота " + max_heigt);
            if (width > max_width) throw new WindowExeption("Превышена максимальная ширина " + max_width);
        }
    }
}
