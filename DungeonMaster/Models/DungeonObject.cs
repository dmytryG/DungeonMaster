using System;
using System.Collections.Generic;
using DungeonMaster.Helpers;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models
{
    [Serializable]
    public abstract class DungeonObject
    {
        public V2 Position; // With pivot in upper-left
        public V2 Size;
        protected MapObjectType[,]? _currentDrawmap;
        protected List<V2>? _connections;

        public virtual List<V2> GetConnections() // Returns relative positions of corridor connections
        {
            if (_connections == null)
                _connections = new List<V2>();
            return _connections;
        }

        public ref MapObjectType[,] GetDrawmap()
        {
            if (_currentDrawmap == null)
            {
                this.generateDrawmap();
            }

            return ref _currentDrawmap!;
        }

        protected abstract void generateDrawmap();

        protected DungeonObject(V2 position, V2 size)
        {
            this.Position = position;
            this.Size = size;
        }

        protected DungeonObject()
        {
        }

        public override string ToString()
        {
            return $"{this.GetType()}: position = {Position.ToString()}\n size = {Size.ToString()}";
        }

        public virtual bool IsCollides(DungeonObject other)
        {
            var thisDrawmap = GetDrawmap();
            var otherDrawmap = other.GetDrawmap();

            for (int x = 0; x < Size.x; x++)
            {
                for (int y = 0; y < Size.y; y++)
                {
                    int otherRelX = (x + Position.x) - other.Position.x;
                    int otherRelY = (y + Position.y) - other.Position.y;

                    if (IntUtils.IsIntInRange(otherRelX, 0, other.Size.x - 1) &&
                        IntUtils.IsIntInRange(otherRelY, 0, other.Size.y - 1) &&
                        IntUtils.IsIntInRange(x, 0, Size.x) &&
                        IntUtils.IsIntInRange(y, 0, Size.y)
                       )
                    {
                        if (thisDrawmap[x, y] != MapObjectType.Unknown &&
                            otherDrawmap[otherRelX, otherRelY] != MapObjectType.Unknown)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}