using System.IO;
using System;
using System.Collections.Generic;



namespace AdventOfCode.Day4
{
    public class Challenge4
    {
        public void Run()
        {
            var elfPairings = CreateElfPairings();
            Part1(elfPairings);
            Part2(elfPairings);
        }
        // 560
        // 839
        void Part1(List<ElfPairing> elfPairings)
        {
            int containsCounter = elfPairings.Sum(pairing => (Contains(pairing.Elf1, pairing.Elf2) || Contains(pairing.Elf2, pairing.Elf1)) ? 1 : 0);
            Console.WriteLine(containsCounter);
        }

        void Part2(List<ElfPairing> elfPairings)
        {
            int overlapCounter = elfPairings.Sum(pairing => (ContainsOrOverlaps(pairing.Elf1, pairing.Elf2)
                                                             || ContainsOrOverlaps(pairing.Elf2, pairing.Elf1)

                                                ) ? 1 : 0);
            Console.WriteLine(overlapCounter);
        }

        bool Contains(ElfRange first, ElfRange second)
        {
            return (first.Start >= second.Start && first.End <= second.End);
        }
        bool Overlaps(ElfRange first, ElfRange second)
        {
            return (first.Start >= second.Start && first.Start <= second.End) || (first.End >= second.Start && first.End <= second.End);
        }
        bool ContainsOrOverlaps(ElfRange first, ElfRange second)
        {
            return Contains(first, second) || Overlaps(first, second);
        }

        List<ElfPairing> CreateElfPairings()
        {
            string filePath = "input.txt";
            return File.ReadAllLines(filePath).ToList().Select(line =>
                       new ElfPairing()
                       {
                           Elf1 = new ElfRange()
                           {
                               Start = int.Parse(line.Split(",")[0].Split("-")[0]),
                               End = int.Parse(line.Split(",")[0].Split("-")[1])
                           },
                           Elf2 = new ElfRange()
                           {
                               Start = int.Parse(line.Split(",")[1].Split("-")[0]),
                               End = int.Parse(line.Split(",")[1].Split("-")[1]),
                           }
                       }
           ).ToList();

        }
    }

    public class ElfPairing
    {
        public ElfRange Elf1 { get; set; }
        public ElfRange Elf2 { get; set; }
    }

    public class ElfRange
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}