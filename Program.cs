using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("First task");// Одномерные массивы
            _ = new Arrs();
            int[] A = new int[5],//Объявление массивов
                  B = new int[5],//и выделение памяти
                  C = new int[5];

            Arrs.CreateOneDimAr(A);//Инициализация
            Arrs.CreateOneDimAr(B);

            for(int i = 0; i < C.Length; i++)//Инициализация через сумму A+B
            {
                C[i] = A[i] + B[i];
            }

            int[] X = { 5, 5, 6, 6, 7, 7 };//Явная инициализация

            int[] U, V;//Отложенная инициализация(Память выделяется позже)

            U = new int[3] { 1, 2, 3 };//Выделение памяти и инициализация
            //V = { 1, 2, 3 }; Память еще не выделена
            V = new int[3];
            V=U;//Ссылка на одну и ту же память
            V[0] = 9;
            Arrs.PrintArr1("A", A);
            Arrs.PrintArr1("B", B);
            Arrs.PrintArr1("C", C);
            Arrs.PrintArr1("X", X);
            Arrs.PrintArr1("U", U);
            Arrs.PrintArr1("V", V);
            Console.WriteLine();

            Console.WriteLine("Введите Количество элементов массива");
            int Size = int.Parse(Console.ReadLine());//Динамический массив, размер массива задается с клавиатуры
            int[] D = new int[Size];
            Arrs.CreateOneDimAr(D);
            Arrs.PrintArr1("D", D);
            Console.WriteLine();


            Console.WriteLine("Second task");//Двумерные массивы 

            int[,] arr1 = new int[4, 2];//Умножение возможно
            int[,] arr2 = new int[2, 3];
            Arrs.CreateArr2(arr1);
            Arrs.CreateArr2(arr2);
            int[,] arr3 = Arrs.MultMutr(arr1, arr2);
            Arrs.PrintArr2("arr1", arr1);
            Arrs.PrintArr2("arr2", arr2);
            Arrs.PrintArr2("arr3", arr3);
            Console.WriteLine();

           int[,] arr11 = new int[4, 2];//Умножение невозможно
            int[,] arr12 = new int[4, 3];
            Arrs.CreateArr2(arr11);
            Arrs.CreateArr2(arr12);
            int[,] arr13 = Arrs.MultMutr(arr11, arr12);
            Arrs.PrintArr2("arr1", arr11);
            Arrs.PrintArr2("arr2", arr12);
            Arrs.PrintArr2("arr3", arr13);
            Console.WriteLine();

            Console.WriteLine("Third task");//Массивы массивов(Изрезанные массивы или Jagged arrays)
            int[][] R = new int[10][];
            Arrs.CreateArr3(R);
            Arrs.PrintArr3("arrArr", R);
            Console.WriteLine();
        }
    }

    class Arrs
    {
        private static Random rnd;

        public Arrs()
        {
            rnd = new Random();
        }
        
        public static void CreateOneDimAr(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 11);
            }
        }
        public static void PrintArr1(string name, int[] arr)
        {
            Console.WriteLine(name);
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("elem[{0}] = {1}",i,arr[i]);
            }
        }
        public static void CreateArr2(int[,] arr)
        {
            int one = arr.GetLength(0);
            int two = arr.GetLength(1);
            for (int i = 0; i < one; i++)
            {
                for (int j = 0; j < two; j++)
                {
                    arr[i, j] = rnd.Next(1, 11);
                }
            }
        }
          public static void PrintArr2(string name, int[,] arr)
        {
            int one = arr.GetLength(0);
            int two = arr.GetLength(1);
            Console.WriteLine(name);
            for (int i = 0; i < one; i++)
            {
                for (int j = 0; j < two; j++)
                {
                    Console.Write("{0} ",arr[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static void CreateArr3(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int[] D = new int[i+1];
                Arrs.CreateOneDimAr(D);
                arr[i] = D;
              
            }
        }

         public static void PrintArr3(string name, int[][] arr)
        {
            Console.WriteLine(name);
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    System.Console.Write("{0} ", arr[i][j]);
                }
                System.Console.WriteLine();
            }
        }

        public static int[,] MultMutr(int[,] matr1, int[,] matr2)
        {
            int M = matr1.GetLength(0);
            int k1 = matr1.GetLength(1);
            int k2 = matr2.GetLength(0);
            int N = matr2.GetLength(1);
            int[,] result = new int[M, N];
            if(k1 == k2)
            {
                for(int i = 0; i < M; i++)
                {
                    for(int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < k2; k++ )
                            result[i, j] += matr1[i, k] * matr2[k, j];
                    }
                }
            }
            return result;
        }
    }
}
