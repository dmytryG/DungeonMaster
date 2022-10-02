using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models;

[Serializable]
public class BasicPath : DungeonObject
{
    private V2 _pointA;
    private V2 _pointB;
    
    public BasicPath(V2 pointA, V2 pointB)
    {
        // this.Size = pointB.Delta(pointA);

        this.Position = new V2();

        Position.x = pointA.x <= pointB.x ? pointA.x : pointB.x;
        Position.y = pointA.y <= pointB.y ? pointA.y : pointB.y;
        
        var farestX = pointA.x > pointB.x ? pointA.x : pointB.x;
        var farestY = pointA.y > pointB.y ? pointA.y : pointB.y;

        // Position.x--;
        // Position.y--;
        Size = new V2(farestX - Position.x + 1, farestY - Position.y + 1);

        _pointA = pointA;
        _pointB = pointB;
    }

    protected override void generateDrawmap()
    {
        _currentDrawmap = new MapObjectType[Size.x, Size.y];
        Console.WriteLine($"Size: {Size}");

        if (_pointA.y <= _pointB.y)
        {
            for (int x = 0; x < Size.x; x++)
            {
                _currentDrawmap[x, 0] = MapObjectType.Floor;
            }
        }
        else
        {
            for (int x = 0; x < Size.x; x++)
            {
                _currentDrawmap[x, Size.y - 1] = MapObjectType.Floor;
            }
        }

        if (_pointA.x <= _pointB.x)
        {
            for (int y = 0; y < Size.y; y++)
            {
                _currentDrawmap[Size.x - 1, y] = MapObjectType.Floor;
            }
        }
        else
        {
            for (int y = 0; y < Size.y; y++)
            {
                _currentDrawmap[0, y] = MapObjectType.Floor;
            }
        }

        //
        // _currentDrawmap[0, 0] = MapObjectType.MapPointA;
        // _currentDrawmap[Size.x - 1, Size.y - 1] = MapObjectType.MapPointB;
        
        
        // int xMoveK = _pointA.x < _pointB.x ? 1 : -1;
        // int yMoveK = _pointA.y < _pointB.y ? 1 : -1;
        //
        // int localX = _pointA.x - _pointA.x;
        // int localY = _pointA.y - _pointA.y <= _pointB.y ? _pointA.y : _pointB.y;

    }

    public override bool IsCollides(DungeonObject other)
    {
        return false;
    }
}