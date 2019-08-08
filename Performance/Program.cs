using System;
using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Performance
{

    public struct MyStruct
    {
        public int num;
    }

    public class MyClass
    {
        private int i;

        public MyClass(int i)
        {
            this.i = i;
        }
    }

    [MemoryDiagnoser]
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();

            // For-ForEach Comparison 
            // Array-List Comparison            
            // String-StringBuilder Comparison            
            // Struct-Class Comparison            
            // Thread-Task Comparison



        }

        [Benchmark]
        public void CompareForLoop()
        {
            List<int> myList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                myList.Add(i);
            }
            int M = 0;
            for (int i = 0; i < 100; i++)
            {
                M++;
            }
        }

        [Benchmark]
        public void CompareForEachLoop()
        {
            List<int> myList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                myList.Add(i);
            }
            int m = 0;
            foreach (var item in myList)
            {
                m += item;
            }
        }

        [Benchmark]
        public void CompareArray()
        {
            int[] array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = i + 100;
            }
        }

        [Benchmark]
        public void CompareList()
        {
            List<int> myList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                myList.Add(i + 100);
            }
        }

        [Benchmark]
        public void CompareString()
        {
            var str = "String";
            for (int i = 0; i < 100; i++)
            {
                str += "a";
            }
        }


        [Benchmark]
        public void CompareStringBuilder()
        {
            var builder = new StringBuilder("String");
            for (int i = 0; i < 100; i++)
            {
                builder.Append("a");
            }
        }

        [Benchmark]
        public void CompareStruct()
        {
            MyStruct[] myStruct = new MyStruct[100];
            for (int i = 0; i < 100; i++)
            {
                myStruct[i].num = i;
            }
        }


        [Benchmark]
        public void CompareClass()
        {
            MyClass[] myClass = new MyClass[100];
            for (int i = 0; i < 100; i++)
            {

                myClass[i] = new MyClass(i);
            }
        }

        [Benchmark]
        public void CompareThread()
        {
            Thread Thread1 = new Thread(new ThreadStart(function1));
            Thread Thread2 = new Thread(new ThreadStart(function2));
            Thread1.Start();
            Thread2.Start();
            Thread1.Join();
            Thread2.Join();
        }


        [Benchmark]
        public void CompareTask()
        {
            Task.Run(async () =>
            {
                var task1 = Function3();

                var task2 = Function4();
                await Task.WhenAll(task1, task2);
            }).GetAwaiter().GetResult();
        }

        public static void function1()
        {
            int m = 0;
            m++;
            m++;
            m++;
        }

        public static void function2()
        {
            int m = 0;
            m++;
            m++;
            m++;
        }


        public async static Task Function3()
        {
            int m = 0;
            m++;
            m++;
            m++;
        }

        public async static Task Function4()
        {
            int m = 0;
            m++;
            m++;
            m++;
        }

    }
}
