public class Player : Game
{
    // tänne nimi
    public String? Name { get; set; }
    public int PlayerChoice { get; private set; }

    public int ChooseObjectToPlay()
    {
        Console.WriteLine("Valitse mitä pelaat:");

        // Toistetaan looppia kunnes pelaaja on syöttänyt kelvolliset tiedot
        bool choosing = true;
        while (choosing)
        {
            // Kerrotaan mitä mikäkin valinta tarkoittaa
            Console.WriteLine("1. Kivi, 2. Paperi, 3. Sakset ");
            string? input = Console.ReadLine();
            // Jos syötetty arvo on kelvollinen
            if (input == "1" || input == "2" || input == "3")
            {
                // Muutetaan pelaajan valinta intiksi ja vähennetään siitä 1 arraytä varten
                PlayerChoice = int.Parse(input) - 1;
                choosing = false;
            }
            // Jos käyttäjä syöttää jotain virheellistä
            else
            {
                Console.WriteLine("Syötit numeron virheellisesti, kokeile uudelleen!");
                continue;
            }
        }

        // Palautetaan pelaajan valinta
        return PlayerChoice;
    }
}