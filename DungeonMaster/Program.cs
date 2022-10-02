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
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            var configuration = new Configuration();
            
            if(configuration.DebugLog)
                Console.WriteLine("Started room generator...");
            
            List<DungeonObject> rooms = RoomListFactory.GetRoomsSet(configuration);
            
            if(configuration.DebugLog)
                Console.WriteLine("Started room collector...");
            
            MapObjectType[,] collectedMap = MapCollectorFactory.GetDrawmap(configuration, rooms);
            
            if(configuration.DebugLog)
                Console.WriteLine("Started path generator...");
            
            List<DungeonObject> paths = PathsListFactory.GetPathsSet(configuration, rooms);
            
            if(configuration.DebugLog)
                Console.WriteLine("Applying paths to the map...");

            collectedMap = MapCollectorFactory.AppendDrawmap(configuration, collectedMap, paths);
            
            if(configuration.DebugLog)
                Console.WriteLine("Drawing map...");

            if(configuration.DebugLog)
                MapDebugDrawer.DrawMap(configuration, collectedMap);
            
            watch.Stop();
            
            Console.WriteLine($"Dungeon completed in {watch.ElapsedMilliseconds} milliseconds");


            // Console.ReadKey();
        }
    }
    
}
