namespace DemoKafka.PersistenceEFCore.Entities
{
    internal class NotificationMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
