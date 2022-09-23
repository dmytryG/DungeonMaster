using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models;

[Serializable]
public abstract class DungeonObject
{
    public V2 Position; // With pivot in upper-left
    public V2 Size;
    protected MapObjectType[,]? _currentDrawmap;
    protected List<V2>? _connections;

    public List<V2> GetConnections() // Returns relative positions of corridor connections
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

    public abstract bool IsCollides(DungeonObject other);
}