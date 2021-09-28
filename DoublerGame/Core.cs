using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubler
{
    class Core
    {
        private int sum;
        private int number;
        private int numberClick;
        public int Sum { get { return sum; } }
        public int Number { get { return number; } }
        public int NumberClicks { get { return numberClick; } }
        public Core()
        {
            sum = 1;
            number = 0;
            numberClick = 0;
            LogDataList.Add(sum);
        }

        Stack<int> LogData = new Stack<int>();
        List<int> LogDataList = new List<int>();
        public void Inc()
        {
            sum++;
            numberClick++;
            LogDataList.Add(sum);

            LogData.Clear();
            for (int i = 0; i < LogDataList.Count-1; i++)
            {
                LogData.Push(LogDataList[i]);
            }
        }

        public void Mul()
        {
            sum *= 2;
            numberClick++;
            LogDataList.Add(sum);

            LogData.Clear();
            for (int i = 0; i < LogDataList.Count - 1; i++)
            {
                LogData.Push(LogDataList[i]);
            }
        }

        public void ReadLog()
        {
            if (numberClick >= 1)
            {
                sum = LogData.Pop();
                LogDataList.Remove(LogDataList.Count-1);
                LogDataList.Remove(LogDataList.Count-2);
                numberClick--;
            }
            else
            {
                sum = 1;
                LogDataList.Clear();
                LogDataList.Add(sum);
            }
        }

        public void Rnd()
        {
            Random rnd = new Random();
            number = rnd.Next(0, 100);
        }

        public bool Chek()
        {
            return sum == number;
        }
        public void Rst()
        {
            sum = 1;
            number = 0;
            numberClick = 0;
            LogDataList.Clear();
            LogDataList.Add(sum);
        }
    }
}
