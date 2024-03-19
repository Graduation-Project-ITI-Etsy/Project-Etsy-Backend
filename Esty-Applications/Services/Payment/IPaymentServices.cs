using Esty_Models;
using Etsy_DTO.Products;
using Etsy_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etsy_DTO.Payment;
namespace Esty_Applications.Services.Payment
{
    public interface IPaymentServices
    {
        public ReturnResultHasObjsDTO<ReturnAllPaymentDTO> GetAllPayment();

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> SearchByPaymentByID(int PaymentID);

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> CreatePayment(ReturnAddUpdatePaymentDTO Payment);

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> UpdatePayment(ReturnAddUpdatePaymentDTO Payment);

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> DeletePayment(ReturnAddUpdatePaymentDTO payment);


        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> SerachCustomerById(int id);
    }

}
