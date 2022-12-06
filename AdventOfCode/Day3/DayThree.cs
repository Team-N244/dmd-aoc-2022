namespace AdventOfCode.DayThree
{
    internal class DayThree
    {
        string[] _fileLines;
        //List<char> lowerPriorty = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
        //List<char> upperPriorty = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();

        /// <summary>
        /// https://adventofcode.com/2022/day/3
        /// 
        /// Part One - Find the item type that appears in both compartments of each rucksack. 
        ///            What is the sum of the priorities of those item types?
        /// 
        /// Part Two - ????
        /// </summary>
        /// <param name="input"></param>
        public DayThree(string[] fileLines)
        {
            _fileLines = fileLines;
        }

        public int Solve(int part)
        {
            int partOneScore = 0;
            foreach (string rucksack in _fileLines)
            {
                // break each line in half
                var halfIndex = rucksack.Length / 2;
                var one = rucksack.Substring(0, halfIndex).ToCharArray();
                var two = rucksack.Substring(halfIndex).ToCharArray();

                // find the items that appear in both compartments
                // apply the priority value to each item
                List<char> same = one.Intersect(two).ToList();
                List<int> ints = same.Select(
                    x => char.IsLower(x)
                    ? (int)x - 96
                    : (int)x - 38
                ).ToList();

                // sum the priorities
                partOneScore += ints.Sum();
            }

            int partTwoScore = 0;
            List<List<List<char>>> groups = new();

            // group into sets of 3
            for (int i = 0; i < _fileLines.Length; i += 3)
            {
                groups.Add(_fileLines.Skip(i).Take(3).Select(x => x.ToCharArray().ToList()).ToList());
            }

            foreach (var group in groups)
            {
                // find the badges
                List<int> badges = group
                    .Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b))
                    .Select(
                        x => char.IsLower(x)
                        ? (int)x - 96
                        : (int)x - 38
                    ).ToList();

                // sum the priorities
                partTwoScore += badges.Sum();
            }

            return part == 1
                ? partOneScore    // part one
                : partTwoScore;   // part two
        }
    }
}
