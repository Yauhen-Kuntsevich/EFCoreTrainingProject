# Models creating

## Product model

```C#
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTrainingProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }
}

```

## Customer model

```C#
namespace EFCoreTrainingProject.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public ICollection<Order> Orders { get; set; } = null!;
}

```

## Order model

```C#
namespace EFCoreTrainingProject.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime? OrderFulFilled { get; set; }
    public int CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;
    public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
}

```

## Order Detail model

```C#
namespace EFCoreTrainingProject.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}

```
