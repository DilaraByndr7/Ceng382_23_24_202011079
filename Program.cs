

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[]? Rooms {get; set;}
}


public class Room
{
    [JsonPropertyName("roomId")]
    public string? roomId{get; set;}

    [JsonPropertyName("roomName")]
    public string? roomName{get; set;}

    [JsonPropertyName("capacity")]
    public int? capacity{get; set;}
}

class Reservation
{
    public string? reserverName;
    public Room? room;
    public DateTime date;
}

class ReservationHandler
{
    private Reservation[,]? reservations = new Reservation[10,7]; 

    // public ReservationHandler()
    // {
    //     reservations = new Reservation[10,7];
    // }

    int row=0, column=0;
   

    public void addReservation(Reservation? rsv)
    {
        if(rsv!=null) 
        {
            if (rsv.date.DayOfWeek == DayOfWeek.Monday)
            {
                column = 0;
            }
            else if (rsv.date.DayOfWeek == DayOfWeek.Tuesday)
            {
                column = 1;
            }
            else if (rsv.date.DayOfWeek == DayOfWeek.Wednesday)
            {
                column = 2;
            }
            else if (rsv.date.DayOfWeek == DayOfWeek.Thursday)
            {
                column = 3;
            }
            else if (rsv.date.DayOfWeek == DayOfWeek.Friday)
            {
                column = 4;
            }
            else if (rsv.date.DayOfWeek == DayOfWeek.Saturday)
            {
                column = 5;
            }
            else if (rsv.date.DayOfWeek == DayOfWeek.Sunday)
            {
                column = 6;
            }


           if (rsv.date.Hour == 8)
            {
                row = 0;
            }
            else if (rsv.date.Hour == 9)
            {
                row = 1;
            }
            else if (rsv.date.Hour == 10)
            {
                row = 2;
            }
            else if (rsv.date.Hour == 11)
            {
                row = 3;
            }
            else if (rsv.date.Hour == 12)
            {
                row = 4;
            }
            else if (rsv.date.Hour == 13)
            {
                row = 5;
            }
            else if (rsv.date.Hour == 14)
            {
                row = 6;
            }
            else if (rsv.date.Hour == 15)
            {
                row = 7;
            }
            else if (rsv.date.Hour == 16)
            {
                row = 8;
            }
            else if (rsv.date.Hour == 17)
            {
                row = 9;
            }


            
            
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            reservations[row,column] = rsv; //zaten ilk çağırılan addReservation için boş olmalı
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }

    }

    public void deleteReservation(Reservation rsv)
    {
        if(reservations != null)
        {
            for(int i = 0 ; i<10 ; i++)
            {
                for(int j = 0 ; j<7 ; j++)
                {
                    if( reservations[i,j] == rsv)
                    {
                        reservations[i,j] = null;
                    }
                }
            }     
        }
       
    }

    public void displayWeeklySchedule()
    {   
        int space = 18;
        string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        // Gün başlıklarını yazdır
        Console.Write("".PadRight(space + 5));
        foreach (string day in daysOfWeek)
        {
            Console.Write(day.PadRight(space));
        }
        Console.WriteLine();

        // Saatler ve rezervasyonları yazdır
        for (int i = 0; i < 10; i++)
        {
            string hour = (i + 8).ToString().PadLeft(2) + ".00";

            Console.Write(hour + "".PadRight(space));
            
            for (int k = 0; k < 7; k++)
            {
                if (reservations?[i, k] != null)
                {
                    string resInfo = $"{reservations[i, k].reserverName}, {reservations[i, k].room?.roomId}, {reservations[i, k].room?.roomName}";
                    Console.Write(resInfo.PadRight(space));
                }
                else
                {
                    Console.Write("- ".PadRight(space));
                }
            }
            Console.WriteLine();
        }
    }


}

class Program
{
    static void Main(string [] args)
    {
        string jsonFilePath = "Data.json";
        string jsonString = File.ReadAllText(jsonFilePath);

      

        var options = new JsonSerializerOptions()
        {
            NumberHandling =JsonNumberHandling.AllowReadingFromString |
            JsonNumberHandling.WriteAsString
        };
        
        var roomData =JsonSerializer.Deserialize<RoomData> (jsonString,options);
        try
        {
           
            
            if(roomData?.Rooms != null)
            {
                

                foreach(var room in roomData.Rooms)
                {
                Console.WriteLine ($"Room ID: {room.roomId}, Name: {room.roomName}, Capacity : {room.capacity}" );
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
        }

        if(roomData.Rooms!=null){
        Room nroom =  roomData.Rooms[3];
        Reservation res = new Reservation();
        ReservationHandler obj = new ReservationHandler();
        
    
        res.reserverName = "lara";
        res.room = nromm;
        res.date = new DateTime(2024, 8, 27, 9, 0, 0, 0);

        obj.addReservation(res);

        }     

        Room n2room = roomData.Rooms[4];
       

        Reservation res3 = new Reservation
        {
            reserverName = "efe",
            room = nnroom,
            date = new DateTime(2024, 7, 13, 13, 0, 0, 0)
        };

        obj.addReservation(res3);

        Room n3room = roomData.Rooms[5];

        Reservation res2 = new Reservation
        {
            reserverName = "luna",
            room = nroom2,
            date = new DateTime(2024, 11, 4, 15, 0, 0, 0)
        };

        obj.addReservation(res2);



        obj.displayWeeklySchedule();

        obj.deleteReservation(res3);
        obj.deleteReservation(res);


       


        obj.displayWeeklySchedule();

       

    }
}