using System;
using Core.Events;
using Newtonsoft.Json;

namespace Tickets.Reservations.ConfirmingReservation
{
    public class ReservationConfirmed : IEvent
    {
        public Guid ReservationId { get; }

        [JsonConstructor]
        private ReservationConfirmed(Guid reservationId)
        {
            ReservationId = reservationId;
        }

        public static ReservationConfirmed Create(Guid reservationId)
        {
            return new(reservationId);
        }
    }
}
