public class ExchangeStudent : Student
{
    public String? Nationality {get; set; }
    public override string ToString()
        {
            return $"Opiskelijan nimi: {Name}, ikä: {Age}, kansalaisuus: {Nationality} ja koulutusohjelma: {Program}";
        }    
}