using DungeonMaster.Models;
using DungeonMaster.Models.MapObjects;

namespace DungeonMaster.Modules;

public class MapDebugDrawer
{
    public static void DrawMap(Configuration configuration, MapObjectType[,] map)
    {
        for (int x = 0; x < configuration.MapSize.x; x++)
        {
            for (int y = 0; y < configuration.MapSize.y; y++)
            {
                // Draw some map
                switch (map[x, y])
                {
                    case MapObjectType.Unknown:
                        Console.Write(" ");
                        break;
                    case MapObjectType.Floor:
                        Console.Write("▓");
                        break;
                    case MapObjectType.Wall:
                        Console.Write("░");
                        break;
                }
            }
            Console.Write("\n");
        }
    }
}