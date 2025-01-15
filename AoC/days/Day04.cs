using System.Security.Cryptography;
using System;
using System.Text;

namespace AoC

{
    public static class Day04
    {
        public static void Run()
        {
            // This puzzle has just a single string input
            //string exp1 = "abcdef";  // answer == "abcdef609043"
            //string exp2 = "pqrstuv";
            string real = "ckczppom";

            string fiveZeros = findNzeros(real, 5);
            Console.WriteLine($"Part 1 == {fiveZeros}");
            string sixZeros = findNzeros(real, 6);
            Console.WriteLine($"Part 2 == {sixZeros}");            

            // 6 digit Part B currently takes about 8 seconds
            // I bet it took longer than that on 2015 vintage hardware...
        }

        public static string getHash(string inputString) {
            // Full disclosure: got some help from ChatGPT for the workflow to 
            //   generate an MD5 hash.
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
            string hashString;
            using (MD5 md5 = MD5.Create()) 
            {
                byte[] outputBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in outputBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
            hashString = sb.ToString();
            }
            //Console.WriteLine($"MD5 Hash: {hashString}");
            return hashString;
        }

        public static string findNzeros(string inputString, int zerosNum) {
            string zeros = new string('0', zerosNum);
            int counter = 0;
            do {
                string testString = inputString + counter.ToString();
                string hash = getHash(testString);
                if (hash.Substring(0,zerosNum) == zeros) {
                    return counter.ToString();
                }
                counter++;
            } while (true);
        }

        // REFACTORED TO ABOVE FUNCTION:

        // public static bool test5zeros(string inputString) {
        //     if (getHash(inputString).Substring(0,5) == "00000") {
        //         return true;
        //     } else {
        //         return false;
        //     }
        // }

        // public static string find5zeros(string inputString) {
        //     int counter = 0;
        //     do {
        //         string testString = inputString + counter.ToString();
        //         if (test5zeros(testString)) {
        //             return counter.ToString();
        //         }
        //         counter++;
        //     } while (true);
        // }

    }
}