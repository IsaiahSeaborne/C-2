using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
//using Sales;

namespace CsvXmlUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var xdoc = Extract();
            //var salesOrders = Transform();
            //Load(salesOrders);
            Console.ReadKey();
        }
        /// <summary>
        /// Extract sales orders from the Database into an XML file
        /// </summary>
        /// <returns></returns>
        //static XDocument Extract()
        //{
        //    var xdoc = SalesOrder.ToXml();
        //    return xdoc;
        //}

        /// <summary>
        /// Transform the XML file into POCOs
        /// </summary>
        /// <returns></returns>
        //static List<SalesOrder> Transform()
        //{
        //    var xdoc = XDocument.Load("XML/SalesOrders.XML");
        //    var xmlSalesOrders = xdoc.Descendants("SalesOrder");
        //    var salesOrders = new List<SalesOrder>();
        //    foreach (var xmlSO in xmlSalesOrders)
        //    {
        //        var so = SalesOrder.FromXml(xmlSO);
        //        salesOrders.Add(so);
        //        Console.WriteLine($"{so.SalesOrderNumber}\t{so.SalesStatusId}\t{so.OrderTotal:c}");
        //    }
        //    return salesOrders;
        //}


        /// <summary>
        /// Load POCOs to the CSV file
        /// </summary>
        /// <param name="salesOrders"></param>
        //static void Load(List<SalesOrder> salesOrders)
        //{
        //    using (StreamWriter file = new StreamWriter(@"SalesOrders.txt"))
        //    {
        //        foreach (var salesOrder in salesOrders)
        //        {
        //            file.WriteLine(salesOrder.ToCsv());
        //        }
        //    }
        //}
    }
}
