

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EmployeePay
{
    public class EmployeeTest
    {
        public static void Test()
        {

            var employees = new List<Employee>();
            employees.AddRange(LoadHourly());
            employees.AddRange(LoadSales());
            employees.AddRange(LoadSalary());
            WriteLine($"Type\tEmployee\tHire Date\tPay");
            WriteLine($"------\t----------\t-----------\t--------");
            foreach (var employee in employees)
                DisplayEmployee(employee);

        }

static void DisplayEmployee(Employee emp)
        {
            var type = emp.GetType();

            WriteLine($"{type.Name}\t{emp.FirstName} {emp.LastName}\t{emp.HireDate:d}\t{emp.Pay:c}");
    }
    static List<Hourly> LoadHourly()
        {
            var hourlies = new List<Hourly>();

            hourlies.Add(new Hourly()
            {
                EmployeeId = 101,
                FirstName = "James",
                LastName = "River",
                HireDate = new DateTime(1988, 06, 07),
                Hours = 39.5,
                HourlyRate = 10
            });
            hourlies.Add(new Hourly()
            {
                EmployeeId = 102,
                FirstName = "Hugh",
                LastName = "Gaknot",
                HireDate = new DateTime(1980, 04, 17),
                Hours = 40,
                HourlyRate = 11
            });
            hourlies.Add(new Hourly()
            {
                EmployeeId = 103,
                FirstName = "Maggie",
                LastName = "Walker",
                HireDate = new DateTime(1977, 07, 27),
                Hours = 41,
                HourlyRate = 12
            });

            return hourlies;
        }
        static List<Sales> LoadSales()
        {
            var sales = new List<Sales>();

            sales.Add(new Sales()
            {
                EmployeeId = 201,
                FirstName = "Skip",
                LastName = "Wythe",
                HireDate = new DateTime(1988, 06, 07),
                Draw = 1200,
                CommissionRate = 8.5,
                GrossSales = 12000
            });
            sales.Add(new Sales()
            {
                EmployeeId = 202,
                FirstName = "Pat",
                LastName = "Terson",
                HireDate = new DateTime(1980, 04, 17),
                Draw = 1500,
                CommissionRate = 7.5,
                GrossSales = 15000
            });
            sales.Add(new Sales()
            {
                EmployeeId = 203,
                FirstName = "Chip",
                LastName = "Enham",
                HireDate = new DateTime(1977, 07, 27),
                Draw = 0,
                CommissionRate = 12.5,
                GrossSales = 20000
            });

            return sales;
        }
        static List<Salary> LoadSalary()
        {
            var salaries = new List<Salary>();

            salaries.Add(new Salary()
            {
                EmployeeId = 301,
                FirstName = "Glen",
                LastName = "Syde",
                HireDate = new DateTime(1988, 06, 07),
                MonthlySalaryAmount = 2200,
                Bonus = 505.05
            });
            salaries.Add(new Salary()
            {
                EmployeeId = 302,
                FirstName = "Henri",
                LastName = "Koh",
                HireDate = new DateTime(1980, 04, 17),
                MonthlySalaryAmount = 3250,
                Bonus = 750.75
            });
            salaries.Add(new Salary()
            {
                EmployeeId = 303,
                FirstName = "Jay",
                LastName = "Sarge",
                HireDate = new DateTime(1977, 07, 27),
                MonthlySalaryAmount = 5000,
                Bonus = 0
            });

            return salaries;
        }

    }
}

