using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;
using System;
using System.Collections.Generic;

namespace DungeonMaster.Models
{
    [Serializable]
    public class BasicRoom : DungeonObject
    {
        public BasicRoom(V2 position, V2 size) : base(position, size)
        {
        }

        protected override void generateDrawmap()
        {
            _currentDrawmap = new MapObjectType[Size.x, Size.y];
            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    _currentDrawmap[x, y] = MapObjectType.Floor;
                }
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
                _connections.Add(new V2(0, Size.y / 2));
                _connections.Add(new V2(Size.x - 1, Size.y / 2));
                _connections.Add(new V2(Size.x / 2, 0));
                _connections.Add(new V2(Size.x / 2, Size.y - 1));
            }

            return _connections;
        }
    }
}