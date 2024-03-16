using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Services.Payment
{
    public interface IPaymentServices
    {
        public List<Payments> GetAllPayment();

        public Payments GetPaymentByID(int Payment);

        public Payments CreatePayment(Payments Payment);

        public Payments UpdatePayment(Payments Payment);

        public Payments DeletePayment(int PaymentId);


        public Payments SerachCustomerById(int id);
    }
}
