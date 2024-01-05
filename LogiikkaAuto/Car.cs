using System.Dynamic;
using System.Net;

public class Car
{
    // auton luominen
    public String? Brand { get; set; }
    public String? Model { get; set; }
    public String? Color { get; set; }

    // nykyinen nopeus
    private int CurrentSpeed;
    // maksiminopeus, mihin käyttäjä haluaa siirtyä
    public int MaxSpeed { get; set; }
    // onko auto käynnissä
    private bool Running = false;
    // onko tankissa bensaa
    private bool FuelInTank = true;
    // ovatko ovet lukossa
    private bool DoorLocked = true;

    public int currentSpeed
    {
        get
        {
            return CurrentSpeed;
        }
        set
        {
            CurrentSpeed = value;
        }
    }

    public bool engineStarted
    {
        get
        {
            return Running;
        }
        set
        {
            Running = value;
        }
    }

    // käynnistää auton
    public void Start()
    {
        // Tarkistetaan onko bensaa, ja ovatko ovet auki
        if (CheckFuel() && !LockDoor)
        {
            // Käynnistetään auto
            Running = true;
            Console.WriteLine("Auto on käynnissä");
        }
        // Jos on bensaa, mutta ovet ovat lukossa
        else if (CheckFuel() && LockDoor)
        {
            Console.WriteLine("Sinulla on bensaa, mutta ovet ovat lukossa");
            Console.WriteLine("Avataanko ovet? k/e");
            string? openDoors = Console.ReadLine();
            // avataan ovet
            if (openDoors == "k")
            {
                LockDoor = false;
                Start();
            }
            else
            {
                Console.WriteLine("Kiitos ohjelman käytöstä");
            }
        }
        // jos ei ole bensaa
        else
        {
            Console.WriteLine("Bensa loppu, et voi käynnistää autoa");
            Console.WriteLine("Kiitos ohjelman käytöstä");
        }
    }

    // Metodi auton sammuttamiseen
    public void Stop()
    {
        Console.WriteLine("Pysäytit auton");
        Running = false;


        // lukitaanko ovet
        Console.WriteLine("Haluatko lukita ovet? k/e");
        string? input = Console.ReadLine();

        if (input == "k")
        {
            LockDoor = true;
            Console.WriteLine("Lukitsit ovet");
        }

        Console.WriteLine("Kiitos ohjelman käytöstä");
    }

    // Metodi bensan tarkistamiseen
    private bool CheckFuel()
    {
        return FuelInTank;
    }

    // Tarkistetaan onko ovet lukossa/ asetetaan arvo sille ovatko ovet lukossa
    public bool LockDoor
    {
        get
        {
            return DoorLocked;
        }
        set
        {
            DoorLocked = value;
        }
    }

    // Metodi auton kiihdyttämiseen
    public int Accelerate(int CurrentSpeed)
    {
        // kiihdyttää autoa
        // Googlaamalla sovittu auton maksiminopeus on 250, ei anneta kiihdyttää sen yli
        if (CurrentSpeed > 245)
        {
            Console.WriteLine("Olet saavuttanut maksiminopeuden");
            return CurrentSpeed;
        }
        else
        {
            CurrentSpeed += 5;
            return CurrentSpeed;
        }
    }

    // Metodi auton jarruttamiseen
    public int Brake(int CurrentSpeed)
    {
        // jarruttaa autoa
        if (CurrentSpeed > 5)
        {
            return CurrentSpeed - 5;
        }
        else
        {
            return 0;
        }
    }

    public string? PrintCar()
    {
        // tulostaa luokan jäsenmuuttujien arvot helpottamaan debuggausta
        return "Merkki: " + Brand + " - Malli: " + Model + ", Väri: " + Color;
    }
}