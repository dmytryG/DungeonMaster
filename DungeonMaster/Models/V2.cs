using DungeonMaster.Helpers;

namespace DungeonMaster.Models;

[Serializable]
public class V2
{
    public int x;
    public int y;

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
        return RandomInt.GetRandom(x, y);
    }

    public V2 RandomInVector(int offset = 0)
    {
        return new V2(RandomInt.GetRandom(offset, x), RandomInt.GetRandom(offset, y));
    }

    public V2 Multiply(V2 multiplyer)
    {
        return new V2(this.x * multiplyer.x, this.y * multiplyer.y);
    }
    
    public V2 Multiply(int multiplyer)
    {
        return new V2(this.x * multiplyer, this.y * multiplyer);
    }

    public V2 Sum(V2 other)
    {
        return new V2(this.x + other.x, this.y + other.y);
    }
    
    public V2 Delta(V2 other)
    {
        return new V2(Math.Abs(this.x - other.x), Math.Abs(this.y - other.y));
    }

    public bool Equals(V2? obj)
    {
        if (obj == null)
            return false;
        else if (this == obj)
            return true;
        else if (x == obj.x && y == obj.y)
            return true;
        return false;
    }
}