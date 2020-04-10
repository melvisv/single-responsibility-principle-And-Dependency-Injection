using System;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(new LogFile());
            int sal = emp.CalculateSalary();

            Employee emp1 = new Employee(new DBLogger());
            int sal1 =  emp1.CalculateSalary();
        }

        public class Employee
        {
            ILogger _logger;
            public Employee(ILogger logger)
            {
                _logger = logger;
            }

            public int CalculateSalary()
            {
                int salary = 0;
                try
                {
                    salary = 50 * 10;
                    throw new Exception();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                return salary;
            }

        }


        public interface ILogger
        {
            void LogError(string message);
        }

        /// <summary>
        /// Log message to a file.
        /// </summary>
        public class LogFile : ILogger
        {
            public void LogError(string message)
            {
                Console.WriteLine("Logging error to File...");
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Logs message to Database
        /// </summary>
        public class DBLogger: ILogger
        {
            public void LogError(string message)
            {
                Console.WriteLine("Logging error to database...");
                Console.WriteLine(message);
            }
        }
    }
}
