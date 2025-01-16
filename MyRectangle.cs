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
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public MyRectangle(SplashKitSDK.Color color, int width, int height) : base(color)
        {
            _width = width;
            _height = height;
        }

        public MyRectangle() : this(SplashKitSDK.Color.Green, 100, 50) { } // default constructor

        public override void Draw()
        {
            // Draw a rectangle
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public override void DrawOutline()
        {
            // Draw outline of rectangle
            SplashKit.DrawRectangle(SplashKitSDK.Color.Black, _x, _y, _width, _height);
        }
        
        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}
