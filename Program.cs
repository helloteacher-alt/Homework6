using System;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num_level, num_menu, num_problem, answer;
            long time, time1, time2;
            double score = 0, score1, Qc = 0,Qa = 0, dLV = 0;
            Difficulty level = Difficulty.Easy;
            Console.WriteLine("Score:{0}, Difficulty:{1}",score,level);
            Console.WriteLine("Choose between 1/2/3");
            num_menu = int.Parse(Console.ReadLine());
            while (num_menu != 2)
            {
                switch (num_menu)
                {
                    case 0:
                        time1 = DateTimeOffset.Now.ToUnixTimeSeconds();
                        if (level == Difficulty.Easy)
                        {
                            num_problem = 3;
                            for (int i = 0; i < 3; i++)
                            {
                                GenrateRandomProblems(num_problem);
                                Problem[] random = GenrateRandomProblems(num_problem);
                                Console.WriteLine(random[i].message1);
                                Console.Write("_____");
                                answer = int.Parse(Console.ReadLine());
                                if (answer == random[i].answer1)
                                {
                                    Qc = Qc + 1;
                                }
                                Qa = 3; dLV = 0;
                            }
                        }
                        else if (level == Difficulty.Normal)
                        {
                            num_problem = 5;
                            for(int i = 0; i < 5; i++)
                            {
                                GenrateRandomProblems(num_problem);
                                Problem[] random = GenrateRandomProblems(num_problem);
                                Console.WriteLine(random[i].message1);
                                Console.Write("_____");
                                answer = int.Parse(Console.ReadLine());
                                if (answer == random[i].answer1)
                                {
                                    Qc = Qc + 1;
                                }
                                Qa = 5; dLV = 1;
                            }
                        }else if (level == Difficulty.Hard)
                        {
                            num_problem = 7;
                            for (int i = 0; i < 7; i++)
                            {
                                GenrateRandomProblems(num_problem);
                                Problem[] random = GenrateRandomProblems(num_problem);
                                Console.WriteLine(random[i].message1);
                                Console.Write("");
                                answer = int.Parse(Console.ReadLine());
                                if (answer == random[i].answer1)
                                {
                                    Qc = Qc + 1;
                                }
                                Qa = 7; dLV = 2;
                            }
                        }
                        time2 = DateTimeOffset.Now.ToUnixTimeSeconds();
                        time = time2 - time1;
                        score1 = (Qc / Qa) * ((25 - Math.Pow(dLV, 2)) / Math.Max(time, 25 - Math.Pow(dLV, 2)) * Math.Pow((2 * (dLV) + 1),2));
                        score = score1 + score;
                        Console.WriteLine("Score:{0}, Difficulty:{1}", score1,level);
                        Console.WriteLine("Choose between 1 / 2 / 3 :");
                        num_menu = int.Parse(Console.ReadLine());
                        break;
                    case 1:
                        Console.Write("____");
                        num_level = int.Parse(Console.ReadLine());
                        while (num_level != 0 && num_level != 1 && num_level != 2)
                        {
                            Console.WriteLine("Please input 0-2.");
                            Console.WriteLine("____");
                            num_level = int.Parse(Console.ReadLine());
                        }
                        if (num_level == 0)
                        {
                            level = Difficulty.Easy;
                        }else if (num_level == 1)
                        {
                            level=Difficulty.Normal;
                        }else if (num_level == 2)
                        {
                            level = Difficulty.Hard;
                        }
                        Console.WriteLine("Score:{0}, Difficulty:{1}",score,level);
                        Console.WriteLine("Choose between 1/2/3");
                        num_menu = int.Parse(Console.ReadLine());
                        break;
                }
            } while (num_menu != 0 && num_menu != 1 && num_menu != 2)
            {
                Console.WriteLine("Please input 0-2");
                num_menu = int.Parse(Console.ReadLine());
            }
        }
        enum Difficulty
        {
            Easy=3,Normal=5,Hard=7
        }
        struct Problem
        {
            public string message1;
            public int answer1;
            public Problem(string message2,int answer2)
            {
                message1 = message2;
                answer1 = answer2;
            }
        }
        static Problem[] GenrateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];
            Random random = new Random();
            int x, y;
            for(int i = 0; i < numProblem; i++)
            {
                x = random.Next(50);
                y = random.Next(50);
                if (random.NextDouble() >= 0.5)
                    randomProblems[i] = new Problem(String.Format("{0}+{1}=?", x, y), x + y);
                else randomProblems[i] = new Problem(String.Format("{0}-{1}=?", x, y), x - y);

            }

        }
    }
}
