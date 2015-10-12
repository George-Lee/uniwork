using CalculatorStaffSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorSolution
{
    class SimpleCalculatorTester
    {
        const int TestCount = 1000;
        Random random;

        CalculatorFinal staffCalculator;
        Calculator studentCalculator;

        /// <summary>
        /// Standard constructor.
        /// Prepares the two calculator instances.
        /// </summary>
        public SimpleCalculatorTester()
        {
            staffCalculator = new CalculatorFinal();
            studentCalculator = new Calculator();
            random = new Random();
        }

        /// <summary>
        /// Given a particular operation, this will run a simple
        /// calculation using the students own calculator and compare
        /// the result against a pre-written solution.
        /// </summary>
        /// <param name="operation">The operation you wish to run.</param>
        /// <returns>The success rate for this type of operation as a percentage.</returns>
        private double RunBasicTest(char operation)
        {
            double successRate = 0.0;

            for (int i = 0; i < TestCount; i++)
            {
                //Generates two random numbers for this operation.
                int number1 = random.Next(int.MaxValue);
                int number2 = random.Next(int.MaxValue);

                //Run the first test against the student solution.
                string result1 = string.Empty;
                studentCalculator.Calculate(number1, operation);
                result1 = studentCalculator.Calculate(number2, '=');

                //Run the second test against a staff solution.
                string result2 = string.Empty;
                staffCalculator.Calculate(number1, operation);
                result2 = staffCalculator.Calculate(number2, '=');

                //Naturally, if your answer is correct, this will increase.
                if (result1.Equals(result2))
                {
                    successRate++;
                }

            }

            return ((successRate/TestCount)*100);
        }

        private double RunAdvancedTest(char operation, char terminus)
        {
            double successRate = 0.0;

            for (int i = 0; i < TestCount; i++)
            {
                //Generates two random numbers for this operation.
                int number1 = random.Next(int.MaxValue);
                int number2 = random.Next(int.MaxValue);

                //Run the first test against the student solution.
                string result1 = string.Empty;
                studentCalculator.Calculate(number1, operation);
                result1 = studentCalculator.Calculate(number2, terminus);

                //Run the second test against a staff solution.
                string result2 = string.Empty;
                staffCalculator.Calculate(number1, operation);
                result2 = staffCalculator.Calculate(number2, terminus);

                //Naturally, if your answer is correct, this will increase.
                if (result1.Equals(result2))
                {
                    successRate++;
                }

            }

            return ((successRate / TestCount) * 100);
        }

        /// <summary>
        /// Our main method for this project will run a series of tests against a completed
        /// calculator solution.  You can then find out how well your solution is performing against
        /// the test we are running here.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            SimpleCalculatorTester calcTest = new SimpleCalculatorTester();

            Console.WriteLine(calcTest.RunBasicTest('+') + "%");
            Console.WriteLine(calcTest.RunBasicTest('-') + "%");
            Console.WriteLine(calcTest.RunBasicTest('*') + "%");
            Console.WriteLine(calcTest.RunBasicTest('/') + "%");
            //Advanced functions
            Console.WriteLine(calcTest.RunBasicTest('^') + "%");
            Console.WriteLine(calcTest.RunBasicTest('%') + "%");

            //basic fuctions with advanced terminus
            Console.WriteLine(calcTest.RunAdvancedTest('+', '\\') + "%");
            Console.WriteLine(calcTest.RunAdvancedTest('+', '!') + "%");
            
        }
    }
}
