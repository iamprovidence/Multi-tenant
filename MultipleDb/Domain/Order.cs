using System.Collections.Generic;

namespace MultipleDb.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
