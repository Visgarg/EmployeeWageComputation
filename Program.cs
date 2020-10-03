using System;

namespace EmployeeWageComputation
{
    class Program
    {
        
        
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
            //instatiating computeEmployeewage class class for calling calculatemonthlywage method to calculate monthlywage.
            ComputeEmployeeWage computeEmployeeWage = new ComputeEmployeeWage();
            computeEmployeeWage.CalculateMonthlyWage();

        }
        
      
    }
}
