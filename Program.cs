using System;



// huvudprogram
class Program
{
    static void Main()
    {
        JobManager manager = new JobManager();
        bool running = true;

        while (running)
        {
            //meny
            Console.WriteLine("\nJob Application Tracker");
            Console.WriteLine("1️.Lägg till ny ansökan");
            Console.WriteLine("2️.Visa alla ansökningar");
            Console.WriteLine("3️.Filtrera efter status");
            Console.WriteLine("4️.Sortera efter datum");
            Console.WriteLine("5️.Visa statistik");
            Console.WriteLine("6️.Uppdatera status");
            Console.WriteLine("7️.Ta bort ansökan");
            Console.WriteLine("0️.Avsluta");
            Console.Write("Välj ett alternativ: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddJob();
                    break;
                case "2":
                    manager.ShowAll();
                    break;
                case "3":
                    manager.ShowByStatus();
                    break;
                case "4":
                    manager.SortByDate();
                    break;
                case "5":
                    manager.ShowStatistics();
                    break;
                case "6":
                    manager.UpdateStatus();
                    break;
                case "7":
                    manager.RemoveJob();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Programmet avslutas...");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen!");
                    break;
            }
        }
    }
}