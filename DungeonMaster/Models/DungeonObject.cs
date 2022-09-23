using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Models;

[Serializable]
public abstract class DungeonObject
{
    public V2 Position; // With pivot in upper-left
    public V2 Size;
    protected MapObjectType[,]? _currentDrawmap;

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