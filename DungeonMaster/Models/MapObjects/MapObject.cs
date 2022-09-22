namespace DungeonMaster.Models.MapObjects;

[Serializable]
public class MapObject
{
    private MapObjectType type;
    
    public MapObjectType Type
    {
        set => type = value;
        get => type;
    }

    public MapObject()
    {
        type = MapObjectType.Unknown;
    }

    public override string ToString()
    {
        return $"MapObject: {this.GetType()}, type = {type.ToString()}";
    }
}