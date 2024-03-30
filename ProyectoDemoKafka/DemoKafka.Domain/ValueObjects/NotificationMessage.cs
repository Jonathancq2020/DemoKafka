namespace DemoKafka.DomainModel.ValueObjects
{
    public class NotificationMessage
    {
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public NotificationMessage(string message)
        {
            Message = message;
        }
    }
}
