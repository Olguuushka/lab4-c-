//серия наибольшей длинны из положительных

namespace лаба4_з
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            int n = 0;//размер матрицы
            Console.WriteLine("Введите размер квадратной матрицы n: ");
            n=Convert.ToInt32(Console.ReadLine());
            int[,] in_arr = new int[n, n];
            Random rnd = new Random();

            //заполнение матрицы произвольными числами
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    in_arr[i, j] = rnd.Next(-100, 100);
            Console.WriteLine("Произвольно заданная матрица размера "+n+"*"+n+":");
            Console.WriteLine("-----------------------------------------------------\n");
           
            //вывод матрицы в консоль
            for (int i = 0; i < in_arr.GetLength(0); i++)
            {
                for (int j = 0; j < in_arr.GetLength(1); j++)
                    Console.Write("\t" + in_arr[i, j]);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------\n");
            Console.WriteLine("Серии наибольшей длины из положительных чисел в каждой строке матрицы\n ");
            Console.WriteLine("-----------------------------------------------------\n");
            for (int i=0;i<n;++i)//обработка матрицы построчно
            {
                int numfactors = 0;//количество элементов полученного массива
                int[] res = test(n, i, ref in_arr, out numfactors);
                Console.Write(i + 1 + ")" + "Серия: ");
                for (int j = 0; j < numfactors; j++)//выводим в консоль результаты обработки каждой строки матрицы
                    Console.Write(res[j] + " ");
                Console.WriteLine("\n  " + "Длина: " + numfactors + "\n");
            }

        }
        //функция поиска подстроки из положительных чисел наибольшей длины в строке матрицы
        //возвращает массив, по ссылке размер массива
        //принимает размер матрицы, матрицу и номер строки, с которой работаем
        static int[] test(int size, int n_str, ref int[,] in_arr, out int numfactors)
        {
            int[] result = new int[size];//массив, который в результате будем возвращать
            numfactors = 0;
            int max_len=0,len=0,ind=0;
            bool flag = false;//положительных еще не было
            for(int j=0;j<size;++j)//идем по элементам строки
            {
                if (in_arr[n_str,j]>0)//если встретили положительное число
                {
                    if(!flag)//если это первое положительное, то есть начало подстроки
                    {
                        flag = true;//появилось положительное
                        ind = j;//запомнили индекс
                    }
                    ++len;
                }
                else//встретили отрицательное
                {
                    if (len > max_len)//если длина превысила максимальную
                    {
                        max_len = len;
                        for (int i = 0; i < max_len; ++i)
                            result[i] = in_arr[n_str, ind++];
                        numfactors = max_len;
                    }
                    flag = false;
                    len = 0;
                }
               
            }
            if (len > max_len)//проверка если подпоследовательность стоит в самом конце
            {
                max_len = len;
                for (int i = 0; i < max_len; ++i)
                    result[i] = in_arr[n_str, ind++];
                numfactors = max_len;
            }
            return result;
        }

    }
}