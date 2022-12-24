using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticWork11_5
{
    internal class Matrix
    {
        
        private int n; // Скрытые поля
        private int[,] mass;

        
        public Matrix() { }  //конструкторы матрицы
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }

        
        public Matrix(int n) //аксессоры для работы с полями вне класса Matrix
        {
            this.n = n;
            mass = new int[this.n, this.n];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        
        public void WriteMatrix() // Ввод матрицы с клавиатуры
        {
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //mass[i, j] = r.Next(2);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        
        public void ReadMatrix() // Вывод матрицы с клавиатуры
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


       
        public void oneMat(Matrix a)  // Проверка матрицы А на единичность
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 1 && i == j)
                    {
                        count++;
                    }
                }

            }
            if (count == a.N)
            {
                Console.WriteLine("Единичная");
            }
            else Console.WriteLine("Не единичная");
        }


     
        public static Matrix umnch(Matrix a, int ch)    // Умножение матрицы А на число
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] += a[i, j] * ch;
                }
            }
            return resMass;
        }

     
        public static Matrix umn(Matrix a, Matrix b)    // Умножение матрицы А на матрицу Б
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }


       
        public Matrix UnitMatrix()  //единичная матрица
        {
            Matrix unitMatrix = new Matrix(n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        unitMatrix[i, j] = 1;
                    else
                        unitMatrix[i, j] = 0;
                }
            return unitMatrix;
        }

        
        public string ConnectedGraph(Matrix reachabilityMatrix) // проверка на связность
        {
            int t = 1;

            for (int i = 0; i < reachabilityMatrix.N; i++)
                for (int j = 0; j < reachabilityMatrix.N; j++)
                    if (reachabilityMatrix[i, j] == 0)
                    {
                        t = 0;
                        break;
                    }

            if (t == 1)
                return "Граф является связным";
            else
                return "Граф не является связным";

        }

        
        public Matrix ReachabilityMatrix(Matrix matrix) // матрица достижимости
        {
            Matrix reachabilityMatrix = new Matrix(n);
            reachabilityMatrix = reachabilityMatrix.UnitMatrix();

            for (int i = 1; i < n; i++)
            {
                Matrix value = new Matrix(n);
                value = matrix;

                for (int j = 0; j < i; j++)
                    value = value * matrix;

                reachabilityMatrix = reachabilityMatrix + value;
            }

            reachabilityMatrix = reachabilityMatrix.BooleanMatrix(reachabilityMatrix);
            return reachabilityMatrix;
        }

        
        public Matrix BooleanMatrix(Matrix matrix) // создание булевой матрицы
        {
            for (int i = 0; i < matrix.n; i++)
                for (int j = 0; j < matrix.n; j++)
                {
                    if (matrix[i, j] != 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }

            return matrix;
        }

        
        public static Matrix operator *(Matrix a, Matrix b) // перегрузка оператора умножения
        {
            return Matrix.umn(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.umnch(a, b);
        }


        
        public static Matrix razn(Matrix a, Matrix b) // Метод вычитания матрицы Б из матрицы А
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }

       
        public static Matrix operator -(Matrix a, Matrix b)  // Перегрузка оператора вычитания
        {
            return Matrix.razn(a, b);
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        
        public static Matrix operator +(Matrix a, Matrix b) // Перегрузка сложения
        {
            return Matrix.Sum(a, b);
        }
        
        ~Matrix()
        {
            Console.WriteLine("Очистка"); // Деструктор Matrix
        }
    }
}
