using DemoKafka.DomainServices.Interfaces.Repositories;
using DemoKafka.PersistenceEFCore.DataContexts;
using Order = DemoKafka.PersistenceEFCore.Entities.Order;
using OrderDetail = DemoKafka.PersistenceEFCore.Entities.OrderDetail;

namespace DemoKafka.PersistenceEFCore.Repositories
{
    internal class RegisterOrderRepository : IRegisterOrderRepository
    {
        readonly DemoKafkaContext Context;

        public RegisterOrderRepository(DemoKafkaContext context)
        {
            Context = context;
        }

        public async ValueTask<int> Register(DomainModel.Entities.Order order)
        {
            Order NewOrder = new Entities.Order()
            {
                ClientName = order.ClientName,
                DocumentTypeId = order.DocumentTypeId,
                DocumentNumber = order.DocumentNumber,
                RegisterDate = order.RegisterDate,
                ReceiptType = order.ReceiptType,
                SubTotal = order.SubTotal,
                Igv = order.Igv,
                Total = order.Total,
                StateId = order.StateId
            };

            Context.Add(NewOrder);

            foreach (var item in order.OrderDetails)
            {
                Entities.OrderDetail orderDetail = new OrderDetail()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Order = NewOrder
                };

                Context.Add(orderDetail);
            }
            await Context.SaveChangesAsync();

            return NewOrder.Id;
        }
    }
}
