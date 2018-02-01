using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab8_Baseball
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputBatter, InputAB, InputResult, PlayAgain;
            int Batters, AtBats, SlgPct, Hit;
            int[][] StatSheet;
            bool RunProg = true;

            while(RunProg == true)
            {
                //input number of batters
                Console.Write("Welcome to the Batting Average Calculator. Let's play ball!\n\n" +
                "Please enter the number of players: ");
                InputBatter = Console.ReadLine();
                Batters = PlayBall.ValidateBatters(InputBatter);

                //initialize array to store results
                StatSheet = new int[Batters][];
                
                //input number of at bats
                //Console.Write("Please enter the number of at bats for each player: ");
                Console.WriteLine();

                AtBats = 0;
                for (int c = 0; c < StatSheet.Length; c++)
                {
                    Console.WriteLine($"Please enter the number of at bats for Player {c+1}: ");
                    InputAB = (Console.ReadLine());
                    AtBats = PlayBall.ValidateAtBats(InputAB);

                    StatSheet[c] = new int[AtBats];
                }

                Console.Clear();

                //enter loop for each batter
                for (int r = 0; r < Batters; r++)
                {
                    Console.WriteLine($"Please enter the results for Player {r + 1}.");
                    Console.WriteLine("[0] = Out, [1] = Single, [2] = Double, [3] = Triple, [4] = Home run");

                    //enter all results for batter r 
                    for (int c = 0; c < StatSheet[r].Length; c++)
                    {
                        Console.Write($"At bat {c + 1}: ");
                        InputResult = Console.ReadLine();

                        //validate
                        while (!Regex.Match(InputResult, "^[0-4]$").Success)
                        {
                            Console.Write("Not a valid entry. Please enter [0],[1],[2],[3] or [4]: ");
                            InputResult = Console.ReadLine();
                        }
                        StatSheet[r][c] = int.Parse(InputResult);
                    }
                    Console.Clear();
                }

                //calculate and print stats
                //loop starts by going into each batter (row)
                for (int r = 0; r < Batters; r++)
                {
                    //loop into getting hits
                    Hit = 0;
                    for (int c = 0; c < StatSheet[r].Length; c++)
                    {
                        //if the value in c > 0, increment number of hits
                        if (StatSheet[r][c] > 0)
                        {
                            Hit += 1;
                        }
                    }
                    //loop into summing scores
                    SlgPct = 0;
                    for (int c = 0; c < StatSheet[r].Length; c++)
                    {
                        SlgPct += StatSheet[r][c];
                    }
                    //print stats for each player
                    Console.WriteLine($"Player {r + 1}\tBA: {PlayBall.CalcBattingAvg(Hit, AtBats)}\tSLG: {PlayBall.CalcSlg(SlgPct, AtBats)}");
                }

                Console.WriteLine();
                Console.WriteLine("Another batter? <Y/N>");

                PlayAgain = Console.ReadLine();
                while (!Regex.Match(PlayAgain, "^[YyNn]$").Success)
                {
                    Console.Write("Not a valid entry. Please enter Y/N: ");
                    PlayAgain = Console.ReadLine();
                }
                if(PlayAgain == "N" || PlayAgain == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Strike three, you're out!");
                    RunProg = false;
                }
                else
                {
                    Console.Clear();
                }

            }
        }
    }
}
