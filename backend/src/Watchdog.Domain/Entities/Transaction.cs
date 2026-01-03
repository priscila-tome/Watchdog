namespace Watchdog.Domain.Entities;
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid ClientId {  get; set; }
        public int Type { get; set; }
        public double Value { get; set; }
        public int Currency { get; set; }
        public int CounterpartyId { get; set; }
        public DateTime DateTime { get; set; }
    }
