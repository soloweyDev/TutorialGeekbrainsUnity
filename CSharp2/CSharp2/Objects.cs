using System;
using System.Drawing;

namespace CSharp2
{
    interface ICollision
    {
        
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    abstract class BaseObject:ICollision
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

        public abstract void Draw();

        public abstract void Update();
        //{
        //    pos.X = pos.X + dir.X;
        //    pos.Y = pos.Y + dir.Y;
        //    if (pos.X < 5 || pos.X > Game.Width - 20) dir.X = -dir.X;
        //    if (pos.Y < 5 || pos.Y > Game.Height - 20) dir.Y = -dir.Y;
        //}

        public override string ToString()
        {
            return "Pos:" + pos.ToString() + " Dir" + dir.ToString() + " Size:" + size.ToString();
        }


        public bool Collision(ICollision o)
        {
            return o.Rect.IntersectsWith(Rect);
        }

        public Rectangle Rect
        {
            get { return new Rectangle(pos, size); }
        }
    }

    class Star: BaseObject
    {
        Image img = Image.FromFile("pictures\\star.png"); 

        public Star(Point pos, Point dir, Size size):base(pos,dir,size)
        {

        }

        public override void Draw()
        {
            //Game.buffer.Graphics.DrawRectangle(Pens.White, pos.X, pos.Y, size.Width, size.Height);
            Game.buffer.Graphics.DrawImage(img, pos);
        }

        public override void Update()
        {
            //base.Update();
            pos.X = pos.X + dir.X;
            //pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) //dir.X = -dir.X;
            {
                pos.X = 1000;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
            }
            //if (pos.X > Game.Width) dir.X = -dir.X;
            //if (pos.Y < 0) dir.Y = -dir.Y;
            //if (pos.Y > Game.Height) dir.Y = -dir.Y;
        }
    }

    class Asteroid: BaseObject
    {
        int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public Asteroid(Point pos, Point dir, Size size): base(pos,dir,size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.Wheat, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0) //dir.X = -dir.X;
            {
                pos.X = 1000;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
            }
        }

    }

    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.OrangeRed, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + 3;
        }
    }


}
