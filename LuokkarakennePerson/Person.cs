// Luo abstrakti luokka Person
public abstract class Person
{
    // määritellään abstrakti metodi move
    public abstract void Move();

    // Jäsenmuuttujat name ja age
    public string? Name { get; set; }
    public int Age { get; set; }

    // Luodaan metodi olion tulostamista varten
    public virtual void PersonToString()
    {
        Console.WriteLine($"Olen {Name} ja ikäni on {Age}");
    }

}

// Luodaan luokka adult, määritellään se perimään Person-luokka
public class Adult : Person
{
    // Toteutetaan metodi move niin, että konsoliin tulostetaan tekstiä
    public override void Move()
    {
        Console.WriteLine("Liikkumismuotoni on käveleminen");
    }

    public override void PersonToString()
    {
        Console.WriteLine($"Olen {Name}, ikäni on {Age} ja olen aikuinen.");
    }
}

// Luodaan luokka baby, luokka perii Person-luokan
public class Baby : Person
{
    public override void Move()
    {
        Console.WriteLine("Liikkumismuotoni on konttaaminen");
    }
}