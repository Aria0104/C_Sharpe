
class Program
{
    public static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result) && result > 0)
                return result;
            Console.Write("Нельзя вводить отрицательные числа и буквы. Введите положительное число: ");
        }
    }

    public static float ReadFloat()
    {
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out float result) && result > 0)
                return result;
            Console.Write("Нельзя вводить отрицательные числа и буквы. Введите положительное число: ");
        }
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - Добавить машину");
            Console.WriteLine("2 - Показать информацию о всех машинах");
            Console.WriteLine("3 - Совершить поездку");
            Console.WriteLine("4 - Заправить машину");
            Console.WriteLine("5 - Авария");
            Console.WriteLine("6 - Выход");
            Console.WriteLine();
            Console.Write("Выберите действие: ");
            if (!int.TryParse(Console.ReadLine(), out int menu) && menu < 1 || menu > 6)
            {
                Console.WriteLine("Введите число от 1 до 6.");
                continue;
            }

            switch (menu)
            {
                case 1:
                    if (Avto.carCount >= Avto.allCars.Length)
                    {
                        Console.WriteLine("Места для новых машин нет");
                        break;
                    }

                    Console.Write("Введите номер новой машины: ");
                    string num = Console.ReadLine();
                    Console.Write("Обьем бака: ");
                    float tank = ReadFloat();

                    float bak;
                    while (true)
                    {
                        Console.Write("Заправте бак (литры): ");
                        bak = ReadFloat();
                        if (bak <= tank)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Нельзя заправить больше чем есть в баке");
                        }
                    }
                    Console.Write("Введите расход (л/100км): ");
                    float ras = ReadFloat();
                    Avto newAvto = new Avto(num, bak, ras, tank);
                    Avto.allCars[Avto.carCount++] = newAvto;
                    Console.WriteLine("Машина успешно добавлена");
                    break;

                case 2:
                    if (Avto.carCount == 0)
                    {
                        Console.WriteLine("Нет доступных машин для поездки");
                        break;
                    }
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Информация о машинах:");
                    Console.WriteLine("-------------------------------------------------");
                    for (int i = 0; i < Avto.carCount; i++)
                    {
                        Console.WriteLine($"Машина {i + 1}:");
                        Avto.allCars[i].Out();
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Выберите номер машины для поездки");
                    int moveAvto = ReadInt() - 1;
                    if (moveAvto >= 0 && moveAvto < Avto.carCount)
                    {
                        Avto.allCars[moveAvto].Move();
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер машины.");
                    }
                    break;

                case 4:
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Выберите номер машины для заправки");
                    int zapravkaAvto = ReadInt() - 1;
                    if (zapravkaAvto >= 0 && zapravkaAvto < Avto.carCount)
                    {
                        Console.Write("Сколько литров заправить: ");
                        float top = ReadFloat();
                        Avto.allCars[zapravkaAvto].Zapravka(top);
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер машины.");
                    }
                    break;

                case 5:
                    Console.WriteLine("-------------------------------------------------");
                    Avto.Avariya();
                    break;

                case 6:
                    Console.WriteLine("Выход из программы");
                    return;
            }

        }
    }
}
