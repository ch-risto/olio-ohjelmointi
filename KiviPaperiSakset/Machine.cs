public class Machine : Game
{
    Random random = new Random();

    // Arvotaan random 1-3    
    public int MachineChoice()
    {
        return random.Next(0, 3);
    }
}