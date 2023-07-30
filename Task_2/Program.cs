using System.Text;

//Задание 2
//Создайте структуру «Десятичное число».
//Определите внутри неё необходимые поля и методы.
//Реализуйте следующую функциональность:
//■ Перевод числа в двоичную систему;
//■ Перевод числа в восьмеричную систему;
//■ Перевод числа в шестнадцатеричную систему.

namespace Task_2
{
    struct Decimal
    {
        public int num { get; set; }

        public Decimal(int a) 
        {
            num = a;
        }
        public override string ToString()
        {
            return num.ToString();
        }
        public string ToBinary()
        {
            if (num == 0) return "0";
            StringBuilder rez = new StringBuilder();
            int a = this.num;
            while (a!=0)
            {
                if (a%2!=0) rez.Insert(0,"1");
                else rez.Insert(0,"0");
                a /= 2;
            }
            return rez.ToString();
        }
        public string ToOctal()
        {
            if (num == 0) return "0";
            StringBuilder rez = new StringBuilder();
            int a = this.num;
            while (a >= 8)
            {
                rez.Insert(0,(a - 8 * (a / 8)));
                a /= 8;
            }
            rez.Insert(0,a);
            return rez.ToString();
        }
        public string ToHex()
        {
            if (num == 0) return "0";
            StringBuilder rez = new StringBuilder();
            int a = this.num, b=0;
            while (a >= 16)
            {
                b = a - 16 * (a / 16);
                if (b==10) rez.Insert(0,'A');
                else if (b == 11) rez.Insert(0, 'B');
                else if (b == 12) rez.Insert(0, 'C');
                else if (b == 13) rez.Insert(0, 'D');
                else if (b == 14) rez.Insert(0, 'E');
                else if (b == 15) rez.Insert(0, 'F');
                else rez.Insert(0,b);
                a /= 16;
            }
            if (a == 10) rez.Insert(0, 'A');
            else if (a == 11) rez.Insert(0, 'B');
            else if (a == 12) rez.Insert(0, 'C');
            else if (a == 13) rez.Insert(0, 'D');
            else if (a == 14) rez.Insert(0, 'E');
            else if (a == 15) rez.Insert(0, 'F');
            else rez.Insert(0, a);
            return rez.ToString();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Decimal d = new Decimal(36752);
            Console.WriteLine($"Decimal d = {d.ToString()}");
            Console.WriteLine($" d in Binary = { d.ToBinary()}");
            Console.WriteLine($" d in Octal = {d.ToOctal()}");
            Console.WriteLine($" d in Hex = {d.ToHex()}");
        }
    }
}