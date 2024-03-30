using DemoKafka.Application.Dtos.RegisterOrder;
using DemoKafka.DomainModel.Entities;
using DemoKafka.DomainModel.ValueObjects;
using DemoKafka.DomainServices.Interfaces.Repositories;
using DemoKafka.DomainServices.Interfaces.Services;
using MediatR;

namespace DemoKafka.Application.UseCases
{
    internal class RegisterOrderUseCase : IRequestHandler<RegisterOrderRequestDto, int>
    {
        readonly IRegisterOrderRepository RegisterOrderRepository;
        readonly IEventProducer EventProducer;
        public RegisterOrderUseCase(IRegisterOrderRepository registerOrderRepository,
            IEventProducer eventProducer)
        {
            RegisterOrderRepository = registerOrderRepository;
            EventProducer = eventProducer;
        }

        public async Task<int> Handle(RegisterOrderRequestDto request, CancellationToken cancellationToken)
        {
            Order NewOrder = new Order()
            {
                ClientName = request.ClientName,
                DocumentNumber = request.DocumentNumber,
                DocumentTypeId = request.DocumentTypeId,
                ReceiptType = request.ReceiptType,
                RegisterDate = request.RegisterDate,
                SubTotal = request.SubTotal,
                Total = request.Total,
                Igv = request.Igv,
                StateId = 1,
                OrderDetails = request.OrderDetail.Select(x => new OrderDetail(x.ProductId, x.Quantity, x.UnitPrice)).ToList()
            };

            int OrderId = await RegisterOrderRepository.Register(NewOrder);

            NotificationMessage Message = new NotificationMessage($"Se ha creado la orden {OrderId}");

            EventProducer.Produce(Message.GetType().Name, Message);

            return OrderId;
        }
    }
}
