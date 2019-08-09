using System;
using System.Windows.Forms;
using System.Drawing;

namespace CSharp2
{
    static class Game
    {
        static BaseObject[] objs;
        static Bullet bullet;
        static Asteroid[] asteroids;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static public Random rnd = new Random();

        static public int Width { get; set; }
        static public int Height { get; set; }

        static Game()
        {
        }

        static public void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width - 10 - 10;
            Height = form.Height - 32 - 10;
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        static public void Load()
        {
            objs = new BaseObject[30];
            asteroids = new Asteroid[3];
            for (int i = 0; i < objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                objs[i] = new Star(new Point(500, Game.rnd.Next(0, Game.Height)), new Point(-r, 0), new Size(3, 3));
            }
            int h = 0;
            for (int i = 0; i < asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                h = Game.rnd.Next(0, Game.Height);
                asteroids[i] = new Asteroid(new Point(800, h), new Point(-5, 0), new Size(r, r));
            }
            bullet = new Bullet(new Point(0, h), new Point(5, 0), new Size(4, 1));
        }
        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            //buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            foreach(BaseObject obj in objs)
            {
                obj.Draw();
            }
            foreach (Asteroid obj in asteroids)
                obj.Draw();
            bullet.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
            for (int i = 0; i < asteroids.Length; ++i)
            {
                asteroids[i].Update();
                if (asteroids[i].Collision(bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
                    int r = rnd.Next(5, 50);
                    asteroids[i] = new Asteroid(new Point(800, 200), new Point(-5, 0), new Size(r, r));
                }
            }
            bullet.Update();


        }
    }
}
