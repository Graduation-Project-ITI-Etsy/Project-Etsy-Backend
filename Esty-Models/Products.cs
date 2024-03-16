using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Models
{
    public class Products
    {
        public int ProductId { get; set; }

        public string? ProductNameEN { get; set; }

        public string? ProductNameAR { get; set; }

        public int ProductPrice { get; set; }

        public int ProductStock { get; set; }

        public int ProductRating { get; set; }

        public string? ProductPublisher { get; set; }

        public string? ProductDescriptionEN { get; set; }

        public string? ProductDescriptionAR { get; set; }


        public int CategoryID { get; set; }
        //public Ctegory ctegory { get; set; }

        public ICollection<Cart>? carts { get; set; }

        //public ICollection<OrderProduct>? OrderProduct { get; set; }

    }
}
