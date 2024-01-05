namespace Eloranta7_2;
class Program
{
    static void Main()
    {
        // Luodaan oliot Triangle ja Box
        Triangle myTriangle = new Triangle();
        Box myBox = new Box();

        // Kutsutaan kummallekin oliolle Draw-metodia
        myTriangle.Draw();
        Console.WriteLine();
        myBox.Draw();
    }
}
