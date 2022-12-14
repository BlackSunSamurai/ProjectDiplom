namespace Shop.Common.DTOs.CreditCard;

public class GetCard
{
    public int Id { get; set; }
    public string Number { get; set; }

    public string CVV { get; set; }

    public string ClientId { get; set; }

    public DateTime ExpirationDate { get; set; }
}