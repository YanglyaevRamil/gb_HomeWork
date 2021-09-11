using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string numLess;
            string repeat = "n";
            int Re, Im;
            getInfo();
            do
            {
                Console.Write("Enter the task number : ");
                numLess = Console.ReadLine();

                switch (numLess)
                {
                    case "0":
                        Console.Clear();
                        messageMiddleXY("Shutdown");
                        Console.ReadLine();
                        break;
                    case "1":
                        messageMiddleX("Structure and Class Complex Number");
                        Console.WriteLine("a - Structure work examination");
                        Console.WriteLine("б - Сlass work examination");
                        Console.WriteLine("в - Class work examination through switch");
                        Console.WriteLine("Enter the under task number : ");

                        string underNumLess = Console.ReadLine();

                        switch (underNumLess)
                        {
                            case "а": // Part A, examination
                                messageMiddleX("Structure Complex Number. Structure work examination");

                                do
                                {
                                    Complex.InitUserComplexNum(out Re, out Im);
                                    Complex cmplx0 = Complex.GetСreateComplexNum(Re, Im);
                                    Console.Write("Enter sign(+-*): ");
                                    string s = Console.ReadLine();
                                    Complex.InitUserComplexNum(out Re, out Im);
                                    Complex cmplx1 = Complex.GetСreateComplexNum(Re, Im);

                                    try
                                    {
                                        Console.WriteLine($" ({cmplx0}) {s} ({cmplx1}) = ({cmplx0.Calculator(cmplx1, s)})");
                                    }
                                    catch (Exception ex)
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

                            case "б": // Part Б, examination
                                messageMiddleX("Class Complex Number. Сlass work examination");

                                do
                                {
                                    ComplexClass.InitUserComplexNum(out Re, out Im);
                                    ComplexClass Cmplx0 = new ComplexClass(Re, Im);
                                    Console.Write("Enter sign(+-*): ");
                                    string S = Console.ReadLine();
                                    ComplexClass.InitUserComplexNum(out Re, out Im);
                                    ComplexClass Cmplx1 = new ComplexClass(Re, Im);

                                    try
                                    {
                                        Console.WriteLine($" ({Cmplx0}) {S} ({Cmplx1}) = ({Cmplx0.Calculator(Cmplx1, S)})");
                                    }
                                    catch (Exception ex)
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

                            case "в": // Part В, examination
                                messageMiddleX("Class Complex Number. Class work examination through switch");
                                do
                                {

                                    ComplexClass.InitUserComplexNum(out Re, out Im);
                                    ComplexClass Cmplx2 = new ComplexClass(Re, Im);
                                    Console.Write("Enter the sign(+-*) : ");
                                    string Sign = Console.ReadLine();
                                    ComplexClass.InitUserComplexNum(out Re, out Im);
                                    ComplexClass Cmplx3 = new ComplexClass(Re, Im);

                                    try
                                    {
                                        switch (Sign)
                                        {
                                            case "+":
                                                Console.WriteLine($" ({Cmplx2}) {Sign} ({Cmplx3}) = ({Cmplx2.Plus(Cmplx3)})");
                                                break;
                                            case "-":
                                                Console.WriteLine($" ({Cmplx2}) {Sign} ({Cmplx3}) = ({Cmplx2.Minus(Cmplx3)})");
                                                break;
                                            case "*":
                                                Console.WriteLine($" ({Cmplx2}) {Sign} ({Cmplx3}) = ({Cmplx2.Mux(Cmplx3)})");
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
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

                            default:
                                Console.WriteLine("Incorrect sign");
                                break;
                        }
                        break;

                    case "2":
                        messageMiddleX("The sum of all odd positive numbers");
                        do
                        {

                            RowOfNumbers();

                            Console.Write("Repeat calculation? y/n: ");
                            repeat = Console.ReadLine();
                        } while (repeat == "y");
                        break;

                    case "3":
                        messageMiddleX("Calss Fraction Number");
                        do
                        {
                            try
                            {
                                Console.Write("Enter the numerator: ");
                                int x0 = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter the denominator: ");
                                int y0 = Convert.ToInt32(Console.ReadLine());
                                Fraction f0 = new Fraction(x0, y0);
                                string sg;

                                do
                                {
                                    Console.Write("Enter the sign, only sign supported (+ - * /) :");
                                    sg = Console.ReadLine();

                                } while (!((sg == "+") || (sg == "-") || (sg == "*") || (sg == "/")));

                                Console.Write("Enter the numerator: ");
                                int x1 = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter the denominator: ");
                                int y1 = Convert.ToInt32(Console.ReadLine());
                                Fraction f1 = new Fraction(x1, y1);
                                Fraction f2 = f0.Calculator(f1, sg);
                                Console.WriteLine($" ({f0}) {sg} ({f1}) = ({f2}) (decimal {f2.DecimalFraction})");
                            }
                            catch (ArgumentException ex)
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
                    case "c":
                        Сlean();
                        break;
                    default:
                        Console.WriteLine("Incorrect sign");
                        break;
                }
            }
            while (numLess != "0");
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
            Console.WriteLine("1 - Task 1 : Structure Complex and Class Number");
            Console.WriteLine("2 - Task 2 : The sum of all odd positive numbers");
            Console.WriteLine("3 - Task 3 : Calss Fraction Number");
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

        //====================================Task_2=======================================================
        /*
         *  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
         *  Требуется подсчитать сумму всех нечётных положительных чисел. 
         *  Сами числа и сумму вывести на экран, используя tryParse.
        */
        static void RowOfNumbers()
        {
            int num, sum = 0;
            string numStr; 
            do
            {
                Console.Write("Enter the number : ");
                numStr = Console.ReadLine();
                if (Int32.TryParse(numStr, out num))
                {
                    if (num > 0 && num % 2 == 1)
                    {
                        sum += num;
                    }
                }
                else
                {
                    Console.WriteLine("You entered a wrong number, please try again");
                }


            }
            while (numStr != "0");

            Console.WriteLine($"The sum of all odd positive numbers : {sum}");
        }
    }

    //====================================Task_1=======================================================
    /*
     * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
     * 
    */

    #region SructComplex
    struct Complex
    {

        public double re;

        public double im;

        public Complex Plus(Complex x)
        {
            Complex y;
            y.re = re + x.re;
            y.im = im + x.im;

            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y;
            y.re = re - x.re;
            y.im = im - x.im;

            return y;
        }

        public Complex Mux(Complex x)
        {
            Complex y;
            y.re = re * x.re - im * x.im;
            y.im = re * x.im + x.re * im;

            return y;
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
        static public void InitUserComplexNum(out int Re, out int Im)
        {
            Console.Write("Re : ");
            Re = Convert.ToInt32(Console.ReadLine());
            Console.Write("Im : ");
            Im = Convert.ToInt32(Console.ReadLine());
        }
        static public Complex GetСreateComplexNum(int Re, int Im)
        {
            Complex cmplx;
            cmplx.re = Re; cmplx.im = Im;
            return cmplx;
        }

        public Complex Calculator(Complex c, string Sign)
        {
            if (Sign == "+")
            {
                return Plus(c);
            }
            else if (Sign == "-")
            {
                return Minus(c);
            }
            else if (Sign == "*")
            {
                return Mux(c);
            }
            else
            {
                throw new Exception("Sign not supported");
            }

        }
    }
    #endregion

    /*
     * б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
     * в) Добавить диалог с использованием switch демонстрирующий работу класса.
    */
    #region ClassComplex
    class ComplexClass
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public ComplexClass()
        {

        }

        public ComplexClass(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public ComplexClass(double im) : this(0, im) { }

        public ComplexClass Plus(ComplexClass x)
        {

            ComplexClass y = new ComplexClass(Re + x.Re, Im + x.Im);
            return y;
        }

        public ComplexClass Minus(ComplexClass x)
        {
            return new ComplexClass(Re - x.Re, Im - x.Im);
        }
        public ComplexClass Mux(ComplexClass x)
        {
            return new ComplexClass(Re * x.Re - Im * x.Im, Re * x.Im + x.Re * Im);
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Re} + {Im}i";
        }
        static public void InitUserComplexNum(out int R, out int I) // возможна дальнейшая модификация, функция будет принимать str формата Re+Im*i
        {
            Console.Write("Re : ");
            R = Convert.ToInt32(Console.ReadLine());
            Console.Write("Im : ");
            I = Convert.ToInt32(Console.ReadLine());
        }

        public ComplexClass Calculator(ComplexClass c, string Sign)
        {
            if (Sign == "+")
            {
                return Plus(c);
            }
            else if (Sign == "-")
            {
                return Minus(c);
            }
            else if (Sign == "*")
            {
                return Mux(c);
            }
            else
            {
                throw new Exception("Sign not supported");
            }
        }
    }
    #endregion


    //====================================Task_3=======================================================
    /*
     * *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
     * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
     * Написать программу, демонстрирующую все разработанные элементы класса.
     * Добавить свойства типа int для доступа к числителю и знаменателю;
     * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; 
     * ** Добавить проверку, чтобы знаменатель не равнялся 0. 
     * Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); *** Добавить упрощение дробей.
    */
    #region CalssFraction
    class Fraction
    {
        private int Denominator;
        int Numer { get; set; }

        public int Denom
        {
            get { return Denominator; }
            set
            {
                if (value != 0)
                {
                    Denominator = value;
                }
                else
                {
                    throw new ArgumentException("The denominator cannot be 0 !!!");
                }
            }
        }
        public double DecimalFraction
        {
            get { return Convert.ToDouble(Numer) / Convert.ToDouble(Denom); }
        }

        public Fraction()
        {
            Denom = 1;
        }
        public Fraction(int N, int D)
        {
            Numer = N;
            Denom = D;
        }
        public Fraction(int D) : this(0, D)
        {
            throw new Exception("You entered an incomplete fraction!");
        }

        public override string ToString()
        {
            return $"{Numer}/{Denom}";
        }

        public Fraction Minus(Fraction a)
        {
            Fraction b = new Fraction(Numer * a.Denom - a.Numer * Denom, Denom * a.Denom);
            int GCD = getGCD(b.Numer, b.Denom);
            b.Numer /= GCD; b.Denom /= GCD;
            return b;
        }
        public Fraction Plus(Fraction a)
        {
            Fraction b = new Fraction(Numer * a.Denom + a.Numer * Denom, Denom * a.Denom);
            int GCD = getGCD(b.Numer, b.Denom);
            b.Numer /= GCD; b.Denom /= GCD;
            return b;
        }
        public Fraction Mux(Fraction a)
        {
            Fraction b = new Fraction(Numer * a.Numer, Denom * a.Denom);
            int GCD = getGCD(b.Numer, b.Denom);
            b.Numer /= GCD; b.Denom /= GCD;
            return b;
        }
        public Fraction Division(Fraction a)
        {
            Fraction b = new Fraction(Numer * a.Denom, Denom * a.Numer);
            int GCD = getGCD(b.Numer, b.Denom);
            b.Numer /= GCD; b.Denom /= GCD;
            return b;
        }

        static private int getGCD(int n, int d)
        {
            int numer = Math.Abs(n);
            int denom = Math.Abs(d);

            while (denom != 0)
            {
                int temp = denom;
                denom = numer % denom;
                numer = temp;
            }
            return numer;
        }

        public Fraction Calculator(Fraction c, string Sign)
        {
            if (Sign == "+")
            {
                return Plus(c);
            }
            else if (Sign == "-")
            {
                return Minus(c);
            }
            else if (Sign == "*")
            {
                return Mux(c);
            }
            else if (Sign == "/")
            {
                return Division(c);
            }
            else
            {
                throw new Exception("Sign not supported");
            }
        }

    }
    #endregion

}
