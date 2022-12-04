using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day2
{
    public class Challenge2
    {
        List<Combo> combosForPart1 = new List<Combo>(){
        new Combo("A","X",4),
        new Combo("A","Y",8),
        new Combo("A","Z",3),
        new Combo("B","X",1),
        new Combo("B","Y",5),
        new Combo("B","Z",9 ),
        new Combo("C","X",7),
        new Combo("C","Y",2 ),
        new Combo("C","Z",6)
    };

        List<Combo> combosForPart2 = new List<Combo>(){
        new Combo("A","X",3),
        new Combo("A","Y",4),
        new Combo("A","Z",8),
        new Combo("B","X",1),
        new Combo("B","Y",5),
        new Combo("B","Z",9),
        new Combo("C","X",2),
        new Combo("C","Y",6),
        new Combo("C","Z",7)
    };


        public void Run()
        {
            var fileLines = File.ReadAllLines("./input.txt");
            Console.WriteLine("Running Part1");
            Run(combosForPart1,fileLines);
            Console.WriteLine("Running Part2");
            Run(combosForPart2,fileLines);
        }

        void Run(List<Combo> combos, string[] fileLines)
        {
            int total = 0;
            for (int i = 0; i < fileLines.Count(); i++)
            {

                var round = combos.Where(w => w.TheirPlay == fileLines[i].Split(" ")[0]
                                         && w.MyPlay == fileLines[i].Split(" ")[1]).First();
                total += round.RoundTotal;
                Console.WriteLine($"Round {i} current Total {total}");
            }
        }

    }


    public class Combo
    {
        public Combo(string theirPlay, string myPlay, int roundTotal)
        {
            TheirPlay = theirPlay;
            MyPlay = myPlay;
            RoundTotal = roundTotal;
        }
        public string TheirPlay { get; set; }
        public string MyPlay { get; set; }
        public int RoundTotal { get; set; }
    }
}

