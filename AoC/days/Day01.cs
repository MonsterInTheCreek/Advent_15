namespace AoC
{
    public static class Day01
    {
        public static void Run()
        {
        
            string PATH = "/home/fairchild/documents/Challenges/Advent_15/AoC/input/";
            string floorDirs = File.ReadAllText(PATH + "input01.txt");

            int floor = 0;
            int dirsLen = floorDirs.Length;
            bool firstBasement = true;
            int basementDir = 0;
            int count = 0;
            for (int i = 0; i<dirsLen; i++) {

                // Part 1 logic
                if (floorDirs[i] == '(' ) {
                    floor += 1;
                } else if (floorDirs[i] == ')' ) {
                    floor -= 1;
                } // else, ignore
                
                // Part 2 logic
                count += 1;
                if (floor == -1 && firstBasement) {
                    basementDir = count;
                    firstBasement = false;      // only record the first time this occurs
                }
                
            }

            Console.WriteLine("Part 1: Santa should go to floor : " + floor);
            Console.WriteLine("Part 2: First time in basement : " + basementDir);

        }
    }
}