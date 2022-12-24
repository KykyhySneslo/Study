﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeExample;

namespace PracticWork8_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree T = new BinaryTree();
            Console.WriteLine("Количество узлов: ");
            T.Root = T.Create_Balanced(Convert.ToInt32(Console.ReadLine()));

            ArithmeticMean Solution = new ArithmeticMean();
            Console.WriteLine("Среднее арифметическое значений информационных полей узлов дерева: " + Solution.InorderTraversal(T.Root));

            SignCount count = new SignCount();
            count.Counting(T.Root);
            Console.WriteLine("Количество положительных значений: " + count.plusCount);
            Console.WriteLine("Количество отрицательных значений: " + count.minusCount);

            Console.WriteLine("Введите искомое значение: ");
            int value = Convert.ToInt32(Console.ReadLine());
            Search search = new Search();
            Console.WriteLine("Найдено совпадений: " + search.SearchValue(T.Root, value));
        }
    }
    public class ArithmeticMean //Среднее арифсетическое информационных полей узлов дерева
    {
        public double InorderTraversal(TreeNode root)
        {
            var sum = 0;
            var count = 0;
            InorderTraversal(root, ref sum, ref count);
            return (double)sum / count;
        }

        private void InorderTraversal(TreeNode root, ref int sum, ref int count)
        {
            if (root == null)
                return;

            if (root.Left != null)
                InorderTraversal(root.Left, ref sum, ref count);

            sum += Convert.ToInt32(root.Info);
            count++;

            if (root.Right != null)
                InorderTraversal(root.Right, ref sum, ref count);
        }
    }
    public class SignCount //Количество положительных и отрицательных значений
    {
        public int plusCount = 0;
        public int minusCount = 0;
        public void Counting(TreeNode root)
        {

            if (root == null)
                return;

            if (root.Left != null)
                Counting(root.Left);

            if (root.Info >= 0)
                plusCount++;
            else
                minusCount++;

            if (root.Right != null)
                Counting(root.Right);
        }
    }
    public class Search //Поиск совпадений по значению
    {
        int result = 0;

        public int SearchValue(TreeNode root, int value)
        {
            if (root == null)
                return result;

            if (root.Left != null)
                SearchValue(root.Left, value);

            if (root.Info == value)
                result++;

            if (root.Right != null)
                SearchValue(root.Right, value);

            return result;
        }
    }
}