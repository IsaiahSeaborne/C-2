using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public abstract class Customer
    {
        public string Name { get; set; }
        public abstract string SalesRep { get; set; }
    }
    interface IShape
    {
        double Perimeter { get; }
        double Area { get; }
    }
    public class Square : IShape
    {
        public Square(Double length) : base()
        {
            Length = length;
        }
        public Square() : this(1)
        {
        }
        public double Length { get; set; }
        public double Area
        {
            get { return Length * Length; }
        }
        public double Perimeter
        {
            get { return Length * 4; }
        }
    }
    interface IBusinessAssociate
    {
        int Id { get; set; }
        string Name { get; set; }
        double TotalAmount();
    }
    public class Consumer : Customer, IBusinessAssociate
    {
        public int ConsumerId { get; set; }
        public override string SalesRep { get; set; }
        public double SalesAmount
        {
            get { return 1000; }
        }

        public int Id
        {
            get { return ConsumerId; }
            set { ConsumerId = value; }
        }
        public double TotalAmount()
        {
            return SalesAmount;
        }
    }
    public class Business : Customer, IBusinessAssociate
    {
        public int BusinessId { get; set; }
        public override string SalesRep { get; set; }
        public double SalesAmount
        {
            get { return 2000; }
        }
        public int Id
        {
            get { return BusinessId; }
            set { BusinessId = value; }
        }
        public double TotalAmount()
        {
            return SalesAmount;
        }
    }
    public class Vendor : IBusinessAssociate
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public double PurchaseAmount
        {
            get { return 3000; }
        }
        public int Id
        {
            get { return VendorId; }
            set { VendorId = value; }
        }
        public double TotalAmount()
        {
            return PurchaseAmount;
        }
    }
    public class Interface
    {
        public static void TestInterface()
        {
            Consumer cutie = new Consumer()
            {
                ConsumerId = 101,
                Name = "Cute Dog",
                SalesRep = "Mary"
            };
            Business dusty = new Business()
            {
                BusinessId = 201,
                Name = "Dusty Dog",
                SalesRep = "Ann"
            };
            Vendor hound = new Vendor()
            {
                VendorId = 301,
                Name = "Hound Dog"
            };
            IBusinessAssociate[] associates = { cutie, dusty, hound };
            Console.WriteLine("People we do business with:");
            foreach (var associate in associates)
            {
                Console.WriteLine($"{associate.Id}\t{associate.Name}\t{associate.TotalAmount():c}\t{associate.GetType().Name}");
            }
        }
    }
}
