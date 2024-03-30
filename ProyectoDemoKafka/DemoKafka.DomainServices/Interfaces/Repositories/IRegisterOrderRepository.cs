using DemoKafka.DomainModel.Entities;

namespace DemoKafka.DomainServices.Interfaces.Repositories
{
    public interface IRegisterOrderRepository
    {
        ValueTask<int> Register(Order order);
    }
}
