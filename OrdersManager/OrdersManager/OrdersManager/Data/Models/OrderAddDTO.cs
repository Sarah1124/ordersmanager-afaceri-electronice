using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersManager.Data.Models
{
    public class OrderAddDTO
    {
        public int Id { get; set; }
        public string OrderPerson { get; set; }
        public List<int> OrderProductIds { get; set; }
    }
}
