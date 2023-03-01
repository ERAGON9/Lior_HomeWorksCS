using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library
{
    public class Home_Work_03
    {

        public static void Run()
        {
            // Remove from comment every exercise you want to check!
            #region Ex1
            //DrawRectangleBorder();
            #endregion

            #region Ex2
            //CreateList();
            #endregion

            #region Ex3
            //CountriesNamesManager();
            #endregion
        }

        public static void DrawRectangleBorder()
        {
            Console.WriteLine("Please enter the height for the rectangle");
            int h = int.Parse(Console.ReadLine());

            while (h < 2) 
            {
                Console.WriteLine("Height must be not less than two!\nTry again...");
                h = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Please enter the width for the rectangle");
            int w = int.Parse(Console.ReadLine());

            while (w < 2)
            {
                Console.WriteLine("Width must be not less than two!\nTry again...");
                w = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Please enter a char to draw the rectangle");
            char tav = char.Parse(Console.ReadLine());

            Console.WriteLine("Please enter it the rectangle full or bordered only. (true = full/ false = bordered only)");
            bool isFull = bool.Parse(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (i == 0 || i == h - 1 || j == 0 || j == w - 1)
                        Console.Write(tav);
                    else if (isFull == true)
                        Console.Write(tav);
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine($"Hight: {h} X Width: {w}");
            if (isFull == true)
                Console.WriteLine($"Area = {h * w}");
            else
                Console.WriteLine($"Size = {(h * 2) + (w * 2)}");
        }

        public static void CreateList()
        {
            int avg = 0, bestGrade = 0;
            string bestStudent = "";
            List<object> studentsgrades = new List<object>();

            Console.WriteLine("Please enter the number of students:");
            int amount = int.Parse(Console.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"Student number {i + 1}:");
                Console.WriteLine("Please enter student name:");
                string name = Console.ReadLine();
                studentsgrades.Add(name);

                Console.WriteLine("Please enter student grade:");
                int grade = int.Parse(Console.ReadLine());
                while (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Grade must be between 0-100, try again...");
                    grade = int.Parse(Console.ReadLine());
                }
                studentsgrades.Add(grade);
                avg += grade;

                if (grade > bestGrade)
                {
                    bestGrade = grade;
                    bestStudent = name;
                }
            }
            avg /= amount;

            Console.WriteLine();

            for (int i=0; i< studentsgrades.Count; i+=2)
                Console.WriteLine($"Student: {studentsgrades[i]} grade: {studentsgrades[i + 1]}");

            Console.WriteLine($"Grades average: {avg}");
            Console.WriteLine($"The best grade is : {bestGrade} belong to the student: {bestStudent}");
        }

        public static void CountriesNamesManager()
        {
            List<string> CountriesList = new List<string>();
            int action;

            do
            {
                ShowMenu();
                action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        AddNewCountry(CountriesList);
                        break;
                    case 2:
                        RemoveCountryByName(CountriesList);
                        break;
                    case 3:
                        PrintCountriesByPrefix(CountriesList);
                        break;
                    case 4:
                        PrintAllCountries(CountriesList);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Wrong input try again");
                        break;

                }

            } while (action != 5);

        }

        public static void ShowMenu()
        {
            Console.WriteLine("Please chose one option from the menu:");
            Console.WriteLine("1 -  Add new Country");
            Console.WriteLine("2 - Remove country from list by name");
            Console.WriteLine("3 - Find coutry by prefix text");
            Console.WriteLine("4 - Show All Countries");
            Console.WriteLine("5 - Exit");
        }

        public static void AddNewCountry(List<string> CountriesList)
        {
            bool isexist = false;

            Console.WriteLine("Enter county name to add:");
            string country = Console.ReadLine();

            for (int i = 0; i < CountriesList.Count; i++)
            {
                if (CountriesList[i] == country)
                {
                    Console.WriteLine("The country already exist at the list! \nBack to menu");
                    isexist = true;
                }
            }

            if(isexist == false)
                CountriesList.Add(country);

        }

        public static void RemoveCountryByName(List<string> CountriesList) 
        {
            bool isdeleted = false;

            Console.WriteLine("Enter county name to remove:");
            string country = Console.ReadLine();

            for (int i = 0; i < CountriesList.Count; i++)
            {
                if (CountriesList[i] == country)
                {
                    CountriesList.RemoveAt(i);
                    Console.WriteLine("country removed!");
                    isdeleted = true;
                }
            }

            if (isdeleted == false)
                Console.WriteLine("country not exist so also not removed!");

        }

        public static void PrintCountriesByPrefix(List<string> CountriesList)
        {
            List<string> prefixList = new List<string>();

            Console.WriteLine("Enter counties prefix name to show:");
            char prefix = char.Parse(Console.ReadLine());

            for (int i = 0; i < CountriesList.Count; i++)
            {
                if (((CountriesList[i])[0]) == prefix)
                    prefixList.Add(CountriesList[i]);
            }

            if (prefixList.Count > 0)
            {
                Console.WriteLine($"Countries that start with the prefix {prefix} are:");

                for (int i = 0; i < prefixList.Count; i++)
                    Console.Write(prefixList[i] + " ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("There is not countries with that prefix!");
        }

        public static void PrintAllCountries(List<string> CountriesList)
        {
            Console.WriteLine("All the countries at the list are:");

            for (int i=0; i< CountriesList.Count; i++)
                Console.WriteLine(CountriesList[i] + "");

        }
    }
}
