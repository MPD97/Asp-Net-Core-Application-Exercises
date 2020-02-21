using System;

namespace _04_CRUD.Data.Entities
{
    public class Item
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
