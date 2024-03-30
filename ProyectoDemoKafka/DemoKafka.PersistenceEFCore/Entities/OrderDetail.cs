namespace DemoKafka.PersistenceEFCore.Entities
{
    internal class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
    }
}
