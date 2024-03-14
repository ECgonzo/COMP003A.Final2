/*
 * Author: Ethen Gonzalez
 * Course: COMP003A
 * Purpose: Dating App - New User Profile Final Project
 */

namespace COMP003A.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User Input Section
            string firstName, lastName, gender;
            int birthYear;

            Console.WriteLine("Welcome to the Dating App New User Profile Intake Form!");
            Console.WriteLine("Please enter the following information:");

            // Method to accept and validate names
            firstName = AcceptAndValidateName("First Name: ");
            lastName = AcceptAndValidateName("Last Name: ");

            // Method to accept and validate birth year
            birthYear = AcceptAndValidateBirthYear();

            // Method to accept and validate gender
            gender = AcceptAndValidateGender();

            // The ! operator is the logical NOT operator in C#. It negates the boolean value of its operand.
            // int.TryParse() is a method used to parse a string representation of an integer into an actual integer value.
            // The out keyword is used to specify that a parameter is passed by reference and that the method will assign a value to it.
            // The || operator is the logical OR operator in C#. It's used to combine two boolean expressions. 

            List<string> questions = new List<string>
            {
                "What is your favorite hobby?",
                "What is your dream travel destination?",
                "What is your favorite movie?",
                "What do you like to do on weekends?",
                "What is your favorite meal?",
                "What is your favorite music genre?",
                "What qualities do you value in a partner?",
                "What is your idea of a perfect date?",
                "What are your career goals?",
                "What do you value most in life?"
            };

            List<string> questionnaire = new List<string>();

            Console.WriteLine("\nPlease answer the following questions:");
            for (int i = 0; i < questions.Count; i++)
            {
                Console.Write($"{questions[i]}: ");
                // Method to validate questionnaire responses
                string response = ValidateResponse();
                questionnaire.Add(response);
            }

            Console.WriteLine("\nProfile Summary:");
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetFullGenderDescription(gender)}");

            // The for loop is used to iterate over the questionnaire list, which contains the responses to the questionnaire questions. It allows us to access each response individually within the loop body and print them out.
            // questionnaire.Count is used to determine the number of elements in the questionnaire list. It represents the total number of questionnaire responses that were collected from the user.
            // Array and list indices are zero-based, meaning the first element in the list has an index of 0, the second has an index of 1, and so on. By initializing i at 0, the loop starts iterating from the first element of the questionnaire list.
            // The expression i + 1 is used to display a more user-friendly numbering for the questions and responses. 

            Console.WriteLine("\nQuestionnaire Responses:");
            for (int i = 0; i < questionnaire.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.WriteLine($"Response {i + 1}: {questionnaire[i]}");
            }
        }

        // Method to accept and validate names
        static string AcceptAndValidateName(string prompt)
        {
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name) || ContainsNumberOrSpecialChar(name));
            return name;
        }

        // Method to validate birth year
        static int AcceptAndValidateBirthYear()
        {
            int birthYear;
            do
            {
                Console.Write("Birth Year: ");
                if (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalid input. Please enter a valid birth year.");
                }
            } while (birthYear < 1900 || birthYear > DateTime.Now.Year);
            return birthYear;
        }

        // Method to validate gender
        static string AcceptAndValidateGender()
        {
            string gender;
            do
            {
                Console.Write("Gender (M/F/O): ");
                gender = Console.ReadLine().ToUpper();
            } while (gender != "M" && gender != "F" && gender != "O");
            return gender;
        }

        // Method to validate questionnaire responses
        static string ValidateResponse()
        {
            string response;
            do
            {
                response = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(response));
            return response;
        }

        // Data Validation method
        static bool ContainsNumberOrSpecialChar(string input)
        {
            foreach (char c in input)
            {
                if (char.IsNumber(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                    return true;
            }
            return false;
        }

        // Full Gender Description method
        static string GetFullGenderDescription(string gender)
        {
            switch (gender)
            {
                case "M":
                    return "Male";
                case "F":
                    return "Female";
                case "O":
                    return "Other";
                default:
                    return "Unknown";
                    // Unreachable code, but kept for completeness. Unnecessary in terms of program flow, it can act as a form of defensive programming, ensuring that the method always returns a value even in unexpected scenarios.
            }
        }
    }
}