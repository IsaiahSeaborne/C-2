
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml;
using System.Xml.Linq;

namespace Purchasing
{
    class Purchasing
    {

        static PurchasingEntities db = new PurchasingEntities();

        public static List<VendorPurchase> VendorPurchases
        {
            get
            {
                //--< Replace the following line with your code >--//
                return new List<VendorPurchase>();                    
            }
        }
    }
    public class VendorPurchase
    {
        public int VendorId { get; set; }
        public string Vendor { get; set; }
        public decimal TotalPurchases { get; set; }
    }
    public partial class Part
    {

        static PurchasingEntities1 db = new PurchasingEntities1();

        public int OrderCount => db.PurchaseOrders.Count(po => po.Amount > 200);
        //public decimal TotalPurchases => db.PurchaseOrders.Sum(po => po.Amount);
        public static List<PartPurchase> PartPurchases
        {
            get
            {
                //--< Replace the following line with your code >--//
                return new List<PartPurchase>();
            }
        }
    }
    public class PartPurchase
    {
        public int PartId { get; set; }
        public string Part { get; set; }
        public decimal TotalPurchases { get; set; }
    }
    public partial class PurchaseOrderPart
    {
        
        public static string StudentName 
        { 
            get
            {
                var name = "Isaiah Seaborne";

                return name;
            }
                
        }
        static PurchasingEntities1 db = new PurchasingEntities1();
        public int QuantityReceived
        {
            get
            {
                var qr = (from pops in db.Receipts
                          
                          select pops.Quantity).Sum();
                return qr;
            }
        }
        public int BackOrdered 
        { 
            get
            {
                var bo =
                    (from pops in db.PurchaseOrderParts
                 select pops.Quantity).Sum();

                return bo - QuantityReceived;
            }
        }
        
        public decimal CostReceived
        {
            get
            {
                return (from pops in db.Receipts
                        select pops.TotalCost).Sum();
            }
        }
    }
    
    public partial class PurchaseOrder
    {
        static PurchasingEntities1 db = new PurchasingEntities1();
        public decimal? TotalAmount 
        { 
            get
            {
                var total = (from pops in db.PurchaseOrderParts
                             select pops.Cost).Sum();
                return total;
            }
        }
        public static List<PurchaseOrder> OpenOrders 
        {
            get
            {
                var pos = (from pops in db.PurchaseOrders
                           where pops.PurchaseOrderStatusID == POSIStatus.Open
                           select pops).ToList();
                return pos;
            }
        }
        public static List<dynamic> MonthlySales 
        { 
            get
            {
                var date = (from pops in db.PurchaseOrders
                            group pops by pops.PODate.Month into monthGroup
                            select new
                            {
                                Month = monthGroup.Key,
                                TotalAmount = monthGroup.Sum(po => po.TotalAmount)

                            }).ToList<dynamic>();

                return date;

                
            }
        }
    }
    public partial class Vendor
    {
        static PurchasingEntities1 db = new PurchasingEntities1();
        public decimal TotalAmount 
        { 
            get
            {
                var total = (from pops in db.PurchaseOrders
                             select pops.Amount).Sum();
                return (decimal)total;
            } 
        }
        public static List<PurchaseOrder> Top3 
        { 
            get
            {
                var top3 = db.PurchaseOrders.OrderByDescending(x => x.Amount).Take(3).ToList();

                return top3;
            }
        }
    }
}
