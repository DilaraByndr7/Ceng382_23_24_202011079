public class Reservation
{
   
    public int Id { get; set; } 
  
    public string? ReserverName { get; set; }

    public Room? Room { get; set; }  

    public DateTime Date { get; set; }
}