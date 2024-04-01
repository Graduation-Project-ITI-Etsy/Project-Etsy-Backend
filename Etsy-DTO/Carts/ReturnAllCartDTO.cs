using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsy_DTO.Carts
{
    public class ReturnAllCartDTO
    {
        public int CartID { get; set; }

        public string CustomerId { get; set; }

        public int ProductId { get; set; }

        public string? ProductNameEN { get; set; }

        public string? ProductNameAR { get; set; }

        public float ProductPrice { get; set; }

        public int ProductStock { get; set; }

        public float ProductRating { get; set; }

        public string? ProductPublisher { get; set; }

        public string? ProductDescriptionEN { get; set; }

        public string? ProductDescriptionAR { get; set; }

        public string? ProductImage { get; set; }

        public int CategoryID { get; set; }

        public int Quantity { get; set; }
    }

}
