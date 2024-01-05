public class Person
{
    // Jokaiselle henkilölle pitää pystyä antamaan nimi ja ikä
    public String? Name { get; set; }
    public int? Age { get; set; }

    public override string ToString()
    {
        return $"Henkilön nimi: {Name}, ikä: {Age}";
    }
}