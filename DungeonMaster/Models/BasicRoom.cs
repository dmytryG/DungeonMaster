using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models;

[Serializable]
public class BasicRoom: DungeonObject
{
    public BasicRoom(V2 position, V2 size) : base(position, size)
    {
    }

    protected override void generateDrawmap()
    {
        _currentDrawmap = new MapObjectType[Size.x, Size.y];
        for (int x = 1; x < Size.x -1; x++)
        {
            for (int y = 1; y < Size.y -1; y++)
            {
                _currentDrawmap[x, y] = MapObjectType.Floor;
            }
        }

        for (int x = 0; x < Size.x; x++)
        {
            _currentDrawmap[x, 0] = MapObjectType.Wall;
            _currentDrawmap[x, Size.y - 1] = MapObjectType.Wall;
        }

        for (int y = 0; y < Size.y; y++)
        {
            _currentDrawmap[0, y] = MapObjectType.Wall;
            _currentDrawmap[Size.x - 1, y] = MapObjectType.Wall;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType()}: position = {Position.ToString()}\n size = {Size.ToString()}";
    }

    public override bool IsCollides(DungeonObject other)
    {
        for (int x = 0; x < other.Size.x; x++)
        {
            for (int y = 0; y < other.Size.y; y++)
            {
                if (IntUtils.IsIntInRange(other.Position.x + x, Position.x, Position.x + Size.x) &&
                    IntUtils.IsIntInRange(other.Position.y + y, Position.y, Position.y + Size.y))
                {
                    return true;
                }
            }
        }

        return false;
    }


    public override List<V2> GetConnections()
    {
        if (_connections == null)
        {
            _connections = new List<V2>();
            _connections.Add(new V2(0, Size.y/2));
            _connections.Add(new V2(Size.x, Size.y/2));
            _connections.Add(new V2(Size.x / 2, 1));
            _connections.Add(new V2(Size.x / 2, Size.y));
        }

        return _connections;
    }
}