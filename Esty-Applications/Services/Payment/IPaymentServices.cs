using Esty_Models;
using Etsy_DTO.Products;
using Etsy_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Dtos.Book;

namespace Esty_Applications.Services.Payment
{
    public interface IPaymentServices
    {
        public ReturnResultHasObjsDTO<GetAllPaymentDTO> GetAllPayment();

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> SearchByPaymentByID(int PaymentID);

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> CreatePayment(CreateOrUpdatePaymentDTO Payment);

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> UpdatePayment(CreateOrUpdatePaymentDTO Payment);

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> DeletePayment(CreateOrUpdatePaymentDTO payment);


        public ReturnResultDTO<CreateOrUpdatePaymentDTO> SerachCustomerById(int id);
    }

}
