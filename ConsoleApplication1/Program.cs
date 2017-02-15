using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static int _activityCount;
        private static int[] _startTimes;
        private static int[] _finishTimes;

        static void Main(string[] args)
        {
            getStarted();            
        }

        public static string Greedy(int[] start, int[] finish)
        {
            string a = "1";
            int i = 0;
            int n = start.Length;

            for (int m = 1; m < n; m++)
            {
                if (start[m] >= finish[i])
                {
                    a = a + ", " + (m + 1);
                    i = m;
                }
            }
            return a;
        }    
        
        //public void LCS(char[]x, char[]y)
        //{
        //    int[][] c = new int[];
        //    int m = x.Length;
        //    int n = y.Length;
        //    for(int i = 1; i < m; i++)
        //    {
        //        c[i][0] = 0;
        //    }
        //    for (int j = 1; j < n; j++)
        //    {
        //        c[0][j] = 0;
        //    }
        //    for(int k = 1;  ; k++) { }
        //}    

        public static void getStarted()
        {
            _activityCount = 0;
            _startTimes = null;
            _finishTimes = null;
            Console.WriteLine("Greedy Activity Selector");
            activityQuestion();
            Console.WriteLine("Compatible activities: " + Greedy(_startTimes, _finishTimes));
            Console.WriteLine();
            getStarted();
        }

        public static void activityQuestion()
        {
            Console.WriteLine("Enter number of activities:");
            var userInput = Console.ReadLine();
            if(userInput.ToLower() == "exit") { Environment.Exit(0); }
            try
            {
            _activityCount = Int32.Parse(userInput);
                startQuestion();
            }
            catch
            {
                Console.WriteLine("You did not enter a whole number");
                activityQuestion();
            }            
        }

        public static void startQuestion()
        {
            Console.WriteLine("Enter start times:");
            var startTimes = Console.ReadLine();
            if (startTimes.ToLower() == "exit") { Environment.Exit(0); }
            try
            {
                _startTimes = startTimes.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                finishQuestion();
            }
            catch
            {
                Console.WriteLine("Invalid format. Separate numbers with a space or comma.");
                startQuestion();
            }
        }

        public static void finishQuestion()
        {
            Console.WriteLine("Enter finish times:");
            var finishTimes = Console.ReadLine();
            if (finishTimes.ToLower() == "exit") { Environment.Exit(0); }
            try
            {
                _finishTimes = finishTimes.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            catch
            {
                Console.WriteLine("Invalid format. Separate numbers with a space or comma.");
                finishQuestion();
            }            
        }             
    }
}