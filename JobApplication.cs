using System;


public enum ApplicationStatus
{           
    Applied,
    Interview,
    Offer,
    Rejected
}

// Klassen representerar en enskild jobbansökan
public class JobApplication
{   
        // Företagets namn  
    public string CompanyName { get; set; }

    // Positionen du sökt
    public string PositionTitle { get; set; }

    // Aktuellt statusvärde (Applied, Interview, Offer, Rejected)
    public ApplicationStatus Status { get; set; }

    // Datum då ansökan skickades
    public DateTime ApplicationDate { get; set; }

    // Datum då svar mottogs 
    public DateTime? ResponseDate { get; set; }

    // Önskad lön
    public int SalaryExpectation { get; set; }

    // Metod som räknar antal dagar sedan du skickade ansökan
    public int GetDaysSinceApplied()
    {
        return (DateTime.Now - ApplicationDate).Days;
    }

    // Returnerar en kort text om ansökan
    public string GetSummary()
    {
        string responseText = ResponseDate.HasValue ? $"Svar: {ResponseDate.Value.ToShortDateString()}" : "Inget svar ännu";
        return $"{CompanyName} - {PositionTitle} | Status: {Status} | Skickad: {ApplicationDate.ToShortDateString()} | {responseText}";
    }
}
