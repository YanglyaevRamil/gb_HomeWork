using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string numLess;

            getInfo();

            do
            {
                Console.Write("Enter the task number : ");
                numLess = Console.ReadLine();

                switch (numLess)
                {
                    case "0":
                        Console.Clear();
                        Shutdown("Shutdown");
                        Console.ReadLine();
                        break;
                    case "1":
                        MinNumer();
                        break;
                    case "2":
                        NumOfDigits();
                        break;
                    case "3":
                        RowOfNumbers();
                        break;
                    case "4":
                        Authorization();
                        break;
                    case "5":
                        IndexMasBody();
                        break;
                    case "6":
                        GoodNumber();
                        break;
                    case "7":
                        Recursion();
                        break;
                    case "c":
                        Сlean();
                        break;
                    default:
                        Console.WriteLine("Incorrect number");
                        break;
                }
            }
            while (numLess != "0");
        }

        static void DrawStar()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }

        static void getInfo()
        {
            DrawStar();
            Console.WriteLine("0 - Shutdown");
            Console.WriteLine("1 - Lesson 1");
            Console.WriteLine("2 - Lesson 2");
            Console.WriteLine("3 - Lesson 3");
            Console.WriteLine("4 - Lesson 4");
            Console.WriteLine("5 - Lesson 5");
            Console.WriteLine("6 - Lesson 6");
            Console.WriteLine("7 - Lesson 7");
            Console.WriteLine("c - Сlear Field");
            DrawStar();
        }

        static void Сlean()
        {
            Console.Clear();
            getInfo();
        }

        static void Shutdown(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(message);
        }

        //====================================Task_1=======================================================

        /*
         * Написать метод, возвращающий минимальное из трёх чисел.
        */
        static void MinNumer()
        {
            Console.WriteLine("Enter three or more numbers separated by a space");
            string nubmer = Console.ReadLine();
            Console.WriteLine($"Array : {nubmer}");
            Console.WriteLine($"Min number in Array : {GetMinArr(nubmer)}");
        }

        static int GetMinArr(string num)
        {
            int[] sqnc_number = Array.ConvertAll(num.Split(' '), int.Parse);

            return sqnc_number.Min();
        }
        //====================================Task_2=======================================================
        /*
         *  Написать метод подсчета количества цифр числа.
        */
        static void NumOfDigits()
        {
            Console.WriteLine("Enter the number");
            string number = Console.ReadLine();
            Console.WriteLine($"Number of digits : {GetNumOfDigits(number)}");
        }

        static int GetNumOfDigits(string num)
        {
            return num.Length;
        }
        //====================================Task_3=======================================================
        /*
         * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        */
        static void RowOfNumbers()
        {
            int num = 0, sum = 0;
            do
            {
                Console.Write("Enter the number : ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num > 0 && num % 2 == 1)
                {
                    sum += num;
                }
            }
            while (num != 0);

            Console.WriteLine($"The sum of all odd positive numbers : {sum}");
        }

        //====================================Task_4=======================================================
        /*
         *  Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
         *  На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
         *  Используя метод проверки логина и пароля, написать программу: 
         *  пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
         *  С помощью цикла do while ограничить ввод пароля тремя попытками.
        */
        static void Authorization()
        {
            int inc = 0;
            do
            {
                Console.Write("Login: ");
                string Login = Console.ReadLine();
                Console.Write("Password: ");
                string Password = Console.ReadLine();
                if (CheckAuthorization(Login, Password))
                {
                    inc = 3;
                    Console.WriteLine("Authorization...");
                }
                else
                { if (inc < 2)
                        Console.WriteLine($"Wrong login or password, you have {2 - inc} attempts left");
                    else
                        Console.WriteLine("All attempts have been expended, you are blocked");
                    inc++;
                }
            }
            while (inc != 3);

        }

        static bool CheckAuthorization(string log, string pas)
        {
            if (log == "root" && pas == "GeekBrains")
            {
                return true;
            }
            else
                return false;
        }
        //====================================Task_5=======================================================
        /*
         *  а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
         *     нужно ли человеку похудеть, набрать вес или всё в норме.
         *  б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса. 
        */
        static void IndexMasBody()
        {
            Console.WriteLine("Enter your weight in kilograms");
            float body_mass = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter your height in meters");
            float body_growth = Convert.ToSingle(Console.ReadLine());

            float ExcessMass = GetLackOfWeight(body_mass, body_growth);

            Console.WriteLine($"Your body mass index {GetIndexMasBody(body_mass, body_growth)}");

            if (ExcessMass == 0)
            {
                Console.WriteLine("You are in good shape. You don't need to lose weight");
            }
            else if (ExcessMass < 0)
            {
                Console.WriteLine("You are overweight. You should reset {0:F} Kg", ExcessMass * (-1));
            }
            else
            {
                Console.WriteLine("You are underweight. You should dial {0:F} Kg", ExcessMass);
            }

        }

        static float GetIndexMasBody(float mass, float growth)
        {
            return mass / (growth * growth);
        }

        static float GetLackOfWeight(float mass, float growth)
        {
            if (GetIndexMasBody(mass, growth) < 18.5)
            {

                return (float)18.5 * growth * growth - mass;
            }
            else if (GetIndexMasBody(mass, growth) > 25)
            {
                return (float)25.0 * growth * growth - mass;
            }
            else
            {
                return 0;
            }

        }
        //====================================Task_6=======================================================
        /*
         *  *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
         *  «Хорошим» называется число, которое делится на сумму своих цифр. 
         *  Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
        */

        static void GoodNumber()
        {
            long clk = DateTime.Now.Second;
            Console.Write("Enter the number to which you want to count 'Good Numbers': ");
            long good_num = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine($"Numbers 'Good Numbers': {GetNumberOfGoodNumbers(good_num)}");
            clk = DateTime.Now.Second - clk;
            Console.WriteLine($"Spent second: {clk}");

        }

        static int GetNumberOfGoodNumbers(long num)
        {
            
            int inc = 0;
            for (int i = 1; i <= num; i++)
            {
                if (i % GetDigitSum(i) == 0)
                {
                    inc++;
                }
            }

            return inc;
        }

        static int GetDigitSum(int num)
        {
            int sum = 0;

            foreach (char n in Convert.ToString(num))
            {
                sum += int.Parse(n.ToString());
                //sum += Convert.ToInt32(n) - 48;
            }

            return sum;
        }

        //====================================Task_7=======================================================
        /*
         * a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
         * б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        */
        static void Recursion()
        {
            Console.Write("Enter number a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            
            if (a > b)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.Write($"a to b: ");
                RecursionNum(a, b);
            }
            Console.WriteLine("");
            Console.WriteLine($"Summ from A to B: {GetRecursionSum(a, b)}");

        }

        static void RecursionNum(int a, int b)
        {
            Console.Write($"{a}   ");
            if (a <= b)
                RecursionNum(a+1, b);
        }
        static int GetRecursionSum(int a, int b)
        {
            if (a < b)
            {
                return a + GetRecursionSum(a + 1, b);
            }
            else if (a > b)
            {
                return b + GetRecursionSum(a, b + 1) ;
            }
            else
                return b; 

            //return a == b ? b : a + GetRecursionSum(a + 1, b);
        }
    }
}
