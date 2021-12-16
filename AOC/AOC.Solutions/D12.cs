namespace AOC.Solutions;

public class D12 : DayBase
{
    protected override int Day => 12;

    private readonly Dictionary<string, List<string>> _nodes;

    private readonly List<string> _paths;
    public D12()
    {
        _paths = new List<string>();
        _nodes = new Dictionary<string, List<string>>();

        foreach (var line in GetInputLines())
        {
            var caves = line.Split('-');

            var a = caves[0];
            var b = caves[1];

            _nodes.TryAdd(a, new List<string>());
            _nodes.TryAdd(b, new List<string>());

            _nodes[a].Add(b);
            _nodes[b].Add(a);
        }
    }

    public override long Solve_1()
    {
        return GetPaths("start", new List<string>());
    }

    private int GetPaths(string node, ICollection<string> currentPath, string visitTwiceNode = "")
    {
        if (node == "end")
        {
            // output for puzzle 2
            _paths.Add(string.Concat(currentPath));
            
            return 1;
        }
        if (node == node.ToLower() && currentPath.Contains(node) && visitTwiceNode != node)
        {
            return 0;
        }
        if (node == visitTwiceNode && currentPath.Count(x => x == visitTwiceNode) == 2)
        {
            return 0;
        }
        
        var newPath = currentPath.ToList();

        newPath.Add(node);

        return _nodes[node].Sum(adjacent => GetPaths(adjacent, newPath, visitTwiceNode));
    }

    public override long Solve_2()
    {
        foreach (var node in _nodes.Keys.Where(node => node == node.ToLower() && node != "start"))
        {
            GetPaths("start", new List<string>(), node);
        }

        return _paths.Distinct().Count();
    }
}