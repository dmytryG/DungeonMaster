namespace DungeonMaster.Models;

[Serializable]
public class V2
{
    public int x;
    public int y;

    protected static Random? _random;

    public V2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public V2()
    {
        x = 0;
        y = 0;
    }

    public override string ToString()
    {
        return $"int V2 X={x}, Y={y}";
    }

    public int Random()
    {
        if (_random == null)
        {
            _random = new Random();
        }

        return _random.Next(x, y + 1);
    }

    public V2 Multiply(V2 multiplyer)
    {
        return new V2(this.x * multiplyer.x, this.y * multiplyer.y);
    }
}