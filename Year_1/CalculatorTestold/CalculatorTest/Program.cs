﻿using CalculatorStaffSolution;
using CalculatorTestFinal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    class Program
    {
        /// <summary>
        /// Our main method for this project will run a series of tests against a completed
        /// calculator solution.  You can then find out how well your solution is performing against
        /// the test we are running here.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            FinalCalculatorTester calcTest = new FinalCalculatorTester();

            Console.WriteLine("BASIC TESTS\n-----------");
            double scorePart1 = calcTest.RunBasicTests();
            double scorePart1Weighted = scorePart1 * CalculatorFinal.WeightingBasic;
            Console.WriteLine("Success Rate for Basic Tests = " + scorePart1*100 + "%");
            Console.WriteLine("Score Towards Grade for Basic Tests (MAX=" + CalculatorFinal.WeightingBasic * 100 + "%) = " + scorePart1Weighted*100+"%");

            Console.WriteLine("\n\nADVANCED TESTS\n-----------");
            double scorePart2 = calcTest.RunAdvancedTests();
            double scorePart2Weighted = scorePart2 * CalculatorFinal.WeightingAdvanced;
            Console.WriteLine("Success Rate for Advanced Tests = " + scorePart2 * 100 + "%");
            Console.WriteLine("Score Towards Grade for Advanced Tests (MAX=" + CalculatorFinal.WeightingAdvanced * 100 + "%) = " + scorePart2Weighted * 100 + "%");

            Console.WriteLine("\n\nCOMBO TESTS\n-----------");
            double scorePart3 = calcTest.RunComboTests();
            double scorePart3Weighted = scorePart3 * CalculatorFinal.WeightingCombos;
            Console.WriteLine("Success Rate for Combo Tests = " + scorePart3 * 100 + "%");
            Console.WriteLine("Score Towards Grade for Combo Tests (MAX=" + CalculatorFinal.WeightingCombos * 100 + "%) = " + scorePart3Weighted * 100 + "%");

            Console.WriteLine("\n\nOVERFLOW TESTS\n-----------");
            double scorePart4 = calcTest.RunOverflowTests();
            double scorePart4Weighted = scorePart4 * CalculatorFinal.WeightingOverflows;
            Console.WriteLine("Success Rate for Overflow Tests = " + scorePart4 * 100 + "%");
            Console.WriteLine("Score Towards Grade for Overflow Tests (MAX=" + CalculatorFinal.WeightingOverflows * 100 + "%) = " + scorePart4Weighted * 100 + "%");

            Console.WriteLine("\n\nTOTAL\n-----------");
            double finalScore = scorePart1Weighted + scorePart2Weighted + scorePart3Weighted + scorePart4Weighted;
            Console.WriteLine("Total Sucess Rate For Tests: " + finalScore * 100 + "%");
            Console.WriteLine("FINAL CONTRIBUTION TO TOTAL GRADE: " + (finalScore * 0.8) * 100 + "%");
        }
    }
}
