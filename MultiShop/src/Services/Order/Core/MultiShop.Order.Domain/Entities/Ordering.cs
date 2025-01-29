namespace MultiShop.Order.Domain.Entities;

public class Ordering
{
    public string OrderingId { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}
