namespace DungeonMaster.Models;

[Serializable]
public class BasicPath : DungeonObject
{
    public BasicPath(V2 pointA, V2 pointB)
    {
        this.Size = pointB.Delta(pointA);
        this.Position = pointA;
        
    }

    protected override void generateDrawmap()
    {
        throw new NotImplementedException();
    }

    public override bool IsCollides(DungeonObject other)
    {
        return false;
    }
}