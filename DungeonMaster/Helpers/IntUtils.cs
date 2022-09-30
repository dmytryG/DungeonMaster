namespace DungeonMaster.Helpers;

public class IntUtils
{
    public static bool IsIntInRange(int x, int a, int b)
    {
        if (a > b)
            (a, b) = (b, a);
        
        var res = x >= a && x <= b;
        return res;
    }
}