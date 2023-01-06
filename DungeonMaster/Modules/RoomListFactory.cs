using System;
using System.Collections.Generic;
using DungeonMaster.Models;

namespace DungeonMaster.Modules
{
    public class RoomListFactory
    {
        public static List<DungeonObject> GetRoomsSet(Configuration configuration)
        {
            var roomsToBeGenerated = configuration.RoomsCountVariation.Random();
            List<DungeonObject> result = new List<DungeonObject>();

            for (int i = 0; i < roomsToBeGenerated; i++)
            {
                BasicRoom currentRoom = new BasicRoom(configuration.StartPosition,
                    new V2(configuration.RoomSizeVariation.Random() * configuration.ChunkkSize,
                        configuration.RoomSizeVariation.Random() * configuration.ChunkkSize));

                V2 roomMaxPosition = new V2(configuration.MapSize.x - currentRoom.Size.x - 1,
                    configuration.MapSize.y - currentRoom.Size.y - 1);

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

                    if (!isCollides)
                    {
                        // If room can be created
                        result.Add(currentRoom);
                        break;
                    }
                    else
                    {
                        // If room can't be created, rebuild it
                        currentRoom.Position = roomMaxPosition.RandomInVector();
                    }

                    if (attemptNumber % 50 == 0 && configuration.DebugLog)
                    {
                        Console.WriteLine($"Room generation failed with attemp {attemptNumber}. Trying again...");
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
}