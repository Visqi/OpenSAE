// Generated by Haxe 4.3.1

#pragma warning disable 109, 114, 219, 429, 168, 162
public class Std
{
    public static readonly System.Random rand = new System.Random();

    public static int random(int x)
    {
        if (x <= 0)
        {
            return 0;
        }

        return rand.Next(x);
    }
}

