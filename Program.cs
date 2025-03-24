using System;

namespace Simple_Student_Management_Project
{
    internal class Program
    {
        // Arrays to store student data
        static double[] marks = new double[10];       // Stores student marks
        static int[] Ages = new int[10];             // Stores student ages
        static string[] names = new string[10];      // Stores student names
        static DateTime[] dates = new DateTime[10];  // Stores student enrollment dates
        static int StudentCounter = 0;               // Tracks the number of students added

        static void Main(string[] args)
        {   //============================================program Menu============================================
            while (true) 
            {
                Console.Clear(); 
                Console.WriteLine("\nChoose an Array Exercise:");
                Console.WriteLine("1. Add a new student record (Name, Age, Marks) ");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Find a student by name");
                Console.WriteLine("4. Calculate the class average");
                Console.WriteLine("5. Find the top-performing student ");
                Console.WriteLine("6. Sort students by marks (highest to lowest) ");
                Console.WriteLine("7. Delete a student record");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    // Read user input for menu choice
                    int choice = int.Parse(Console.ReadLine());

                    // Switch statement to choose the appropriate method based on the user's choice
                    switch (choice)
                    {
                        case 1: AddNewStudent(); break;       // Add a new student
                        case 2: ViewAllStudents(); break;     // View all students
                        case 3: FindStudentByName(); break;   // Find a student by name
                        case 4: CalculateClassAverage(); break; // Calculate class average
                        case 5: FindTopPerformingStudent(); break; // Find the top-performing student
                        case 6: SortStudentsByMarks(); break; // Sort students by marks
                        case 7: DeleteStudentRecord(); break; // Delete a student record
                        case 0: return; // Exit the program
                        default: Console.WriteLine("Invalid choice! Try again."); break; // for invalid choices
                    }
                }
                catch (FormatException) // Handle invalid input (not entring num)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.ReadLine(); 
            }
        }
        //============================================program Methods============================================

        //====================================================add new student ========================
        static void AddNewStudent()
        {
            try
            {
                string StudentName;
                int StudentAge = 0;
                double StudentMark = 0;
                DateTime StudentEnDate = DateTime.Now; // Set enrollment date to the current date and time

                Console.WriteLine("\nEnter Student Data :");

                // Loop to add student data
                for (int i = StudentCounter; i < names.Length; i++)
                {
                    Console.WriteLine("Enter Student Name: ");
                    StudentName = Console.ReadLine();
                    names[i] = StudentName.ToUpper(); // Convert name to uppercase for consistency

                    Console.WriteLine("Enter Student Age:  ");
                    StudentAge = int.Parse(Console.ReadLine());

                    // Validate age (must be 21 or older)
                    while (StudentAge < 21)
                    {
                        Console.WriteLine("Invalid Age!");
                        Console.WriteLine("Enter Student Age Again must be More Than *21*:  ");
                        StudentAge = int.Parse(Console.ReadLine());
                    }
                    Ages[i] = StudentAge;

                    Console.WriteLine("Enter Student Mark: ");
                    StudentMark = double.Parse(Console.ReadLine());
                    marks[i] = StudentMark;

                    dates[i] = StudentEnDate; // Set enrollment date

                    StudentCounter++; // Increment the student counter

                    // Display the added student's details
                    Console.WriteLine($"Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");

                    break; // Exit the loop after adding one student
                }

                // Check if the array is full
                if (StudentCounter == 4)
                {
                    Console.WriteLine("Array is Full! You can't add more students.");
                }
            }
            catch (FormatException) // Handle invalid input (non-numeric)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
            catch (Exception ex) // Handle any other unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //===================================View all students===================================
        static void ViewAllStudents()
        {
            try
            {
                Console.WriteLine("\nList of All Students :\n");

                // Loop through all students and display their details
                for (int i = 0; i < StudentCounter; i++)
                {
                    Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");
                }
            }
            catch (Exception ex) // Handle any unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // ===================================Find a student by name===================================
        static void FindStudentByName()
        {
            try
            {
                int index;
                string StudentName;

                // Allow the user to try twice to find a student
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Enter Student Name:");
                    StudentName = Console.ReadLine().ToUpper(); // Convert input to uppercase for consistency

                    index = Array.IndexOf(names, StudentName); // Search for the student in the array
                    if (index != -1) // If found, display the student's details
                    {
                        Console.WriteLine($"Position: {index} , Name of Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
                        break;
                    }
                    else // If not found, display a message
                    {
                        Console.WriteLine("Student is not exists in the array");
                    }
                }
            }
            catch (Exception ex) // Handle any unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // ===================================Calculate the class average===================================
        static void CalculateClassAverage()
        {
            try
            {
                double SumOfMarks = 0;
                double ClassAverage = 0;

                // Calculate the sum of all student marks
                for (int i = 0; i < StudentCounter; i++)
                {
                    SumOfMarks += marks[i];
                }

                // Calculate the average and round it to 2 decimal places
                ClassAverage = SumOfMarks / StudentCounter;
                ClassAverage = Math.Round(ClassAverage, 2);
                Console.WriteLine($"Class Average: {ClassAverage}");
            }
            catch (Exception ex) // Handle any unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // ===================================Find the top-performing student===================================
        static void FindTopPerformingStudent()
        {
            try
            {
                double top = 0;

                // Find the highest mark in the array
                for (int i = 0; i < StudentCounter; i++)
                {
                    if (marks[i] > top)
                    {
                        top = marks[i];
                    }
                }

                // Find the index of the top-performing student
                int index = Array.IndexOf(marks, top);

                // Display the top-performing student's details
                Console.WriteLine($"Top Performing Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
            }
            catch (Exception ex) // Handle any unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // ===================================Sort students by marks (highest to lowest)===================================
        static void SortStudentsByMarks()
        {
            try
            {
                // Bubble sort algorithm to sort students by marks
                for (int i = 0; i < StudentCounter; i++)
                {
                    for (int j = i + 1; j < StudentCounter; j++)
                    {
                        double tempMark = marks[i];
                        string tempName = names[i];
                        int tempAge = Ages[i];
                        DateTime tempDate = dates[i];

                        // Swap if the current student's mark is less than the next student's mark
                        if (marks[i] < marks[j])
                        {
                            marks[i] = marks[j];
                            marks[j] = tempMark;

                            names[i] = names[j];
                            names[j] = tempName;

                            Ages[i] = Ages[j];
                            Ages[j] = tempAge;

                            dates[i] = dates[j];
                            dates[j] = tempDate;
                        }
                    }
                }

                // Display the sorted list of students
                Console.WriteLine("Students Sorted by Marks :");
                for (int i = 0; i < StudentCounter; i++)
                {
                    Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");
                }
            }
            catch (Exception ex) // Handle any unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //=======================================Delet student record============================================================
        static void DeleteStudentRecord()
        {
            try
            {
                Console.Write("Enter the name of the student to delete: ");
                string StudentName = Console.ReadLine().ToUpper(); // Convert input to uppercase for consistency

                // Find the index of the student to delete
                int index = Array.IndexOf(names, StudentName);

                // Check if the student exists
                if (index == -1 || index >= StudentCounter)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                // Shift all elements to the left to remove the student (remove by overwrite)
                for (int i = index; i < StudentCounter - 1; i++)
                {
                    names[i] = names[i + 1];
                    Ages[i] = Ages[i + 1];
                    marks[i] = marks[i + 1];
                    dates[i] = dates[i + 1];
                }

                StudentCounter--; // Decrement the student counter

                Console.WriteLine("Student record deleted successfully.");
            }
            catch (Exception ex) // Handle any unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}