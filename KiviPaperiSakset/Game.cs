public class Game
{
    // Tänne voi luoda muuttujan kierrosvoittojen muistissa pitämiselle
    // Ehkä myös kivi-paperi-sakset "muuttujat"
    public int WinsComputer { get; private set; }
    public int WinsPlayer { get; private set; }
    public bool LetsPlay = true;
    // Annetaan käyttäjän valita monestako pelistä pelataan, jos ei muuta arvoa, oletus on 3
    public int HowManyWins = 3;
    // tallennetaan pelissä käytettävät "objektit", pelivälineet taulukkoon.
    // sitä ei tarvitse myöhemmmin muuttaa ja asioita on helppo käydä läpi indeksin avulla
    public string[] GameObject = new string[] { "Kivi", "Paperi", "Sakset" };

    // metodit mitä tapahtuu kun
    // konevoittaa()
    public int MachineWins()
    {
        WinsComputer++;
        return WinsComputer;
    }

    // pelaajavoittaa()
    public int PlayerWins()
    {
        WinsPlayer++;
        return WinsPlayer;
    }

    // Nollataan voitot, jos pelaaja haluaa pelata uudelleen
    public void Restart()
    {
        WinsComputer = 0;
        WinsPlayer = 0;
    }

}