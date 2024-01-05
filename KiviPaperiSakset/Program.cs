namespace Eloranta5_3;
class Program
{
    static void Main()
    {
        // Luodaan objektit
        Machine myMachine = new Machine();
        Player myPlayer = new Player();
        Game myGame = new Game();

        // Kysytään käyttäjän nimi
        Console.WriteLine("Anna nimesi:");
        myPlayer.Name = Console.ReadLine();

        // Kivi-paperi-sakset -peli
        // Tervehditään pelaajaa ja kerrotaan mikä homma
        Console.WriteLine($"Hei {myPlayer.Name}, tervetuloa pelaamaan Kivi-Paperi-Sakset -peliä");

        // Annetaan valita monestako voitosta pelataan - jos ei valitse mitään tai syötä kunnollista numeroa,
        // oletus on kolme
        Console.WriteLine("Kuinka monesta voitosta haluat pelata?");
        string? input = Console.ReadLine();
        int value;
        if (int.TryParse(input, out value))
        {
            myGame.HowManyWins = value;
            Console.WriteLine($"Kiitos valinnasta, pelaatte {myGame.HowManyWins}sta voitosta");
        }
        else
        {
            Console.WriteLine($"Pelaatte {myGame.HowManyWins}:sta voitosta");
        }

        // Kerrotaan säännöt
        Console.WriteLine("Pelissä Kivi voittaa Sakset, Sakset voittaa Paperin ja Paperi voittaa Kiven");
        Console.WriteLine($"Ensimmäisenä {myGame.HowManyWins} voittoa saanut pelaaja voittaa");

        // Looppi
        // While looppi, jota pelataan niin kauan kunnes kolme voittoa on selvillä
        while (myGame.LetsPlay)
        {
            // Ehto siihen milloin peli lopetetaan
            if (myGame.WinsComputer == myGame.HowManyWins || myGame.WinsPlayer == myGame.HowManyWins)
            {
                // Julistetaan voittaja!
                if (myGame.WinsComputer > myGame.WinsPlayer)
                {
                    Console.WriteLine($"Tietokone voitti");
                }
                else
                {
                    Console.WriteLine($"Sinä voitit");
                    Console.WriteLine($"ONNEKSI OLKOON {myPlayer.Name}!");
                }

                // Annetaan käyttäjälle mahdollisuus valita haluaako hän pelata uudelleen
                Console.WriteLine("Haluatko pelata uudelleen? k/e");
                input = Console.ReadLine();
                if (input == "k")
                {
                    myGame.Restart();
                }
                else
                {
                    myGame.LetsPlay = false;
                }
            }

            // Pelin logiikka
            else
            {
                // Tallennetaan pelaajan ja koneen valinnat
                int myPlayerChoice = myPlayer.ChooseObjectToPlay();
                int myMachineChoice = myMachine.MachineChoice();

                // Kerrotaan valinta
                Console.WriteLine($"Sinä valitsit {myGame.GameObject[myPlayer.PlayerChoice]}");
                Console.WriteLine($"Tietokone pelaa {myGame.GameObject[myMachineChoice]}");

                // *** Logiikka ***
                // if ( myMachinepelaa == pelaajanvalinta ) -> tasapeli
                if (myPlayerChoice == myMachineChoice)
                {
                    Console.WriteLine("Tasapeli");
                }
                // else if ( myMachinepelaa == 0 && pelaajanvalinta == 1 ) -> pelaaja voittaa
                // else if ( myMachinepelaa == 0 && pelaajanvalita == 2 ) -> myMachine voittaa
                // else if ( myMachinepelaa == 1 && pelaajanvalinta == 0 ) -> myMachine voittaa
                // else if ( myMachinepelaa == 1 && pelaajanvalinta == 2 ) -> pelaaja voittaa
                // else if ( myMachinepelaa == 2 && pelaajanvalinta == 0 ) -> pelaaja voittaa
                // else if ( myMachinepelaa == 2 && pelaajanvalinta == 1 ) -> myMachine voittaa
                else if (myMachineChoice == 0 && myPlayerChoice == 2
                        || myMachineChoice == 1 && myPlayerChoice == 0
                        || myMachineChoice == 2 && myPlayerChoice == 1)
                {
                    Console.WriteLine("Tietokone voittaa!");
                    myGame.MachineWins();
                }
                else if (myMachineChoice == 0 && myPlayerChoice == 1
                        || myMachineChoice == 1 && myPlayerChoice == 2
                        || myMachineChoice == 2 && myPlayerChoice == 0)
                {
                    Console.WriteLine("Sinä voitit!");
                    myGame.PlayerWins();
                }
                else
                {
                    Console.WriteLine("Tapahtui virhe");
                }

                Console.WriteLine();
                Console.WriteLine($"Tilanne on {myGame.WinsPlayer} - {myGame.WinsComputer}");
            }
        }


    }
}
