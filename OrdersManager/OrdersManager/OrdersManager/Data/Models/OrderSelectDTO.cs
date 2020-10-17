using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersManager.Data.Models
{
    public class OrderSelectDTO
    {
        public int Id { get; set; }
        public string PersonResponsible { get; set; }
        public string CreateDate { get; set; }
    }
}
