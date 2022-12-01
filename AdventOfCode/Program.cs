#region { FILE INPUT }

string day = "DayOne";

string inputPath = $@"C:\Users\ddupuis\source\repos\dmd-aoc-2022\AdventOfCode\Input\{day}.txt";
Console.WriteLine(inputPath);
string[] fileLines = File.ReadAllLines(inputPath);

#endregion { FILE INPUT }

#region { DAY ONE }
/**
 * https://adventofcode.com/2022/day/1
 * 
 * Part One - Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
 * 
 * Part Two - Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
 */

int index = 0;
int curCal = 0;
List<int> elfCalories = new();

foreach (string line in fileLines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        //Console.WriteLine($"adding {curCal} to list");
        elfCalories.Add(curCal);
        index++;
        curCal = 0;
        continue;
    }
    curCal += int.Parse(line);
}

// sort list
var sortedList = elfCalories.OrderByDescending(x => x);

var topElf = sortedList.First(); // 67450
var topThree = sortedList.Take(3).Sum(); // 199357

Console.WriteLine(topThree);

#endregion { DAY ONE }