using Etsy_DTO.Carts;
using Etsy_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etsy_DTO.Products;
using Esty_Models;

namespace Esty_Applications.Services.Carts
{
    public interface ICartServices
    {
        public Task<ReturnResultDTO<ReturnAddUpdateCartDTO>> CreateCart(ReturnAddUpdateCartDTO cart);

        public Task<ReturnResultHasObjsDTO<ReturnAllCartDTO>> GetAllCards(string customerId);

        public Task<ReturnResultDTO<ReturnAddUpdateCartDTO>> DeleteCart(string customerId);
    }
}