//Задание 3
//Создайте структуру «RGB цвет». Определите внутри 
//неё необходимые поля и методы. Реализуйте следующую 
//функциональность:
//■ Перевод в HEX формат;
//■ Перевод в HSL;
//■ Перевод в CMYK.

namespace Task_3
{
    // Определение структуры RGB цвет
    struct RGBColor
    {
        // Поля для хранения компонентов цвета
        public byte R; // Красный
        public byte G; // Зеленый
        public byte B; // Синий

        // Конструктор для инициализации полей
        public RGBColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        // Метод для перевода в HEX формат
        public string ToHex()
        {
            // Используем форматирование строк для получения шестнадцатеричного представления каждого байта
            return $"#{R:X2}{G:X2}{B:X2}";
        }

        // Метод для перевода в HSL формат
        public (double H, double S, double L) ToHSL()
        {
            // Преобразуем компоненты цвета в дробные числа от 0 до 1
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            // Находим минимальное и максимальное значение среди компонентов
            double min = Math.Min(r, Math.Min(g, b));
            double max = Math.Max(r, Math.Max(g, b));

            // Вычисляем яркость (lightness) как среднее арифметическое минимума и максимума
            double l = (min + max) / 2;

            // Если минимум и максимум равны, то цвет является оттенком серого и насыщенность (saturation) и оттенок (hue) равны нулю
            if (min == max)
            {
                return (0, 0, l);
            }

            // Иначе вычисляем насыщенность в зависимости от яркости
            double s = l < 0.5 ? (max - min) / (max + min) : (max - min) / (2 - max - min);

            // Вычисляем оттенок в зависимости от того, какой компонент является максимальным
            double h;
            if (r == max)
            {
                h = (g - b) / (max - min);
            }
            else if (g == max)
            {
                h = 2 + (b - r) / (max - min);
            }
            else
            {
                h = 4 + (r - g) / (max - min);
            }

            // Приводим оттенок к диапазону от 0 до 360 градусов
            h *= 60;
            if (h < 0)
            {
                h += 360;
            }

            // Возвращаем кортеж из трех значений: оттенок, насыщенность и яркость
            return (h, s, l);
        }

        // Метод для перевода в CMYK формат
        public (double C, double M, double Y, double K) ToCMYK()
        {
            // Преобразуем компоненты цвета в дробные числа от 0 до 1
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            // Вычисляем ключевой компонент (black)
            double k = 1 - Math.Max(r, Math.Max(g, b));
            //Голубой цвет (C) рассчитывается на основе красного (R ') и черного (K) цветов:
            double c = (1 - r - k) / (1 - k);
            //Пурпурный цвет (M) рассчитывается из зеленого (G ') и черного (K) цветов:
            double m = (1 - g - k) / (1 - k);
            //Желтый цвет (Y) рассчитывается из синего (B ') и черного (K) цветов:
            double y = (1 - b - k) / (1 - k);

            return (c, m, y, k);
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
                RGBColor red = new RGBColor(255,0,0);
                RGBColor green = new RGBColor(0,255,0);
                RGBColor blue = new RGBColor(0,0,255);

                Console.WriteLine(red.ToHex());
                Console.WriteLine(green.ToHSL());
                Console.WriteLine(blue.ToCMYK());
        }
    }
}