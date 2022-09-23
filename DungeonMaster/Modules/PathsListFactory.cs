using DungeonMaster.Helpers;
using DungeonMaster.Models;

namespace DungeonMaster.Modules;

public class PathsListFactory
{
    public static List<DungeonObject> GetRoomsSet(Configuration configuration, List<BasicRoom> rooms)
    {
        List<DungeonObject> paths = new List<DungeonObject>();
        DungeonObject currentRoom = rooms[0];

        for (int i = 1; i < rooms.Count; i++)
        {
            var currentRandomPath = currentRoom.GetConnections()[RandomInt.GetRandom(0, currentRoom.GetConnections().Count - 1)];
            var nextRoom = rooms[i];
            var nextRandomPath = nextRoom.GetConnections()[RandomInt.GetRandom(0, nextRoom.GetConnections().Count - 1)];

            DungeonObject path = new BasicPath(currentRandomPath.Sum(currentRoom.Position) , nextRandomPath.Sum(nextRoom.Position));
            paths.Add(path);

            currentRoom = nextRoom;
        }

        return paths;
    }
}