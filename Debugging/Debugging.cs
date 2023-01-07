using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugging
{
    public static class Debugging
    {
        static int[] numbers = { 14, 35, 70, 63, 28, 7, 0, 42, 56, 49, 21 };
        static DateTime date = DateTime.Now;
        static string[] names = { "Adam", "Emily", "Evelyn", "Eamon" };

        public static void Test()
        {
            Breakpoint();
            //MoreBreakpoint();
            //StepInStepOver();
            //LocalsWindow();
            //CallStack();
            //ImmediateWindow();
            Console.ReadLine();
        }
        private static void Breakpoint()
        {
            int total = 0;
            double average = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                /* Add a breakpoint on the next line of code by:
                 * keying F9 or 
                 * by clicking in the gray area to the left of the line or
                 * by clicking Debug / Toggle Breakpoint on the Menu .
                 * The line is highlighted in red
                 */
                total += numbers[i];        //--< Pres F10 to execute this line of code <<<
                average = total / i + 1;    //--< Notice in the "Locals" window below that toal changes to red and the value to 10 <<<
                /* Press F5 to Continue executing, or click the "Continue" button above */
                /* Note that an exception is thrown on the "average = ..." line of code 
                 * Examine the code by hovering your mouse over the variable "i". It is 0.
                 * Change the line to be "average = total / (i + 1)
                 */

                /*  Click on the line above that has a breakpoint. Press F9 to toggle the breakpoint off
                 *  Hover your mouse beside the closing bracket below "}". Notice the green right-arrow to the left of it.
                 *  Click on the green arrow and the program runs to that point and stops.   
                 *  
                 *  Press F5 to complete the execution 
                 */
            }
            Console.WriteLine($"Total: {total}\t\tAverage: {average}");
        }
        private static void MoreBreakpoint()
        {
            int total = 0;
            double average = 0;
            /* Press F5 to start the program. The program runs fine, then crashes.
             * Why does it work and then stop working? Let's examine the code.
             * Put a Breakpoint on the "average = total ..." line and restart the Program (F5)
             * 
             * The Program stops at each line, even the ones that don't cause a problem. This is tedious.
             * R-Click the red dot on the left side and choose "Conditions"
             * In the rightmost text box under "Conditions", enter "i == 6" and click "Close". Press F5
             * Note that it runs until the variable "i" = 6, then stops.
             * 
             * Use your mouse to "grab" the yellow arrow on the left side and drag it down one line, then release it.
             * This skips the offending line of code and moves the execution point to the next line.
             * This does not solve our problem, but allows us to continue. 
             * Note that the yellow arrow can be moved up as well as long as it stays in the current executing block of code.
             * Press F5 to continue
             * 
             * To fix the Divide by 0 problem, we add an "if statement" around the "average = ... and the "Console.Write.." lines
             * Note: In class I will show a nice way to do this.
             */

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                total += number;
                average = total / number;
                Console.WriteLine($"{i}\t\t{number}\t\tTotal: {total}\t\tAverage: {average}");
            }
        }
        private static void LocalsWindow()
        {

            /* Testing various values that are hard to simulate
             * 
             * Add a Breakpoint on the "Console.Write ..." line of code below
             * Press F5 to start the program. 
             * R-Click the "name" variable below. Choose "Quick watch"
             * Under "Value", 2xClick the name "Adam" and change it to your name. 
             * Now we can test a condition that may be hard to simulate in actual testing.
             * 
             * Press F5 again
             * R-Click the variable "name" again and choose "Add Watch".
             * Now the "watch" stays there across multiple tests.
             */
            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }

        }
        private static void CallStack()
        {
            /*  The "stack" shows the methods that were called to get to the current executable line of code.
             *  Add a Breakpoint to the "foreach ..." line of code below.
             *  
             *  Examine the "Call Stack" window below.
             *  The red / yellow arrow shows the current method and how we got there in reverse order.
             *      We first called method "Main". Notice the line number as well and see in the Main method. 
             *      It points to the CallStack method
             *      Next we called "CallStack".
             *  
             *  Remove the BreakPoint and add one on the "LocalsWindow" call below. 
             *  Press F5 to continue
             *  Press F11 to Step Into the LocalsWindows method. Examine the "Call Stack" again.
             *  Do you see the change?
             */
            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
            LocalsWindow();
        }
        private static void StepInStepOver()
        {
            /*  In the Main() method, add a Breakpoint to the line that calls this method
             *  Press F5. When the Program stops at the Breakpoint, Press F10.
             *  This "Steps Over" the method, executes it, and returns to the next lihe
             *  
             *  Run the program again (F5), stopping at the same line of code.
             *  This time, press F11. This "Steps Into" the method and stops at the first
             *      line in the method.
             * 
             */

            foreach (var name in names)
                Console.WriteLine($"{name}");
        }
        private static void ImmediateWindow()
        {
            /*  Add a Breakpoint on the line "int i = ..." below.
             *  Press F5 to start the program
             *  Press F10 after it breaks at the Breakpoint
             *  Open the "Immediate Window" on the lower right corner (same as the Stack Trace area).
             *  Type "i" and hit enter. The number 99 displays showing the value of i.
             *  Type "names[3]". The name "Ann" appears.
             *  Type 7 + 10 / 2 + 5. The number 17 shows.
             *  
             * 
             */
#pragma warning disable 0219
            int i = 99;
#pragma warning restore 0219
        }
    }
}
