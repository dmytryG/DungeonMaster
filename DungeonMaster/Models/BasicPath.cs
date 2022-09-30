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
        this.Size = pointB.Delta(pointA);
        
        this.Position = new V2();

        if (pointB.x < pointA.x)
            (pointA, pointB) = (pointB, pointA);
        
        this.Position.x = pointA.x;

        if (pointB.y < pointA.y)
        {
            this.Position.y = pointB.y;
        }
        else
        {
            this.Position.y = pointA.y;
        }

        _pointA = pointA;
        _pointB = pointB;
    }

    protected override void generateDrawmap()
    {
        _currentDrawmap = new MapObjectType[Size.x, Size.y];
        float k = (float)(_pointB.y - _pointA.y) / (_pointB.x - _pointA.x);

        var yPos = (int x) =>
        {
            return (int)(x * k);
        };

        for (int x = 0; x < Size.x; x++)
        {
            int y = yPos(x);
            if (IntUtils.IsIntInRange(y, 0, Size.y))
            {
                if (x == 0)
                    _currentDrawmap[x, y] = MapObjectType.MapPointA;
                else if (x == Size.x - 1)
                    _currentDrawmap[x, y] = MapObjectType.MapPointB;
                else
                    _currentDrawmap[x, y] = MapObjectType.Floor;
            }
        }
    }

    public override bool IsCollides(DungeonObject other)
    {
        return false;
    }
}