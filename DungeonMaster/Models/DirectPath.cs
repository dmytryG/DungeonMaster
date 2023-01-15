using System;
using System.Collections.Generic;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models
{
    public class DirectPath : BasicPath
    {
        public DirectPath(V2 pointA, V2 pointB) : base(pointA, pointB)
        {
            Size = new V2(Math.Abs(pointA.x - pointB.x), Math.Abs(pointA.y - pointB.y));
        }

        protected override void generateDrawmap()
        {
            _currentDrawmap = new MapObjectType[Size.x + 5, Size.y + 5];
            
            bool checkLastY = false;
            int lastY = 0;
            for (int x = 0; x < Size.x; x++)
            {
                
                
                int y = ((x + Position.x - PointB.x) * (PointA.y - PointB.y)) / (PointA.x - PointB.x) + PointB.y;
                
                // Main line
                _currentDrawmap[x, y - Position.y] = MapObjectType.Floor;
                // Top line
                _currentDrawmap[x, y - Position.y + 1] = MapObjectType.Floor;

                if (checkLastY)
                {
                    if (Math.Abs((y - Position.y) - lastY) > 0)
                    {
                        Console.Out.WriteLine("Have to fix this line");
                        int ytmp = y - Position.y;
                        while (Math.Abs(ytmp - lastY) > 0)
                        {
                            ytmp -= Math.Sign(ytmp - lastY);
                            _currentDrawmap[x, ytmp] = MapObjectType.Floor;
                        }
                    }
                }

                checkLastY = true;
                lastY = y - Position.y;
            }
        }
    }
}