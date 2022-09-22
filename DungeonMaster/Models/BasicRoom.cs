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
}