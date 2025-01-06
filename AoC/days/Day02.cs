using System.Linq;

namespace AoC
{
    public static class Day02
    {
        public static void Run()
        {

            string PATH = "/home/fairchild/documents/Challenges/Advent_15/AoC/input/";
            string[] boxDims = File.ReadAllLines(PATH + "input02.txt");
            
            //string EXP = "1x1x10";
            //int giftPaper = getPaper(EXP);
            //Console.WriteLine(giftPaper);

            int totalPaper = 0;
            int totalRibbon = 0;
            foreach (string box in boxDims) {
                var materials = getMaterials(box);
                totalPaper += materials.Item1;
                totalRibbon += materials.Item2;
            }
            Console.WriteLine("Part 1: Total paper = " + totalPaper);
            Console.WriteLine("Part 2: Total ribbon = " + totalRibbon);

        }


        public static (int, int) getMaterials(string dims) {
            // 2x3x4 maps to a*b*c --> (a*b, b*c, c*a) as side1, side2, side3
            // then return 2 * (side1 + side2 + side3) + min(side1, side2, side3)

            string[] sides = dims.Split("x");
            int a = int.Parse(sides[0]);
            int b = int.Parse(sides[1]);
            int c = int.Parse(sides[2]);
            
            // Part 1:
            int side1 = a * b;
            int side2 = b * c;
            int side3 = c * a;
            int[] sidesArea = {side1, side2, side3};
            int smallestSide = sidesArea.Min();
            int totalPaper = 2 * (side1 + side2 + side3) + smallestSide;
            
            // Part 2:
            // Could refactor entire function to use less common objs between both parts
            // But at this scale, not a concern.
            List<int> sidesLength = new List<int> {a, b, c};
            sidesLength.Sort();
            int totalRibbon = 0;
            totalRibbon += 2 * (sidesLength[0] + sidesLength[1]);
            totalRibbon += a * b * c;

            return (totalPaper, totalRibbon);

        }


    }

}
