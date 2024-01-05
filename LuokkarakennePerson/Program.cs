namespace Eloranta7_1;
class Program
{
    static void Main()
    {
        // Luodaan yksi aikuinen ja yksi vauva olio
        Baby myBaby = new Baby();
        Adult myAdult = new Adult();

        // Lisätään olioille tietoja
        myBaby.Name = "Veeti Vauveli";
        myBaby.Age = 1;

        myAdult.Name = "Assi Aikuinen";
        myAdult.Age = 43;

        // Tulostetaan oliot ja kutsutaan niiden Move()-metodia
        myBaby.PersonToString();
        myBaby.Move();
        Console.WriteLine();
        myAdult.PersonToString();
        myAdult.Move();
    }
}
