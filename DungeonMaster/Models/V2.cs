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
}