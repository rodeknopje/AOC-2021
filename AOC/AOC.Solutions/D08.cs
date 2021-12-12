namespace AOC.Solutions;

public class D08 : DayBase
{
    protected override int Day => 8;

    private readonly int[] _displayCodes;

    public D08()
    {
        _displayCodes = new[] {126, 48, 109, 121, 51, 91, 95, 112, 127, 123};
    }

    public override long Solve_1()
    {
        return GetInputLines().Sum(line => line.Split("|")[1].Trim().Split(" ").Select(x => x.Length).Count(x => x is 2 or 4 or 3 or 7));
    }

    public override long Solve_2()
    {
        var sum = 0;
        
        foreach (var line in GetInputLines())
        {
            var number = string.Empty;
            
            var codes_1 = line.Split("|")[0].Trim().Split(" ");
            var codes_2 = line.Split("|")[1].Trim().Split(" ");
            
            var decoded = DecodeCodes(codes_1);

            foreach (var code in codes_2)
            {
                number += decoded[Order(code)];
            }
            
            sum += int.Parse(number);
        }

        return sum;
    }

    private Dictionary<string, int> DecodeCodes(string[] codes)
    {
        var decoded = new Dictionary<string, int>();
        
        // get codes for unique numbers
        var knownCodes = new Dictionary<int, string>
        {
            {1, codes.First(x => x.Length == 2)},
            {4, codes.First(x => x.Length == 4)},
            {7, codes.First(x => x.Length == 3)},
            {8, codes.First(x => x.Length == 7)}
        };


        foreach (var code in knownCodes)
        {
            decoded[Order(code.Value)] = code.Key;
        }
        
        foreach (var code in codes)
        {
            if (knownCodes.ContainsValue(code))
            {
                continue;
            }

            // loop though possible numbers
            for (var i = 0; i < 10; i++)
            {
                var correctNumber = true;
                
                // loop through known codes
                foreach (var known in knownCodes.Keys)
                {
                    var binaryOverlap = Convert.ToString(_displayCodes[known] & _displayCodes[i], 2).Count(x => x == '1');
                    var codeOverlap = knownCodes[known].Count(x => code.Contains(x));

                    if (codeOverlap != binaryOverlap)
                    {
                        correctNumber = false;
                        break;;
                    }
                }

                if (correctNumber)
                {
                    decoded.Add(Order(code), i);
                }
            }
        }

        return decoded;
    }

    private string Order(string origin) => string.Concat(origin.OrderBy(x => x));

}