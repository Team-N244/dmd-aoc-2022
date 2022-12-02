using AdventOfCode.DayTwo;

#region { FILE INPUT }

string day = "Two";

string inputPath = $@"C:\Users\ddupuis\source\repos\dmd-aoc-2022\AdventOfCode\Day{day}\Input.txt";
Console.WriteLine(inputPath);
string[] fileLines = File.ReadAllLines(inputPath);

#endregion { FILE INPUT }

#region { DAY ONE }

//DayOne solver1 = new DayOne(fileLines);

//Console.WriteLine("Part One: " + solver1.Solve(1)); // solution for part 1
//Console.WriteLine("Part Two: " + solver1.Solve(2)); // solution for part 2

#endregion { DAY ONE }

#region { DAY TWO }

DayTwo solver2 = new DayTwo(fileLines);

Console.WriteLine("Part One: " + solver2.Solve(1)); // solution for part 1
Console.WriteLine("Part Two: " + solver2.Solve(2)); // solution for part 2

#endregion { DAY TWO }
