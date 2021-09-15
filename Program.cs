using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Array2DLib;

using ArrayLib; // using Lib, Task 3(б)

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string numLess;
            int[] arr;
            string repeat = "n";
            getInfo();
            do
            {
                Console.Write("Enter the task number: ");
                numLess = Console.ReadLine();

                switch (numLess)
                {

                        case "0":
                            Console.Clear();
                            messageMiddleXY("Shutdown");
                            Console.ReadLine();
                            break;

                        case "1":

                            messageMiddleX("Task 1");

                            do
                            {
                                Console.Write("Enter the number of array elements: ");

                                arr = ArrayRnd(Convert.ToInt32(Console.ReadLine()));
                                int sum = 0;
                                Console.WriteLine($"The array looks like: ");
                                for (int i = 0; i < arr.Length - 1; i++)
                                {                        
                                    Console.WriteLine($"  {arr[i]}");
                                    sum += (GetDigitSum(arr[i]) % 3 == 0) ^ (GetDigitSum(arr[i + 1]) % 3 == 0) ? 1 : 0;
                                }
                                Console.WriteLine($"The number of pairs of array elements in which only one number is divisible by 3: {sum}");

                                Console.Write("Repeat calculation? y/n: ");
                                repeat = Console.ReadLine();
                            } while (repeat == "y") ;
                    break;

                    case "2":
                        messageMiddleX("Task 2");
                            do { 
                            Console.Write("Enter the number of array elements: ");
                            int sum0 = ArrRnd.GetSumDivThree(ArrRnd.GetArrayRnd(Convert.ToInt32(Console.ReadLine())));

                            Console.WriteLine($"The number of pairs of array elements in which only one number is divisible by 3: {sum0}");

                            try
                            {
                                string[] arrStr = ArrRnd.LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "TextFile1.txt");
                                int[] arrInt = new int[arrStr.Length];
                                for (int i = 0; i < arrStr.Length; i++)
                                {
                                    arrInt[i] = Convert.ToInt32(arrStr[i]);
                                }
                                
                                int sum1 = ArrRnd.GetSumDivThree(arrInt);

                                Console.WriteLine($"The number of pairs of array_txt elements in which only one number is divisible by 3: {sum1}");
                            }
                            catch (FileNotFoundException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            finally
                            {
                                Console.Write("Repeat calculation? y/n: ");
                                repeat = Console.ReadLine();
                            }

                        } while (repeat == "y");

                        break;
                    case "3":
                        messageMiddleX("Task 3");
                        do
                        {
                            Console.Write("Enter the size of the array: ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter array step: ");
                            int step = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the left border: ");
                            int left = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the right border: ");
                            int right = Convert.ToInt32(Console.ReadLine());
                            MyArray Arr = new MyArray(size, step, left, right);

                            Console.WriteLine("What class function do you want to check?");
                            Console.WriteLine("Sum - sum of array elements");
                            Console.WriteLine("Inverse - returning a new array with changed signs for all array elements");
                            Console.WriteLine("Multi - multiplying each element of the array by a certain number");
                            Console.WriteLine("MaxCount - returning the number of maximum elements");
                            Console.WriteLine("Frequency - the frequency of occurrence of each element in the array, return Dictionary<int, int>");

                            string skill = Console.ReadLine();

                            switch (skill)
                            {
                                case "Sum" :
                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Console.WriteLine($"{i} : {Arr[i]}");
                                    }
                                    Console.WriteLine($"Sum of all array {Arr.Sum}");
                                    break;
                                case "Inverse":
                                    MyArray invArr = Arr.Inverse();
                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Console.WriteLine($"{i} : {Arr[i]} : inv {invArr[i]}");
                                    }
                                    break;
                                case "Multi":
                                    Console.WriteLine("Enter the number you want to multiply: ");
                                    int mul = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Before Multi");
                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Console.WriteLine($"{i} : {Arr[i]}");
                                    }
                                    Arr.Multi(mul);
                                    Console.WriteLine("After Multi");
                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Console.WriteLine($"{i} : {Arr[i]}");
                                    }
                                    break;
                                case "MaxCount":
                                    for (int i = 0; i < Arr.Length; i++)
                                    {
                                        Console.WriteLine($"{i} : {Arr[i]}");
                                    }
                                    Console.WriteLine($"Number of maximum elements {Arr.MaxCount}");
                                    break;
                                case "Frequency":
                                    Dictionary<int, int> myDict = Arr.GetFreqElement();
                                    foreach (KeyValuePair<int, int> i in myDict)
                                    {
                                        Console.WriteLine($"Num : {i.Key} - Frequency : {i.Value}");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("This skill is not supported!");
                                    break;
                            }

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;

                    case "4":
                        messageMiddleX("Task 4");
                        do
                        {
                            int inc = 0;
                            do
                            {
                                Console.Write("Login: ");
                                string Login = Console.ReadLine();
                                Console.Write("Password: ");
                                string Password = Console.ReadLine();
                                if (Account.CheckAuthorization(Login, Password))
                                {
                                    inc = 3;
                                    Console.WriteLine("Authorization...");
                                }
                                else
                                {
                                    if (inc < 2)
                                        Console.WriteLine($"Wrong login or password, you have {2 - inc} attempts left");
                                    else
                                        Console.WriteLine("All attempts have been expended, you are blocked");
                                    inc++;
                                }
                            }
                            while (inc != 3);

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;  

                    case "5":
                        messageMiddleX("Task 5");
                        int maxIndX, maxIndY;
                        MyArray2D Arr2D = new MyArray2D(4,4);
                        Arr2D.GetMaxIndex(out maxIndX, out maxIndY);

                        try
                        {
                            Arr2D.WriteArrayFromFile("WrDoc.txt");
                            Arr2D.LoadArrayFile("Account.txt");

                            for (int i = 0; i < Arr2D.GetLength(0); i++)
                            {
                                for (int j = 0; j < Arr2D.GetLength(1); j++)
                                {
                                    Console.Write($"{Arr2D[i, j]}\t");

                                }

                                Console.WriteLine();
                            }
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "c":
                        Сlean();
                        break;

                    default:
                        break;
                }

            } while (numLess != "0");
        }

        #region Support
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
            Console.WriteLine("1 - Task 1");
            Console.WriteLine("2 - Task 2");
            Console.WriteLine("3 - Task 3");
            Console.WriteLine("4 - Task 4");
            Console.WriteLine("5 - Task 5");
            Console.WriteLine("c - Сlear Field");
            DrawStar();
        }
        static void Сlean()
        {
            Console.Clear();
            getInfo();
        }
        static void messageMiddleXY(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(message);
        }
        static void messageMiddleX(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.CursorTop);
            Console.WriteLine(message);

        }
        #endregion

        //====================================Task_1=======================================================
        /*
         * Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
         * Заполнить случайными числами. 
         * Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
         * В данной задаче под парой подразумевается два подряд идущих элемента массива.
         * 
        */
        #region Task_1
        public static int[] ArrayRnd(int counter)
        {
            Random random = new Random();

            int[] arr = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                int number = random.Next(-10000, 10001);
                arr[i] = number;
            }

            return arr;
        }

        public static int GetDigitSum(int num)
        {
            int sum = 0;

            foreach (char n in Convert.ToString(Math.Abs(num)))
            {
                sum += int.Parse(n.ToString());
                //sum += Convert.ToInt32(n) - 48;
            }

            return sum;
        }
        #endregion
    }

    //====================================Task_2=======================================================
    /*
     * Реализуйте задачу 1 в виде статического класса StaticClass;
     * а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
     * б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
     * в)*Добавьте обработку ситуации отсутствия файла на диске.
     * 
    */
    #region Task_2
    static class ArrRnd
    {
        private static int GetDigitSum(int num)
        {
            int sum = 0;

            foreach (char n in Convert.ToString(Math.Abs(num)))
            {
                sum += int.Parse(n.ToString());
            }

            return sum;
        }

        public static int[] GetArrayRnd(int counter)
        {
            Random random = new Random();

            int[] arr = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                int number = random.Next(-10000, 10001);
                arr[i] = number;
            }

            return arr;
        }

        public static int GetSumDivThree(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                sum += (GetDigitSum(arr[i]) % 3 == 0) ^ (GetDigitSum(arr[i + 1]) % 3 == 0) ? 1 : 0;
            }
            return sum;
        }
        public static string[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string[] buf = new string[1000];
                    int counter = 0;

                    while (!reader.EndOfStream)
                    {
                        buf[counter] = reader.ReadLine();
                        counter++;
                    }

                    string[] arr = new string[counter];

                    Array.Copy(buf, arr, counter);

                    return arr;
                }
            }
            else
            {
                throw new FileNotFoundException("File no exists !");
            }
        }
    }
    #endregion

    #region Task_4
    struct Account
    {

        public string Login;
        private string Password;

        static Account GetСreateAccount(string log, string pas)
        {
            Account user;
            user.Login = log; user.Password = pas;
            return user;
        }

        static public bool CheckAuthorization(string log, string pas)
        {
            string[,] loadArr = Load_data();
            for (int i = 0; i < loadArr.GetLength(0); i++)
            {       
                if (log == loadArr[i, 0])
                {
                    if (pas == loadArr[i, 1]) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static string[,] Load_data()
        {
            string[] arr0 = ArrRnd.LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "Account.txt");
            string[,] arrCoupleLogPass = new string[arr0.Length, 2];
            for (int i = 0; i < arr0.Length; i++)
            {
                arrCoupleLogPass[i, 0] = arr0[i].Split(':')[0];
                arrCoupleLogPass[i, 1] = arr0[i].Split(':')[1];
            }
            return arrCoupleLogPass;
        }

    }


    #endregion
}

//====================================Task_3=======================================================
/*
 * Реализуйте задачу 1 в виде статического класса StaticClass;
 * а) Дописать класс для работы с одномерным массивом. 
 * Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
 * Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, 
 * возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений), метод Multi, 
 * умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
 * б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
 * в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
*/

#region Task_3
//б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
namespace ArrayLib
{
    #region Task_3_a
    class MyArray
    {
        public MyArray()
        {
            arr = new int[100];
        }
        public MyArray(int[] arr)
        {
            this.arr = arr;
        }
        public MyArray(int counter, int step, int left_border, int right_border)
        {
            Random random = new Random();

            arr = new int[counter];

            for (int i = 0; i < counter; i += step)
            {
                int number = random.Next(left_border, right_border);
                arr[i] = number;
            }
        }
        public MyArray(int counter) : this(counter, 1, -1000, 1001) { }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
        }
        public int MaxCount
        {
            get
            {
                int inc = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr.Max() == arr[i])
                    {
                        inc++;
                    }
                }

                return inc;
            }
        }
        public int Length
        {
            get { return arr.Length; }
        }
        public int this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }

        private int[] arr;

        public void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t");
            }
            Console.WriteLine();
        }

        public int GetElement(int index)
        {
            return arr[index];
        }

        public MyArray Inverse()
        {
            int[] a = new int[arr.Length];
            MyArray InvArr = new MyArray(a);
            for (int i = 0; i < arr.Length; i++)
            {
                InvArr[i] = arr[i] * -1;
            }
            return InvArr;
        }

        public int[] Multi(int mul)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * mul;
            }
            return arr;
        }

        // в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
        public Dictionary<int, int> GetFreqElement()
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();

            int repet = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (myDictionary.ContainsKey(arr[i]))
                {
                    myDictionary[arr[i]]++;
                }
                else
                {
                    myDictionary.Add(arr[i], repet);
                }
            }
            return myDictionary;
        }
    }
    #endregion
}
#endregion

