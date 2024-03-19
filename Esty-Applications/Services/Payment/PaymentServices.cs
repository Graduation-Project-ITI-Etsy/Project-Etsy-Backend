using AutoMapper;
using Etsy_DTO.Payment;
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

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> CreatePayment(ReturnAddUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var createdPayment = _Payrepo.CreateEntity(payment);
            var createdPaymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(createdPayment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = createdPaymentDto, Message = "Payment created successfully" };
        }

        public ReturnResultHasObjsDTO<ReturnAllPaymentDTO> GetAllPayment()
        {
            var allPayments = _Payrepo.GetAllEntity();
            var paymentsDto = _mapper.Map<List<ReturnAllPaymentDTO>>(allPayments);
            return new ReturnResultHasObjsDTO<ReturnAllPaymentDTO>
            {
                Entities = paymentsDto,
                Count = allPayments.Count(),
                Message = "All payments were Retrieved"
            };
        }

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> SearchByPaymentByID(int paymentId)
        {
            var payment = _Payrepo.GetEntitybyId(paymentId);
            var paymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(payment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> 
            { Entity = paymentDto, Message = "Payment found" };
        }

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> UpdatePayment(ReturnAddUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var updatedPayment = _Payrepo.UpdateEntity(payment);
            _Payrepo.Save();
            var updatedPaymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(updatedPayment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = updatedPaymentDto, Message = "Payment updated successfully" };
        }

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> DeletePayment(ReturnAddUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var deletedPayment = _Payrepo.DeleteEntity(payment.PaymentID);
            _Payrepo.Save();
            var deletedPaymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(deletedPayment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = deletedPaymentDto, Message = "Payment deleted successfully" };
        }

        public ReturnResultDTO<ReturnAddUpdatePaymentDTO> SerachCustomerById(int id)
        {
            var payment = _Payrepo.SerachCusromerPayById(id);
            var paymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(payment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = paymentDto, Message = "Payment found" };
        }
    }
}
