using System;
using System.IO;
using SplashKitSDK;

namespace DrawingProgram
{
	public class MyLine : Shape
	{
        private float _endX;
        private float _endY;

        // Constructor to initialize the line with color and start/end points
        public MyLine(SplashKitSDK.Color color, float startX, float startY, float endX, float endY) : base(color)
        {

            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        public MyLine() : this(SplashKitSDK.Color.Red, 0, 0, 400, 300) { } // default constructor

        // Properties for EndX and EndY
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        // Method to draw the line
        public override void Draw()
        {
            SplashKit.DrawLine(Color.Red, X, Y, _endX, _endY);
        }

        // Method to draw the outline of the line
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, 5); // Start point outline
            SplashKit.FillCircle(Color.Black, _endX, _endY, 5); // End point outline
        }

        // Method to check if a point is on the line
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _endX, _endY));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _endX= reader.ReadInteger();
            _endY = reader.ReadInteger();
        }
    }
}

