using DungeonMaster.Helpers;
using DungeonMaster.Models;

namespace DungeonMaster.Modules;

public class PathsListFactory
{
    public static List<DungeonObject> GetPathsSet(Configuration configuration, List<DungeonObject> rooms)
    {
        List<DungeonObject> paths = new List<DungeonObject>();
        List<DungeonObject> alreadyFound = new List<DungeonObject>();

        foreach (var currentRoom in rooms)
        {
            bool isPathFound = false;
            foreach (var anotherRoom in rooms)
            {
                if (currentRoom == anotherRoom || alreadyFound.Contains(anotherRoom))
                    continue;

                foreach (var currentConnection in currentRoom.GetConnections())
                {
                    foreach (var anotherConnection in anotherRoom.GetConnections())
                    {
                        DungeonObject path = new BasicPath(currentConnection.Sum(currentRoom.Position) , anotherConnection.Sum(anotherRoom.Position));

                        foreach (var isCollidesWithRoom in rooms)
                        {
                            if (path.IsCollides(isCollidesWithRoom))
                            {
                                Console.WriteLine("Collides");
                                continue;
                            }
                        }
                        paths.Add(path);
                        alreadyFound.Add(currentRoom);
                        isPathFound = true;
                        break;
                    }
                    if (isPathFound)
                        break;
                }
                if (isPathFound)
                    break;
            }
        }

        return paths;
    }
}