using System;

namespace EmployeeWageComputation
{
    class Program
    {
        const int IS_PRESENT = 1;
        const int IS_PART_TIME = 2;
        
        //const int IS_ABSENT = 0;
        NLog nLog = new NLog();
        /// <summary>
        /// Main method for calling welcome message and checking employee presence.
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            NLog nLog = new NLog();
            Console.WriteLine("Welcome to Employee Wage computation Program");
            nLog.LogInfo("Welcome message displayed : Main()");
            //instatiating program class for calling calculatemonthlywage method to calculate monthlywage.
            Program program = new Program();
            program.CalculateMonthlyWage();

        }
        /// <summary>
        /// calculating monthly wages of employee
        /// </summary>
        public void CalculateMonthlyWage()
        {
            int wagePerHour = 20;
            int fullDayHour;
            int workDayCount = 0;
            int noOfWorkingDays = 20;
            int totalWorkingHours = 0;
            int totalDailyWage;
            int monthlyWage;
            //calculating total monthly wage by applying while loop on working days
            while(workDayCount<noOfWorkingDays)
            {
                //using Random method to generate random no and compare with constants to check presence.
                Random random = new Random();
                int checkIfPresent = random.Next(0, 3);
                // instatiating program class and calling WorkHours method which returns no of hours according to employee's presence.
                Program program = new Program();
                fullDayHour = program.WorkHours(checkIfPresent,workDayCount);
                totalDailyWage = fullDayHour * wagePerHour;
                Console.WriteLine($"Total daily wage is for {workDayCount+1} is {totalDailyWage}");
                totalWorkingHours += fullDayHour;
                workDayCount++;
                //.LogDebug("Successfully Calculated daily employee wage : Main()");
            }
            monthlyWage = totalWorkingHours * wagePerHour;
            nLog.LogDebug("Successfully calculated monthly employee wage: calculateMonthlyWage()");
            Console.WriteLine("********************************************************************");
            Console.WriteLine("The monthly wage of an employee is " + monthlyWage);
        }



        /// <summary>
        /// Calculating Work hours after checking presence of employee.
        /// </summary>
        /// <param name="checkIfPresent"></param>
        /// <returns>int emphours</returns>
        public int WorkHours(int checkIfPresent,int workDayCount)
        {
            switch (checkIfPresent)
            {
                case IS_PRESENT:
                    Console.WriteLine($"Employee is present on {workDayCount+1} day.");
                    nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                    return 8;
                case IS_PART_TIME:
                    Console.WriteLine($"Employee is present for part time on {workDayCount+1} day.");
                    nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                    return 4;
                default:
                    Console.WriteLine($"Employee is Absent on {workDayCount+1}");
                    nLog.LogDebug("Debug successful, for employee presence: WorkHours()");
                    return 0;
            }
        }
    }
}
