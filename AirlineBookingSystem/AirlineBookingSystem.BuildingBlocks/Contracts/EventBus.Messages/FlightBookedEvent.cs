namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages
{
    public record FlightBookedEvent
        (Guid BookingId, Guid FlightId, string passengerName, string SeatNumber, DateTime BookingDate);
}