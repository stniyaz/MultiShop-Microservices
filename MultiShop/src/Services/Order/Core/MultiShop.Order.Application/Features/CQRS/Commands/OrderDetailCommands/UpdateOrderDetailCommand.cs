﻿namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public class UpdateOrderDetailCommand
{
    public string OrderDetailId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int OrderingId { get; set; }
}
