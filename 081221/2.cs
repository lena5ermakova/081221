using System;
using System.Collections.Generic;

namespace Factorization
{
    public class PrimeFactors
    {
        //объявляем глобальный список для сбора делителей числа
        List<int> Dividers;

        public string GetFactors(int n)
        {
            Dividers = new List<int>();
            Factorize(n);
            //сортировка списка делителей числа по возрастанию
            Dividers.Sort();
            //формирование строки из делителей
            string sdiv = "n=";
            for (int i = 0; i < Dividers.Count - 1; i++)
                sdiv = sdiv + Dividers[i] + "*";
            sdiv = sdiv + Dividers[Dividers.Count - 1];
            //возврат в вызывающую функцию строки из делителей
            return sdiv;
        }

        private void Factorize(int k)
        {
            int mult = 1;//произвеление делителей, полученных на текущем шаге
            List<int> div = new List<int>();//делители, полученные на текущем шаге
            for (int i = 2; i <= Math.Floor(Math.Sqrt(k)); i++)//проходим по числам от 2 до корня из k
            {
                if (k % i == 0) //если делит...
                {
                    bool IsPrime = true;
                    foreach (int j in div)//проверяем делитель на простоту
                        if (i % j == 0) { IsPrime = false; break; }
                    if (IsPrime)//если делитель прост, то сохраняем
                    {
                        div.Add(i);
                        mult *= i;
                    }
                }
            }
            if (mult == 1) { Dividers.Add(k); return; } //если k не имело собственных делителей, то разложение завершено
            else
            {
                Dividers.AddRange(div);//в противном случае сохраняем все полученные делители
                int next = k / mult;
                if (next == 1) return;//если осталась 1, то разложение закончено
                Factorize(next);//иначе рекурсивно вызываем метод для разложения числа после вычеркивания всех делителей, полученных на этом шаге
                                //в mult находится свободный от квадратов делитель k
            }
        }
    }
}