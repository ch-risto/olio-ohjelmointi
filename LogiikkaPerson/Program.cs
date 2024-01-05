using System.Net.NetworkInformation;

namespace Eloranta5_2;
class Program
{
    static void Main()
    {
        // Luodaan opiskelija, vaihto-opiskelija ja opettaja ja lisätään niille tietoja
        Student student = new Student();
        student.Name = "Oili Opiskelija";
        student.Age = 32;
        student.Program = "Tieto- ja viestintätekniikka";

        ExchangeStudent exchangestudent = new ExchangeStudent();
        exchangestudent.Name = "Maija Mallioppilas";
        exchangestudent.Age = 28;
        exchangestudent.Program = "Teollinen muotoilu";
        exchangestudent.Nationality = "French";

        Teacher teacher = new Teacher();
        teacher.Name = "Teuvo Tuntiopettaja";
        teacher.Age = 48;
        teacher.Wage = 3800;

        // Tulostetaan konsoliion olioihin tallennetut tiedot
        Console.WriteLine(student.ToString());
        Console.WriteLine(exchangestudent.ToString());
        Console.WriteLine(teacher.ToString());
    }
}