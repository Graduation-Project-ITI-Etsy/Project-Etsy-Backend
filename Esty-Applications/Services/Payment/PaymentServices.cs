using AutoMapper;
using Ecommerce.Dtos.Book;
using Esty_Applications.Contract;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var payment = _mapper.Map<Payments>(paymentDto);
            var createdPayment = _Payrepo.CreateEntity(payment);
            var createdPaymentDto = _mapper.Map<CreateOrUpdatePaymentDTO>(createdPayment);
            return new ReturnResultDTO<CreateOrUpdatePaymentDTO> { Entity = createdPaymentDto, Message = "Payment created successfully" };
        }

        public ReturnResultHasObjsDTO<GetAllPaymentDTO> GetAllPayment()
        {
            var allPayments = _Payrepo.GetAllEntity();
            var paymentsDto = _mapper.Map<List<GetAllPaymentDTO>>(allPayments);
            return new ReturnResultHasObjsDTO<GetAllPaymentDTO>
            {
                Entities = paymentsDto,
                Count = allPayments.Count(),
                Message = "All payments were Retrieved"
            };
        }

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> SearchByPaymentByID(int paymentId)
        {
            var payment = _Payrepo.GetEntitybyId(paymentId);
            var paymentDto = _mapper.Map<CreateOrUpdatePaymentDTO>(payment);
            return new ReturnResultDTO<CreateOrUpdatePaymentDTO> { Entity = paymentDto, Message = "Payment found" };
        }

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> UpdatePayment(CreateOrUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var updatedPayment = _Payrepo.UpdateEntity(payment);
            var updatedPaymentDto = _mapper.Map<CreateOrUpdatePaymentDTO>(updatedPayment);
            return new ReturnResultDTO<CreateOrUpdatePaymentDTO> { Entity = updatedPaymentDto, Message = "Payment updated successfully" };
        }

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> DeletePayment(CreateOrUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var deletedPayment = _Payrepo.DeleteEntity(payment.PaymentID);
            var deletedPaymentDto = _mapper.Map<CreateOrUpdatePaymentDTO>(deletedPayment);
            return new ReturnResultDTO<CreateOrUpdatePaymentDTO> { Entity = deletedPaymentDto, Message = "Payment deleted successfully" };
        }

        public ReturnResultDTO<CreateOrUpdatePaymentDTO> SerachCustomerById(int id)
        {
            var payment = _Payrepo.SerachCusromerPayById(id);
            var paymentDto = _mapper.Map<CreateOrUpdatePaymentDTO>(payment);
            return new ReturnResultDTO<CreateOrUpdatePaymentDTO> { Entity = paymentDto, Message = "Payment found" };
        }
    }
}
