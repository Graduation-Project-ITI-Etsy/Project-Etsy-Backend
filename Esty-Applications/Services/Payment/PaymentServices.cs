﻿using AutoMapper;
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

        public async Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> CreatePayment(ReturnAddUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var createdPayment = await _Payrepo.CreateEntity(payment);
            if (await _Payrepo.Save() > 0)
            {
                var createdPaymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(createdPayment);
                return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = createdPaymentDto, Message = "Payment created successfully" };
            }

            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = null, Message = "Payment created successfully" };

         }

        public async Task<ReturnResultHasObjsDTO<ReturnAllPaymentDTO>> GetAllPayment()
        {
            var allPaymentsQuery = await _Payrepo.GetAllEntity(); 
            var allPayments = allPaymentsQuery.ToList(); 
            var paymentsDto = _mapper.Map<List<ReturnAllPaymentDTO>>(allPayments);
            return new ReturnResultHasObjsDTO<ReturnAllPaymentDTO>
            {
                Entities = paymentsDto,
                Count = allPayments.Count(),
                Message = "All payments were Retrieved"
            };
           
        }

        public async Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> SearchByPaymentByID(int paymentId)
        {
            var payment = await Task.Run(() => _Payrepo.GetEntitybyId(paymentId));
            var paymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(payment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = paymentDto, Message = "Payment found" };

        }

        public async Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> UpdatePayment(ReturnAddUpdatePaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payments>(paymentDto);
            var updatedPayment = await _Payrepo.UpdateEntity(payment); 
            await _Payrepo.Save();
            var updatedPaymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(updatedPayment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = updatedPaymentDto, Message = "Payment updated successfully" };

        }

        public async Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> DeletePayment(int paymentId)
        {
            var deletedPayment = await _Payrepo.DeleteEntity(paymentId);
            await _Payrepo.Save();
            var deletedPaymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(deletedPayment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = deletedPaymentDto, Message = "Payment deleted successfully" };
        }


        public async Task<ReturnResultDTO<ReturnAddUpdatePaymentDTO>> SerachCustomerById(string id)
        {
            var payment = await _Payrepo.SerachCusromerPayById(id); 
            var paymentDto = _mapper.Map<ReturnAddUpdatePaymentDTO>(payment);
            return new ReturnResultDTO<ReturnAddUpdatePaymentDTO> { Entity = paymentDto, Message = "Payment found" };
        }

        public async Task<int> PaymentsCount()
        {
            var paymentCount = await _Payrepo.GetAllEntity();

            return paymentCount.Count();
        }

        public async Task<double> CalculateProfit()
        {
            double Calculation = 0;
            var allpayments = await _Payrepo.GetAllEntity();
        
            foreach ( var payment in allpayments )
            {
                Calculation += (payment.TotalPrice * 50) / 100;
            }
            double roundedResult = Math.Round(Calculation, 3);

            return roundedResult;
        }

        public async Task<double> CalculateTotalPricePaymects()
        {
            double Calculation = 0;
            var allpayments = await _Payrepo.GetAllEntity();

            foreach (var payment in allpayments)
            {
                Calculation += payment.TotalPrice;
            }
            double roundedResult = Math.Round(Calculation, 3);

            return roundedResult;
        }
    }
}
