using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D05 : DayBase
{
    protected override int Day => 5;

    private readonly Dictionary<(int y, int x), int> _nodes;
    private readonly IEnumerable<((int x, int y) curr, (int x, int y) dest)> _input;

    public D05()
    {
        _input = GetInputLines()
            .Select(line => new Regex("\\d+").Matches(line))
            .Select(match => match.Select(x => int.Parse(x.ToString())).ToList())
            .Select(x => ((x[0], x[1]), (x[2], x[3])));

        _nodes = new Dictionary<(int y, int x), int>();
    }

    public override long Solve_1()
    {
        foreach (var (curr, dest) in _input)
        {
            if (curr.x != dest.x && curr.y != dest.y)
            {
                continue;
            }

            RegisterVents(curr, dest);
        }

        return _nodes.Values.Count(x => x > 1);
    }

    public override long Solve_2()
    {
        foreach (var (curr, dest) in _input)
        {
            RegisterVents(curr, dest);
        }

        return _nodes.Values.Count(x => x > 1);
    }

    private void RegisterVents((int x, int y) curr, (int x, int y) dest)
    {
        RegisterVent(dest);

        while (curr != dest)
        {
            RegisterVent(curr);

            curr.x += Math.Clamp(dest.x - curr.x, -1, 1);
            curr.y += Math.Clamp(dest.y - curr.y, -1, 1);
        }
    }

    private void RegisterVent((int, int) pos)
    {
        _nodes.TryAdd(pos, 0);
        _nodes[pos]++;
    }
}