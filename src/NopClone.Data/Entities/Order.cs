using NopClone.Data.Entities.Base;

namespace NopClone.Data.Entities;

public class Order : BaseEntity<string>
{
    public decimal Discount { get; set; }
    public decimal OrderTotal { get; set; }

    public string CustomerOrderNumber { get; set; }
    
    public Customer Customer { get; set; }
    public string CustomerId { get; set; }
    
    public IList<OrderItem> OrderItems { get; set; }
}

public class OrderItem : BaseEntity<int>
{
    public int  OrderId { get; set; }
    public Order Order { get; set; }

    public int Qty { get; set; }

    public int ProductID { get; set; }
    public Product Product { get; set; }
}