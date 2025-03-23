using System;

namespace Simple_Student_Management_Project
{
    internal class Program
    {
        static double[] marks = new double[10];
        static int[] Ages = new int[10];
        static string[] names = new string[10];
        static DateTime[] dates = new DateTime[10];
        static int StudentCounter = 0;

        static void Main(string[] args)
        {
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

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddNewStudent(); break;
                    case 2: ViewAllStudents(); break;
                    case 3: FindStudentByName(); break;
                    case 4: CalculateClassAverage(); break;
                    case 5: FindTopPerformingStudent(); break;
                    case 6: SortStudentsByMarks(); break;
                    case 7: DeleteStudentRecord(); break;
                    case 0: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }

                Console.ReadLine();
            }


        }


        static void AddNewStudent()
        {
            string StudentName;
            int StudentAge = 0, StudentAge1 = 0;
            double StudentMark = 0;
            DateTime StudentEnDate = DateTime.Now;


            Console.WriteLine("\nEnter Student Data :");


            for (int i = StudentCounter; i < names.Length; i++)
            {
                Console.WriteLine("Enter Student Name: ");
                StudentName = Console.ReadLine();
                names[i] = StudentName;
                names[i] = names[i].ToUpper();

                Console.WriteLine("Enter Student Age:  ");
                StudentAge = int.Parse(Console.ReadLine());
                for (int j = 0; StudentAge < 21; j++)
                {
                    if (21 > StudentAge )
                    {
                        Console.WriteLine("Invalid Age!");
                        Console.WriteLine("Enter Student Age Again must be More Than *21*:  ");
                        StudentAge = int.Parse(Console.ReadLine());
                        Ages[i] = StudentAge;
                    }
                    else
                    {
                        Ages[i] = StudentAge;
                    }
                }

                Ages[i] = StudentAge;

                Console.WriteLine("Enter Student Mark: ");
                StudentMark = double.Parse(Console.ReadLine());
                marks[i] = StudentMark;


                dates[i] = StudentEnDate;

                StudentCounter++;

                Console.WriteLine($"Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");

                break;

            }


            if (StudentCounter == 4)
            {
                Console.WriteLine("Array is Full! You can't add more students.");
            }




        }






        static void ViewAllStudents()
        {
            Console.WriteLine("\nList of All Students :\n");

            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");

            }

        }




        static void FindStudentByName()
        {
            int index;
            string StudentName;
            for (int i = 0; i < 2; i++)
            {


                Console.WriteLine("Enter Student Name:");
                StudentName = Console.ReadLine();
                StudentName = StudentName.ToUpper();

                index = Array.IndexOf(names, StudentName);
                if (index != -1)
                {
                    Console.WriteLine($"Position: {index} , Name of Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
                    break;
                }
                else
                {
                    Console.WriteLine("Student is not exists in the array");
                }
            }
        }



        static void CalculateClassAverage()
        {

            double SumOfMarks = 0;
            double ClassAverage = 0;
            for (int i = 0; i < StudentCounter; i++)
            {
                SumOfMarks += marks[i];
            }
            ClassAverage = SumOfMarks / StudentCounter;
            ClassAverage =Math.Round(ClassAverage, 2);
            Console.WriteLine($"Class Average: {ClassAverage}");

        }




        static void FindTopPerformingStudent()
        {

            double top = 0;

            for (int i = 0; i < StudentCounter; i++)
            {
                if (marks[i] > top)
                {
                    top = marks[i];
                }
                else
                {
                    top = top;
                }


            }
            int index = Array.IndexOf(marks, top);

            Console.WriteLine($"Top Performing Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
        }


        static void SortStudentsByMarks()
        {
            for (int i = 0; i < StudentCounter; i++)
            {
                for (int j = i + 1; j < StudentCounter; j++)
                {
                    double tempMark = marks[i];
                    string tempName = names[i];
                    int tempAge = Ages[i];
                    DateTime tempDate = dates[i];



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

            Console.WriteLine("Students Sorted by Marks :");
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");
            }
        }





        static void DeleteStudentRecord()
        {

            

        }
    }
}