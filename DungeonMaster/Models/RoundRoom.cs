using System.Collections.Generic;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models
{
    public class RoundRoom : BasicRoom
    {
        private V2 _center;
        
        
        public RoundRoom(V2 position, V2 size) : base(position, size)
        {
            _center = new V2(position.x + size.x / 2, position.y + size.y / 2);
        }

        protected override void generateDrawmap()
        {
            _currentDrawmap = new MapObjectType[((DungeonObject)this).Size.x, ((DungeonObject)this).Size.y];
            
            for (int x = Position.x; x < Position.x + Size.x; x++)
            {
                for (int y = Position.y; y < Position.y + Size.y; y++)
                {
                    _currentDrawmap[x - Position.x, y - Position.y] = MapObjectType.Floor;
                    // if (IsPointInRoom(x, y))
                    // {
                    //     
                    // }
                }
            }
        }

        private bool IsPointInRoom(int x, int y)
        {
            return (((x - _center.x) ^ 2 + (y - _center.y) ^ 2) <= ((Size.x / 2) ^ 2));
        }

        public override bool IsCollides(DungeonObject other)
        {
            bool isCollides = false;
            var otherDrawmap = other.GetDrawmap();
            
            for (int oxa = other.Position.x; oxa < other.Position.x + other.Size.x; oxa++)
            {
                for (int oya = other.Position.y; oya < other.Position.y + other.Size.y; oya++)
                {
                    if (otherDrawmap[oxa - other.Position.x, oya - other.Position.y] != MapObjectType.Unknown)
                    {
                        isCollides = isCollides || IsPointInRoom(oxa, oya);
                    }
                }
            }

            return isCollides;
        }

        public override List<V2> GetConnections()
        {
            return new List<V2>(){_center};
        }
    }
}