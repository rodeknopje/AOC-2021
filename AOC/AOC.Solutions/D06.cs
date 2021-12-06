namespace AOC.Solutions;

public class D06 : DayBase
{
    protected override int Day => 6;
    
    public override long Solve_1() => GetFishCount(80);
    public override long Solve_2() => GetFishCount(256);
    
    private long GetFishCount(int days)
    {
        var input = GetInputRaw().Split(',').Select(long.Parse).ToList();
        
        var generations = new long[9];

        for (var i = 0; i < generations.Length; i++)
        {
            generations[i] = input.Count(x => x == i);
        }
        for (var i = 0; i < days; i++)
        {
            var births = generations[0];
            
            var tempGenerations = new long[9];

            for (var j = 0; j < generations.Length - 1; j++)
            {
                tempGenerations[j] = generations[j + 1];
            }

            tempGenerations[6] += births;
            tempGenerations[8] += births;

            generations = tempGenerations;
        }

        return generations.Sum(x => x);
    }
}