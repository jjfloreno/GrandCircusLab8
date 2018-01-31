using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab8_Baseball
{
    class PlayBall
    {
        public static string CalcBattingAvg (float hits, float atbats)
        {
            float BattingAvg = hits / atbats;
            return BattingAvg.ToString("0.000");
        }

        public static string CalcSlg (float sum, float atbats)
        {
            float SlgPct = sum / atbats;
            return SlgPct.ToString("0.000");
        }

        public static int ValidateAtBats(string input)
        {
            while (!Regex.Match(input, "^[0-9]+$").Success || Regex.Match(input, "^[0]$").Success)
            {
                Console.Clear();
                Console.Write("Not a valid number of at bats. Please try again!\n" +
                    "Number of at bats: ");
                input = (Console.ReadLine());
            }
            return int.Parse(input);
        }

        public static int ValidateBatters(string input)
        {
            while (!Regex.Match(input, "^[0-9]+$").Success || Regex.Match(input, "^[0]$").Success)
            {
                Console.Clear();
                Console.Write("Not a valid number of batters. Please try again!\n" +
                    "Number of batters: ");
                input = (Console.ReadLine());
            }
            return int.Parse(input);
        }
    }
}
