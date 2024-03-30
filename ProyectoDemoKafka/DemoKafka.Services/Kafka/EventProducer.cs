using Confluent.Kafka;
using DemoKafka.DomainModel.ValueObjects;
using DemoKafka.DomainServices.Interfaces.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DemoKafka.Services.Kafka
{
    internal class EventProducer : IEventProducer
    {
        public KafkaSettings KafkaSettings;

        public EventProducer(IOptions<KafkaSettings> kafkaSettings)
        {
            KafkaSettings = kafkaSettings.Value;
        }

        public void Produce(string topic, object @event)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = $"{KafkaSettings.Hostname}:{KafkaSettings.Port}"
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var classEvent = @event.GetType();
                string value = JsonConvert.SerializeObject(@event);
                var message = new Message<Null, string> { Value = value };
                producer.ProduceAsync(topic, message)
                     .GetAwaiter().GetResult();

            }
        }
    }
}
