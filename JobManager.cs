using System;
using System.Collections.Generic;
using System.Linq;

// Klassen ansvarar för logik och hantering av flera jobbansökningar
public class JobManager
{
    // Lista som lagrar alla jobbansökningar
    public List<JobApplication> Applications { get; private set; }

    // initierar listan när klassen skapas
    public JobManager()
    {
        
        Applications = new List<JobApplication>();
    }

    // Lägger till en ny ansökan genom användarinmatning
    public void AddJob()
    {
        Console.WriteLine("Ange företagsnamn:");
        string company = Console.ReadLine();

        Console.WriteLine("Ange positionstitel:");
        string position = Console.ReadLine();

        Console.WriteLine("Ange önskad lön (kr):");
        int salary = int.Parse(Console.ReadLine());

        // Skapar nytt JobApplication-objekt
        JobApplication job = new JobApplication
        {
            CompanyName = company,
            PositionTitle = position,
            SalaryExpectation = salary,
            Status = ApplicationStatus.Applied,
            ApplicationDate = DateTime.Now
        };

        // Lägger till i listan
        Applications.Add(job);
        Console.WriteLine("Ansökan är tillagd!");
    }

    // Uppdaterar status för en vald ansökan
    public void UpdateStatus()
    {
        ShowAll();

        Console.WriteLine("\nAnge nummer för ansökan att uppdatera:");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < Applications.Count)
        {
            Console.WriteLine("Välj ny status (0=Applied, 1=Interview, 2=Offer, 3=Rejected):");
            if (Enum.TryParse(Console.ReadLine(), out ApplicationStatus newStatus))
            {
                Applications[index].Status = newStatus;
                Console.WriteLine("Status uppdaterad!");
            }
            else
            {
                Console.WriteLine("Ogiltigt statusval!");
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt index!");
        }
    }

    // Tar bort en ansökan
    public void RemoveJob()
    {
        ShowAll();

        Console.WriteLine("\nAnge nummer för ansökan att ta bort:");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < Applications.Count)
        {
            Applications.RemoveAt(index);
            Console.WriteLine("Ansökan borttagen!");
        }
        else
        {
            Console.WriteLine("Ogiltigt index!");
        }
    }

    // Visar alla ansökningar
    public void ShowAll()
    {
        Console.WriteLine("\n Alla ansökningar:");
        if (Applications.Count == 0)
        {
            Console.WriteLine("Inga ansökningar registrerade ännu.");
            return;
        }

        for (int i = 0; i < Applications.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Applications[i].GetSummary()}");
        }
    }

    // Filtrera ansökningar efter status med hjälp av LINQ
    public void ShowByStatus()
    {
        Console.WriteLine("Välj status att filtrera (0=Applied, 1=Interview, 2=Offer, 3=Rejected):");
        if (Enum.TryParse(Console.ReadLine(), out ApplicationStatus status))
        {
            // LINQ Where-filter
            var filtered = Applications.Where(a => a.Status == status);

            Console.WriteLine($"\nAnsökningar med status {status}:");
            foreach (var app in filtered)
            {
                Console.WriteLine(app.GetSummary());
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt statusval!");
        }
    }

    // Sorterar ansökningar efter datum
    public void SortByDate()
    {
        var ordered = Applications.OrderBy(a => a.ApplicationDate);

        Console.WriteLine("\nAnsökningar sorterade efter datum:");
        foreach (var app in ordered)
        {
            Console.WriteLine(app.GetSummary());
        }
    }

    //Statistik sorterad med LINQ
    public void ShowStatistics()
    {
        Console.WriteLine("\nStatistik:");

        int total = Applications.Count;
        Console.WriteLine($"Totalt antal ansökningar: {total}");

        // Antal per status (LINQ GroupBy)
        var byStatus = Applications
            .GroupBy(a => a.Status)
            .Select(g => new { Status = g.Key, Count = g.Count() });

        Console.WriteLine("\nAntal per status:");
        foreach (var group in byStatus)
        {
            Console.WriteLine($"{group.Status}: {group.Count}");
        }

        // Genomsnittlig svarstid
        var avgResponse = Applications
            .Where(a => a.ResponseDate != null)
            .Average(a => (a.ResponseDate - a.ApplicationDate)?.TotalDays);

        Console.WriteLine($"\nGenomsnittlig svarstid: {avgResponse:F1} dagar");
    }
}
