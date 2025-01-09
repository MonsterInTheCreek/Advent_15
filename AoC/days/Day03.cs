namespace AoC
{
    public static class Day03
    {
        public static void Run()
        {

            string PATH = "/home/fairchild/documents/Challenges/Advent_15/AoC/input/";
            string dirsString = File.ReadAllText(PATH + "input03.txt");

            // Part 1
            int housesCount = RunDirs(dirsString).Count;
            Console.WriteLine("Part 1 = " + housesCount);

            // Part 2
            // Split dirsString into two sets of dirs
            string sDirs = "";      // Santa directions
            string rDirs = "";      // Robo-Santa directions
            int counter = 0;
            foreach (char dir in dirsString) {
                if (counter % 2 == 0) {
                    sDirs += dir;
                    counter += 1;
                } else {
                    rDirs += dir;
                    counter += 1;
                }
            }
            HashSet<(int x, int y)> sHouses = RunDirs(sDirs);
            HashSet<(int x, int y)> rHouses = RunDirs(rDirs);
            // mod sHouses by union with rHouses to solve for total unique values
            sHouses.UnionWith(rHouses);

            Console.WriteLine("Part 2 = " + sHouses.Count);
        }

        static (int, int) AddTup((int x1, int y1) t1, (int x2, int y2) t2) {
            int x3 = t1.Item1 + t2.Item1;
            int y3 = t1.Item2 + t2.Item2;
            return (x3, y3);
        }

        static HashSet<(int x, int y)> RunDirs(string dirs) {
            (int x, int y) start = (0,0);
            (int x, int y) current = start;
            HashSet<(int x, int y)> visited = new HashSet<(int, int)>();

            Dictionary<char, (int x, int y)> dirsLookup = new Dictionary<char, (int, int)>();
            // using upper left as origin, similar to Numpy
            dirsLookup.Add('>',(0,1));
            dirsLookup.Add('<',(0,-1));
            dirsLookup.Add('^',(-1,0));
            dirsLookup.Add('v',(1,0));

            foreach (char dir in dirs) {
                visited.Add(current);
                current = AddTup(current, dirsLookup[dir]);
            }
            return visited;
        }

    }
}