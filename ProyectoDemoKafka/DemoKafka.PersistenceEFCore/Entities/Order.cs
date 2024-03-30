namespace DemoKafka.PersistenceEFCore.Entities
{
    internal class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public short ReceiptType { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public short StateId { get; set; }
        public HashSet<OrderDetail> OrderDetails { get; set; }
    }
}
