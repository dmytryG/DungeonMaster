using System.Collections.Generic;
using DungeonMaster.Helpers;
using DungeonMaster.Models;

namespace DungeonMaster.Modules
{
    public class DirectPathsListFactory
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
                    if (currentRoom == anotherRoom || alreadyFound.Contains(anotherRoom) ||
                        alreadyFound.Contains(currentRoom))
                        continue;

                    foreach (var currentConnection in currentRoom.GetConnections())
                    {
                        foreach (var anotherConnection in anotherRoom.GetConnections())
                        {
                            bool isPathFailed = false;
                            DungeonObject path = new DirectPath(currentConnection.Sum(currentRoom.Position),
                                anotherConnection.Sum(anotherRoom.Position));

                            foreach (var isCollidesWithRoom in rooms)
                            {
                                if (path.IsCollides(isCollidesWithRoom))
                                {
                                    break;
                                }
                            }

                            if (isPathFailed)
                                break;

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
}