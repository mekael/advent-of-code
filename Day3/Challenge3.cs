using System.IO;
using System;
using System.Collections.Generic;



namespace AdventOfCode.Day3
{
public  class Challenge3
{

    public void Run()
    { 
        string filePath = "./Day3/input.txt";
        var fileLines = File.ReadAllLines(filePath);
        Part1(fileLines);
        Part2(fileLines);
    }

     void Part2(string[] fileLines)
    {
        int sum = 0;

        for (int i = 0; i < fileLines.Count(); i += 3)
        {
            var elf1 = fileLines[i].ToCharArray();
            var elf2 = fileLines[i + 1].ToCharArray();
            var elf3 = fileLines[i + 2].ToCharArray();
            var intersectingChar = (elf1.Intersect(elf2).Intersect(elf3).First());
            sum += DecimalConvert(intersectingChar);
        }
        Console.WriteLine(sum);
    }


     void Part1(string[] fileLines)
    {
        int sum = 0;
        foreach (var line in fileLines)
        {
            var intersectingChar = line.Substring(0, line.Length / 2)
                                       .ToCharArray()
                                       .Intersect(line.Substring(line.Length / 2)
                                                      .ToCharArray())
                                       .First();
            sum += DecimalConvert(intersectingChar);
        }
        Console.WriteLine(sum);
    }
     int DecimalConvert(char intersectingChar)
    {
        int decimalVal = (int)intersectingChar;
        return (decimalVal >= 97) ? decimalVal - 96 : decimalVal - 38;
    }
}
}