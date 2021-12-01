using AOC.Solutions.Utility;

namespace AOC.Solutions;

public class D01 : DayBase
{
    protected override int Day => 1;
    
    public override int Solve_1() => GetIncreasedMeasurement(1);
    public override int Solve_2() => GetIncreasedMeasurement(3);
    
    private int GetIncreasedMeasurement(int lookBack)
    {
        var measurements = GetInputAsLinesAsNumbers();
        var i = lookBack;
        return measurements.Skip(lookBack).Count(x => x > measurements[i++-lookBack]);
    }
}