using System.Drawing;
using System.Windows.Forms;

namespace CSharp2
{
    class SplashScreen
    {
        private Form form;
        BufferedGraphicsContext context;
        static BufferedGraphics buffer;

        public SplashScreen()
        { }

        public void Init()
        {
            form = new Form() { Height = 200, Width = 300 };

            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            buffer = context.Allocate(g, new Rectangle(0, 0, 300, 200));
        }

        public void Draw()
        {
            form.Show();

            for (int i = 0; i < 280; i += 5)
            {
                buffer.Graphics.Clear(Color.Black);

                buffer.Graphics.DrawImage(Image.FromFile("test.jpg"), 0, 0, 290, 165);

                buffer.Graphics.FillRectangle(Brushes.Green, new RectangleF(3, 150, 3 + i, 9));

                buffer.Render();
                System.Threading.Thread.Sleep(200);
            }

            System.Threading.Thread.Sleep(2000);
            form.Hide();
        }
    }
}
