using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



public class ReservationHandler
{
    public void bookRoom(Reservation reservation) 
    {
        ReservationService.reserveRoom(reservation);
        
    }

    public void removeBooking(Reservation reservation) 
    {
        ReservationService.deleteReservation(reservation);
        
    }


}