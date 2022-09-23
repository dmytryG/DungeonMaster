namespace DungeonMaster.Models;

[Serializable]
public class BasicRoom: DungeonObject
{
    public BasicRoom(V2 position, V2 size) : base(position, size)
    {
    }

    protected override void generateDrawmap()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{this.GetType()}: position = {Position.ToString()}\n size = {Size.ToString()}";
    }

    public bool IsCollides(BasicRoom other)
    {
        return (IsIntInRange(other.Position.x, Position.x, Position.x + Size.x)
               && IsIntInRange(other.Position.y, Position.y, Position.y + Size.y))
               ||
               (IsIntInRange(other.Position.x + other.Size.x, Position.x, Position.x + Size.x)
               && IsIntInRange(other.Position.y + other.Size.y, Position.y, Position.y + Size.y))
               ||
               (IsIntInRange(other.Position.x + Size.x, Position.x, Position.x + Size.x)
                && IsIntInRange(other.Position.y + Size.y, Position.y, Position.y + Size.y))
               ||
               (IsIntInRange(other.Position.x, Position.x, Position.x + Size.x)
                && IsIntInRange(other.Position.y + Size.y, Position.y, Position.y + Size.y));
    }

    private bool IsIntInRange(int x, int a, int b)
    {
        return x >= a && x <= b;
    }
}