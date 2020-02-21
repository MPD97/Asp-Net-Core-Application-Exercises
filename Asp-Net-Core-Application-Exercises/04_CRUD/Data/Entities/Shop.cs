using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_CRUD.Data.Entities
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
