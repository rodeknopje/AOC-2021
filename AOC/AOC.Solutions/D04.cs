using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D04 : DayBase
{
    protected override int Day => 4;

    private readonly int[,,] _grid;
    private readonly List<int> _drawOrder;
    private readonly Dictionary<int, List<(int b, int y, int x)>> _numberCoords;

    private readonly int _boardCount;

    private const int BoardSize = 5;

    public D04()
    {
        var input = GetInputRaw().Split("\n\n", 2);
        var nums = new Regex(@"\d+").Matches(input[1]).Select(x => int.Parse(x + "")).ToList();
        
        _boardCount = GetInputRaw().Split("\n\n").Length - 1;
        
        _drawOrder = input[0].Split(',').Select(int.Parse).ToList();
        
        _grid = new int[_boardCount, BoardSize, BoardSize];
        
        _numberCoords = new Dictionary<int, List<(int b, int y, int x)>>();

        for (var i = 0; i < _boardCount; i++)
        {
            _numberCoords.Add(i, new List<(int b, int y, int x)>());
        }
        for (var i = 0; i < nums.Count; i++)
        {
            var b = i / (BoardSize * BoardSize);
            var y = i / BoardSize - b * BoardSize;
            var x = i % BoardSize;
            var v = nums[i];

            _grid[b, y, x] = v;
            _numberCoords[v].Add((b, y, x));
        }
    }


    public override long Solve_1()
    {
        foreach (var lucky in _drawOrder)
        foreach (var pos in _numberCoords[lucky])
        {
            _grid[pos.b, pos.y, pos.x] = 0;

            if (CheckBingo(pos))
            {
                return GetBoardSum(pos.b) * lucky;
            }
        }

        return -1;
    }

    public override long Solve_2()
    {
        var solvedBoards = new List<int>();

        foreach (var lucky in _drawOrder)
        foreach (var pos in _numberCoords[lucky])
        {
            _grid[pos.b, pos.y, pos.x] = 0;

            if (solvedBoards.Contains(pos.b) || CheckBingo(pos) == false)
            {
                continue;
            }

            solvedBoards.Add(pos.b);

            if (solvedBoards.Count == _boardCount)
            {
                return GetBoardSum(pos.b) * lucky;
            }
        }

        return -1;
    }

    private bool CheckBingo((int b, int y, int x) pos)
    {
        int y = 0, x = 0;

        for (var i = 0; i < BoardSize; i++)
        {
            y += _grid[pos.b, i, pos.x];
            x += _grid[pos.b, pos.y, i];
        }

        return y == 0 || x == 0;
    }

    private int GetBoardSum(int b)
    {
        var sum = 0;

        for (var y = 0; y < 5; y++)
        for (var x = 0; x < 5; x++)
        {
            sum += _grid[b, y, x];
        }

        return sum;
    }
}