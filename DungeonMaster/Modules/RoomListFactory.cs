using DungeonMaster.Models;

namespace DungeonMaster.Modules;

public class RoomListFactory
{
    public static List<BasicRoom> GetRoomsSet(Configuration configuration)
    {
        var roomsToBeGenerated = configuration.RoomsCountVariation.Random();
        List<BasicRoom> result = new List<BasicRoom>();

        for (int i = 0; i < roomsToBeGenerated; i++)
        {
            BasicRoom currentRoom = new BasicRoom(configuration.StartPosition,
                configuration.RoomSizeVariation.Multiply(new V2(configuration.RoomSizeVariation.Random(),
                    configuration.RoomSizeVariation.Random())));
            int attemptNumber = 0;

            while (true)
            {
                bool isCollides = false;
                attemptNumber++;
                // Check whether room collides with all previosely generated
                foreach (var otherRoom in result)
                {
                    if (otherRoom.IsCollides(currentRoom))
                    {
                        isCollides = true;
                        break;
                    }
                }
                if (!isCollides && currentRoom.Position.x + currentRoom.Size.x <= configuration.MapSize.x &&
                    currentRoom.Position.y + currentRoom.Size.y <= configuration.MapSize.y)
                {
                    // If room can be created
                    result.Add(currentRoom);
                    break;
                }
                else
                {
                    // If room can't be created, rebuild it
                    currentRoom.Position = new V2(configuration.MapSize.Random(), configuration.MapSize.Random());
                }

                if (attemptNumber > configuration.MaxAttemptsToCreateRoom)
                {
                    throw new Exception("Can't create room, it's overcrowded");
                }
            }
        }

        return result;
    }
}