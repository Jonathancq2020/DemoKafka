using DemoKafka.DomainModel.ValueObjects;

namespace DemoKafka.DomainServices.Interfaces.Repositories
{
    public interface IRegisterNotificationMessageRepository
    {
        Task Register(NotificationMessage notificationMessage);
    }
}
