using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace lesson_6
{


    class Program
    {
        public delegate double Fun(double x);
        public delegate double FunHW(double a, double x);

        static void Main()
        {
            
            string numLess;
            string repeat = "n";
            getInfo(4);

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
                            // Создаем новый делегат и передаем ссылку на него в метод Table
                            Console.WriteLine("Таблица функции MyFunc:");
                            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
                            Table(new Fun(MyFunc), -2, 2);
                            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");

                            // Упрощение(c C# 2.0).Делегат создается автоматически.            
                            Table(MyFunc, -2, 2);
                            Console.WriteLine("Таблица функции Sin:");
                            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
                            Console.WriteLine("Таблица функции x^2:");
                            // Упрощение(с C# 2.0). Использование анонимного метода
                            Table(delegate (double x) { return x * x; }, 0, 3);
                            Console.WriteLine("==============================Home_Work=========================================");
                            Console.WriteLine("Таблица функции a*x^2:");
                            Table(FuncAXX, 5, -2, 2);
                            Console.WriteLine("Таблица функции a*sin(x):");
                            Table(FuncASin, 5, -2, 2);

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;

                    case "2":
                        messageMiddleX("Task 2");
                        double minOut;
                        do
                        {
                            int nameFunc;
                            bool flag = true; 
                            List<Fun> delegats = new List<Fun>();

                            delegats.Add(Sin);
                            delegats.Add(Cos);
                            delegats.Add(Tan);
                            delegats.Add(Exp);
                            delegats.Add(Qdrt);

                            do
                            {
                                Console.WriteLine("0 - Sin");
                                Console.WriteLine("1 - Cos");
                                Console.WriteLine("2 - Tan");
                                Console.WriteLine("3 - Exp");
                                Console.WriteLine("4 - Qdrt");
                                if (flag)
                                {
                                    Console.Write("Select number function: ");
                                    nameFunc = Convert.ToInt16(Console.ReadLine());
                                    flag = false;
                                }
                                else
                                {
                                    Console.Write("There is no such function number, repeat select number function: ");
                                    nameFunc = Convert.ToInt16(Console.ReadLine());
                                }

                            } while (nameFunc > 4);

                            Console.Write("Enter the left border: ");
                            double Min = Convert.ToDouble(Console.ReadLine());
                            
                            Console.Write("Enter the right border: ");
                            double Max = Convert.ToDouble(Console.ReadLine());

                            SaveFunc(delegats[nameFunc], "data.bin", Min, Max, 0.5);

                            double[] arr = Load("data.bin", out minOut);
                            Console.WriteLine(minOut);

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;

                    case "3":
                        messageMiddleX("Task 3");

                        do
                        {
                            try
                            {
                                // test а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
                                Console.WriteLine($"Number of students in 5th and 6th courses: { Student.GetStatFieldDoc("..\\..\\students.csv", "course", 5, 6)}");
                                // test б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
                                Console.WriteLine($"Students aged 18 to 20: {Student.GetStatFieldDoc("..\\..\\students.csv", "age", 18, 20)}");

                                // test в) отсортировать список по возрасту студента;
                                //      г) *отсортировать список по курсу и возрасту студента;
                                List<Student> s = Student.GetStudentList("..\\..\\students.csv");

                                foreach (Student st in s)
                                {
                                    Console.WriteLine($"{st.LastName} {st.FirstName} курс {st.Course} - возраст {st.Age}");
                                }

                                Console.WriteLine("-------------------------------------------");
                                s.Sort();

                                foreach (Student st in s)
                                {
                                    Console.WriteLine($"{st.LastName} {st.FirstName} курс {st.Course} - возраст {st.Age}");
                                }
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine($"Error - {e.Message}");
                            }

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;

                    case "4":
                        messageMiddleX("Task 4");

                        do
                        {

                            byte[] arr1 = FileStreamSample("..\\..\\test.txt");
                            string textFromFile1 = System.Text.Encoding.Default.GetString(arr1);
                            Console.WriteLine(textFromFile1);

                            Console.WriteLine("*****************************");

                            byte[] arr2 = BufferedStreamSample("..\\..\\test.txt", 256);
                            string textFromFile2 = System.Text.Encoding.Default.GetString(arr2);
                            Console.WriteLine(textFromFile2);

                            Console.WriteLine("*****************************");

                            string str1 = StreamReaderSample("..\\..\\test.txt");
                            Console.WriteLine(str1);

                            Console.WriteLine("*****************************");
                            int[] str2 = BinaryReaderSample("..\\..\\test.txt");

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");

                        break;

                    case "dop":
                        DirectoryInfo directoryInfo = new DirectoryInfo("C:/Users/User/Documents/my_work/C#/gb/lesson_6");
                        PrintDir(directoryInfo, "", true);
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
        private static void DrawStar()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("*");
            }
        }
        private static void getInfo(int j)
        {
            DrawStar();
            Console.WriteLine("0 - Shutdown");
            for (int i = 1; i <= j; i++)
            {
                Console.WriteLine($"{i} - Task {i}");
            }
            Console.WriteLine("dop - Additional Taskd");
            Console.WriteLine("c - Сlear Field");
            DrawStar();
        }
        private static void Сlean()
        {
            Console.Clear();
            getInfo(4);
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


        //====================================Task_1=======================================================
        /*
         * Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
         * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).    
         */
        #region Task_1
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
            //BaseTable(F(x), 0, x, b);
        }
        public static void Table(FunHW F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
            //BaseTable(F(a, x), a, x, b);
        }

        //public static void BaseTable(object d, double a, double x, double b)
        //{
        //    Console.WriteLine("----- X ----- Y -----");
        //    while (x <= b)
        //    {
        //        Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, d);
        //        x += 1;
        //    }
        //    Console.WriteLine("---------------------");
        //}

        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public static double FuncAXX(double a, double x)
        {
            return a * x * x;
        }
        public static double FuncASin(double a, double x)
        {
            return a * Math.Sin(x);
        }
        #endregion

        //====================================Task_2=======================================================
        /*
         * Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
         * а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. 
         * Использовать массив (или список) делегатов, в котором хранятся различные функции.
         * б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
         * Пусть она возвращает минимум через параметр (с использованием модификатора out).
         */
        #region Task_2

        public static double Sin(double x)
        {
            return Math.Sin(x);
        }
        
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }
        public static double Tan(double x)
        {
            return Math.Tan(x);
        }
        public static double Exp(double x)
        {
            return Math.Exp(x);
        }
        public static double Qdrt(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static void SaveFunc(Fun F, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            List<double> arr = new List<double>();
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                arr.Add(bw.ReadDouble());
            }
            bw.Close();
            fs.Close();
            min = arr.Min();
            return arr.ToArray();
        }


        #endregion

        //====================================Task_4=======================================================
        /*
         *  **Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
         *  Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader и массив int для BinaryReader.
         */
        #region Task_4
        static byte[] FileStreamSample(string fileName)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                byte[] arr = new byte[fs.Length];
                fs.Read(arr, 0, arr.Length);
                return arr;
            }
            
        }
        static byte[] BufferedStreamSample(string fileName, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            int countPart = 4;
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            using (FileStream fs = File.OpenRead(fileName))
            using (BufferedStream bs = new BufferedStream(fs, bufsize))
            {
                bs.Read(buffer, 0, 256);
            }
            stopwatch.Stop();
            return buffer;
        }

        static string StreamReaderSample(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                while (sr.ReadLine() != null)
                {
                    sb.Append(sr.ReadLine());
                }
                return sb.ToString();
            }
        }
        static int[] BinaryReaderSample(string fileName)
        {
            List<int> list = new List<int>();
            

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            while (br.PeekChar() > -1)
            {
                list.Add(br.Read());
            }
            fs.Close();

            byte[] arr = new byte[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                arr[i] =Convert.ToByte(list[i]);
            }

            char[] sp = {'\r', '\n'};
            
            string[] FromFile = System.Text.Encoding.Default.GetString(arr).Split(sp, StringSplitOptions.RemoveEmptyEntries);

            return Array.ConvertAll(FromFile, int.Parse);
        }

        #endregion

        //====================================AdditionalTask=======================================================
        static void PrintDir(DirectoryInfo dir, string indent, bool lastDirectory)
        {
            Console.Write(indent);
            if (lastDirectory)
            {
                Console.Write("└─");
                indent += "  "; // indent = indent + "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "│ ";
            }

            FileInfo[] subFiles = dir.GetFiles();

            DirectoryInfo[] subDirs = dir.GetDirectories();

            int NumberOfFiles = Convert.ToInt32(dir.GetFiles().Length.ToString());

            
            if (NumberOfFiles == 0)
            {
                Console.WriteLine(dir.Name);
            }
            else
            {
                Console.WriteLine(dir.Name);
                foreach (FileInfo item in subFiles)
                {
                    Console.WriteLine($"{indent}│ {item.Name}");
                }
                
            }
            //Console.WriteLine();

            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintDir(subDirs[i], indent, i == subDirs.Length - 1);
            }

        }

    }

    //====================================Task_3=======================================================
    /*
     * Переделать программу Пример использования коллекций для решения следующих задач:
     * а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
     * б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
     * в) отсортировать список по возрасту студента;
     * г) *отсортировать список по курсу и возрасту студента;
     */
    #region Task_3
    class Student : IComparable<Student>
    {

        private int course;
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string University { set; get; }
        public string Faculty { set; get; }
        public string Department { set; get; }
        public int    Age { set; get; }
        public int Course
        {
            set
            {
                if (value >= 1 && value <= 6)
                {
                    course = value;
                }
                else
                {
                    if (value < 1)
                    {
                        throw new ArgumentException("Parameter Course cannot be less than 1");
                    }
                    else
                    {
                        throw new ArgumentException("Parameter Course cannot be greater than 6");
                    }

                }
            }
            get
            {
                return course;
            }
        }
        public int    Group { set; get; }
        public string City { set; get; }

        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.University = university;
            this.Faculty = faculty;
            this.Department = department;
            this.Course = course;
            this.Age = age;
            this.Group = group;
            this.City = city;
        }
        public Student(string[] s)
        {
            this.LastName = s[0];
            this.FirstName = s[1];
            this.University = s[2];
            this.Faculty = s[3];
            this.Department = s[4];
            this.Age = Convert.ToInt32(s[5]);
            this.Course = Convert.ToInt32(s[6]);
            this.Group = Convert.ToInt32(s[7]); ;
            this.City = s[8];
        }
        public Student()
        {

        }

        static public List<Student> GetStudentList(string nameDoc)
        {
            List<Student> studentsList = new List<Student>();

            StreamReader sr = new StreamReader(nameDoc);
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(';');
                studentsList.Add(new Student(s));
            }

            return studentsList;
        }
        static private Dictionary<string, int> GetFreqDict(string str, List<Student> s)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();

            switch (str)
            {
                case "age":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string age = Convert.ToString(s[i].Age);
                        if (d.ContainsKey(age))
                        {
                            d[age]++;
                        }
                        else
                        {
                            d.Add(age, 1);
                        }
                    }
                    break;

                case "city":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string city = s[i].City;
                        if (d.ContainsKey(city))
                        {
                            d[city]++;
                        }
                        else
                        {
                            d.Add(city, 1);
                        }
                    }
                    break;

                case "group":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string group = Convert.ToString(s[i].Group);
                        if (d.ContainsKey(group))
                        {
                            d[group]++;
                        }
                        else
                        {
                            d.Add(group, 1);
                        }
                    }
                    break;

                case "department":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string department = s[i].Department;
                        if (d.ContainsKey(department))
                        {
                            d[department]++;
                        }
                        else
                        {
                            d.Add(department, 1);
                        }
                    }
                    break;

                case "course":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string course = Convert.ToString(s[i].Course);
                        if (d.ContainsKey(course))
                        {
                            d[course]++;
                        }
                        else
                        {
                            d.Add(course, 1);
                        }
                    }
                    break;

                case "faculty":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string faculty = s[i].Faculty;
                        if (d.ContainsKey(faculty))
                        {
                            d[faculty]++;
                        }
                        else
                        {
                            d.Add(faculty, 1);
                        }
                    }
                    break;

                case "university":
                    for (int i = 0; i < s.Count; i++)
                    {
                        string university = s[i].University;
                        if (d.ContainsKey(university))
                        {
                            d[university]++;
                        }
                        else
                        {
                            d.Add(university, 1);
                        }
                    }
                    break;

                default:
                    break;
            }

            return d;
        }

        static public int GetStatFieldDoc(string nameDoc, string field, int min, int max)
        {
            int sum = 0;

            Dictionary<string, int> d = GetFreqDict(field, GetStudentList(nameDoc));
            for (int i = min; i <= max; i++)
            {   
                if (d.ContainsKey(Convert.ToString(i)))
                {
                    sum += d[Convert.ToString(i)];
                }
            }
            return sum;
        }
        static public int GetStatFieldDoc(string nameDoc, string field, string str)
        {
            Dictionary<string, int>  d = GetFreqDict(field, GetStudentList(nameDoc));

            return d[str];
        }

        public int CompareTo(Student other)
        {
            if (Course.CompareTo(other.Course) == 0)
            {
                return Age.CompareTo(other.Age);
            }
            else
            {
                return Course.CompareTo(other.Course);
            }
            //Age.CompareTo(other.Age);
            //Course.CompareTo(other.Course); 
        }
    }

    #endregion

}
