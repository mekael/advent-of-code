namespace AdventOfCode.Day5;
using System.Collections.Generic;

public class Challenge5
{


  
    public void Run()
    {
        string[] fileContents = File.ReadAllLines("./Day5/input.txt");

        var divider = Array.IndexOf(fileContents, "");

        int numberOfStacks = int.Parse(fileContents[divider - 1].Trim()
            .Replace("  "," ")
            .Split(" ")
            .Last());

        Dictionary<int, Stack<string>> stackPart1 = CreateStacks(fileContents, numberOfStacks, divider);
        Dictionary<int, Stack<string>> stackPart2 = CreateStacks(fileContents, numberOfStacks, divider);


        var actions = CreateListOfCraneActions(fileContents, divider+1);

        Part1(stackPart1, actions, numberOfStacks);
        Part2(stackPart2, actions, numberOfStacks);
        
    }

    Dictionary<int, Stack<string>> CreateStacks(string[] fileContents, int numberOfStacks, int divider)
    {
        Dictionary<int, Stack<string>> stacks = new Dictionary<int, Stack<string>>();
        for (int i = 1; i <= numberOfStacks; i++)
        {
            stacks.Add(i, new Stack<string>());
        }

        for (int i = (divider - 2); i >= 0; i--)
        {
            var line = fileContents[i].PadRight(numberOfStacks * 4, ' ');
            for (int j = 1; j <= numberOfStacks; j++)
            {
                var positionVal = line.Substring((j - 1) * 4, 4)
                    .Replace(" ","")
                    .Replace("[","")
                    .Replace("]","");
                if (!string.IsNullOrWhiteSpace(positionVal))
                {
                    stacks[j].Push(positionVal);
                }
            }
        }

        return stacks;
    }
    
    
    void Part1(Dictionary<int, Stack<string>> stacks, Dictionary<int, CraneMovementAction> actions, int numberOfStacks)
    {
        for (int i = 1; i <= actions.Count(); i++)
        {
            var action = actions[i];
            for (int j = 0; j < action.NumberToMove; j++)
            {
                stacks[action.EndingStack].Push(stacks[action.StartingStack].Pop());
            }
        }

        Console.WriteLine("Part1");
        DetermineEndArrangement(stacks, numberOfStacks);
    }
    void Part2(Dictionary<int, Stack<string>> stacks, Dictionary<int, CraneMovementAction> actions, int numberOfStacks)
    {
        for (int i = 1; i <= actions.Count(); i++)
        {
            var action = actions[i];
            Stack<string> tempStack = new Stack<string>();
            
            for (int j = 0; j < action.NumberToMove; j++)
            {
                tempStack.Push(stacks[action.StartingStack].Pop());
            }

            while (tempStack.Count() != 0)
            {
                stacks[action.EndingStack].Push(tempStack.Pop());
            }

        }
        Console.WriteLine("Part2");
        DetermineEndArrangement(stacks, numberOfStacks);
    }

    void DetermineEndArrangement(Dictionary<int, Stack<string>> stacks,  
        int numberOfStacks)
    {
        string endArrangement = "";
        for (int i = 1; i <= numberOfStacks; i++)
        {
            if (stacks[i].Count != 0)
            {
                endArrangement += stacks[i].Pop();
            }
        }
        Console.WriteLine(($"Ending Arrangement : {endArrangement}"));

    }
    
    Dictionary<int, CraneMovementAction> CreateListOfCraneActions(string[] fileContents,int startOfCraneActions)
    {
        Dictionary<int, CraneMovementAction> craneMovementActions = new Dictionary<int, CraneMovementAction>();
        int offset = startOfCraneActions - 1;
        for(int i = startOfCraneActions; i< fileContents.Length; i++)
        {
            //move 7 from 3 to 9

            var cleansedLine = fileContents[i].Replace("move ", "")
                .Replace(" from ", " ")
                .Replace(" to ", " ")
                .Split(" ");
            craneMovementActions.Add( (i-offset),new CraneMovementAction()
            {
                ActionNumber = i - offset,
                NumberToMove = int.Parse(cleansedLine[0]),
                StartingStack = int.Parse(cleansedLine[1]),
                EndingStack = int.Parse(cleansedLine[2])
            });
        }

        return craneMovementActions;
    }
}

public class CraneMovementAction
{
    public  int ActionNumber { get; set; }
    public  int NumberToMove { get; set; }
    public int StartingStack { get; set; }
    public  int EndingStack { get; set; }
}