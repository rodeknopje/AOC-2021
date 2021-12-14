namespace AOC.Solutions;

public class D10 : DayBase
{
    private readonly Dictionary<char, char> pairs;

    protected override int Day => 10;

    public D10()
    {
        pairs = new Dictionary<char, char>
        {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
            {'<', '>'}
        };
    }

    public override long Solve_1()
    {
        var sum = 0;

        foreach (var line in GetInputLines())
        {
            var openings = new Stack<char>();

            foreach (var chr in line)
            {
                if ("([{<".Contains(chr))
                {
                    openings.Push(chr);
                }
                else if (chr != pairs[openings.Pop()])
                {
                    sum += chr switch
                    {
                        ')' => 3,
                        ']' => 57,
                        '}' => 1197,
                        '>' => 25137,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                }
            }
        }

        return sum;
    }

    public override long Solve_2()
    {
        var scores = new List<long>();

        foreach (var line in GetInputLines())
        {
            var openings = new Stack<char>();

            var skip = false;

            foreach (var chr in line)
            {
                if ("([{<".Contains(chr))
                {
                    openings.Push(chr);
                }
                else if (chr != pairs[openings.Pop()])
                {
                    skip = true;
                }
            }

            if (skip)
            {
                continue;
            }

            long score = 0;
            
            foreach (var opening in openings)
            {
                score *= 5; 
                score += opening switch
                {
                    '(' => 1,
                    '[' => 2,
                    '{' => 3,
                    '<' => 4,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            scores.Add(score);
        }

        return scores.OrderBy(x => x).ToList()[scores.Count/2];

    }
}