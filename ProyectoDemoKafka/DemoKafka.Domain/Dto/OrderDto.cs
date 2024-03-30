namespace DemoKafka.DomainModel.Dto
{
    public record struct OrderDto(
        int OrderId,
        string DocumentNumber,
        string ClientName,
        DateTime CreatedDate,
        decimal Total,
        short StateId,
        string State
        );
}
