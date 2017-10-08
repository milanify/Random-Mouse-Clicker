using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Random_Mouse_Clicker
{
    class ImageSplitter
    {
        private static int width;
        private static int height;
        private static int numberOfAreas;
        private static ArrayList primeFactors;
        public static Dictionary<int, int> dimensions;
        public static List<int> dimensionWidths;
        public static List<int> dimensionHeights;

        public static void drawSplitImage(int selectedIndex, decimal dividers)
        {
            int eachWidth = dimensionWidths[selectedIndex];
            int eachHeight = dimensionHeights[selectedIndex];
            int totalRectangleWidth = SnippingTool.getRectangleWidth();
            int totalRectangleHeight = SnippingTool.getRectangleHeight();

            using (Graphics g = Graphics.FromImage(SnippingTool.Image))
            {
                Color customColor = Color.FromArgb(50, Color.Gray);
                SolidBrush brush = new SolidBrush(customColor);
                g.FillRectangles(brush, new RectangleF[] {
                    new RectangleF(new PointF(0.0F, 0.0F), new SizeF((float)totalRectangleWidth, (float)totalRectangleHeight)) });

                customColor = Color.FromArgb(255, Color.Red);
                brush = new SolidBrush(customColor);

                int horizontalLines = totalRectangleWidth / eachWidth;
                int verticalLines = totalRectangleHeight / eachHeight;

                for (int i = 1; i < horizontalLines + 1; i++)
                {
                    g.FillRectangles(brush, new RectangleF[] {
                    new RectangleF(new PointF(0.0F, (float)eachHeight*i), new SizeF((float)totalRectangleWidth, 5.0F)) });
                }

                for (int i = 1; i < verticalLines + 1; i++)
                {
                    g.FillRectangles(brush, new RectangleF[] {
                    new RectangleF(new PointF((float)eachWidth*i, 0.0F), new SizeF(5.0F, (float)totalRectangleHeight)) });
                }
            }
        }

        public static void getDimensions(int areas)
        {
            numberOfAreas = areas;
            calculatePrimes(numberOfAreas);
        }

        private static void calculatePrimes(int numberOfAreas)
        {
            primeFactors = new ArrayList();

            for (int i = 1; i <= numberOfAreas; i++)
            {
                if (numberOfAreas % i == 0)
                {
                    primeFactors.Add(i);
                }
            }

            pairFactorizations();
        }

        private static void pairFactorizations()
        {
            width = SnippingTool.getRectangleWidth();
            height = SnippingTool.getRectangleHeight();
            dimensions = new Dictionary<int, int>();
            dimensionWidths = new List<int>();
            dimensionHeights = new List<int>();

            foreach (int factor in primeFactors)
            {
                pair(factor);
            }
        }

        private static void pair(int factor)
        {
            foreach (int number in primeFactors)
            {
                if (factor * number == numberOfAreas)
                {
                    calculateDimensions(factor, number);
                }
            }
        }

        private static void calculateDimensions(int widthFactor, int heightFactor)
        {
            int newWidth = width / widthFactor;
            int newHeight = height / heightFactor;

            dimensions.Add(newWidth, newHeight);
            dimensionWidths.Add(newWidth);
            dimensionHeights.Add(newHeight);
        }
    }
}
