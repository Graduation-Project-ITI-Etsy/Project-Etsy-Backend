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

        public Task<ReturnResultHasObjsDTO<ReturnAllPaymentDTO>> GetAllPayment();

        public Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> SearchByPaymentByID(int PaymentID);

        public Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> CreatePayment(ReturnAddUpdatePaymentDTO Payment);

        public Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> UpdatePayment(ReturnAddUpdatePaymentDTO Payment);

        public Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> DeletePayment(ReturnAddUpdatePaymentDTO payment);

        public Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> SerachCustomerById(string id);

    }

}
