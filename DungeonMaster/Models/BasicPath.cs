﻿using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models;

[Serializable]
public class BasicPath : DungeonObject
{
    private V2 _pointA;
    private V2 _pointB;
    
    public BasicPath(V2 pointA, V2 pointB)
    {
        this.Position = new V2();

        Position.x = pointA.x <= pointB.x ? pointA.x : pointB.x;
        Position.y = pointA.y <= pointB.y ? pointA.y : pointB.y;
        
        var farestX = pointA.x > pointB.x ? pointA.x : pointB.x;
        var farestY = pointA.y > pointB.y ? pointA.y : pointB.y;
        
        Size = new V2(farestX - Position.x + 1, farestY - Position.y + 1);

        _pointA = pointA;
        _pointB = pointB;
    }

    protected override void generateDrawmap()
    {
        _currentDrawmap = new MapObjectType[Size.x, Size.y];

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
    }
    
    // public override bool IsCollides(DungeonObject other)
    // {
    //     var thisDrawmap = GetDrawmap();
    //     var otherDrawmap = other.GetDrawmap();
    //     
    //     for (int x = 0; x < Size.x - 1; x++)
    //     {
    //         for (int y = 0; y < Size.y - 1; y++)
    //         {
    //             int otherRelX = (x + Position.x) - other.Position.x;
    //             int otherRelY = (y + Position.y) - other.Position.y;
    //
    //             if (IntUtils.IsIntInRange(otherRelX, 0, other.Size.x) &&
    //                 IntUtils.IsIntInRange(otherRelY, 0, other.Size.y)
    //                )
    //             {
    //                 if (thisDrawmap[x, y] != MapObjectType.Unknown &&
    //                     otherDrawmap[otherRelX, otherRelY] != MapObjectType.Unknown)
    //                 {
    //                     return true;
    //                 }
    //             }
    //         }
    //     }
    //     return false;
    // }
}