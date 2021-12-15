using System.Net;

namespace AOC.Solutions.Utility;

public abstract class DayBase
{
    private const int Year = 2021;
    
    private readonly AdventClient _adventClient;

    protected abstract int Day { get; }
    
    protected DayBase()
    {
        _adventClient = new AdventClient();
    }
    
    public abstract long Solve_1();
    public abstract long Solve_2();
    
    protected string GetInputRaw() => _adventClient.FetchInput(Year, Day);
    protected List<string> GetInputLines() => _adventClient.FetchInput(Year, Day).Split('\n').ToList();
    protected List<int> GetInputNumbers() => _adventClient.FetchInput(Year, Day).Split('\n').Select(x=> Convert.ToInt32(x)).ToList();

    protected int[,] GetInputIntMap()
    {
        var input = _adventClient.FetchInput(Year, Day).Split('\n');

        var map = new int[input.Length,input.First().Length];

        for (var y = 0; y < map.GetLength(0); y++)
        for (var x = 0; x < map.GetLength(1); x++)
        {
            map[y, x] = int.Parse(input[y][x].ToString());
        }

        return map;
    }
    
    protected char[,] GetInputCharMap()
    {
        var input = _adventClient.FetchInput(Year, Day).Split('\n');

        var map = new char[input.Length,input.First().Length];

        for (var y = 0; y < map.GetLength(0); y++)
        for (var x = 0; x < map.GetLength(1); x++)
        {
            map[y, x] = input[y][x];
        }

        return map;
    }
}