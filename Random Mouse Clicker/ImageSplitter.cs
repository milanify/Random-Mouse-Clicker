using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Random_Mouse_Clicker
{
    class ImageSplitter
    {
        private static int width;
        private static int height;
        public static Image drawnImage;
        private static int numberOfAreas;
        public static List<int> xCoordinates;
        public static List<int> yCoordinates;
        private static ArrayList primeFactors;
        public static List<int> dimensionWidths;
        public static List<int> dimensionHeights;
        public static Dictionary<int, int> dimensions;

        /**
         * Draws red lines over the image when user views preview tab
         * Store the width and height the user selected
         * Store the total width and height of the rectangular region drawn
         * Store the original region so that the newly drawn image can be reverted back
         * */
        public static void drawSplitImage(int selectedIndex, decimal dividers)
        {
            int eachWidth = dimensionWidths[selectedIndex];
            int eachHeight = dimensionHeights[selectedIndex];
            int totalRectangleWidth = SnippingTool.getRectangleWidth();
            int totalRectangleHeight = SnippingTool.getRectangleHeight();
            drawnImage = (Image) SnippingTool.Image.Clone();

            using (Graphics g = Graphics.FromImage(drawnImage))
            {
                Color customColor = Color.FromArgb(50, Color.Gray);
                SolidBrush brush = new SolidBrush(customColor);
                g.FillRectangles(brush, new RectangleF[] {
                    new RectangleF(new PointF(0.0F, 0.0F), new SizeF((float)totalRectangleWidth, (float)totalRectangleHeight)) });

                customColor = Color.FromArgb(255, Color.Red);
                brush = new SolidBrush(customColor);

                //Draws horizontal lines, by moving along the height of the rectangle
                for (int i = 1; i < dividers; i++)
                {
                    g.FillRectangles(brush, new RectangleF[] {
                    new RectangleF(new PointF(0.0F, (float)eachHeight*i), new SizeF((float)totalRectangleWidth, 5.0F)) });
                }

                //Drawrs vertical lines, by moving along the width rectangle
                for (int i = 1; i < dividers; i++)
                {
                    g.FillRectangles(brush, new RectangleF[] {
                    new RectangleF(new PointF((float)eachWidth*i, 0.0F), new SizeF(5.0F, (float)totalRectangleHeight)) });
                }
            }
        }

        /**
         * Setup the specific coordinates of the split areas
         * Store the width and height the user selected
         * Store the total width and height of the rectangular region drawn
         * Store x and y coordinates, will always have 0 in them, so a list with two elements is one number range (0 to num1)
         * Another example: The list has three elements, so two numbers ranges (0 to num1, num1 to num2)
         * Store the number of times the total width and height of the rectangle divides by each
         * Calculate the remainder if the size of each width or height doesn't divide evenly
         * Add the number ranges to the width and height list
         * Add the remainder value to the final value in the array, this means that the final slice may be bigger than the rest
         * */
        public static void setSplitAreas(int selectedIndex)
        {
            int eachWidth = dimensionWidths[selectedIndex];
            int eachHeight = dimensionHeights[selectedIndex];
            int totalRectangleWidth = SnippingTool.getRectangleWidth();
            int totalRectangleHeight = SnippingTool.getRectangleHeight();

            xCoordinates = new List<int>();
            yCoordinates = new List<int>();
            xCoordinates.Add(0);
            yCoordinates.Add(0);

            int numberOfWidthDivisions = totalRectangleWidth / eachWidth;
            int numberOfHeightDivisions = totalRectangleHeight / eachHeight;

            int remainderWidth = totalRectangleWidth % eachWidth;
            int remainderHeight = totalRectangleHeight % eachHeight;

            for (int i = 0; i < numberOfWidthDivisions; i++)
            {
                xCoordinates.Add(eachWidth + xCoordinates[i]);
            }

            for (int i = 0; i < numberOfHeightDivisions; i++)
            {
                yCoordinates.Add(eachHeight + yCoordinates[i]);
            }

            xCoordinates[numberOfWidthDivisions] = xCoordinates[numberOfWidthDivisions] + remainderWidth;
            yCoordinates[numberOfHeightDivisions] = yCoordinates[numberOfHeightDivisions] + remainderHeight;
        }

        /**
         * Takes in the numer of areas that the region will be divided into
         * Calculates the prime numbers of that
         * */
        public static void getDimensions(int areas)
        {
            numberOfAreas = areas;
            calculatePrimes(numberOfAreas);
        }

        /**
         * Makes a new ArrayList to store prime factors
         * Is a prime if the number divides evenly into the numberOfAreas
         * Example: The primes of 10 are 1, 2, 5, and 10
         * */
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

        /**
         * Gets the width and height of the drawn region
         * Sets up a dictionary to pair factors
         * Sets up two lists to hold each individual width and height
         * */
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

        /**
         * If the factor multiplied by another factor is equal to the number of areas, they are pairs
         * Example: The primes of 10 are 1, 2, 5, and 10
         * So 1 will be paired with 10, 2 with 5, 5 with 2, and 10 with 1
         * */
        private static void pair(int factor)
        {
            foreach (int anotherFactor in primeFactors)
            {
                if (factor * anotherFactor == numberOfAreas)
                {
                    calculateDimensions(factor, anotherFactor);
                }
            }
        }

        /**
         * Calculates actual dimensions based on the factor pairs
         * The width of the divided area is the total width divided by one factor
         * The height is the total height divided by the other factor
         * Example: The primes of 10 are 1, 2, 5, and 10
         * So 1 will be paired with 10, 2 with 5, 5 with 2, and 10 with 1
         * For a 300x300 image, divided into 10 areas, the areas would be 300x30, 150x60, 60x150, and 30x300
         * */
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
