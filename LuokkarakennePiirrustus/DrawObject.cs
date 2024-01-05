// Luodaan luokat Draw object, Triangle ja Box
// Draw object on kantaluokka
public abstract class DrawObject
{
    // Luodaan metodi Draw
    public abstract void Draw();
}

public class Triangle : DrawObject
{
    // Toteutetaan metodi tehtävänannon mukaisesti Triangle- ja Box-luokissa
    public override void Draw()
    {
        Console.WriteLine("Triangle-luokan Draw-metodi");
        Console.WriteLine("    *");
        Console.WriteLine("  * * *");
        Console.WriteLine(" * * * *");
        Console.WriteLine("* * * * *");
    }
}

public class Box : DrawObject
{
    public override void Draw()
    {
        Console.WriteLine("Box-luokan Draw-metodi");
        Console.WriteLine("*******");
        Console.WriteLine("*     *");
        Console.WriteLine("*     *");
        Console.WriteLine("*******");
    }
}