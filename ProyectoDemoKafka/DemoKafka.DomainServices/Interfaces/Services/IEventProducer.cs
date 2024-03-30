namespace DemoKafka.DomainServices.Interfaces.Services
{
    public interface IEventProducer
    {
        void Produce(string topic, object @event);
    }
}
