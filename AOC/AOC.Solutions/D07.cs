using System.Diagnostics;

namespace AOC.Solutions;

public class D07 : DayBase
{
    protected override int Day => 7;

    private readonly List<int> _input;

    public D07()
    {
        _input = GetInputRaw().Split(',').Select(int.Parse).ToList();
    }

    public override long Solve_1()
    {
        var median = _input.OrderBy(x => x).ToList()[_input.Count / 2];

        return _input.Sum(number => Math.Abs(number - median));
    }

    public override long Solve_2()
    {
        return _input.Distinct().Select(t => _input.Select(x => Math.Abs(x - t)).Select(x => x * (x + 1) / 2).Sum()).Min();
    }
}