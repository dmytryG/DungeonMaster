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
}