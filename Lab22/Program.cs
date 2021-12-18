using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива, который сформируется из случайных чисел");
            int arrayLenght = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int[] arrayRandom = new int[arrayLenght];
            Random random = new Random();
            for (int i = 0; i < arrayLenght; i++)
            {
                arrayRandom[i] = random.Next(0, 100);
            }
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.WriteLine(arrayRandom[i]);
            }
            Console.WriteLine();
            Action<object> action = new Action<object>(CalculateSumFromArray);
            Task task1 = new Task(action, arrayRandom);

            Action<Task, object> actionTask = new Action<Task, object>(FindMaxFromArray);
            Task task2 = task1.ContinueWith(actionTask, arrayRandom);
            task1.Start();

            Console.ReadKey();
        }
        static void CalculateSumFromArray(object arrayObject)
        {
            int[] array = (int[])arrayObject;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("Сумма всех чисел в массиве равна {0}", sum);
        }
        static void FindMaxFromArray(Task task, object arrayObject)
        {
            int[] array = (int[])arrayObject;
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.Write("Максимальное число в массиве равно {0}", max);
        }
    }
}
