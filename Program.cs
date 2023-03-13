using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;


public class Program
{
    public static void Main()
    {
        Table Tafel = new Table(200, 200);
        Tafel.CreateTables();
        while (true)
        {
            // Send.SendReservationConfirmation("tymovanrijn@gmail.com", "23-04-2023", "18:00-20:00").Wait();
            Console.WriteLine("Met hoeveel personenen bent u?");
            int AantalPersonen = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(Tafel.ReserveerTafel(AantalPersonen));
            Tafel.Tafelindeling();
        }

    }
}

