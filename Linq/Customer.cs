using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public float TotalSales { get; set; }
        public float Balance { get; set; }
        public Customer() : this(1, "Knows", "Nobody", "Richmond", "VA", 0.0f, 0.0f) { }
        public Customer(int customerId, string lastName, string firstName,
            string city, string state, float totalSales, float balance)
        {
            CustomerId = customerId;
            LastName = lastName;
            FirstName = firstName;
            City = city;
            State = state;
            TotalSales = totalSales;
            Balance = balance;
        }
        public static List<Customer> Load()
        {
            return new List<Customer>()
            {
                new Customer(101, "River", "James", "Richmond", "VA", 3318.80f, 0.0f),
                new Customer(107, "Walker", "Maggie", "Richmond", "VA",  134.77f, 134.77f),
                new Customer(104, "Gaknot", "Hugh", "Montreal", "QB", 4723.28f, 194.79f),
                new Customer(103, "Franklin", "Ben", "Philadelphia", "PA", 5012.98f, 1249.71f),
                new Customer(109, "Wythe", "Skip", "Short Pump", "VA", 318.04f, 0.00f),
                new Customer(102, "Penn", "William", "Harrisburg", "PA", 4281.40f, 4018.40f),
                new Customer(105, "Syde", "Glenn", "Glenside", "NC", 2793.79f, 0.00f),
                new Customer(112, "Terson", "Pat", "Charlotte", "NC",  2148.72f, 2148.72f),
                new Customer(108, "Allen", "Glen", "Pittsburgh", "PA", 3913.08f, 193.44f),
                new Customer(111, "Ashe", "Arthur", "Flushing Meadow", "NY", 8433.39f, 0.0f)
            };
        }

    }
}
