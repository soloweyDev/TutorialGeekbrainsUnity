using System.Windows.Forms;

namespace CSharp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Height = 600;
            form.Width = 800;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
