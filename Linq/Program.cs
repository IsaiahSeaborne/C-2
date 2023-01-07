
//#undef Customers
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            

            //LinqNumbers();

            //LinqStudents();



             LinqCustomers();

            Console.ReadKey();
        }
        public static void LinqCustomers()
        {
            var customers = Customer.Load();
            /* Replace the "0" in the code for the next five variables */
            var totalSales = customers.Sum(s => s.TotalSales);
            var totalBalance = customers.Sum(s => s.Balance);
            var highestBalance = customers.Max(s => s.Balance);
            var averageBalance = customers.Average(s => s.Balance);
            var lowestBalance = customers.Min(s => s.Balance > 0.00);

            Console.WriteLine($"For all customers" +
                $"\nTotal Sales: {totalSales:c}" +
                $"\nTotal Balance: {totalBalance:c}" +
                $"\nHighest Balance: {highestBalance:c}" +
                $"\nAverage Balance: {averageBalance:c}" +
                $"\nLowest Balance: {lowestBalance:c}");

            /* Replace the code for the next four variables */
            var virginiaCustomers = customers.Where(s => s.State.Contains("VA"));
            var virginiaCount = virginiaCustomers.Count();
            var virginiaSales = virginiaCustomers.Sum(s => s.TotalSales);
            var virginiaAverageSales = virginiaCustomers.Average(s => s.TotalSales);

            Console.WriteLine($"\nVirginia only" +
                $"\nVirginia Count: {virginiaCount}" +
                $"\nVirginia Sales: {virginiaSales:c}" +
                $"\nVirginia Average Sales: {virginiaAverageSales:c}");
        }
       
        delegate bool IsMin(int num);
        public static bool IsMinimum(int num)
        {
            return num > 50;
        }
        public static void LinqNumbers()
        {
            int[] numbers = { 16, 32, 48, 88, 64, 8, 40, 80, 72, 56, 24 };

            var sum = numbers.Sum();
            var avg = numbers.Average();
            var max = numbers.Max();
            var min = numbers.Min();
            var first = numbers.First();
            var last = numbers.Last();
            var count = numbers.Count();

            //IsMin minn = IsMinimum;
            System.Func<int, bool> selector = delegate (int num) { return num > 50; };
            selector = IsMinimum;
            selector = (num) => num > 50;

            sum = numbers.Where(selector).Sum();

            sum = numbers.Where(num => num > 50).Sum();
            avg = numbers.Where(num => num > 50).Average();
            max = numbers.Where(num => num > 50).Max();
            min = numbers.Where(num => num > 50).Min();
            first = numbers.Where(num => num > 50).First();
            last = numbers.Where(num => num > 50).Last();
            count = numbers.Where(num => num > 50).Count();

            var sorted = numbers.OrderBy(num => num);
            sorted = numbers.OrderByDescending(num => num);

            int x = 0;
            var array = numbers.Where(num => num > x);
            x = 80;
            sum = array.Sum();
        }
        private static int SumNumbers(int[] numbers)
        {
            int total = 0;
            foreach (var num in numbers)
                total += num;
            return total;
        }
        public static void LinqStudents()
        {
            var students = Student.Load();
            var count = students.Count();
            var sum = students.Sum(s => s.GPA);
            var avg = students.Average(s => s.GPA);
            var max = students.Select(s => s.GPA).Max();
            var first = students.First(s => s.Name.Contains("J"));
            var last = students.Last();
        }
        
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }
        public Student() : this(1, "Nobody", 0.0f) { }
        public Student(int studentId, string name, float gpa)
        {
            StudentId = studentId;
            Name = name;
            GPA = gpa;
        }
        public static List<Student> Load()
        {
            return new List<Student>()
            {
                new Student(101, "River, James", 3.8f),
                new Student(107, "Walker, Maggie", 3.77f),
                new Student(104, "Gaknot, Hugh", 3.28f),
                new Student(103, "Ham, Chip N.", 2.98f),
                new Student(109, "Wythe, Skip", 3.04f),
                new Student(102, "de Gar, Tre", 4.00f),
                new Student(105, "Lake, Anna", 2.79f),
                new Student(112, "Terson, Pat", 3.72f),
                new Student(108, "Allen, Glen", 3.08f),
                new Student(111, "Ashe, Arthur", 3.93f)
            };
        }
        public static bool IsVA(string sta)
        {
            return sta == "VA";
        }
        //public static void LinqCustomers()
        //{
        //    var customers = Customer.Load();
        //    var count = customers.Count();
        //    var sumSales = customers.Sum(s => s.TotalSales);
        //    var sumBalance = customers.Sum(s => s.Balance);
        //    var highBalance = customers.Max(s => s.Balance);
        //    var lowBalance = customers.Min(s => s.Balance);
        //    var avgBalance = customers.Average(s => s.Balance);
        //    var lowestthanBalance = customers.Min(s => s.Balance > 0.00);

        //    //For Virginia

        //    var arrayVA = customers.Where(s => s.State.Contains("VA"));

        //    var countVA = arrayVA.Count();
        //    var sumSalesVA = arrayVA.Sum(s => s.TotalSales);
        //    var averageSalesVA = arrayVA.Average(s => s.TotalSales);
            
        //}
    }
}
