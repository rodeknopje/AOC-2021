namespace AOC.Solutions;

public class D01 : DayBase
{
    protected override int Day => 1;
    
    public override int Solve_1() => GetIncreaseCount(1);
    public override int Solve_2() => GetIncreaseCount(3);
    
    private int GetIncreaseCount(int lookBack)
    {
        var measurements = GetInputNumbers();
        var i = lookBack;
        return measurements.Skip(lookBack).Count(x => x > measurements[i++-lookBack]);
    }
}