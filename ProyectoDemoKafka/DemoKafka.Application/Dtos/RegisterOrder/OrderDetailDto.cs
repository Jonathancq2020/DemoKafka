namespace DemoKafka.Application.Dtos.RegisterOrder
{
    public record struct OrderDetailDto(
        int ProductId,
        int Quantity,
        decimal UnitPrice
        );
}
