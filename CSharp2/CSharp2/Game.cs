using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp2
{
    static class Game
    {
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        static BaseObject[] objs;

        static Game()
        {
        }

        static public void Init(Form form)
        {
            Width = form.Width - 10 - 10;
            Height = form.Height - 32 - 10;

            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        static public void Load()
        {
            objs = new BaseObject[44];
            for (int i = 0; i < 8; i++)
                objs[i] = new BaseObject(new Point(400, i * 20 + 20), new Point(15-i, 15-i), new Size(20, 20));

            for (int i = 8; i < 16; i++)
                objs[i] = new RectangleO(new Point(400, i * 20 + 20), new Point(15 - i, 15 - i), new Size(20, 20));

            for (int i = 16; i < 24; i++)
                objs[i] = new PolygonO(new Point(400, i * 20 + 20), new Point(15 - i, 15 - i), new Size(20, 20));

            for (int i = 24; i < 44; ++i)
            {
                int x = StarSpace.Rnd.Next(20, Width + 50);
                int y = StarSpace.Rnd.Next(20, Height - 20);
                objs[i] = new StarSpace(new Point(x, y), new Point(-3, 0), new Size(4, 4));
            }
        }

        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in objs)
                obj.Draw();

            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
