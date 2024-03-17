using AutoMapper;
using Ecommerce.Dtos.Book;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Payment
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPayment _Payrepo;
        private readonly IMapper _mapper;

        public PaymentServices(IPayment repo, IMapper mapper)
        {
            _Payrepo = repo;
            _mapper = mapper;
        }


        public ReturnResultDTO<CreateOrUpdatePaymentDTO> CreatePayment(CreateOrUpdatePaymentDTO paymentDto)
        {
            throw new NotImplementedException();

        }



        public ReturnResultHasObjsDTO<GetAllPaymentDTO> GetAllPayment()
        {
            var AllPayments = _Payrepo.GetAllEntity();
            var payments = AllPayments
                .Select(_payments => new GetAllPaymentDTO
                {
                    PaymentID = _payments.PaymentID,
                    TotalPrice = _payments.TotalPrice,
                    Response = _payments.Response,

                }).ToList();
            return new ReturnResultHasObjsDTO<GetAllPaymentDTO>
            {
                Entities = payments,
                Count = AllPayments.Count(),
                Message = "All payments were Retrieved"
            };
        }


        public ReturnResultDTO<CreateOrUpdatePaymentDTO> SearchByPaymentByID(int paymentId)
        {
            throw new NotImplementedException();

        }


        public ReturnResultDTO<CreateOrUpdatePaymentDTO> UpdatePayment(CreateOrUpdatePaymentDTO paymentDto)
        {
            throw new NotImplementedException();

        }

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> DeletePayment(CreateOrUpdatePaymentDTO payment)
        {
            throw new NotImplementedException();
     
        }

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> SerachCustomerById(int id)
        {
            throw new NotImplementedException();

        }
    }
}
