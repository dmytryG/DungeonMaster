using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models;

[Serializable]
public class BasicPath : DungeonObject
{
    private V2 _pointA;
    private V2 _pointB;
    
    private V2 _M; // Direction vector
    
    public BasicPath(V2 pointA, V2 pointB)
    {
        this.Size = pointB.Delta(pointA);
        this.Position = new V2();

        if (pointB.x < pointA.x)
            (pointA, pointB) = (pointB, pointA);

        this.Position.x = pointA.x;

        if (pointB.y < pointA.y)
            this.Position.y = pointB.y;
        else
            this.Position.y = pointB.y;

        _pointA = pointA;
        _pointB = pointB;
        
        _M = new V2(pointB.x - pointA.x, pointB.y - pointA.y);
    }

    protected override void generateDrawmap()
    {
        _currentDrawmap = new MapObjectType[Size.x, Size.y];
        float a = _pointB.y - _pointA.y;
        float d = _pointA.x * (_pointA.y - _pointB.y) + _pointA.y * (_pointB.x - _pointA.x);
        float c = _pointB.x - _pointA.x;

        var yPos = (int x) =>
        {
            return (int)((x * a + d)/c);
        };

        for (int x = 0; x < Size.x; x++)
        {
            int y = yPos(x);
            if (IntUtils.IsIntInRange(y, 0, Size.y - 1))
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