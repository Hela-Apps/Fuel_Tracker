using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class CustomerViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }

        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string FaxNumber { get; set; }
        public string VatNumber { get; set; }
        public int PaymentTermId { get; set; }
        public int PaymentMethodId { get; set; } // cash,BankTransfer,cheque
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
