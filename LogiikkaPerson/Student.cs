public class Student : Person
{
    // Opiskelijalle ja vaihto-opiskelijalle pitää pystyä antamaan koulutusohjelman tiedot
    public String? Program { get; set; }

    public override string ToString()
    {
        return $"Opiskelijan nimi: {Name}, ikä: {Age} ja koulutusohjelma: {Program}";
    }
}