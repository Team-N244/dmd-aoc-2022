namespace AdventOfCode.DayOne
{
    internal class DayOne
    {
        string[] _fileLines;

        /// <summary>
        /// https://adventofcode.com/2022/day/1
        /// 
        /// Part One - Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?
        /// 
        /// Part Two - Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
        /// </summary>
        /// <param name="input"></param>
        public DayOne(string[] fileLines)
        {
            _fileLines = fileLines;
        }

        public int Solve(int puzzleNumber)
        {
            int index = 0;
            int curCal = 0;
            List<int> elfCalories = new();

            foreach (string line in _fileLines)
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

            var sortedList = elfCalories.OrderByDescending(x => x);

            var topElf = sortedList.First(); // 67450
            var topThree = sortedList.Take(3).Sum(); // 199357

            return puzzleNumber == 1
                ? topElf    // part one
                : topThree;   // part two
        }
    }
}