using System.Threading.Channels;

namespace AOC.Solutions;

public class D03 : DayBase
{
    protected override int Day => 3;

    public override int Solve_1()
    {
        var input = GetInputLines();

        string ga = "", ep = "";

        for (var i = 0; i < input.First().Length; i++)
        {
            var avg = Math.Round(input.Select(line => int.Parse(line[i]+"")).Average());
            
            ga += avg;
            ep += Math.Abs(--avg);
        }

        return Convert.ToInt16(ga, 2) * 
               Convert.ToInt16(ep, 2);
    }
    
    public override int Solve_2()
    {
        var oxy = Filter((_0s, _1s) => _0s > _1s ? '0' : '1');
        var co2 = Filter((_0s, _1s) => _1s < _0s ? '1' : '0');

        return oxy * co2;
    }

    private int Filter(Func<int, int, char> condition)
    {
        var input = GetInputLines();

        for (var i = 0; input.Count > 1; i++)
        {
            var _0s = input.Count(line => line[i] == '0');
            var _1s = input.Count(line => line[i] == '1');
            
            input = input.Where(x => x[i] == condition(_0s, _1s)).ToList();
        }

        return Convert.ToInt16(input.First(), 2);
    }
}

