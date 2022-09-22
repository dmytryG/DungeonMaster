namespace DungeonMaster.Models;

[Serializable]
public class BasicPath : DungeonObject
{
    public BasicPath(V2 pointA, V2 pointB)
    {
        
    }

    protected override void generateDrawmap()
    {
        throw new NotImplementedException();
    }
}