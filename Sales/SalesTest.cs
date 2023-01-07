using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace Sales
{
    public class SalesTest
    {
        public static void Test()
        {
            //TestCriticalThinking();
            //TestView();
            //TestFunction();
            TestStoredProcedure();
            //MaintainSales();
        }
        private static void MaintainSales()
        {

            //U in crud updating
            using (var db = new Entities())
            {
                var customer = db.Customers.Find(1);
                var balance = customer.Balance;
                customer.Balance = balance + 100;

                db.SaveChanges();

                var salesorder = db.SalesOrders.Find(2);
                salesorder.SalesStatusId = SalesStatus.Open;
                db.SaveChanges();

                //C in crud create
                customer = new Customer()
                {
                    FirstName = "Bob",
                    LastName = "Black",
                    City = "Glen Allen",
                    State = "VA",
                    Balance = 200,
                };
                db.Customers.Add(customer);
                db.SaveChanges();

                salesorder = new SalesOrder()
                {
                    CustomerId = 3,
                    OrderDate = new DateTime(2000, 10, 9),
                    OrderTotal = 2343443,
                    OrderCost = 2333,
                    GrossProfit = 2343,
                    SalesStatusId = SalesStatus.Closed

                };

                //D in Crud delete record
                customer = db.Customers.Find(9);
                db.Customers.Remove(customer);
                db.SaveChanges();

                salesorder = db.SalesOrders.Find(10);
                db.SalesOrders.Remove(salesorder);
                db.SaveChanges();
            }
        }

        private static void TestCriticalThinking()
        {
            /*
             * Can an object can be retrieved, updated, deleted, and re-inserted in the 
             * same SaveChanges( ) execution?
             */


        }
        private static void TestView()
        {
            using (var db = new Entities())
            {
                var summaries = db.SoSummaries;

                foreach (var s in summaries)
                {
                    Console.WriteLine($"{s.SalesOrderNumber}\t{ s.Customer}\t{s.TotalAmount}");
                }
            }

        }
        private static void TestFunction()
        {

            using (var db = new Entities())
            {
                var details = db.SoDetail(4);
                foreach (var detail in details)
                {
                    Console.WriteLine($"{detail.SalesOrderNumber}" +
                        $"\t{detail.Customer}" +
                        $"\t{detail.Part}" +
                        $"\t{detail.Quantity}" +
                        $"\t{detail.OrderTotal:c}");
                }

            }
        }
        private static void TestStoredProcedure()
            {

                int soNum = 1;
                Console.WriteLine("Before Stored Procedure");

            using (var db = new Entities())
            {
                var so = db.SalesOrders.Find(soNum);
                so.OrderTotal = 0;
                db.SaveChanges();

                Console.WriteLine($"{so.SalesOrderNumber}\t{so.OrderTotal}");

                ObjectParameter orderTotalParm = new ObjectParameter("OrderTotal", 0);

                db.SOP(soNum, orderTotalParm);

                Console.WriteLine("After SP");
            }

                using (var db = new Entities())
                {
                    var so = db.SalesOrders.Find(1);
                    Console.WriteLine($"{so.SalesOrderNumber}\t{so.OrderTotal}");
                }
                
            }
        
    }
}
