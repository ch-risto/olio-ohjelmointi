public class Teacher : Person
{
    // Opettajalle pitää pystyä antamaan palkkatiedot
    // Palkkaluokka? kuukausipalkka? 
    public int Wage { get; set; }

    public override string ToString()
    {
        return $"Opettajan nimi: {Name}, ikä: {Age} ja palkka: {Wage}";
    }
}