using DungeonMaster.Models;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Modules;

public class MapCollectorFactory
{
    public static MapObjectType[,] GetDrawmap(Configuration configuration, List<DungeonObject> dungeonObjects)
    {
        MapObjectType[,] currentMap = new MapObjectType[configuration.MapSize.x, configuration.MapSize.y];

        foreach (var dungeonObject in dungeonObjects)
        {
            MapObjectType[,] dungeonObjectDrawmap = dungeonObject.GetDrawmap();

            for (int x = 0; x < dungeonObject.Size.x; x++)
            {
                for (int y = 0; y < dungeonObject.Size.y; y++)
                {
                    if (dungeonObjectDrawmap[x, y] != MapObjectType.Unknown)
                        currentMap[x + dungeonObject.Position.x, y + dungeonObject.Position.y] =
                            dungeonObjectDrawmap[x, y];
                }
            }
        }

        return currentMap;
    }

    public static MapObjectType[,] AppendDrawmap(Configuration configuration, MapObjectType[,] currentMap,
        List<DungeonObject> dungeonObjects)
    {
        foreach (var dungeonObject in dungeonObjects)
        {
            MapObjectType[,] dungeonObjectDrawmap = dungeonObject.GetDrawmap();

            for (int x = 0; x < dungeonObject.Size.x; x++)
            {
                for (int y = 0; y < dungeonObject.Size.y; y++)
                {
                    if (x + dungeonObject.Position.x < configuration.MapSize.x &&
                        y + dungeonObject.Position.y < configuration.MapSize.y &&
                        dungeonObjectDrawmap[x, y] != MapObjectType.Unknown)
                        currentMap[x + dungeonObject.Position.x, y + dungeonObject.Position.y] =
                            dungeonObjectDrawmap[x, y];
                }
            }
        }

        return currentMap;
    }
}