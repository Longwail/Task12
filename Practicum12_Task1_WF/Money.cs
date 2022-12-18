using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum12_Task1_WF
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

        public string outInfo()
        {
            return $"Номинал купюры - {first}\nКоличество купюр - {second}";
        }

        public string isEnoughMoney(int sum)
        {
            if (first * second >= sum) return "Бюджета хватит на покупку товара";
            else return "Бюджета не хватит на покупку товара";
        }

        public string quantityOfGoods(int price, int sum)
        {
            if (sum >= price)
            {
                return $"Можно приобрести {sum / price} шт. товара";
            }
            else return "Товар нельзя приобрести так как его цена превышает денежную сумму";
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
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index == 0) first = value;
                else if (index == 1) second = value;
                else throw new ArgumentOutOfRangeException();
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
