using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        [Required]
        public string PaymentTypeName { get; set; }
        public string Description { get; set; }
    }
    public class PaymentReceive
    {
        public int PaymentReceiveId { get; set; }
        [Display(Name = "Payment Number")]
        public string PaymentReceiveName { get; set; }
        [Display(Name = "Invoice")]
        public int InvoiceId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }
        public double PaymentAmount { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; } = true;
    }
    public class PaymentVoucher
    {
        public int PaymentvoucherId { get; set; }
        [Display(Name = "Payment Voucher Number")]
        public string PaymentVoucherName { get; set; }
        [Display(Name = "Bill")]
        public int BillId { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }
        public double PaymentAmount { get; set; }
        [Display(Name = "Payment Source")]
        public int CashBankId { get; set; }
        [Display(Name = "Full Payment")]
        public bool IsFullPayment { get; set; } = true;
    }
}
