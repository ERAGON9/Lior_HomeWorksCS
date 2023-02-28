using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Home_Works_Library
{
    public class Home_Work_02
    {
        public static void Run()
        {
            // Remove from comment every exercise you want to check!

            /////////////////////////////////////////////
            //// Ex1
            // Static array

            //string[] staticArr = new string[5] { "Hi", "Bye", "Good bye friend", "Hello", "Whats up" };
            //string longSstr = LongestString(staticArr);
            //Console.WriteLine(longSstr + "\n");

            /////////////////////////////////////////////
            // Dynamic array

            //List<string> DynamicArr = new List<string> { "Hi", "Bye", "Good bye friend", "Hello", "Whats up" };
            //string longDstr = LongestString(DynamicArr);
            //Console.WriteLine(longDstr + "\n");

            ////////////////////////////////////////////
            //// Ex2

            //List<int> numbers = new List<int> { 1, 2, 3, 4, };
            //string Strnumbers = JoinAll(numbers);
            //Console.WriteLine(Strnumbers + "\n");

            ////////////////////////////////////////////
            //// Ex3

            //Console.Write("Enter fisrt number: ");
            //int num1 = int.Parse(Console.ReadLine());

            //Console.Write("Enter secount number: ");
            //int num2 = int.Parse(Console.ReadLine());

            //Console.Write("Enter operator: ");
            //string operatorSighn = Console.ReadLine();

            //int calcExprassion = Calculate(num1, num2, operatorSighn);
            //Console.WriteLine("the expression after calculate is: " + calcExprassion + "\n");

            ////////////////////////////////////////////
            //// Ex4

            //int[] staticNumbers = new int[7] { 10, 2, 38, 22, 38, 23, 21 };
            //List<int> dynamicNumbers = DitanceFromAvg(staticNumbers, 2);

            //Console.Write("The Dynamic arr should be:");
            //for (int i = 0; i < dynamicNumbers.Count; i++)
            //    Console.Write($" {dynamicNumbers[i]}");
            //Console.WriteLine();

            ////////////////////////////////////////////
            //// Ex5

            //PrintFromLastStrings();

            ////////////////////////////////////////////
            //// Ex6

            //List<int> numArr = new List<int>() { 18, 23, 99, 54, 107, 94, -20 };

            //SortDynamicNumbersArr(numArr);

            ////////////////////////////////////////////
            //// Ex7

            //ReadIntegers();

            ////////////////////////////////////////////
            //// Ex8

            //List<string> stringsBefore = new List<string>() { "hi", "hello", "hi", "bye", "hi" };
            //string valuetoremove = "hi";

            //Console.Write($"List of string before remove {valuetoremove} is:");
            //for (int i = 0; i < stringsBefore.Count; i++)
            //    Console.Write($" {stringsBefore[i]} ");
            //Console.WriteLine("\n");

            //List<string> stringAfter = RemoveFromList(stringsBefore, valuetoremove);

            //Console.Write($"List of string after removed {valuetoremove} is:");
            //for (int i = 0; i < stringAfter.Count; i++)
            //    Console.Write($" {stringAfter[i]} ");
            //Console.WriteLine("\n");

            ////////////////////////////////////////////
            //// Ex9

            //List<int> numbers = new List<int>() { 1, 22, 44, 88, 105, 12};

            //Console.Write($"List of int before remove:");
            //for (int i = 0; i < numbers.Count; i++)
            //    Console.Write($" {numbers[i]} ");
            //Console.WriteLine("\n");

            //List<int> numbersAfterRemove = integers(numbers);

            //Console.Write($"List of int after remove:");
            //for (int i = 0; i < numbersAfterRemove.Count; i++)
            //    Console.Write($" {numbersAfterRemove[i]} ");
            //Console.WriteLine("\n");

        }

        //// Ex1
        // Static array
        public static string LongestString(string[] arrOfStr)
        {
            int bigestLength = 0;
            string wordToReturn = "";

            for (int i = 0; i < arrOfStr.Length; i++)
            {
                if (arrOfStr[i].Length > bigestLength)
                {
                    bigestLength = arrOfStr[i].Length;
                    wordToReturn = arrOfStr[i];
                }
            }

            return wordToReturn;
        }

        // Dynamic array
        public static string LongestString(List<string> arrOfStr)
        {
            int bigestLength = 0;
            string wordToReturn = "";

            for (int i = 0; i < arrOfStr.Count; i++)
            {
                if (arrOfStr[i].Length > bigestLength)
                {
                    bigestLength = arrOfStr[i].Length;
                    wordToReturn = arrOfStr[i];
                }
            }

            return wordToReturn;
        }

        //// Ex2
        public static string JoinAll(List<int> arrOfInt)
        {
            string allNumbersTogether = "";

            for (int i = 0; i < arrOfInt.Count - 1; i++)
            {
                allNumbersTogether += arrOfInt[i] + "_";
            }

            allNumbersTogether += arrOfInt[arrOfInt.Count - 1];

            return allNumbersTogether;
        }

        //// Ex3
        public static int Calculate(int num1, int num2, string operatorSighn)
        {
            if (operatorSighn == "+")
                return num1 + num2;
            else if (operatorSighn == "-")
                return num1 - num2;
            else if(operatorSighn == "*")
                return num1 * num2;
            else
                return num1 / num2;
        }


        ////Ex4
        public static List<int> DitanceFromAvg(int[] numbers, int distanceAvg)
        {
            List<int> dynamicArr = new List<int>();
            int avg = 0;

            for (int i = 0; i < numbers.Length; i++)
                avg += numbers[i];

            avg /= numbers.Length;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (((avg - numbers[i]) < distanceAvg) && (avg - numbers[i]) > (distanceAvg * -1))
                    dynamicArr.Add(numbers[i]);
            }

            return dynamicArr;
        }


        ////Ex5
        public static void PrintFromLastStrings()
        {
            List<string> dynamicStringArr = new List<string>();
            string strValue;

            Console.WriteLine("Please enter names and at the end enter-> exit");

            do
            {
                strValue = Console.ReadLine();

                if (strValue != "exit")
                    dynamicStringArr.Add(strValue);

            } while (strValue != "exit");

            Console.WriteLine($"There are {dynamicStringArr.Count()} strings at the list:");

            for (int i = dynamicStringArr.Count() - 1; i >= 0; i--)
            {
                Console.WriteLine(dynamicStringArr[i].ToUpper());
            }
        }

        ////Ex6
        public static void SortDynamicNumbersArr(List<int> numbers)
        {
            // numbers.Sort();          // one option!

            for (int i = 0; i < numbers.Count; i++) // Bubble Sort or we can do also a Merge Sort
            {
                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        ////Ex7
        public static void ReadIntegers()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Please write how much integers you want to enter:");
            int amount = int.Parse(Console.ReadLine());
            int number;

            Console.WriteLine("Numbers:");
            for (int i = 0; i < amount; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 100)
                    numbers.Add(number);
                else
                {
                    while (number < 0 || number > 100)
                    {
                        Console.WriteLine("Number not between 0-100, try again:");
                        number = int.Parse(Console.ReadLine());
                    }
                    numbers.Add(number);
                }
            }

            Console.WriteLine("The final List is:");
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($" {numbers[i]} ");
            }
        }


        ////Ex8
        public static List<string> RemoveFromList(List<string> strings, string valuetoremove)
        {
            List<string> listToReturn = new List<string>();

            for(int i=0; i< strings.Count; i++) 
            {
                if (strings[i] != valuetoremove)
                    listToReturn.Add(strings[i]);
            }

            return listToReturn;
        }

        ////Ex9
        public static List<int> integers(List<int> numbers)
        {
            List<int> numbersAfterRemove = numbers;
            int avg = 0;

            for (int i = 0; i < numbersAfterRemove.Count; i++)
                avg += numbersAfterRemove[i];

            avg /= numbersAfterRemove.Count;

            Console.WriteLine($"AVG: {avg} ");

            for (int i = 0, index=0 ; i < numbersAfterRemove.Count; i++, index++)
            {
                if (numbersAfterRemove[i] > avg)
                {
                    numbersAfterRemove.RemoveAt(i);
                    Console.WriteLine($"Removed number at index {index}");
                    i--;
                }
            }

            return numbersAfterRemove;
        }
    }
}
