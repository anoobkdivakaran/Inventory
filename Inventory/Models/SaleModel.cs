using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        [Display(Name = "Order Number")]
        public string SalesOrderName { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Customer Ref. Number")]
        public string CustomerRefNumber { get; set; }
        [Display(Name = "Sales Type")]
        public int SalesTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }
        public List<SalesOrderLine> SalesOrderLines { get; set; } = new List<SalesOrderLine>();
    }
    public class SalesOrderLine
    {
        public int SalesOrderLineId { get; set; }
        [Display(Name = "Sales Order")]
        public int SalesOrderId { get; set; }
        [Display(Name = "Sales Order")]
        public SalesOrder SalesOrder { get; set; }
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
    public class SalesType
    {
        public int SalesTypeId { get; set; }
        [Required]
        public string SalesTypeName { get; set; }
        public string Description { get; set; }
    }
}
