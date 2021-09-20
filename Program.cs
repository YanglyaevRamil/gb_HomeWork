using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string numLess;
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
                            Console.WriteLine($"method : CheckRegex   log : 8Hello!   bool : {CheckRegex("8Hello!")}");
                            Console.WriteLine($"method : Check   log : 8Hello!   bool : {Check("8Hello!")}");

                            Console.WriteLine($"method : CheckRegex   log : 8Hello!   bool : {CheckRegex("Hello!8")}");
                            Console.WriteLine($"method : Check   log : 8Hello!   bool : {Check("Hello!8")}");

                            Console.WriteLine($"method : CheckRegex   log : 8Hello!   bool : {CheckRegex("H")}");
                            Console.WriteLine($"method : Check   log : 8Hello!   bool : {Check("H")}");

                            Console.WriteLine($"method : CheckRegex   log : 8Hello!   bool : {CheckRegex("2")}");
                            Console.WriteLine($"method : Check   log : 8Hello!   bool : {Check("2")}");

                            Console.Write("Enter login: ");
                            string login = Console.ReadLine();
                            Console.WriteLine($"method : CheckRegex   log : {login}!   bool : {CheckRegex(login)}");
                            Console.WriteLine($"method : Check   log : {login}!   bool : {Check(login)}");

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;
                    case "2":
                        messageMiddleX("Task 2");

                        do
                        {
                            // а) Вывести только те слова сообщения, которые содержат не более n букв.
                            Console.WriteLine(Message.GetNormalWord("Hel Hello H", 4));
                            // б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
                            Console.WriteLine(Message.GetStrFilerLastSign("ffff fff ffffa dwdea www reghtehtgha", "a"));
                            // в) Найти самое длинное слово сообщения.
                            Console.WriteLine(Message.GetLongWord("Октябрь уж наступил — уж роща отряхает"));
                            string txt = "Октябрь уж наступил — уж роща отряхает. Октябрь. Октябрь. роща. уж наступил — уж роща отряхает";
                            //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
                            string s = Message.GetLongSrt(new string[] { "Октябрь уж наступил — уж роща отряхает.", "Последние листы с нагих своих ветвей", "Дохнул осенний хлад — дорога промерзает" });
                            Console.WriteLine(s);
                            // д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст,
                            // в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
                            Dictionary<string, int> myDict = Message.GetFreqElement(new string[] { "Октябрь", "роща" }, txt);
                            foreach (KeyValuePair<string, int> i in myDict)
                            {
                                Console.WriteLine($"word : {i.Key} - Frequency : {i.Value}");
                            }

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;
                    case "3":
                        messageMiddleX("Task 3");

                        do
                        {
                            Console.WriteLine($"str0 = badc  :  str1 = abcd  :  {Message.GetPermutation("badc", "abcd")}");
                            Console.WriteLine($"str0 = badcw  :  str1 = abcdv  :  {Message.GetPermutation("badcw", "abcdv")}");

                            Console.Write("Enter the first STRING: ");
                            string str0 = Console.ReadLine();
                            Console.Write("Enter the second STRING: ");
                            string str1 = Console.ReadLine();

                            Console.WriteLine($"str0 = {str0}  :  str1 = {str1}  :  {Message.GetPermutation(str0, str1)}");

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break; ;
                    case "4":
                        messageMiddleX("Task 4");

                        do
                        {   
                            string[,] classList = Diary.GetArrGrades(Diary.LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "list.txt"));
                            string[,] ArrLoser = Diary.GetLoser(classList);
                            Console.WriteLine($"List of worst students");
                            for (int i = 0; i < ArrLoser.GetLength(0); i++)
                            {
                                Console.WriteLine($"{i+1} : {ArrLoser[i, 0]}");
                            }
                        } while (repeat == "y");
                        break; ;

                    case "c":
                        Сlean();
                        break;

                    default:
                        break;
                }

            } while (numLess != "0");
        }

        //====================================Task_1=======================================================
        /*
         * Создать программу, которая будет проверять корректность ввода логина. 
         * Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, 
         * при этом цифра не может быть первой:
         * а) без использования регулярных выражений;
         * б) **с использованием регулярных выражений.        
         */

        public static bool Check(string log)
        {
            if (log.Length >= 2 && log.Length <= 10 && !(char.IsDigit(log[0])))
            {
                for (int i = 0; i < log.Length; i++)
                {
                    if ((log[i] >= 'A' && log[i] <= 'Z') || (log[i] >= 'a' && log[i] <= 'z'))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool CheckRegex(string log)
        {
            Regex reg = new Regex("^[^0-9][a-zA-Z]{2,10}");
            return reg.IsMatch(log);
        }

        #region Support
        private static void DrawStar()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }
        private static void getInfo()
        {
            DrawStar();
            Console.WriteLine("0 - Shutdown");
            Console.WriteLine("1 - Task 1");
            Console.WriteLine("2 - Task 2");
            Console.WriteLine("3 - Task 3");
            Console.WriteLine("4 - Task 4");
            Console.WriteLine("c - Сlear Field");
            DrawStar();
        }
        private static void Сlean()
        {
            Console.Clear();
            getInfo();
        }
        private static void messageMiddleXY(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(message);
        }
        private static void messageMiddleX(string message)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, Console.CursorTop);
            Console.WriteLine(message);

        }
        #endregion

    }

    //====================================Task_2=======================================================
    /*
     * Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
     * а) Вывести только те слова сообщения, которые содержат не более n букв.
     * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
     * в) Найти самое длинное слово сообщения.
     * г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
     * д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, 
     *    в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.      
     */
    static class Message
    {
        private static string[] separators = { ",", ".", "?", ";", ":", " ", "+", "-", "/", "*", "<", ">", "^" };

        static private bool RulerWord(string w, int n)
        {
            if (w.Length <= n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string GetNormalWord(string w, int n)
        {
            string[] words = w.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string new_word = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (RulerWord(words[i], n))
                {
                    new_word += words[i] + " ";
                }
            }
            return new_word;
        }
        static public string[] GetNormalWord(string[] w, int n)
        {
            List<string> arrWord = new List<string>();

            for (int i = 0; i < w.Length; i++)
            {
                if (RulerWord(w[i], n))
                {
                    arrWord.Add(w[i]);
                }
            }
            return arrWord.ToArray();
        }
        static public string[] GetNormalWord(List<string> w, int n)
        {
            for (int i = 0; i < w.Count; i++)
            {
                if (!RulerWord(w[i], n))
                {
                    w.RemoveAt(i);
                }
            }
            return w.ToArray();
        }

        // б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        static public string GetStrFilerLastSign(string str, string x)
        {
            StringBuilder s = new StringBuilder(str);
            string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Regex reg = new Regex($"{x}$");
            for (int i = 0; i < words.Length; i++)
            {
                if (reg.IsMatch(words[i]))
                {
                    s.Replace(words[i], "");
                }
            }
            return s.ToString();
        }

        // в) Найти самое длинное слово сообщения.
        static public string GetLongWord(string str)
        {
            string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int max = 0, index = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (max < words[i].Length)
                {
                    index = i;
                    max = words[i].Length;
                }
            }
            return words[index];
        }

        // г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        static public string GetLongSrt(string[] ArrStr)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < ArrStr.Length; i++)
            {
                s.Append($"{GetLongWord(ArrStr[i])} ");
            }
            return s.ToString();
        }

        // д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, 
        //    в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary. 
        static public Dictionary<string, int> GetFreqElement(string[] word, string txt)
        {

            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            string[] wordsTxt = txt.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < word.Length; i++)
            {
                myDictionary.Add(word[i], 0);
            }

            foreach (string item in word)
            {
                for (int i = 0; i < wordsTxt.Length; i++)
                {
                    if (item == wordsTxt[i])
                    {
                        myDictionary[item]++;
                    }
                }
            }

            return myDictionary;
        }

        //====================================Task_3=======================================================
        /*
         * *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
         * Например: badc являются перестановкой abcd.   
         */
        static public bool GetPermutation(string s0, string s1)
        {
            StringBuilder sb0 = new StringBuilder(s0);
            StringBuilder sb1 = new StringBuilder(s1);

            if (s0.Length == s1.Length)
            {
                for (int i = 0; i < s0.Length; i++)
                {
                    for (int j = 0; j < sb1.Length; j++)
                    {
                        if (sb0[i] == sb1[j])
                        {
                            //sb0.Remove(i, 1);
                            sb1.Remove(j, 1);
                        }
                    }

                }
                if (sb1.Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }

    //====================================Task_4=======================================================
    /*
     * *Задача ЕГЭ.
     */
    static class Diary
    {
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
                        buf[counter] = Convert.ToString(reader.ReadLine());
                        counter++;
                    }

                    string[] arr = new string[counter];

                    Array.Copy(buf, arr, counter);

                    return arr;

                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static string[,] GetArrGrades(string[] arr)
        {

            List<string> w = arr[1].Split(' ').ToList();

            string[,] grades = new string[Convert.ToInt32(arr[0]), 3];
            string[] words = new string[w.Count];
            int sum;
            for (int i = 0; i < arr.Length-1; i++)
            {
                sum = 0;
                words = arr[i+1].Split(' ');
                for (int j = 2; j < w.Count; j++)
                {
                    sum += Convert.ToInt32(words[j]);
                }
                grades[i, 0] = words[0] + " " + words[1];
                grades[i, 1] = Convert.ToString(sum);
                grades[i, 2] = "0";
            }
            return grades;
        }

        private static int GetMaxList2D(List<List<string>> vs, out int indx)
        {
            int max = 0;
            indx = 0;
            for (int i = 0; i < vs.Count; i++)
            {
                if (max < Convert.ToInt32(vs[i][1]))
                {
                    max = Convert.ToInt32(vs[i][1]);
                    indx = i; 
                }
            }
            //indx = 0;
            return max;
        }

        public static string[,] GetLoser(string[,] ar)
        {
            List<List<string>> listLosser = new List<List<string>>();

            int indx = 0;
            for (int i = 0; i < ar.GetLength(0); i++)
            { 
                if (i < 3)
                {
                    listLosser.Add(new List<string>());
                    listLosser[i].Add(ar[i, 0]);
                    listLosser[i].Add(ar[i, 1]);
                    ar[i, 2] = "1";
                }
                else 
                {
                    if (GetMaxList2D(listLosser, out indx) > Convert.ToInt32(ar[i, 1]))
                    {
                        listLosser[indx][0] = ar[i, 0];
                        listLosser[indx][1] = ar[i, 1];
                        ar[i, 2] = "1";
                    }
                    
                }
            }

            for (int i = 0; i < ar.GetLength(0); i++)
            {
                if (GetMaxList2D(listLosser, out indx) == Convert.ToInt32(ar[i, 1]) && ar[i, 2] != "1")
                {
                    listLosser.Add(new List<string>());
                    listLosser[listLosser.Count - 1].Add(ar[i, 0]);
                    listLosser[listLosser.Count - 1].Add(ar[i, 1]);
                }
            }

            string[,] ArrLosser = new string[listLosser.Count, 2];
            for (int i = 0; i < listLosser.Count; i++)
            {
                ArrLosser[i, 0] = listLosser[i][0];
                ArrLosser[i, 1] = listLosser[i][1];
            }

            return ArrLosser;
        }
    }
}
