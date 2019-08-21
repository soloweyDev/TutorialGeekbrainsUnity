using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace CSharp2
{
    static public class Game
    {
        static BaseObject[] objs;
        static List<Bullet> bullets = new List<Bullet>();
        static Ship ship;
        static Asteroid[] asteroids;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        static public Random rnd = new Random();
        static Timer timer = new Timer();

        static public int Width { get; set; }
        static public int Height { get; set; }
        internal static List<Bullet> Bullets { get => bullets; }

        static int score;

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
            if (e.KeyCode == Keys.ControlKey) Bullets.Add(new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1)));
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
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
            asteroids = new Asteroid[3];
            for (int i = 0; i < objs.Length; i++)
            {
                int r = rnd.Next(5, Width - 10);
                objs[i] = new Star(new Point(500, Game.rnd.Next(0, Game.Height - 10)), new Point(-r, 0), new Size(3, 3));
            }
            for (int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i] = new Asteroid(new Point(800, Game.rnd.Next(0, Game.Height - 10)), new Point(-5, 0), new Size(15, 25));
            }
            ship = new Ship(new Point(10, Game.Height / 2), new Point(5, 5), new Size(10, 10));
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

            for (int i = 0; i < asteroids.Length; ++i)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Update();
                    if (Bullets != null)
                    {
                        foreach (Bullet bullet in Bullets)
                        {
                            if (bullet.Collision(asteroids[i]))
                            {
                                System.Media.SystemSounds.Hand.Play();
                                asteroids[i] = new Asteroid(new Point(800, Game.rnd.Next(0, Game.Height - 30)), new Point(-5, 0), new Size(15, 25));
                                Bullets.Remove(bullet);
                                score++;
                                return;
                            }
                        }
                    }
                    if (ship.Collision(asteroids[i]))
                    {
                        ship.EnergyLow(rnd.Next(1, 10));
                        System.Media.SystemSounds.Asterisk.Play();
                        asteroids[i] = new Asteroid(new Point(800, Game.rnd.Next(0, Game.Height - 30)), new Point(-5, 0), new Size(15, 25));
                        if (ship.Energy <= 0)
                        {
                            ship.Energy = 0;
                            Draw();
                            ship.Die();
                        }
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
