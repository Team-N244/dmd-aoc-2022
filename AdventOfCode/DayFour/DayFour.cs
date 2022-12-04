namespace AdventOfCode.DayFour
{
    internal class DayFour
    {
        string[] _fileLines;

        /// <summary>
        /// https://adventofcode.com/2022/day/4
        /// 
        /// Part One - In how many assignment pairs does one range fully contain the other?
        /// 
        /// Part Two - In how many assignment pairs do the ranges overlap at all?
        /// </summary>
        /// <param name="input"></param>
        public DayFour(string[] fileLines)
        {
            _fileLines = fileLines;
        }

        public int Solve(int part)
        {
            var partOneCount = 0;
            var partTwoCount = 0;
            foreach (var line in _fileLines)
            {
                // break each line into pairs (split on ",")
                var pairs = line.Split(',');
                var one = pairs[0].Split('-');
                (var s1, var e1) = (int.Parse(one[0]), int.Parse(one[1]));

                var two = pairs[1].Split('-');
                (var s2, var e2) = (int.Parse(two[0]), int.Parse(two[1]));

                // check if s1 >= s2 && e1 <= e2
                //       or s2 >= s1 && e2 <= e1
                partOneCount +=
                    (s1 >= s2 && e1 <= e2) ||
                    (s2 >= s1 && e2 <= e1) ? 1 : 0;

                // find earliest start time
                // if start time of later interval < end of earlier interval there is an overlap
                partTwoCount +=
                    (s1 <= s2 && s2 <= e1) ||
                    (s2 <= s1 && s1 <= e2) ? 1 : 0;
            }

            return part == 1
                ? partOneCount    // part one
                : partTwoCount;   // part two
        }
    }
}
