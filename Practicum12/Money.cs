using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practicum12
{
    internal class Money
    {
        private int first;
        private int second;

        public Money(int nomination, int value)
        {
            first = nomination;
            second = value;
        }

        public void outInfo()
        {
            Console.WriteLine($"Номинал купюры - {first}");
            Console.WriteLine($"Количество купюр - {second}");
        }

        public void isEnoughMoney(int sum)
        {
            if (first * second >= sum) Console.WriteLine("Бюджета хватит на покупку товара");
            else Console.WriteLine("Бюджета не хватит на покупку товара");
        }

        public void quantityOfGoods(int price, int sum)
        {
            if (sum >= price)
            {
                Console.WriteLine($"Можно приобрести {sum / price} шт. товара");
            }
            else Console.WriteLine("Товар нельзя приобрести так как его цена превышает денежную сумму");
        }

        public int First
        {
            get { return first; }
            set { first = value; }
        }
        public int Second
        {
            get { return second; }
            set { second = value; }
        }

        public int Sum
        {
            get { return first * second; }
        }

        public int this[int index]
        {
            get
            {
                if (index == 0) return first;
                else if (index == 1) return second;
                else throw new ArgumentOutOfRangeException("Индекс должен быть равен 0 или 1");
            }
            set
            {
                if (index == 0) first = value;
                else if (index == 1) second = value;
                else throw new ArgumentOutOfRangeException("Индекс должен быть равен 0 или 1");
            }
        }

        public static Money operator ++(Money m)
        {
            m.first++;
            m.second++;
            return m;
        }

        public static Money operator --(Money m)
        {
            m.first--;
            m.second--;
            return m;
        }

        public static bool operator !(Money m)
        {
            return m.second != 0;
        }

        public static Money operator +(Money m, int scalar)
        {
            m.second += scalar;
            return m;
        }
        public static explicit operator String(Money m)
        {
            return $"Номинал = {m.first}, количество = {m.second}";
        }

        public static explicit operator Money(string s)
        {
            string[] values = s.Split(' ');
            if (values.Length != 2) throw new Exception("Необходимо ввести 2 значения: для поля first и для поля second!");
            int first = int.Parse(values[0]);
            int second = int.Parse(values[1]);
            if (first < 0 || second < 0) throw new Exception("Значение поля не может быть меньше нуля!");
            return new Money(first, second);
        }
    }
}
