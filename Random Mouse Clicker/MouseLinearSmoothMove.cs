//Original from: https://stackoverflow.com/questions/913646/c-sharp-moving-the-mouse-around-realistically

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Random_Mouse_Clicker
{
    class MouseLinearSmoothMove
    {
        private static readonly int speed_slow = 50;
        private static readonly int speed_normal = 20;
        private static readonly int speed_fast = 5;
        private static readonly int speed_instant = 0;

        private static void LinearSmoothMove(Point newPosition, int steps)
        {
            Point start = Cursor.Position;
            PointF iterPoint = start;

            // Find the slope of the line segment defined by start and newPosition
            PointF slope = new PointF(newPosition.X - start.X, newPosition.Y - start.Y);

            // Divide by the number of steps
            slope.X = slope.X / steps;
            slope.Y = slope.Y / steps;

            // Move the mouse to each iterative point.
            for (int i = 0; i < steps; i++)
            {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                Cursor.Position = (Point.Round(iterPoint));
                Thread.Sleep(20);
            }

            // Move the mouse to the final destination.
            Cursor.Position = (newPosition);
        }

        public static void slow(Point newPosition)
        {
            LinearSmoothMove(newPosition, speed_slow);
        }

        public static void normal(Point newPosition)
        {
            LinearSmoothMove(newPosition, speed_normal);
        }

        public static void fast(Point newPosition)
        {
            LinearSmoothMove(newPosition, speed_fast);
        }

        public static void instant(Point newPosition)
        {
            LinearSmoothMove(newPosition, speed_instant);
        }
    }
}
