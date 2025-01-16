using System.Drawing;
using System.IO;
using System.Security.Principal;
using SplashKitSDK;


namespace DrawingProgram
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        private static ShapeKind kindToAdd = ShapeKind.Circle; // Initialize the shape kind
        private static int lineCount = 0;

        static void Main()
        {
            Drawing myDrawing = new Drawing();
            Window window = new Window("DrawingProgram", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                myDrawing.Draw();

                // Check for user input to change shape type
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // Handle left mouse click to add shapes
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = null;

                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            myShape = new MyCircle(); // Assuming MyCircle has a default constructor
                            break;

                        case ShapeKind.Rectangle:
                            myShape = new MyRectangle(); // Assuming MyRectangle has a default constructor
                            break;

                        case ShapeKind.Line:
                            if (lineCount < 5)
                            {
                                myShape = new MyLine(); // Create a new line
                                lineCount++;
                            }
                            break;

                        default:
                            myShape = null;
                            break;
                    }

                    if (myShape != null)
                    {
                        // Set the position of the shape
                        myShape.X = SplashKit.MouseX();
                        myShape.Y = SplashKit.MouseY();
                        myDrawing.AddShape(myShape);
                    }
                }

                // Change background color on space key press
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                // Handle right mouse click to select shapes
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapesAt(SplashKit.MousePosition());
                }

                foreach (Shape s in myDrawing.SelectedShapes)
                {
                    s.DrawOutline();
                }

                // Handle deletion of selected shapes
                if (SplashKit.KeyDown(KeyCode.BackspaceKey) || SplashKit.KeyDown(KeyCode.DeleteKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                // save file
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("/Users/rahul/Desktop/TestDrawing.txt");
                }

                // load file
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("/Users/rahul/Desktop/TestDrawing.txt");
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }
                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("DrawingProgram"));
        }
    }
}