//====================================Task_5=======================================================
/*
* а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
* Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
* возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива 
* (через параметры, используя модификатор ref или out).
* *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
* **в) Обработать возможные исключительные ситуации при работе с файлами.
*/
#region Task_5
namespace Array2DLib
{
    class MyArray2D
    {
        private string[,] arr;
        public MyArray2D()
        {
            arr = new string[100,100];
        }
        public MyArray2D(string[,] arr)
        {
            this.arr = arr;
        }
        public MyArray2D(int counterX, int counterY, int stepX, int stepY, int left_border, int right_border)
        {
            Random random = new Random();

            arr = new string[counterX, counterY];

            for (int x = 0; x < counterX; x += stepX)
            {
                for (int y = 0; y < counterX; y += stepY)
                {
                    int number = random.Next(left_border, right_border);
                    arr[x, y] = Convert.ToString(number);
                }
            }
        }
        public MyArray2D(int counterX, int counterY) : this(counterX, counterY, 1, 1, -1000, 1001) { }
        public MyArray2D(int counterX, int counterY, int left_border, int right_border) : this(counterX, counterY, 1, 1, left_border, right_border) { }
        public string this[int x, int y]
        {
            get
            {
                return arr[x, y];
            }
            set
            {
                arr[x, y] = value;
            }
        }

