


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;           //--< Be sure to "Include" this <<<

using System.Xml;
using System.Xml.Linq;

namespace Sales
{
    public partial class Customer
    {
        public static string Student => "Amanda Shelton";

        public string Name => $"{FirstName} {LastName}";

        public int OrderCount => SalesOrders.Count(so => so.OrderTotal>200);

        public int LargeOrderCount => SalesOrders.Count(so => so.OrderTotal > 100);

        public decimal TotalSales => SalesOrders.Sum(so => so.OrderTotal);

        public override string ToString()
        {
            return $"{CustomerId}\t{FirstName}\t{LastName}";
        }
        static Entities db = new Entities();
        public static decimal Taxes()
        {
            
            var taxes = db.SalesOrders.Select(
                so => new
                {
                    OrderNum = so.SalesOrderNumber,
                    so.OrderTotal,
                    Customer = $"{so.Customer.FirstName} {so.Customer.LastName}",
                    Taxes = so.OrderTotal * .06m
                }
                ).ToList();
            return taxes.Sum(t => t.Taxes);
        }
    }
    public partial class SalesOrder
    {
        public static string Student => "Isaiah Seaborne";

        public override string ToString()
        {
            return $"{SalesOrderNumber}\t{Customer.FirstName}\t{Customer.LastName}";
        }
    }
   

}


