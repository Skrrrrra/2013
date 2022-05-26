using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LikeMinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //путь
            string inputpath = "D:\\SolutionsForSpaceApp\\2013\\input.txt";
            string outputpath = "D:\\SolutionsForSpaceApp\\2013\\output.txt";

            //создание файлов
            FileStream fs = new FileStream(inputpath, FileMode.OpenOrCreate);
            fs.Close();
            FileStream fsout = new FileStream(outputpath, FileMode.OpenOrCreate);
            fsout.Close();

            //переменная для обьвления размера массива(1 стр)
            int a;
            using (var reader = new StreamReader(inputpath))
            {
                a = Convert.ToInt32(reader.ReadLine());  // записываем в переменную
            }

            //запись в строку содержимого 2 строки файла
            string secondLine;
            using (var reader = new StreamReader(inputpath))
            {
                reader.ReadLine(); //пропуск 1 строки
                secondLine = reader.ReadLine();  // записываем в переменную
            }
            //запись из строки в массив строк с разделением
            string[] secondlineforint = secondLine.Split(' ');

            //массив для действий над числами
            int[] lastintarr;
            lastintarr = new int[a];

            //запись в интовый массив из массива строк
            int count = 0;
            foreach (var s in secondlineforint)
            {
                lastintarr[count] = Convert.ToInt32(s);
                count++;
            }


            //вычисление минимального элемента массива и переназначение
            int min = lastintarr[0];
            for (int i = 0; i < lastintarr.Length; i++)
            {
                for (int j = 0; j < lastintarr.Length - 1; j++)
                {
                    if (lastintarr[j] < lastintarr[j + 1])
                    {
                        min = lastintarr[j];
                    }
                    else min=lastintarr[j + 1];

                }
            }
            //обьявление счетчика прогонка по массиву для поиска совпадений
            int score = 0;
            for (int i = 0; i < a; i++)
            {
                
                    if (lastintarr[i] == min)
                    {
                        score++;
                    }
                
            }
            File.WriteAllText(outputpath, score.ToString());





        }
    }
}
