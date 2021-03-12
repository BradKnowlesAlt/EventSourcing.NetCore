using System;
using Marten.Events.Aggregation;
using Marten.Events.Projections;
using Tickets.Reservations.Events;

namespace Tickets.Reservations.Projections
{
    public class ReservationShortInfo
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public ReservationStatus Status { get; set; }

        public void Apply(TentativeReservationCreated @event)
        {
            Id = @event.ReservationId;
            Number = @event.Number;
            Status = ReservationStatus.Tentative;
        }

        public void Apply(ReservationConfirmed @event)
        {
            Status = ReservationStatus.Confirmed;
        }
    }

    public class ReservationShortInfoProjection : AggregateProjection<ReservationShortInfo>
    {
        public ReservationShortInfoProjection()
        {
            ProjectEvent<TentativeReservationCreated>((item, @event) => item.Apply(@event));

            ProjectEvent<ReservationConfirmed>((item, @event) => item.Apply(@event));

            DeleteEvent<ReservationCancelled>();
        }
    }
}
