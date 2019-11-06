using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threads
{
    class Matrix
    {
        public int[,] Value { get; set; }
        public int Rows { get; private set; }
        public int Colums { get; private set; }

        private int _sum;
        private int[] _partSum;

        public Matrix(){}
        public Matrix(int n, int m)
        {
            Rows = n;
            Colums = m;
            Value = GetMatrix(n, m);
            _partSum = new int[n];
        }

        public int AddElements(int amountOfThreads)
        {
            _sum = 0;            
            int start;
            int end;
            amountOfThreads = amountOfThreads > Rows ? Rows : amountOfThreads;
            Thread[] threads = new Thread[amountOfThreads];

            int forThread = Rows / (amountOfThreads);           

            for (int i = 0; i < amountOfThreads; i++)
            {
                if (i != amountOfThreads - 1)
                {
                    start = i * forThread;
                    end = (i + 1) * forThread;
                    threads[i] = new Thread(() => AddInRows(start, end));
                    threads[i].Start();
                }
                else
                {
                    start = i * forThread;
                    end = Rows;
                        threads[i] = new Thread(() => AddInRows(start, end));
                    threads[i].Start();
                }
            }

            foreach (Thread th in threads)
                th.Join();

            _sum = _partSum.Sum();

            return _sum;          
        }

        private void AddInRows(int from, int to)
        {           
            for (int i = from; i < to; i++)
            {
                _partSum[i] = 0;
                for (int j = 0; j < Colums; j++)
                {
                    _partSum[i] += Value[i, j];
                }
            }
        }

        private int[,] GetMatrix(int n, int m)
        {
            Random rnd = new Random();
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(0, 1000);
                }
            }

            return matrix;
        }
    }
}
