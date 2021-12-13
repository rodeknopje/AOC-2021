namespace AOC.Solutions;

public class D09 : DayBase
{
    protected override int Day => 9;

    private readonly int[,] _map;

    public D09()
    {
        var lines = GetInputLines();
         
        _map = new int[lines.Count, lines.First().Length];
        
        for (var i = 0; i < lines.Count; i++)
        for (var j = 0; j < lines[i].Length; j++)
        {
            _map[i, j] = int.Parse(lines[i][j].ToString());
        }
    }

    public override long Solve_1()
    {
        var risk = 0;
        
        for (var y = 0; y < _map.GetLength(0); y++)
        for (var x = 0; x < _map.GetLength(1); x++)
        {
            if (GetAdjacent(y, x).Any(node => node.value <= _map[y,x]) == false)
            {
                risk += _map[y, x] + 1;
            }
        }

        return risk;
    }
    
    public override long Solve_2()
    {
        var basins = new List<int>();
        
        for (var y = 0; y < _map.GetLength(0); y++)
        for (var x = 0; x < _map.GetLength(1); x++)
        {
            if (GetAdjacent(y, x).Any(node => node.value <= _map[y,x]) == false)
            {
                basins.Add(GetBasinSize((y,x), new HashSet<(int y, int x)>()));
            }
        }
        
        return basins.OrderByDescending(x => x).Take(3).Aggregate((a,b) => a * b);
    }
    
    private int GetBasinSize((int y, int x) node, HashSet<(int y, int x)> nodes)
    {
        if (_map[node.y, node.x] == 9 || nodes.Contains(node))
        {
            return 0;
        }

        var sum = 1;

        nodes.Add(node);

        foreach (var adjacent in GetAdjacent(node.y,node.x))
        {
            sum += GetBasinSize((adjacent.y, adjacent.x), nodes);
        }
        
        return sum;
    }
    
    
    private IEnumerable<(int y,int x, int value)> GetAdjacent(int y, int x)
    {
        var nodes = new List<(int y,int x, int value)>();
        
        if (x > 0)
            nodes.Add((y,x-1,_map[y, x - 1]));
        if (x < _map.GetLength(1) - 1)
            nodes.Add((y,x+1,_map[y, x + 1]));
        if (y > 0)
            nodes.Add((y-1,x,_map[y - 1, x]));
        if (y < _map.GetLength(0) - 1)
            nodes.Add((y+1,x,_map[y + 1, x]));
        
        return nodes;
    }
}