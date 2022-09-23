namespace DungeonMaster.Helpers;

public class RandomInt
{
    protected static Random? _random;

    public static int GetRandom(int x, int y)
    {
        if (_random == null)
        {
            _random = new Random();
        }

        if (x > y)
        {
            (x, y) = (y, x);
        }
        var res = _random.Next(x, y + 1);
        return res;
    }
    
}