namespace AOC.Solutions;

public class D11 : DayBase
{
    protected override int Day => 11;

    private readonly int[,] _map;
    private List<(int, int)> _flashed;

    public D11()
    {
        _map = GetInputIntMap();
    }

    public override long Solve_1()
    {
        var sum = 0;
        
        _flashed = new List<(int, int)>();

        for (var i = 0; i < 100; i++)
        {
            for (var y = 0; y < _map.GetLength(0); y++)
            for (var x = 0; x < _map.GetLength(1); x++)
            {
                sum += TryFlash((y, x));
            }
        }

        return sum;
    }

    public override long Solve_2()
    {
        for (var i = 1;; i++)
        {
            var sum = 0;
            
            _flashed = new List<(int, int)>();

            for (var y = 0; y < _map.GetLength(0); y++)
            for (var x = 0; x < _map.GetLength(1); x++)
            {
                sum += TryFlash((y, x));
            }

            if (sum == _map.Length)
            {
                return i;
            }
        }
    }

    private int TryFlash((int y, int x) node)
    {
        if (_flashed.Contains(node))
        {
            return 0;
        }

        if (++_map[node.y, node.x] <= 9)
        {
            return 0;
        }

        _flashed.Add(node);

        _map[node.y, node.x] = 0;

        return 1 + GetAdjacent(node.y, node.x).Sum(TryFlash);
    }


    private List<(int y, int x)> GetAdjacent(int posY, int posX)
    {
        var adjacent = new List<(int, int)>();

        for (var y = posY - 1; y <= posY + 1; y++)
        for (var x = posX - 1; x <= posX + 1; x++)
        {
            if (y < 0 || x < 0 || y >= _map.GetLength(0) || x >= _map.GetLength(1) || x == posX && y == posY)
            {
                continue;
            }

            adjacent.Add((y, x));
        }

        return adjacent;
    }
}