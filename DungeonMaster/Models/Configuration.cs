namespace DungeonMaster.Models;

[Serializable]
public class Configuration
{
    public int ChunkkSize = 8;
    public V2 RoomSizeVariation = new V2(1, 3);
    public V2 RoomsCountVariation = new V2(20, 20);
    public V2 MapSize = new V2(100, 200);
    public V2 StartPosition = new V2(0, 0);
    public int MaxAttemptsToCreateRoom = 1000;
}