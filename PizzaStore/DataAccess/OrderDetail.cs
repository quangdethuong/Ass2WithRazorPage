using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaStore.DataAccess
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double? UnitPrice { get; set; }
        public double? Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
