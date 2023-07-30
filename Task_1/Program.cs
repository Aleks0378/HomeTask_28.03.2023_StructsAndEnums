
//Задание 1
//Создайте структуру «Трёхмерный вектор». Определите внутри неё необходимые поля и методы.
//Реализуйте следующую функциональность:
//■ Умножение вектора на число;
//■ Сложение векторов;
//■ Вычитание векторов.

namespace Task_1
{
    public struct Vector3D
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3D MultOnNum(double a)
        {
            this.x *= a;
            this.y *= a;
            this.z *= a;
            return this;
        }
        public static Vector3D operator + (Vector3D lhs, Vector3D rhs)
        {
            Vector3D rez = new Vector3D();
            rez.x = lhs.x + rhs.x;
            rez.y = lhs.y + rhs.y;
            rez.z = lhs.z + rhs.z;
            return rez;
        }
        public static Vector3D operator - (Vector3D lhs, Vector3D rhs)
        {
            Vector3D rez = new Vector3D();
            rez.x = lhs.x - rhs.x;
            rez.y = lhs.y - rhs.y;
            rez.z = lhs.z - rhs.z;
            return rez;
        }
        public override string ToString()
        {
            return $" x = {x}, y = {y}, z = {z}";
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Vector3D v1 = new Vector3D(25.5, 30.1, 15.4);
            Vector3D v2 = new Vector3D(13.45, 18.15, 21.65);
            Vector3D v3 = new Vector3D();
            Console.WriteLine($"\n Vector v1:\n\t{v1}");
            Console.WriteLine($"\n Vector v2:\n\t{v2}");
            Console.WriteLine($"\n\t v1*5 = {v1.MultOnNum(5)}");
            Console.WriteLine($"\n\t v1+v2 = {v1+v2}");
            Console.WriteLine($"\n\t v1-v2 = {v1-v2}");
        }
    }
}