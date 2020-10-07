using System;
using Ardalis.GuardClauses;
using Core.Events;
using Payments.Payments.Events.Enums;

namespace Payments.Payments.Events
{
    public class PaymentTimedOut: IEvent
    {
        public Guid PaymentId { get; }

        public DateTime TimedOutAt { get; }

        private PaymentTimedOut(Guid paymentId, DateTime timedOutAt)
        {
            PaymentId = paymentId;
            TimedOutAt = timedOutAt;
        }

        public static PaymentTimedOut Create(Guid paymentId, in DateTime timedOutAt)
        {
            Guard.Against.Default(paymentId, nameof(paymentId));
            Guard.Against.Default(timedOutAt, nameof(timedOutAt));

            return new PaymentTimedOut(paymentId, timedOutAt);
        }
    }
}
