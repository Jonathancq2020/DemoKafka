using MediatR;

namespace DemoKafka.Application.Dtos.RegisterOrder
{
    public record struct RegisterOrderRequestDto(
        string ClientName,
        int DocumentTypeId,
        string DocumentNumber,
        DateTime RegisterDate,
        short ReceiptType,
        decimal SubTotal,
        decimal Igv,
        decimal Total,
        List<OrderDetailDto> OrderDetail
        ) : IRequest<int>;
}
