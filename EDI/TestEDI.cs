
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace EDI
{
    /// <summary>
    // Tests Extension Methods, Delegates, and Interfaces
    /// </summary>
    public class TestEDI
    {
        delegate string Int2String(int value);
        public static void Test()
        {
            Delegate.DelegateTest();
            TestExtension();
            TestDelegate();
           TestInterface();
        }

        static void TestExtension()
        {
            WriteLine($"\n<----- Extension Test ----->");

            var name = "Isaiah Seaborne";
            var firstName = name.Left(4);
            var lastName = name.Right(4);
            WriteLine($"Name: {name}\t\tFirstName: {firstName}\t\tLastName: {lastName}");

        }
        static void TestDelegate()
        {
            WriteLine("<-------Test Delegate------->");
            Delegate.DelegateTutorial();

            //Delegate.TestDateDiff();



            Int2String zip = Zipper;
            WriteLine($"\n<----- Delegate Test ----->\nint\tZip Code");
            int zipNum = 1;
            Display(zipNum, zip); zipNum += 10;
            Display(zipNum, zip); zipNum += 100;
            Display(zipNum, zip); zipNum += 1000;
            Display(zipNum, zip); zipNum += 10000;
            Display(zipNum, zip); zipNum += 100000;
            Display(zipNum, zip);
        }
        private static string Zipper(int value)
        {

            return value.ZipCode();
 
            //return string.Empty;

        }
        private static void TestInterface()
        {
            WriteLine($"\n<----- Interface Test ----->");

            List<IBusinessAssociate> busAssoc = new List<IBusinessAssociate>();
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
                SalesRep = "Chris"
            };
            Vendor hound = new Vendor()
            {
                VendorId = 301,
                Name = "Hound Dog"
            };
            busAssoc.Add(cutie);
            busAssoc.Add(dusty);
            busAssoc.Add(hound);
            foreach (var associate in busAssoc)
            {
                WriteLine($"\t{associate.Id} + \t{associate.Name} + {associate.TotalAmount()} + { associate.GetType().Name}");
            }
            IShape square = new Square(10);
           Display(square);

        }

        private static void Display(IShape shape)
        {
            WriteLine($"area\tperimeter\n{shape.Area}\t{shape.Perimeter}");
        }

        private static void Display(int zip, Int2String zipCode)
        {
            WriteLine($"{zip}\t{zipCode(zip)}");
        }
        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public float GPA { get; set; }
            public Student() : this(1, "Nobody", 0.0f) { }
            public Student(int studentId, string name, float gpa)
            { StudentId = studentId; Name = name; GPA = gpa; }
            public static List<Student> Load()
            {
                return new List<Student>() { new Student(101, "River, James", 3.8f),
                new Student(107, "Walker, Maggie", 3.77f), new Student(104, "Gaknot, Hugh", 3.28f),
                new Student(103, "Ham, Chip N.", 2.98f), new Student(109, "Wythe, Skip", 3.04f),
                new Student(102, "de Gar, Tre", 4.00f), new Student(105, "Lake, Anna", 2.79f),
                new Student(112, "Terson, Pat", 3.72f), new Student(108, "Allen, Glen", 3.08f),
                new Student(111, "Ashe, Arthur", 3.93f) };
            }
        }
    }

    public class LinqExample
    {
        public LinqExample()
        {
            int[] numbers = { 2, 26, 75, 12, 5, 54, 30, 22, 46, 32, 93, 84, 77, 65 };
            double avgNum = numbers.Average();

            int sumTotal = numbers.Where(n => n > avgNum).Sum();

            int minNum = numbers.Where(n => n > avgNum).Min();

            int firstNum = numbers.Where(n => n > avgNum).First();
        }
    }
}
