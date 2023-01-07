using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public class Delegate
    {
        delegate int DateDifference(DateTime startTime, DateTime endTime);

        public static void DelegateTest()
        {
            DateTime startTime = new DateTime(2022, 10, 1);
            DateTime endTime = new DateTime(2022, 10, 4);

            //this is a method call, you need to set this to the Program.Days 
            DateDifference code = Days;
            int diffInDays = code(startTime, endTime);

            code = Hours;
            int diffInHours = code(startTime, endTime);

            code = Minutes;
            int diffInMinutes = code(startTime, endTime);

        }

        public static int Days(DateTime startTime, DateTime endTime)
        {
            int diffInDays = (endTime.Date - startTime.Date).Days;
            return diffInDays;

        }
        public static int Hours(DateTime startTime, DateTime endTime)
        {
            int diffInHours = ((endTime.Date - startTime.Date).Days * 24);
            return diffInHours;
        }
        public static int Minutes(DateTime startTime, DateTime endTime)
        {
            int diffInMinutes = (((endTime.Date - startTime.Date).Days * 24) * 60);
            return diffInMinutes;
        }



        delegate int Numbers(int[] numbers);
        public static void DelegateTutorial()
        {
            int[] numbers = { 42, 7, 14, 63, 21, 70, 49, 28, 35, 56 };
            Numbers code = SumTheNumbers;
            int total = code(numbers);


            code = MaximumNumber;
            int max = code(numbers);

            code = delegate (int[] nums) { return nums[0]; };
            int first = code(numbers);

            Console.WriteLine($"The total is {total}");
            Console.WriteLine($"The largest number is {max}");
            Console.WriteLine($"The first number is {first}");
        }

        private static int MaximumNumber(int[] numbers)
        {
            var max = int.MinValue;
            foreach (var num in numbers)
                if (num > max)
                    max = num;
            return max;
        }
        private static int SumTheNumbers(int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
                total += num;
            return total;
        }
    }
}
