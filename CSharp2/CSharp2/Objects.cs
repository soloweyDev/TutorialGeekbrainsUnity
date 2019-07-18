using System;
using System.Drawing;

namespace CSharp2
{
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }

        public virtual void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 5 || pos.X > Game.Width - 20) dir.X = -dir.X;
            if (pos.Y < 5 || pos.Y > Game.Height - 20) dir.Y = -dir.Y;
        }
    }

    class RectangleO : BaseObject
    {
        public RectangleO(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.White, pos.X, pos.Y, size.Width, size.Height);
        }
    }

    class PolygonO : BaseObject
    {
        public PolygonO(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawPolygon(Pens.White, new PointF[] { new PointF(pos.X, pos.Y), new PointF(size.Width, size.Height), new PointF(pos.X, size.Height) });
        }
    }

    class StarSpace : BaseObject
    {
        public static Random Rnd { get; set; } = new Random();

        public StarSpace(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.White, new RectangleF(pos.X, pos.Y, size.Width, size.Height));
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) pos.X = Game.Width;
        }
    }
}
