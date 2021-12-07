namespace AOC.Solutions;

public class D02 : DayBase
{
    protected override int Day => 2;

    public override long Solve_1()
    {
        int x = 0, y = 0;

        foreach (var line in GetInputLines())
        {
            var amount = Convert.ToInt32(line.Split(" ")[1]);

            switch (line[0])
            {
                case 'u':
                    y -= amount;
                    break;
                case 'd':
                    y += amount;
                    break;
                case 'f':
                    x += amount;
                    break;
            }
        }

        return x * y;
    }

    public override long Solve_2()
    {
        int x = 0, y = 0, aim = 0;

        foreach (var line in GetInputLines())
        {
            var amount = Convert.ToInt32(line.Split(" ")[1]);

            switch (line[0])
            {
                case 'u':
                    aim -= amount;
                    break;
                case 'd':
                    aim += amount;
                    break;
                case 'f':
                    x += amount;
                    y += amount * aim;
                    break;
            }
        }
        
        return x * y;
    }
}