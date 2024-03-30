using Confluent.Kafka;
using DemoKafka.DomainModel.ValueObjects;
using DemoKafka.DomainServices.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DemoKafka.Services.Kafka
{
    public class ConsumerService : IHostedService
    {
        readonly IRegisterNotificationMessageRepository RegisterNotificationMessageRepository;
        public KafkaSettings KafkaSettings { get; }

        public ConsumerService(IServiceScopeFactory factory)
        {
            RegisterNotificationMessageRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IRegisterNotificationMessageRepository>();
            KafkaSettings = factory.CreateScope().ServiceProvider.GetRequiredService<IOptions<KafkaSettings>>().Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = KafkaSettings.GroupId,
                BootstrapServers = $"{KafkaSettings.Hostname}:{KafkaSettings.Port}",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    var Topics = new string[]
                    {
                        typeof(NotificationMessage).Name,
                    };

                    consumerBuilder.Subscribe(Topics);
                    var cancelToken = new CancellationTokenSource();

                    try
                    {
                        while (true)
                        {
                            var consumer = consumerBuilder.Consume(cancelToken.Token);

                            if (consumer.Topic == typeof(NotificationMessage).Name)
                            {
                                var NotificationMessage = JsonConvert.DeserializeObject<NotificationMessage>(consumer.Message.Value);

                                Console.WriteLine($"Leyendo el JSON {consumer.Message.Value}");

                                RegisterNotificationMessageRepository.Register(NotificationMessage).Wait();
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
