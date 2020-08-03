using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int StockId { get; set; }
        public int Cantidad { get; set; }
    }
}
