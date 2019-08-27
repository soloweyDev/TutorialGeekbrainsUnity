using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace CSharp2
{
    static public class Game
    {
        static BaseObject[] objs;
        static Ship ship;
        static List<Asteroid> asteroids = new List<Asteroid>();
        static int asteroidsNum = 3;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static public Random rnd = new Random();
        static Timer timer = new Timer();

        static public int Width { get; set; }
        static public int Height { get; set; }
        internal static List<Bullet> Bullets { get; } = new List<Bullet>();

        static int score;
        static public int BulletCount { get; set; }

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
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Bullet bullet = new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
                bullet.OnCount += Bullet_OnCount;
                Bullets.Add(bullet);
                bullet.Count();
            }
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }

        private static void Bullet_OnCount()
        {
            BulletCount++;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        static public void Load()
        {
            score = 0;
            objs = new BaseObject[30];
            for (int i = 0; i < objs.Length; i++)
            {
                int r = rnd.Next(5, Width - 10);
                objs[i] = new Star(new Point(500, rnd.Next(0, Height - 10)), new Point(-r, 0), new Size(3, 3));
            }
            for (int i = 0; i < asteroidsNum; i++)
            {
                asteroids.Add(new Asteroid(new Point(800, rnd.Next(0, Height - 10)), new Point(-5, 0), new Size(15, 25)));
            }
            ship = new Ship(new Point(10, Height / 2), new Point(5, 5), new Size(10, 10));
        }

        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach(BaseObject obj in objs)
                obj.Draw();
            foreach (Asteroid a in asteroids)
                if (a != null) a.Draw();
            if (Bullets != null)
            {
                foreach (Bullet bullet in Bullets)
                    bullet.Draw();
            }
            ship.Draw();
            buffer.Graphics.DrawString("Energy: " + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Graphics.DrawString("Score: " + score, SystemFonts.DefaultFont, Brushes.White, Width - 100, 0);
            buffer.Graphics.DrawString("Bullet: " + BulletCount, SystemFonts.DefaultFont, Brushes.White, Width - 100, 20);
            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs) obj.Update();
            if (Bullets != null)
            {
                foreach (Bullet bullet in Bullets)
                {
                    bullet.Update();
                    if (bullet.remove)
                    {
                        return;
                    }
                }
            }

            if (asteroids.Count == 0)
            {
                asteroidsNum++;
                for (int i = 0; i < asteroidsNum; i++)
                {
                    asteroids.Add(new Asteroid(new Point(800, rnd.Next(0, Height - 10)), new Point(-5, 0), new Size(15, 25)));
                }
            }

            foreach (Asteroid asteroid in asteroids)
            {
                if (asteroid != null)
                {
                    asteroid.Update();

                    if (Bullets != null)
                    {
                        foreach (Bullet bullet in Bullets)
                        {
                            if (bullet.Collision(asteroid))
                            {
                                System.Media.SystemSounds.Hand.Play();
                                asteroids.Remove(asteroid);
                                Bullets.Remove(bullet);
                                score++;
                                return;
                            }
                        }
                    }

                    if (ship.Collision(asteroid))
                    {
                        ship.EnergyLow(rnd.Next(1, 10));
                        System.Media.SystemSounds.Asterisk.Play();
                        asteroids.Remove(asteroid);
                        if (ship.Energy <= 0)
                        {
                            ship.Energy = 0;
                            Draw();
                            ship.Die();
                        }
                        return;
                    }
                }
            }
        }

        static public void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            buffer.Render();
        }
    }
}
