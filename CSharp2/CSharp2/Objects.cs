using System.Drawing;

namespace CSharp2
{
    delegate void Messsage();

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
        readonly Image img = Image.FromFile("pictures\\star.png"); 

        public Star(Point pos, Point dir, Size size):base(pos,dir,size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 10, 10);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0)
            {
                pos.X = 1000;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
            }
        }
    }

    class Asteroid: BaseObject
    {
        int power;
        readonly Image img = Image.FromFile("pictures\\asteroid.png");

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
            Game.buffer.Graphics.DrawImage(img, pos);
        }
        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0)
            {
                pos.X = 1000;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
            }
        }
    }

    class Bullet : BaseObject
    {
        readonly Image img = Image.FromFile("pictures\\bullet.png");
        public bool remove = false;

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos);
        }

        public override void Update()
        {
            pos.X = pos.X + 3;

            if (pos.X > Game.Width + 5)
            {
                Game.Bullets.Remove(this);
                remove = true;
            }
        }
    }

    class Ship : BaseObject
    {
        readonly Image img = Image.FromFile("pictures\\gamer.png");

        public static event Messsage MessageDie;

        public int Energy { get; internal set; }

        internal void EnergyLow(int n)
        {
            Energy -= n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Energy = 200;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos);
        }

        public override void Update()
        {
        }

        internal void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }

        internal void Down()
        {
            if (pos.Y < Game.Height - 20) pos.Y = pos.Y + dir.Y;
        }

        internal void Die()
        {
            if (MessageDie != null) MessageDie();
        }
    }
}
