// Luodaan auto (ei tälläkertaa oteta ohjelman käyttäjää mukaan tekemiseen)
Car myCar = new Car();
myCar.Brand = "Volkswagen";
myCar.Model = "Golf";
myCar.Color = "Red";

// Kerrotaan käyttäjälle mitä tapahtuu ja kysellään mitä hän haluaa tehdä
Console.WriteLine($"Olet lähdössä ajamaan autoa " + myCar.PrintCar());
Console.WriteLine("Painamalla jotain näppäintä käynnistät auton");
Console.WriteLine("Kirjoittamalla 'exit' poistut ohjelmasta");
string? input = Console.ReadLine();

// jos käyttäjä ei halua lopettaa ohjelmaa, käynnistetään auto
if (input == "exit")
{
    Console.WriteLine("Kiitos ohjelman käytöstä");
    return;
}
else
{
    myCar.Start();
}

// Toistetaan looppia niin kauan kuin on käynnissä
while (myCar.engineStarted)
{
    // Kerrotaan käyttäjälle nopeus ja mitä loopin sisällä voi tehdä
    Console.WriteLine($"Nopeutesi on: " + myCar.currentSpeed);
    Console.WriteLine("Lisää nopeutta painamalla '+' tai jarruta painamalla '-'");
    Console.WriteLine("Tai aseta nopeus, johon haluat siirtyä syöttämällä se numeroina");
    Console.WriteLine("Voit sammuttaa auton kirjoittamalla 'stop'");
    // Tallennetaan käyttäjän vastaus muuttujaan
    string? andThen = Console.ReadLine();

    // Toiminnallisuutta sen mukaan, mitä käyttäjä haluaa tehdä
    if (andThen == "stop")
    {
        myCar.Stop();
    }

    // Jos käyttäjä haluaa asettaa numeroina, mihin nopeus vaihdetaan
    else if (int.TryParse(andThen, out int speed))
    {
        myCar.MaxSpeed = speed;
        Console.WriteLine($"Haluat siirtyä nopeuteen {myCar.MaxSpeed}? k/e");
        string? wantingToChangeSpeed = Console.ReadLine();

        // Jos halutaan vaihtaa nopeutta ja nykyinen nopeus on pienempi kuin nopeus mihin halutaan siirtyä
        if (wantingToChangeSpeed == "k" && myCar.currentSpeed < myCar.MaxSpeed)
        {
            // Looppi, jossa kiihdytetään niin kauan kunnes haluttu nopeus on saavutettu
            while (myCar.currentSpeed < myCar.MaxSpeed)
            {
                // Jos Käyttäjä on saavuttanut maks nopeuden (kiihdytysmetodissa asetettu 250)
                // nopeus ei enää nouse vaan pysyy samana. Tällöin katkaistaan looppi
                if (myCar.Accelerate(myCar.currentSpeed) == myCar.currentSpeed)
                {
                    break;
                }
                // Kerrotaan käyttäjälle nykyinen nopeus ja lisätään vauhdia
                else
                {
                    Console.WriteLine($"Nykyinen nopeutesi on {myCar.currentSpeed}, kiihdytetään");
                    myCar.currentSpeed = myCar.Accelerate(myCar.currentSpeed);
                }
            }
            continue;
        }
        // Jos halutaan vaihtaa nopeutta ja nykyinen nopeus on suurempi kuin nopeus johon halutaan siirtyä
        else if (wantingToChangeSpeed == "k" && myCar.currentSpeed > myCar.MaxSpeed)
        {
            // Looppi jossa jarrutetaan kunnes saavutetaan haluttu nopeus
            while (myCar.currentSpeed > myCar.MaxSpeed)
            {
                Console.WriteLine($"Nykyinen nopeutesi on {myCar.currentSpeed}, jarrutetaan");
                myCar.currentSpeed = myCar.Brake(myCar.currentSpeed);
            }
            continue;
        }
        else
        {
            continue;
        }

    }
    // Kiihdyttämiseen pykälä kerrallaan
    else if (andThen == "+")
    {
        myCar.currentSpeed = myCar.Accelerate(myCar.currentSpeed);
    }
    // Jarruttamiseen pykälä kerrallaan
    else if (andThen == "-")
    {
        myCar.currentSpeed = myCar.Brake(myCar.currentSpeed);
    }

    else
    {
        continue;
    }
}