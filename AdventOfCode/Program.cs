#region { FILE INPUT }

using AdventOfCode.DayFive;

string day = "Five";

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

//DayTwo solver2 = new(fileLines);

//Console.WriteLine("Part One: " + solver2.Solve(1)); // solution for part 1
//Console.WriteLine("Part Two: " + solver2.Solve(2)); // solution for part 2

#endregion { DAY TWO }

#region { DAY THREE }

//DayThree solver3 = new(fileLines);

//Console.WriteLine("Part One: " + solver3.Solve(1)); // solution for part 1
//Console.WriteLine("Part Two: " + solver3.Solve(2)); // solution for part 2

#endregion { DAY THREE }

#region { DAY FOUR }

//DayFour solver4 = new(fileLines);

//Console.WriteLine("Part One: " + solver4.Solve(1)); // solution for part 1
//Console.WriteLine("Part Two: " + solver4.Solve(2)); // solution for part 2

#endregion { DAY FOUR }

#region { DAY FIVE }

DayFive solver5 = new(fileLines);

Console.WriteLine("Part One: " + solver5.Solve(1)); // solution for part 1
Console.WriteLine("Part Two: " + solver5.Solve(2)); // solution for part 2

#endregion { DAY FIVE }
