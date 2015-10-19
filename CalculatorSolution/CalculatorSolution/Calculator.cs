// Look at Terminal Operations

using CalculatorStaffSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorSolution
{
    /// <summary>
    /// This is the calculator class that you will use to complete your assignment.  Note that
    /// certain methods have already been crafted.  This provides some input on how to 
    /// proceed with this assessed component.
    /// 
    /// Good luck!
    /// 
    /// Tommy and Dave.
    /// </summary>
    public class Calculator
    {
        /**
         * Here are some basic variables to help us get running.
         */
        double accumulator;
        double previousOperand;
        char previousOperation;
        const string Error = "ERROR";

        /**
         * We have a collection of other useful boolean variables here.  You can try to
         * use these as part of your work to dicate the structure of execution.
         */
        bool errorFound;
        bool calculationStarted;
        bool awaitingOperation;
        bool calculationComplete;

        /// <summary>
        /// Moves through the next step of the calculators process.
        /// </summary>
        /// <param name="operand">The number that a particular operation is committed to.</param>
        /// <param name="operation">The next operation we wish to run.</param>
        /// <returns>The current value of the calculation.</returns>
        public string Calculate(double operand, char operation)
        {
            //Assume no failure until we find one!
            errorFound = false;
            calculationComplete = false;
            //Run any pending calculations
            if (awaitingOperation)
            {
                //Run the operation we still need to run.
                RunOperation(operand, previousOperation);
            }

            //Run any terminal operations (e.g. =) if needed.
            if (IsTerminalOperation(operation))
            {
                RunTerminalOperation(operation);

                //We won't be awaiting further computation.
                awaitingOperation = false;

                //And this calculation is done!
                calculationComplete = true;
            }
            else
            {
                //Store the operator and set the output.
                previousOperand = operand;
                previousOperation = operation;
                awaitingOperation = true;
            }

            //Run either an error or the actual output.
            if (errorFound)
            {
                ResetCalculator();
                return Error;
            }
            else
            {
                if (calculationComplete)
                {
                    string result = accumulator.ToString();
                    ResetCalculator();
                    return result;
                }
                else
                {
                    return accumulator.ToString();
                }
            }
        }

        private void ResetCalculator()
        {
            //Reset all of the variables that you need for this calculator.
            previousOperand = 0;
            errorFound = false;
            calculationComplete = false;
        }


        /// <summary>
        /// Determines whether a calculator operation is terminal.
        /// </summary>
        /// <param name="operation">The operator in question.</param>
        /// <returns>True if terminal, false otherwise.</returns>
        private bool IsTerminalOperation(char operation)
        {
            if (operation == '=' || operation == '!' || operation == '\\')
            {
                return true;
            }

            return false;
        }

        private void RunTerminalOperation(char operation)
        {
            double result = 0;

            switch (operation)
            {
                case '!':
                    int accum = Convert.ToInt32(accumulator);
                    if (accum > 0)
                    {
                        Console.WriteLine("Not less than 0 {0} | {1}", accumulator, accum);
                        result = Factorial(accum);
                        accumulator = result;
                    }
                    else
                    {
                        Console.WriteLine("Less than 0 {0}", accum);
                        errorFound = true;
                        break;
                    }
                    break;
                case '\\':
                    if (accumulator <= 0)
                    {
                        errorFound = true;
                        break;
                    }
                    else
                    {
                        result = Root(accumulator);
                        accumulator = result;
                    }   
                    break;
                case '=':
                default: break;
            }
        }


        /// <summary>
        /// Figures out which is the calculation that we need to
        /// complete and then runs it.
        /// </summary>
        /// <param name="operand">The operand from the last statement.</param>
        /// <param name="operation">The operation we wish to run.</param>
        private void RunOperation(double operand, char operation)
        {
            double result = 0;

            double input = SelectInput();

            switch (operation)
            {
                case '+':
                    result = Add(input, operand);
                    accumulator = result;
                    break;
                case '-':
                    result = Subtract(input, operand);
                    accumulator = result;
                    break;
                case '*':
                    result = Multiply(input, operand);
                    accumulator = result;
                    break;
                case '/':
                    if (operand == 0)
                    {
                        errorFound = true;
                        break;
                    }
                    else
                    {
                        result = Divide(input, operand);
                        accumulator = result;
                        break;
                    }
                case '^':
                    result = Power(input, operand);
                    accumulator = result;
                    break;
                case '%':
                    if (operand == 0)
                    {
                        errorFound = true;
                        break;
                    }
                    else
                    {
                        result = Modulus(input, operand);
                        accumulator = result;
                        break;
                    } 
                default: break;
            }
        }

        /// <summary>
        /// Decides which input is the one needed for this 
        /// calculation?
        /// </summary>
        /// <returns>The input we need for this calculation.</returns>
        private double SelectInput()
        {
            double input;

            //Is the input *always* going to be the previous operand?
            input = previousOperand;
            return input;
        }
        
        // Basic functions

        /// <summary>
        /// Calculates the addition of two numbers.
        /// </summary>
        /// <param name="number1">The first number in the operation.</param>
        /// <param name="number2">The second number in the operation.</param>
        /// <returns>The result of the addition, rounded to two decimal places.</returns>
        private double Add(double number1, double number2)
        {
            double result = number1 + number2;
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Calculates one number subtracted from another.
        /// </summary>
        /// <param name="number1">The first number in the operation.</param>
        /// <param name="number2">The second number in the operation.</param>
        /// <returns>The result of the subtraction, rounded to two decimal places.</returns>
        private double Subtract(double number1, double number2)
        {
            double result = number1 - number2;
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Calculates the multiplication of two numbers.
        /// </summary>
        /// <param name="number1">The first number in the operation.</param>
        /// <param name="number2">The second number in the operation.</param>
        /// <returns>The result of the multiplication, rounded to two decimal places.</returns>
        private double Multiply(double number1, double number2)
        {
            double result = number1 * number2;
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Calculates the division of one number by another.
        /// </summary>
        /// <param name="number1">The first number in the operation.</param>
        /// <param name="number2">The divisor in the operation.</param>
        /// <returns>The result of the division, rounded to two decimal places.</returns>
        private double Divide(double number1, double number2)
        {
            double result = number1 / number2;
            result = Math.Round(result, 2);
            return result;
        }


        // Advanced functions

        /// <summary>
        /// Calculates the factorial of a number through recursion.
        /// </summary>
        /// <param name="number1">The number to factor in the operation.</param>
        /// <returns>The result of the factorial.</returns>
        private int RecursiveFactiorial(int number1)
        {
            if (number1 == 0)
            {
                return 1;
            }
            return number1 * Factorial(number1 - 1);
        }

        /// <summary>
        /// Calculates the factorial of a number.
        /// </summary>
        /// <param name="number1">The number to factor in the operation.</param>
        /// <returns>The result of the factorial.</returns>
        private int Factorial(int number1)
        {
            int result = 1;
            Console.Write(number1);
            if (number1 < 13)
            {
                //number is small enough for us to use recursion, and be slightly quicker.
                result = RecursiveFactiorial(number1);
            }
            else
            {
                for (int number = 1; number <= number1; number++)
                {
                    result = result * number;
                }
            }
            Console.Write('|');
            return result;

            // No need to round this as we're dealing with integers
        }

        /// <summary>
        /// Calculates a number raised to a second number.
        /// </summary>
        /// <param name="number1">The base of the power in the operation.</param>
        /// <param name="number2">The exponent of the power in the operation.</param>
        /// <returns>The result of the exponent, rounded to two decimal places.</returns>
        private double Power(double number1, double number2)
        {
            double result = Math.Pow(number1, number2);
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Calculates the square root of a number.
        /// </summary>
        /// <param name="number1">The number to square root in the operation.</param>
        /// <returns>The result of the square root, rounded to two decimal places.</returns>
        private double Root(double number1)
        {
            double result = Math.Sqrt(number1);
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Calculates the modulus of a number by a factor.
        /// </summary>
        /// <param name="number1">The first number in the operation.</param>
        /// <param name="number2">The second number in the operation.</param>
        /// <returns>The result of the modulus, rounded to two decimal places.</returns>
        private double Modulus(double number1, double number2)
        {
            double result = number1 % number2;
            result = Math.Round(result, 2);
            return result;
        }
    }
}
