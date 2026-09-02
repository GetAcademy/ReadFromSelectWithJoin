namespace ReadFromSelectWithJoin.DTOs
{
    internal class OrderWithCustomer
    {
        public int OrderId { get; set; }
        public DateTime CreatedUtc { get; set; }
        public decimal TotalAmount { get; set; }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
