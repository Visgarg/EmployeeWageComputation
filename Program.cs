using System;

namespace EmployeeWageComputation
{
    class Program
    {
        const int IS_PRESENT = 1;
        NLog nLog = new NLog();
        /// <summary>
        /// Main method for calling welcome message and checking employee presence.
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
         NLog nLog = new NLog();
        
            int wagePerHour = 20;
            int fullDayHour;

            Console.WriteLine("Welcome to Employee Wage computation Program");
            nLog.LogInfo("Welcome message displayed : Main()");
            //using Random method to generate random no and compare with constants to check presence.
            Random random = new Random();
            int checkIfPresent = random.Next(0, 2);
            // instatiating program class and calling WorkHours method which returns no of hours according to employee's presence.
            Program program = new Program();
            fullDayHour = program.WorkHours(checkIfPresent);
            int totalDailyWage = fullDayHour * wagePerHour;
            Console.WriteLine("Total daily wage is " + totalDailyWage);
            nLog.LogDebug("Successfully Calculated daily employee wage : Main()");
            
            
            

        }
        /// <summary>
        /// Calculating Work hours after checking presence of employee.
        /// </summary>
        /// <param name="checkIfPresent"></param>
        /// <returns></returns>
        public int WorkHours(int checkIfPresent)
        {
           
            if (checkIfPresent == IS_PRESENT)
            {
                Console.WriteLine("Employee is present");
                nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                return 8;
            }
            else
            {
                Console.WriteLine("Employee is Absent");
                return  0;
            }

        }
    }
}
