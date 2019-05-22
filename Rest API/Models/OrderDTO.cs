using System;

namespace SampleAPI.Models
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Customer { get; set; }
        public float Total { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}