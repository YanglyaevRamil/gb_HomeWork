using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class CoreForm1
    {
        private int number;

        public int Number { get { return number; } }

        public CoreForm1()
        {
            Rnd();
        }

        public void Rnd()
        {
            Random rnd = new Random();
            number = rnd.Next(1, 100);
        }

        public bool Less(int n)
        {
            return n < number;
        }

        public bool Greate(int n)
        {
            return n > number;
        }

        public bool Eq(int n)
        {
            return n == number;
        }

        public int Comparison(int n)
        {
            return n > number ? 1 : n == number ? 0 : -1;
        }
    }
}
