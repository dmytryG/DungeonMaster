using DungeonMaster.Models;
using DungeonMaster.Models.MapObjects;
using DungeonMaster.Modules;

namespace DungeonMaster
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Master entry point");
            Console.Title = "Processing map...";
            var configuration = new Configuration();
            List<DungeonObject> rooms = RoomListFactory.GetRoomsSet(configuration);
            
            
            
            MapObjectType[,] collectedMap = MapCollectorFactory.GetDrawmap(configuration, rooms);
            MapDebugDrawer.DrawMap(configuration, collectedMap);

            Console.ReadKey();
        }
    }
    
}