        public int GetLength(int v)
        {
            return arr.GetLength(v);
        }

        public int GetSum()
        {
            int sum = 0;
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    sum += Convert.ToInt32(arr[x, y]);
                }
            }
            return sum;
        }
        public int GetSum(int filter)
        {
            int sum = 0;
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (Convert.ToInt32(arr[x, y]) > filter)
                    {
                        sum += Convert.ToInt32(arr[x, y]);
                    }
                }
            }
            return sum;
        }

        public int MaxNum
        {
            get 
            {
                int[] a = Array.ConvertAll(Arr1D(), int.Parse);
                return a.Cast<int>().Max(); 
            }
        }
        public int MinNum
        {
            get 
            {
                int[] a = Array.ConvertAll(Arr1D(), int.Parse);
                return arr.Cast<int>().Min(); 
            }
        }

        public void GetMaxIndex(out int maxIndX, out int maxIndY)
        {
            int maxX = 0, maxY = 0; 
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (MaxNum == Convert.ToInt32(arr[x, y]))
                    {
                        maxX = x;  maxY = y;
                    }
                }
            }
            maxIndX = maxX; maxIndY = maxY;
        }

        // Подсчитать частоту вхождения каждого элемента в массив 
        public Dictionary<int, int> GetFreqElement()
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();

            int repet = 1;

            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (myDictionary.ContainsKey(Convert.ToInt32(arr[x, y])))
                    {
                        myDictionary[Convert.ToInt32(arr[x, y])]++;
                    }
                    else
                    {
                        myDictionary.Add(Convert.ToInt32(arr[x, y]), repet);
                    }
                }
            }
            return myDictionary;
        }

        private static string[] LoadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string[] buf = new string[1000];
                    int counter = 0;

                    while (!reader.EndOfStream)
                    {
                        buf[counter] = reader.ReadLine();
                        counter++;
                    }
                    
                    string[] arr = new string[counter];

                    Array.Copy(buf, arr, counter);

                    return arr;
                }
            }
            else
            {
                throw new FileNotFoundException("File no exists !");
            }
        }
        static void WriteArrayFromFile(string fileName, string wrData)
        {
            if (File.Exists(fileName))
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + fileName, wrData);
            }
            else
            {
                throw new FileNotFoundException("File no exists !");
            }
        }
        public void WriteArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + fileName, Arr1D());
            }
            else
            {
                throw new FileNotFoundException("File no exists !");
            }
        }

        /*
        * *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        */
        public MyArray2D(string nameFile)
        {
            string[] arr0 = LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + nameFile);
            arr = new string[arr0.Length, 2];
            for (int i = 0; i < arr0.Length; i++)
            {
                arr[i, 0] = arr0[i].Split(' ')[0];
                arr[i, 1] = arr0[i].Split(' ')[1];
            }
        }

        //public MyArray2D(string nameFile)
        //{

        //}

        public void LoadArrayFile(string nameFile) 
        {
            string[] arr0 = LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + nameFile);
            arr = new string[arr0.Length, 2];
            for (int i = 0; i < arr0.Length; i++)
            {
                arr[i, 0] = arr0[i].Split(':')[0];
                arr[i, 1] = arr0[i].Split(':')[1];
            }
        }
        
        private string[] Arr1D()
        {
            string[] arr1D = new string[arr.Length];
            int z = 0;
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    arr1D[z] = arr[x, y];
                    z++;
                }
            }

            return arr1D;
        }
    }
}
#endregion

