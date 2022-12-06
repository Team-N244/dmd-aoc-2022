namespace AdventOfCode.DayTwo
{
    internal class DayTwo
    {
        string[] _fileLines;

        /// <summary>
        /// https://adventofcode.com/2022/day/
        /// 
        /// Part One - What would your total score be if everything goes exactly according to your strategy guide?
        /// 
        /// Part Two - Correct meaning of second column
        /// </summary>
        /// <param name="input"></param>
        public DayTwo(string[] fileLines)
        {
            _fileLines = fileLines;
        }

        public int Solve(int part)
        {
            int partOneScore = 0;
            foreach (string round in _fileLines)
            {
                var shapes = round.Split(' ');
                var myShape = shapes[1];

                // apply score for shape (1 for Rock [AX], 2 for Paper [BY], and 3 for Scissors [CZ])
                var myScore = myShape switch { "X" => 1, "Y" => 2, "Z" => 3, _ => 0 };

                // apply score for outcome (0 for L, 3 for T, and 6 for W) => (X > C, Y > A, Z > B)
                myScore += round switch
                {
                    "A Y" or "B Z" or "C X" => 6,
                    "A X" or "B Y" or "C Z" => 3,
                    _ => 0
                };

                // sum the value of each round
                partOneScore += myScore;
            }

            int partTwoScore = 0;
            foreach (string round in _fileLines)
            {
                var shapes = round.Split(' ');
                var oppShape = shapes[0];
                var outcome = shapes[1];

                // apply score for outcome
                var myScore = outcome switch
                {
                    "Z" => 6,
                    "Y" => 3,
                    _ => 0
                };

                // apply score for shape
                myScore += round switch
                {
                    "A Y" or "B X" or "C Z" => 1,
                    "C X" or "B Y" or "A Z" => 2,
                    "A X" or "B Z" or "C Y" => 3,
                    _ => 0
                };

                partTwoScore += myScore;
            }

            return part == 1
                ? partOneScore    // part one
                : partTwoScore;   // part two
        }
    }
}
