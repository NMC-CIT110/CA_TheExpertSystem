﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_TheExpertSystem
{

    // *************************************************************
    // Application:     The Expert System
    // Author:          Velis, John E
    // Description:     An application that has a conversation with the user
    //                  about getting a loan. Console properties are controlled.
    // Date Created:    5/20/2019
    // Date Revised:    12/20/2019
    // *************************************************************

    class Program
    {
        static void Main(string[] args)
        {
            //
            // screen configurations
            // set screen colors for the theme
            // 
            ConsoleColor openingClosingScreenBackground = ConsoleColor.Gray;
            ConsoleColor openingClosingScreenForeground = ConsoleColor.DarkRed;
            ConsoleColor appScreenBackground = ConsoleColor.White;
            ConsoleColor appScreenForeground = ConsoleColor.DarkBlue;

            //
            // constants
            //
            const double INTEREST_RATE_HOME = 0.035;
            const double INTEREST_RATE_VEHICLE = 0.06;
            const double INTEREST_RATE_COLLEGE = 0.075;
            const double INTEREST_RATE_PERSONAL = 0.08;

            //
            // variables
            //
            string userName;
            string bankChoice;
            string typeOfLoan;
            string userResponse;

            double loanPrinciple;
            double monthlyInterestRate;
            int loanTermYears;
            int loanTermMonths = 0; // for precompiler check
            double monthlyPayment = 0; // for precompiler check

            bool validResponse;


            //
            //      **********************
            //      *   Opening Screen   *
            //      **********************
            //
            // set cursor invisible, background colors, foreground colors, and clear screen
            //
            Console.CursorVisible = false;
            Console.BackgroundColor = openingClosingScreenBackground;
            Console.ForegroundColor = openingClosingScreenForeground;
            Console.Clear();


            //
            // display a opening screen
            // 
            Console.WriteLine();
            Console.WriteLine("\t\tThe Loan Consultant");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();

            //
            //      ***************************
            //      *   Initial User Screen   *
            //      ***************************
            //
            // set cursor invisible, background colors, foreground colors, and clear screen
            //
            Console.CursorVisible = true;
            Console.BackgroundColor = appScreenBackground;
            Console.ForegroundColor = appScreenForeground;
            Console.Clear();

            //
            // greet the user
            //
            Console.WriteLine();
            Console.WriteLine(" Hello!");
            Console.WriteLine(" This application is designed to calculate monthly loan payments.");

            //
            // get the user's name and echo it back
            //
            Console.WriteLine();
            Console.Write(" What is your name? ");
            userName = Console.ReadLine();
            Console.WriteLine(" It is nice to meet you " + userName + ".");

            //
            // other methods to embed variables in a string
            //
            //Console.WriteLine("It is nice to meet you {0}.", userName);
            //Console.WriteLine($"It is nice to meet you {userName}.");

            //
            // determine if the user is looking for a loan
            //
            Console.WriteLine();
            Console.Write($" Are you interested in getting a loan {userName}?");
            userResponse = Console.ReadLine();

            //
            // get more information if the user is looking for a loan
            //
            if (userResponse == "yes")
            {
                //
                //      *******************************
                //      *   User Information Screen   *
                //      *******************************
                //
                // set cursor visible and clear screen
                //
                Console.CursorVisible = true;
                Console.Clear();

                //
                // display header
                //
                Console.WriteLine();
                Console.WriteLine("\t\tLoan Information");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" Well you have come to the right place.");
                Console.WriteLine();
                Console.WriteLine(" I will need to get some more information from you and then I can calculate your monthly payment.");

                //
                // get user bank info
                //
                Console.WriteLine();
                Console.Write(" What is the name of the bank you will applying to for the loan?");
                bankChoice = Console.ReadLine();
                Console.WriteLine(" Very good {0}, you will be getting a loan from {1}.", userName, bankChoice);

                //
                // get the user's type of loan and validate response
                //
                do
                {
                    validResponse = true;

                    //
                    //      *******************************
                    //      *   Type of Loan              *
                    //      *******************************
                    //
                    // set cursor visible and clear screen
                    //
                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //
                    Console.WriteLine();
                    Console.WriteLine("\t\tType of Loan");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine(" Please tell me the type of loan you are seeking so that I can determine the interest rate.");
                    Console.WriteLine("\t\"Home\"  \"Vehicle\"  \"College\"  \"Personal\"");
                    Console.Write(" Enter loan type:");
                    typeOfLoan = Console.ReadLine().ToLower(); // set typeOfLoan string to all lower case to compare in the if statement

                    if (typeOfLoan != "home" && typeOfLoan != "vehicle" && typeOfLoan != "college" && typeOfLoan != "personal")
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("It appears you entered an invalid loan type. Please reenter your loan type.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to continue.");
                        Console.ReadKey();
                    }

                } while (!validResponse);


                //
                // get the principle of the loan and validate
                //
                do
                {
                    validResponse = true;

                    //
                    //      *******************************
                    //      *   Principle of Loan         *
                    //      *******************************
                    //
                    // set cursor visible and clear screen
                    //
                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //
                    Console.WriteLine();
                    Console.WriteLine("\t\tPrinciple of Loan");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.Write(" Please tell me the amount of the loan.");
                    Console.Write(" Enter loan amount:");
                    userResponse = Console.ReadLine();

                    if (!double.TryParse(userResponse, out loanPrinciple))
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("It appears you entered an invalid number for the principle. Please enter a positive number.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to continue.");
                        Console.ReadKey();
                    }
                } while (!validResponse);


                //
                // get the length of the loan and validate
                //
                do
                {
                    validResponse = true;

                    //
                    //      *******************************
                    //      *      Length of Loan         *
                    //      *******************************
                    //
                    // set cursor visible and clear screen
                    //
                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //
                    Console.WriteLine();
                    Console.WriteLine("\t\tLength of Loan");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.Write(" Please tell me the length of the loan in years.");
                    Console.Write(" Enter loan length:");
                    userResponse = Console.ReadLine();

                    if (!int.TryParse(userResponse, out loanTermYears))
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("It appears you entered an invalid number for the years. Please enter a positive number.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        loanTermMonths = loanTermYears * 12;
                    }

                } while (!validResponse);

                //
                // assign the interest rate based on the loan type
                //
                switch (typeOfLoan)
                {
                    case "home":
                        monthlyInterestRate = INTEREST_RATE_HOME / 12;
                        break;

                    case "vehicle":
                        monthlyInterestRate = INTEREST_RATE_VEHICLE / 12;
                        break;

                    case "college":
                        monthlyInterestRate = INTEREST_RATE_COLLEGE / 12;
                        break;

                    case "personal":
                        monthlyInterestRate = INTEREST_RATE_PERSONAL / 12;
                        break;

                    default:
                        monthlyInterestRate = 0;
                        break;
                }

                if (monthlyInterestRate != 0.0)
                {
                    //
                    // calculate the monthly payments
                    //
                    double factor = (monthlyInterestRate * (Math.Pow(monthlyInterestRate + 1, loanTermMonths))) / (Math.Pow(monthlyInterestRate + 1, loanTermMonths) - 1);
                    monthlyPayment = loanPrinciple * factor;
                }

                //
                //      *******************************
                //      *      Monthly Payments       *
                //      *******************************
                //
                // set cursor visible and clear screen
                //
                Console.CursorVisible = true;
                Console.Clear();

                //
                // display header
                //
                Console.WriteLine();
                Console.WriteLine("\t\tMonthly Payments");
                Console.WriteLine();

                Console.WriteLine($"Loan for {userName}.");
                Console.WriteLine();
                //
                // code to take a single word to proper case
                //
                string typeOfLoanProperCase = typeOfLoan.Substring(0, 1).ToUpper() + typeOfLoan.Substring(1).ToLower();
                Console.WriteLine($"Type: {typeOfLoanProperCase}");
                Console.WriteLine($"Rate: {monthlyInterestRate * 12:p}");
                Console.WriteLine($"Principle: {loanPrinciple:c}"); // currency format
                Console.WriteLine($"Years: {loanTermYears}");
                Console.WriteLine($"Monthly Payments: {monthlyPayment:c}"); // currency format

                //
                // pause the app for the user
                //
                Console.WriteLine();
                Console.WriteLine("\tPress any key to continue.");
                Console.ReadKey();


                //
                //      *******************************
                //      *    Amortization Table       *
                //      *******************************
                //
                // set cursor visible and clear screen
                //
                Console.CursorVisible = true;
                Console.Clear();

                //
                // display header
                //
                Console.WriteLine();
                Console.WriteLine("\t\tAmortization Table");
                Console.WriteLine();

                //
                // display table headers
                //
                Console.WriteLine(
                    "Month".PadLeft(5) +
                    "Current Balance".PadLeft(20) +
                    "Payment".PadLeft(10) +
                    "Interest".PadLeft(10) +
                    "Principle".PadLeft(10) +
                    "New Balance".PadLeft(20)
                    );

                //
                // display table values
                //
                double currentBalance = loanPrinciple;
                double newBalancee;
                double monthlyPrinciple;
                double monthlyInterest;
                for (int month = 1; month <= loanTermMonths; month++)
                {
                    monthlyInterest = currentBalance * monthlyInterestRate;
                    monthlyPrinciple = monthlyPayment - monthlyInterest;
                    newBalancee = currentBalance - monthlyPrinciple;
                    Console.WriteLine(
                        month.ToString().PadLeft(5) +
                        currentBalance.ToString("C2").PadLeft(20) +
                        monthlyPayment.ToString("C2").PadLeft(10) +
                        monthlyInterest.ToString("C2").PadLeft(10) +
                        monthlyPrinciple.ToString("C2").PadLeft(10) +
                        newBalancee.ToString("C2").PadLeft(20)
                        );
                    currentBalance = newBalancee;
                }

                //
                // pause the app for the user
                //
                Console.WriteLine();
                Console.WriteLine("\tPress any key to continue.");
                Console.ReadKey();

            }
            //
            // user not interested in the loan, thank them
            //
            else
            {
                //
                //      **********************************
                //      *   User Not Interested Screen   *
                //      **********************************
                //
                // set cursor visible and clear screen
                //

                Console.CursorVisible = true;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($" I am sorry you are not looking for a loan {userName}, but this application ");
                Console.WriteLine(" is for people interested in the monthly payments for a specific loan.");
                Console.WriteLine(" Have a nice day.");

                //
                // display a prompt to exit the application
                //
                Console.WriteLine();
                Console.WriteLine(" Press any key to continue.");
                Console.ReadKey();
            }

            //
            //      **********************
            //      *   Closing Screen   *
            //      **********************
            //
            // set cursor invisible, background colors, foreground colors, and clear screen
            //
            Console.CursorVisible = false;
            Console.BackgroundColor = openingClosingScreenBackground;
            Console.ForegroundColor = openingClosingScreenForeground;
            Console.Clear();

            //
            // display a closing screen
            // 
            Console.WriteLine();
            Console.WriteLine("\t\tThank You for Your Interest in Our Application");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to exit.");
            Console.ReadKey();
        }
    }
}
