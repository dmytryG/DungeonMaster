namespace DungeonMaster.Models;

[Serializable]
public class Configuration
{
    public int ChunkkSize = 8;
    public V2 RoomSizeVariation = new V2(1, 4);
    public V2 RoomsCountVariation = new V2(200, 400);
    public V2 MapSize = new V2(2000, 4000);
    public V2 StartPosition = new V2(0, 0);
    public int MaxAttemptsToCreateRoom = 1000;
    public bool DebugLog = true;
}