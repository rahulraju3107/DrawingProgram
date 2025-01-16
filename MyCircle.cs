using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DrawingProgram
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(SplashKitSDK.Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public MyCircle() : this(SplashKitSDK.Color.Blue, 50) { } // Default constructor

        public override void Draw()
        {
            // Draw circle
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void DrawOutline()
        {
            // Draw outline for circle
            SplashKit.DrawCircle(SplashKitSDK.Color.Black, _x, _y, _radius + 5);
        }

        public override bool IsAt(Point2D pt)
        {
            Circle circle = SplashKit.CircleAt(_x, _y, _radius);
            return SplashKit.PointInCircle(pt, circle);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}

