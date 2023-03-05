using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Home_Works_Library.Home_Work_04;

namespace Home_Works_Library
{
    public class Home_Work_04
    {
        public enum CustomerType
        {
            Regular,
            Subscriber,
            Gold
        }

        public enum StudentType
        {
            External,
            Inner
        }

        public static void Run()
        {
            // Remove from comment every exercise you want to check!

            #region Ex1
            //bool isvalid = false;
            //CustomerType coustomertype;

            //do
            //{
            //    Console.WriteLine("Please enter your customer type (Regular/Subscriber/Gold): ");
            //    string type = Console.ReadLine();   

            //    switch (type)
            //    {
            //        case "Regular":
            //            coustomertype = CustomerType.Regular;
            //            isvalid = true;
            //            break;
            //        case "Subscriber":
            //            coustomertype = CustomerType.Subscriber;
            //            isvalid = true;
            //            break;
            //        case "Gold":
            //            coustomertype = CustomerType.Gold;
            //            isvalid = true;
            //            break;
            //        default:
            //            Console.WriteLine("You entered wrong input, try again...");
            //            coustomertype = CustomerType.Regular;
            //            break;
            //    }

            //} while (isvalid == false);


            //Console.WriteLine("Please enter a product price: ");
            //double price = double.Parse(Console.ReadLine());

            //double newPrice = DiscountCalc(coustomertype, price);
            //Console.WriteLine($"Your price after Discount is: {newPrice}");
            #endregion

            #region Ex2
            StudentGradesManager();
            #endregion
        }

        public static double DiscountCalc(CustomerType customerType, double productPrice)
        {
            switch((int)customerType)
            {
                case 0:
                    return productPrice * 0.9;
                case 1:
                    return productPrice * 0.75;
                case 2:
                    return productPrice * 0.65;
                default:
                    Console.WriteLine("An error occurred");
                    return -1;
            }
        }

        public static void StudentGradesManager()
        {
            List<string> IdsList = new List<string> {"123456789" ,"234567891", "345678912"};
            List<string> NamesList = new List<string> {"Lior", "Roy", "Michael"};
            List<int> GradesList = new List<int> { 95, 98, 100};
            List<StudentType> TypeList = new List<StudentType> { StudentType.External, StudentType.Inner, StudentType .External};

            bool toExit = false;

            while (toExit == false)
            {

                PrintMenu();
                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        AddStudent(IdsList, NamesList, GradesList, TypeList);
                        break;
                    case 2:
                        UpdateGrade(IdsList, GradesList);
                        break;
                    case 3:
                        Show_All_Grades(IdsList, NamesList, GradesList);
                        break;
                    case 4:
                        Remove_Student(IdsList, NamesList, GradesList, TypeList);
                        break;
                    case 5:
                        Print_User_Grade_by_Name(IdsList, NamesList, GradesList);
                        break;
                    case 6:
                        Print_All_Users_By_student_Type(IdsList, NamesList, GradesList, TypeList);
                        break;
                       case 7:
                        toExit= true;
                        break;
                    default:
                        Console.WriteLine("You enter wrong input");
                        break;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Please choose action from the list:");
            Console.WriteLine("1 - Add New Student to list");
            Console.WriteLine("2 - Update Grade for user");
            Console.WriteLine("3 - Show All Grades");
            Console.WriteLine("4 - Remove Student");
            Console.WriteLine("5 - Print User Grade by Name");
            Console.WriteLine("6 - Print All Users By student Type");
            Console.WriteLine("7 - To exit");
        }

        public static void AddStudent(List<string> IdsList, List<string> NamesList, List<int> GradesList, List<StudentType> TypeList)
        {
            Console.WriteLine("Enter student id");
            string id = Console.ReadLine();
            Console.WriteLine("Enter student name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student type (Inner/External)");
            string typeString = Console.ReadLine();
            StudentType type;

            switch (typeString)
            {
                case "Inner":
                    type = StudentType.Inner;
                    break;
                case "External":
                    type = StudentType.External;
                    break;
                default:
                    type = StudentType.Inner;
                    break;
            }
            IdsList.Add(id);
            NamesList.Add(name);
            GradesList.Add(0);
            TypeList.Add(type);
        }

        public static void UpdateGrade(List<string> IdsList, List<int> GradesList)
        {
            Console.WriteLine("Enter student Id: ");
            string id = Console.ReadLine();
            bool isValid = false;
            int grade;

            do
            {
                Console.WriteLine("Enter student new grade: ");
                isValid = int.TryParse(Console.ReadLine(), out grade);

            } while (isValid != true || grade < 0 || grade > 100);


            for (int i = 0; i < IdsList.Count; i++)
            {
                if (IdsList[i] == id)
                {
                    GradesList[i] = grade;
                }
            }

        }

        public static void Show_All_Grades(List<string> IdsList, List<string> NamesList, List<int> GradesList)
        {
            for (int i = 0; i < IdsList.Count; i++)
            {
                Console.WriteLine($"Id = {IdsList[i]}, name = {NamesList[i]}, grade = {GradesList[i]}");
            }
        }

        public static void Remove_Student (List<string> IdsList, List<string> NamesList, List<int> GradesList, List<StudentType> TypeList)
        {
            Console.WriteLine("Enter student Id: ");
            string id = Console.ReadLine();

            for (int i = 0; i < IdsList.Count; i++)
            {
                if (IdsList[i] == id)
                {
                    IdsList.RemoveAt(i);
                    NamesList.RemoveAt(i);
                    GradesList.RemoveAt(i);
                    TypeList.RemoveAt(i);
                }
            }
        }

        public static void Print_User_Grade_by_Name(List<string> IdsList, List<string> NamesList, List<int> GradesList)
        {
            Console.WriteLine("Enter student name: ");
            string name = Console.ReadLine();

            for (int i = 0; i < NamesList.Count; i++)
            {
                if (NamesList[i] == name)
                {
                    Console.WriteLine($"Id = {IdsList[i]}, name = {NamesList[i]}, grade = {GradesList[i]}");
                }
            }
        }

        public static void Print_All_Users_By_student_Type(List<string> IdsList, List<string> NamesList, List<int> GradesList, List<StudentType> TypeList)
        {
            Console.WriteLine("Enter student type (Inner/External)");
            string typeString = Console.ReadLine();
            StudentType type;

            switch (typeString)
            {
                case "Inner":
                    type = StudentType.Inner;
                    break;
                case "External":
                    type = StudentType.External;
                    break;
                default:
                    type = StudentType.Inner;
                    break;
            }

            for (int i = 0; i < NamesList.Count; i++)
            {
                if (TypeList[i] == type)
                {
                    Console.WriteLine($"Id = {IdsList[i]}, name = {NamesList[i]}, grade = {GradesList[i]}");
                }
            }
        }

    }
}
