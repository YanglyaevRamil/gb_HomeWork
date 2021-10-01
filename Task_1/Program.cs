using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    // С помощью рефлексии выведите все свойства структуры DateTime.
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(DateTime);

            FieldInfo[] fieldInfo = type.GetFields();
            PropertyInfo[] propertyInfos = type.GetProperties();

            Console.WriteLine("------------------------------");
            Console.WriteLine("Field Info --->");

            for (int i = 0; i < fieldInfo.Length; i++)
            {
                Console.WriteLine(fieldInfo[i]);
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("Property Info --->");

            for (int i = 0; i < propertyInfos.Length; i++)
            {
                Console.WriteLine(propertyInfos[i]);
            }

            Console.ReadLine();

        }
    }
}
