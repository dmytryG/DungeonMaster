namespace DungeonMaster.Models.MapObjects;

[Serializable]
public class MapObject
{
    private MapObjectType _type;
    
    public MapObjectType Type
    {
        set => _type = value;
        get => _type;
    }

    public MapObject()
    {
        _type = MapObjectType.Unknown;
    }

    public override string ToString()
    {
        return $"MapObject: {this.GetType()}, type = {_type.ToString()}";
    }
}