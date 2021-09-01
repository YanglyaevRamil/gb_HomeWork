using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 1.Form
            /*
             * Написать программу «Анкета». 
             * Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).
             * В результате вся информация выводится в одну строчку:
             * а) используя склеивание;
             * б) используя форматированный вывод;
             * в) используя вывод со знаком $.
            */

            Console.Title = "Form"; 

            Console.WriteLine("Напишите ваше имя");
            string name = Console.ReadLine();

            Console.WriteLine("Напишите вашу фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Напишите ваш возраст");
            string age = Console.ReadLine();

            Console.WriteLine("Напишите ваш рост");
            string growth = Console.ReadLine();

            Console.WriteLine("Напишите ваш вес");
            string weight = Console.ReadLine();

            //Console.WriteLine("Пользователь " + name + " " + surname + " его возраст " + age + ", рост " + growth + ", вес " + weight);
            //Console.WriteLine("Пользователь {0} {1} его возраст {2}, рост {3}, вес {4}", name, surname, age, growth, weight);
            Console.WriteLine($"Пользователь {name} {surname} его возраст {age}, рост {growth}, вес {weight}");
            Console.ReadLine();
            #endregion

            Console.Clear();

            #region 2.Index_Mas_Body
            /*
             * Ввести вес и рост человека. 
             * Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
             * где m — масса тела в килограммах, h — рост в метрах.
            */
            Console.Title = "IMB";

            Console.WriteLine("Введите ваш вес в килограммах");
            float body_mass = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Введите ваш рост в метрах");
            float body_growth = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine($"Ваш индекс массы тела ИМТ = {body_mass / (body_growth * body_growth)}");
            
            Console.ReadLine();
            #endregion

            Console.Clear();

            #region 3.Distance
            /*
             * а) Написать программу, которая подсчитывает расстояние между точками с координатами 
             * x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
             * Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой)
             * б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            */
            Console.Title = "Distance";

            Console.WriteLine("Введите координаты первой точки x1, y1");
            double x1 = Convert.ToSingle(Console.ReadLine());
            double y1 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите координаты второй точки x2, y2");
            double x2 = Convert.ToSingle(Console.ReadLine());
            double y2 = Convert.ToSingle(Console.ReadLine());
            // 1 realization
            //Console.WriteLine("Растояние между точками : {0:F}", Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))) ;

            // 2 realization
            Console.WriteLine("Растояние между точками : {0:F}", Ruler(x1, y1, x2, y2));
            Console.ReadLine();
            #endregion

            Console.Clear();

            #region 4.Exch_numbers
            /*
             * Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
             * а) с использованием третьей переменной;
             * б) *без использования третьей переменной.
            */
            Console.Title = "Exch_numbers";

            Console.WriteLine("Введите 2 числа");

            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"x = {x} y = {y}");

            // 1 realization
            // int k = x;
            // x = y;
            // y = k;

            // 2 realization
            x = x + y;
            y = x - y;
            x = x - y;

            Console.WriteLine($"x = {x} y = {y}");

            Console.ReadLine();
            #endregion

            Console.Clear();

            #region 5.output_FullName
            /*
             * а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
             * б) Сделать задание, только вывод организовать в центре экрана.
             * в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
            */
            Console.Title = "FullName";

            string message = "Ramil Yanglyaev from Moscow";
            Console.WriteLine(message);
            Pause();

            Console.SetCursorPosition(Console.WindowWidth/2 - message.Length / 2, Console.WindowHeight/2 - 1);
            Console.WriteLine(message);
            Pause();


            Print(message, 50, 50);
            Pause();
            #endregion

            Console.Clear();

            #region 6.sap_class
            /*
             * *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
            */
            help_class help = new help_class();

            help.Print("Hello!", 13, 9);
            help.Print("Hello!");

            Console.ReadLine();
            #endregion
        }

        #region Distance_function
        static double Ruler(double x1, double y1, double x2, double y2)
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }
        #endregion

        #region output_FullName_function
        static void Print(string ms, int x, int y)
        {
            Console.SetCursorPosition(x/2 - ms.Length/2, y/2 - 1);
            Console.WriteLine(ms);
        }
        static void Pause()
        {
            Console.ReadLine();
            Console.Clear();
        }
        #endregion
    }

    class help_class  //не понятен смысл данного класса, какую сущность должен описывать данный класс ?
    {
        public help_class() { } 

        public void Print(string text)
        {
            Console.WriteLine(text);

            Console.ReadLine();
        }
        public void Print(string text, int num_color, int num_back)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.ForegroundColor = colors[num_color];
            Console.BackgroundColor = colors[num_back ];
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadLine();
        }

        public void Pause(int sec)
        {
            System.Threading.Thread.Sleep(1000 * sec);
        }
    }
}
