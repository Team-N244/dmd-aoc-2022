namespace AdventOfCode.DaySix
{
    internal class DaySix
    {
        string[] _fileLines;

        /// <summary>
        /// https://adventofcode.com/2022/day/6
        /// 
        /// Part One - How many characters need to be processed before the first start-of-packet marker (4 chars) is detected?
        /// 
        /// Part Two - start-of-message marker (14 chars)
        /// </summary>
        /// <param name="input"></param>
        public DaySix(string[] fileLines)
        {
            _fileLines = fileLines;
        }

        public int Solve(int part)
        {
            var fullString = _fileLines[0];
            // get substrings of length 4, check for uniqueness
            // keep track of end index and return
            var endIndex = part == 1 ? 4 : 14;
            var i = 0;
            string substring;
            while (endIndex <= fullString.Length)
            {
                substring = fullString.Substring(i++, part == 1 ? 4 : 14);
                if (IsSubstringUnique(substring))
                {
                    return endIndex;
                }
                endIndex++;
            }
            return -1;
        }

        private static bool IsSubstringUnique(string str)
        {
            HashSet<int> map = new();
            foreach (char c in str)
            {
                if (map.Contains(c))
                    return false;

                map.Add(c);
            }
            return true;
        }
    }
}
