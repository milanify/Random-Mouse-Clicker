using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
