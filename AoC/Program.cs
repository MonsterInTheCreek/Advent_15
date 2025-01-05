using System;

namespace AoC.days
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Full disclosure: got some help from ChatGPT to setup this method of
            // branching code to other files from Main().

            if (args.Length == 0) {
                Console.WriteLine("Runtime Arg is enforced.  Please append, such as dotnet run -- 1 to run Day 01.");
                return;
            }

            switch (args[0]) {
                case "1":
                Day01.Run();
                break;
            }

        }
    }
}
