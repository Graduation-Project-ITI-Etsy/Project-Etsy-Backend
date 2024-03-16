using Esty_Applications.Contract;
using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Payment
{
    public class PaymentServices : IPaymentServices
    {
        IPayment _Payrepo;
        public PaymentServices(IPayment repo)
        {
            _Payrepo = repo;
        }

        public Payments CreatePayment(Payments payment)
        {
            var Payment = _Payrepo.CreateEntity(payment);
            _Payrepo.Save();
            return Payment;
        }

        public Payments DeletePayment(int paymentId)
        {
            var Paydelete = _Payrepo.DeleteEntity(paymentId);
            return Paydelete;
        }

        public List<Payments> GetAllPayment()
        {
            return _Payrepo.GetAllEntity();
        }

        public Payments GetPaymentByID(int payment)
        {
            var Pay = _Payrepo.GetEntitybyId(payment);
            return Pay;
        }


        public Payments SerachCustomerById(int id)
        {
            var query = _Payrepo.SerachCusromerPayById(id);
            return query;
        }

        public Payments UpdatePayment(Payments payment)
        {
            var Payupdate = _Payrepo.UpdateEntity(payment);
            _Payrepo.Save();
            return Payupdate;
        }
    }
}
