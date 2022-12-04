using System.IO;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    public class Challenge1
    {
        public void Run()
        {
            string filePath = "./Day1/input.txt";

            Dictionary<int, int> elvesCalorieCount = new Dictionary<int, int>() { { 1, 0 } };
            // loop over the file and get 
            int elfCounter = 1;

            string[] fileLines = File.ReadAllLines(filePath);

            for (int i = 0; i < fileLines.Count(); i++)
            {
                // if we are at a blank line then we need have come to a new elf. 
                if (string.IsNullOrWhiteSpace(fileLines[i]))
                {
                    elfCounter++;
                    elvesCalorieCount.Add(elfCounter, 0);
                }
                else
                {
                    elvesCalorieCount[elfCounter] += int.Parse(fileLines[i]);
                }
            }
            var max = elvesCalorieCount.OrderByDescending(obd => obd.Value).First();
            var topThree = elvesCalorieCount.OrderByDescending(obd => obd.Value).Take(3).Sum(s => s.Value);

            Console.WriteLine($"Part 1 : {max.Key} => {max.Value}");
            Console.WriteLine($"Part 2 : {topThree}");

        }
    }
}