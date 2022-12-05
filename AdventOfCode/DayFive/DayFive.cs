using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.DayFive
{
    internal class DayFive
    {
        readonly string[] _fileLines;
        readonly Regex emptyBlock = new("\\s{4}");

        /// <summary>
        /// https://adventofcode.com/2022/day/5
        /// 
        /// Part One - After the rearrangement procedure completes, what crate ends up on top of each stack?
        /// 
        /// Part Two - Crane rearranges multiple crates in one move
        /// </summary>
        /// <param name="input"></param>
        public DayFive(string[] fileLines)
        {
            _fileLines = fileLines;
        }

        public string Solve(int part)
        {
            // create stacks of crates from input lines
            List<string> stackLines = GetStackLines();
            List<Stack<string>> crateStacks = CreateCrateStacks(stackLines);

            //Console.WriteLine("Initial Configuration");
            //PrintValues(cols[0]);
            //PrintValues(cols[1]);
            //PrintValues(cols[2]);
            //Console.WriteLine();

            // create rearrangement procedure
            List<string> rearrangementProcedure = CreateRearrangementProcedure();

            // rearrange crates
            RearrangeCrates(rearrangementProcedure, crateStacks, part);

            StringBuilder partOne = new();
            StringBuilder partTwo = new();
            foreach (var column in crateStacks)
            {
                if (part == 1)
                    partOne.Append(column.First());
                else
                    partTwo.Append(column.First());
            }

            return part == 1
                ? partOne.ToString()    // part one
                : partTwo.ToString();   // part two
        }

        private List<string> GetStackLines()
        {
            List<string> stackLines = new();
            foreach (var line in _fileLines)
            {
                if (line.Trim().StartsWith('1'))
                {
                    break;
                }
                // create stacks and rearrangement procedure
                if (!line.StartsWith("move"))
                {
                    stackLines.Add(line);
                }
            }
            stackLines.Reverse();
            return stackLines;
        }

        private List<Stack<string>> CreateCrateStacks(List<string> stackLines)
        {
            List<Stack<string>> crateStacks = new();

            int colIdx = 0;
            // create stacks
            foreach (var line in stackLines)
            {
                var crates = emptyBlock.Replace(line, "_ ").Split(' ');
                Array.ForEach(crates, x =>
                {
                    if (crateStacks.Count == colIdx)
                    {
                        crateStacks.Add(new());
                    }
                    var crate = x.Trim(new char[] { '_', '[', ']' });
                    if (crate != "")
                        crateStacks[colIdx].Push(crate);
                    colIdx++;
                });
                colIdx = 0;
            }

            return crateStacks;
        }

        private List<string> CreateRearrangementProcedure()
        {
            List<string> rearrProc = new();
            Regex deleteWords = new("move |from |to ");
            foreach (var line in _fileLines)
            {
                // ignore non-move lines
                if (line.Trim().StartsWith("move"))
                {
                    rearrProc.Add(deleteWords.Replace(line, ""));
                }
            }
            return rearrProc;
        }

        private static void RearrangeCrates(List<string> rearrangementProcedure, List<Stack<string>> crateStacks, int part)
        {
            var lineCount = 1;
            foreach (var line in rearrangementProcedure)
            {
                var instructions = line.Split(' ');
                var numBlocks = int.Parse(instructions[0].Trim());
                var fromCol = int.Parse(instructions[1].Trim()) - 1;
                var toCol = int.Parse(instructions[2].Trim()) - 1;
                List<string> moveList = new();
                for (int i = 0; i < numBlocks; i++)
                {
                    if (part == 1)
                    {
                        crateStacks[toCol].Push(crateStacks[fromCol].Pop());
                        //Console.WriteLine("Configuration after line {0}, move {1}", lineCount, i + 1);
                        //PrintValues(crateStacks[0]);
                        //PrintValues(crateStacks[1]);
                        //PrintValues(crateStacks[2]);
                        //Console.WriteLine();
                    }
                    else
                    {
                        // pop all into a temp list
                        moveList.Add(crateStacks[fromCol].Pop());
                    }
                }

                if (part == 2)
                {
                    // push all into toCol
                    moveList.Reverse();
                    foreach (var move in moveList)
                    {
                        crateStacks[toCol].Push(move);
                    }
                    //Console.WriteLine("Configuration after line {0} move", lineCount);
                    //PrintValues(cols[0]);
                    //PrintValues(cols[1]);
                    //PrintValues(cols[2]);
                    //Console.WriteLine();
                }
                lineCount++;
            }
        }

        private static void PrintValues(IEnumerable<string> myCollection)
        {
            foreach (string crate in myCollection)
                Console.Write("{0}", crate == "" ? "_" : crate);
            Console.WriteLine();
        }
    }
}
