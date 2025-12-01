namespace AirlineBookingSystem.Flight.Core.Entities
{
    public class Flight
    {
        public Guid Id { get; set; }

        public string? FlightNumber { get; set; }

        public string? Origin { get;set; }

        public string? Destination { get; set; }

        public DateTime DepartmentTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
