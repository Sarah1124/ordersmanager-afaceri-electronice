using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersManager.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string PersonResponsible { get; set; }
        public DateTime CreateDate { get; set; }
        
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
