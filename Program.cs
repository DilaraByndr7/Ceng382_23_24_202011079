using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;


public class Program
{
    public static void Main()
    {
        string jsonFilePath = "ReservationData.json";
        ReservationService.InitializeReservations(jsonFilePath);
        
        ReservationHandler reservationHandler = new ReservationHandler();
            
         RoomHandler roomHandler= new RoomHandler
        {
            reservationHandler = reservationHandler,
            DateTime = "2024-07-13",
            ReserverName = "Dilara",

        };
        Room room = new Room("001", "A-100", 3);
        roomHandler.manageRoom(room,true);

            

        RoomHandler roomHandler1= new RoomHandler
        {
            reservationHandler = reservationHandler,
            DateTime = "2024-11-17",
            ReserverName = "Ahmet",
        };
        Room room1 = new Room("002", "A-156", 4);
        roomHandler1.manageRoom(room1,true);
            


        RoomHandler roomHandler2= new RoomHandler
        {
            reservationHandler = reservationHandler,
            DateTime = "2024-01-21",
            ReserverName = "Lara",
        };
        Room room2 = new Room("004", "A-193", 2);
        roomHandler2.manageRoom(room2,true);


        RoomHandler roomHandler3= new RoomHandler
        {
            reservationHandler = reservationHandler,
            DateTime = "2024-11-11",
            ReserverName = "Atlas",
        };
        Room room3 = new Room("005", "A-156", 2);
        roomHandler3.manageRoom(room3,true);

        //removing reservation
        roomHandler2.manageRoom(room2,false);

        // print resevation
        ReservationService .PrintReservations();


        LogService.DisplayLogsByName("Atlas");



        DateTime start = new DateTime(2024, 5, 28, 13, 41, 42, 579); 
        DateTime end = new DateTime(2024, 5, 28, 13, 41, 42, 732);

        LogService.DisplayLogs(start, end);
        


    }
}
