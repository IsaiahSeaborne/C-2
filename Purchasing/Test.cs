using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace Purchasing
{
    public class PurchasingTest
    {
        public static void Test()
        {
            //TestUpdateVendor();
            //TestView();
            //TestFunction();
            TestStoredProcedure();
        }
        private static void TestUpdateVendor()
        {
            //Update PurchaseOrder set PurchaseOrderStatusId = 1
            using (var db = new PurchasingEntities())
            {
                //C in crud create
                var vendor = db.Vendors.Find(28);
                vendor = new Vendor()
                {
                    Name = "Mr.Bobbie",
                };
                db.Vendors.Add(vendor);
                db.SaveChanges();

                //U in crud update
                var purchaseorder = db.PurchaseOrders.Find(2);
                var purchaseorderstatus = purchaseorder.PurchaseOrderStatusID;
                purchaseorder.PurchaseOrderStatusID = POSIStatus.Open;

                
                var name = vendor.Name;
                vendor.Name = "Poopie";

                db.SaveChanges();

                

                //D in Crud delete record
                vendor = db.Vendors.Find(28);
                db.Vendors.Remove(vendor);
                db.SaveChanges();
            }

        }
        private static void TestView()

        {
            using (var db = new PurchasingEntities1())
            {
                var summaries = db.PoSummaries;

                foreach (var s in summaries)
                {
                    Console.WriteLine($"{s.PurchaseOrderId}\t{ s.PODate}\t{s.Vendor}\t{s.TotalAmount}");
                }
            }
        
        }
        private static void TestFunction()
        {
            using (var db = new PurchasingEntities1())
            {
                var details = db.PoDetail(4);
                foreach (var detail in details)
                {
                    Console.WriteLine($"{detail.PurchaseOrderId}" +
                        $"\t{detail.PODate}" +
                        $"\t{detail.Vendor}" +
                        $"\t{detail.Part}" +
                        $"\t{detail.Quantity}" +
                        $"\t{detail.Value}");
                }

            }

        }
        private static void TestStoredProcedure()
        {
            int poNum = 1;
            Console.WriteLine("Before Stored Procedure");

            using (var db = new PurchasingEntities1())
            {
                var po = db.PurchaseOrders.Find(1);
                po.Amount = 0;
                db.SaveChanges();

                Console.WriteLine($"{po.PurchaseOrderId}\t{po.Amount}");

                ObjectParameter amount = new ObjectParameter("Amount", 0);

                db.POP(poNum, amount);

                Console.WriteLine("After SP");
            }

            using (var db = new PurchasingEntities1())
            {
                var po = db.PurchaseOrders.Find(1);
                Console.WriteLine($"{po.PurchaseOrderId}\t{po.Amount}");
            }

        }

    }
}
