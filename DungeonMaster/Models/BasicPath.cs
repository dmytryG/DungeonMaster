using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;
using System;

namespace DungeonMaster.Models
{
    [Serializable]
    public class BasicPath : DungeonObject
    {
        protected V2 PointA;
        protected V2 PointB;

        public BasicPath(V2 pointA, V2 pointB)
        {
            this.Position = new V2();

            Position.x = pointA.x <= pointB.x ? pointA.x : pointB.x;
            Position.y = pointA.y <= pointB.y ? pointA.y : pointB.y;

            var farestX = pointA.x > pointB.x ? pointA.x : pointB.x;
            var farestY = pointA.y > pointB.y ? pointA.y : pointB.y;

            Size = new V2(farestX - Position.x + 1, farestY - Position.y + 1);

            PointA = pointA;
            PointB = pointB;
        }

        protected override void generateDrawmap()
        {
            _currentDrawmap = new MapObjectType[Size.x, Size.y];

            if (PointA.y <= PointB.y)
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

            if (PointA.x <= PointB.x)
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
    }
}