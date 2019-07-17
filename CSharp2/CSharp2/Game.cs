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
            objs = new BaseObject[26];
            for (int i = 0; i < objs.Length; i++)
                objs[i] = new BaseObject(new Point(400, i * 20 + 20), new Point(15-i, 15-i), new Size(20, 20));
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
