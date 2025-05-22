using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

class Avto
{
    private string avto_number;
    private float fuel_spend; // расход топлива
    private float probeg; // пробег
    private float petrol; // бензин в баке
    private float obem_bac;
    private int x, y;
    private float speed; // скорость
    public static Avto[] allCars = new Avto[5];
    public static int carCount = 0;
    private Avto()
    {
        avto_number = "Мяу";
        petrol = 0;
        fuel_spend = 0;
        probeg = 0;
        obem_bac = 0;
        x = 0;
        y = 0;
        speed = 0;
    }

    // Полный конструктор
    public Avto(string nom, float bak, float ras, float tank)
    {
        avto_number = nom;
        petrol = (int)bak;
        fuel_spend = ras;
        obem_bac = tank;
        probeg = 0;
        x = 0;
        y = 0;
        speed = 0;
    }

    public void Out()
    {
        Console.WriteLine($"Номер авто : {avto_number}");
        Console.WriteLine($"Количество бензина в баке : {petrol} л");
        Console.WriteLine($"Расход бензина на 100 км : {fuel_spend} л");
        Console.WriteLine($"Обьем бака : {obem_bac}");
        Console.WriteLine($"Пробег : {probeg} км");
        Console.WriteLine($"Текущая позиция : ({x}, {y})");
        Console.WriteLine($"Текущая скорость : {speed} км/ч");
    }

    public void Zapravka(float top)
    {
        if (top <= 0)
        {
            Console.WriteLine("Нельзя заправить отрицательное количество топлива.");
            return;
        }
        if (petrol + top <= obem_bac)
        {
            petrol += (int)top;
            Console.WriteLine($"Заправлено {top} л. Всего: {petrol} л");
        }
        else
        {
            Console.WriteLine("Вы не можите заправить больше чем есть в баке");
        }
    }


    public void Move()
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Совершить поездку");
            Console.WriteLine("2 - Выход");
            Console.Write("Выберите действие: ");
            Console.WriteLine();
            int direction = Program.ReadInt();

            if (direction == 2) return;
            int newX = x, newY = y;
            int dx;
            int dy;
            if (direction == 1)
            {
                while (true)
                {
                    Console.Write("Введите смещение по X: ");
                    if ((int.TryParse(Console.ReadLine(), out dx) && dx >= 0))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Нельзя вводить отрицатеьные числа и буковки");
                    }
                }
                while (true)
                {
                    Console.Write("Введите смещение по Y: ");
                    if ((int.TryParse(Console.ReadLine(), out dy) && dy >= 0))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Нельзя вводить отрицатеьные числа и буковки");
                    }

                }
                newX = x + dx;
                newY = y + dy;
            }

            else
            {
                Console.WriteLine("Неверный выбор.");
                continue;
            }

            float km = RaschetRasstoyaniya(x, y, newX, newY);
            float neededFuel = (km / 100) * fuel_spend;
            Console.WriteLine($"До новой точки: {km:F2} км, нужно топлива: {neededFuel} л");

            Razgon();

            double remainingKm = km;

            while (true)
            {
                float fuelRange = (petrol / fuel_spend) * 100;

                if (fuelRange >= remainingKm)
                {
                    petrol -= (float)(remainingKm / 100) * fuel_spend;
                    probeg += km;
                    x = newX;
                    y = newY;
                    Tormozhenie();
                    Ostatok();
                    break;
                }
                else
                {
                    remainingKm -= fuelRange;
                    probeg += fuelRange;
                    petrol = 0;
                    Console.WriteLine($"Топливо закончилось. Осталось проехать: {remainingKm:F2} км");
                    Console.WriteLine($"Нужно долить: {(remainingKm * fuel_spend / 100)} л");
                    Console.WriteLine("1 - Заправиться");
                    Console.WriteLine("2 - Отменить поездку");
                    Console.Write("Ваш выбор: ");
                    Console.WriteLine();

                    int choice = Program.ReadInt();

                    if (choice == 1)
                    {
                        Console.Write("Введите количество топлива: ");
                        float fuelToAdd = Program.ReadFloat();
                        if (fuelToAdd > 0)
                        {
                            Zapravka(fuelToAdd);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: количество должно быть положительным.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Поездка отменена");
                        Tormozhenie();
                        break;
                    }
                }
            }

            Console.Write("Продолжить движение? (да/нет): ");
            if (Console.ReadLine().ToLower() != "да")
            {
                break;
            }
        }
    }

    public void Razgon()
    {
        speed += 20;
        Console.WriteLine($"Автомобиль {avto_number} ускоряется вжихххх. Скорость : {speed}");
    }

    public void Tormozhenie()
    {
        speed = 0;
        Console.WriteLine($"Автомобиль {avto_number} тормозит. Скорость : {speed} км/ч");
    }

    private int RaschetRasstoyaniya(int x1, int y1, int x2, int y2)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;

        double distance = Math.Sqrt(dx * dx + dy * dy);

        return (int)Math.Round(distance);
    }
    public string GetNumber()
    {
        return avto_number;
    }

    public static void Avariya()
    {
        if (carCount == 0)
        {
            Console.WriteLine("Нет машин для аварии.");
            return;
        }
        Random rnd = new Random();
        Console.WriteLine("Произошли аварии с машинами : ");

        int skokoAvariy = rnd.Next(1, Math.Min(4, carCount + 1));

        for (int i = 0; i < skokoAvariy; i++)
        {
            int index = rnd.Next(0, carCount);
            Console.WriteLine($"Машина {index + 1} ({allCars[index].GetNumber()}) попала в аварию!!!");
            allCars[index].Ostatok();
        }
    }

    private int Ostatok()
    {
        Console.WriteLine("Автомобиль остановился");
        return (int)petrol;
    }

}
