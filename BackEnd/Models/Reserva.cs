namespace BackEnd.Models;
public class Reserva
{

    public int ReservaId {get; set;}
    public int ObraId {get; set;}

    public DateTime DiaReservado {get; set;}

    public TimeSpan HoraReserva {get; set;}

    public List<Asiento> AsientosReservados {get; set;}

       

    public Reserva (){

    }

    

}
