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
        public string ClientId { get; set; }
        public IdentityUserDb Cliente { get; set; }

        public List<CartItem> Items { get;  set; }
    }


    public class CartViewModel : Cart
    {
        public int[] CartItems { get;set; }
    }

}
