using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{

    public class PurchaseType
    {
        public int PurchaseTypeId { get; set; }
        [Required]
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
    }
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Order Number")]
        public string PurchaseOrderName { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Vendor")]
        public int VendorId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }

        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        [Display(Name = "Purchase Type")]
        public int PurchaseTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();


    }
    public class PurchaseOrderLine
    {
        public int PurchaseOrderLineId { get; set; }
        [Display(Name = "Purchase Order")]
        public int PurchaseOrderId { get; set; }
        [Display(Name = "Product Item")]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        [Display(Name = "Disc %")]
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double SubTotal { get; set; }
        [Display(Name = "Tax %")]
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
        public double Total { get; set; }
    }
}
