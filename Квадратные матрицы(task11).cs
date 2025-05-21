using System.ComponentModel.Design;

int znach1;
int diopozon;
int diopozon1;
while (true)
{
    Console.WriteLine("Введите значение");
    string znach = Console.ReadLine();
    if (int.TryParse(znach, out znach1))
    {
        if (znach1 >= 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Знаение должено быть больше 0. Попробуйте снова.");
        }
    }
    else { Console.WriteLine("Нельзя вводить буквы."); }
}

while (true)
{
    Console.WriteLine("Введите диапозон");
    string a0 = Console.ReadLine();
    string a1 = Console.ReadLine();
    if ((int.TryParse(a0, out diopozon)) && (int.TryParse(a1, out diopozon1)))
    {
        break;
    }
    else
    {
        Console.WriteLine("Нельзя вводить буквы.");
    }
}

Random random = new Random();
int[,] A = new int[znach1, znach1];

Console.WriteLine("Первая матрица:");
for (int i = 0; i < znach1; i++)
{
    for (int j = 0; j < znach1; j++)
    {
        A[i, j] = random.Next(diopozon, diopozon1 + 1);
        Console.Write($"{A[i, j]}\t");
    }
    Console.WriteLine();
}

int[,] B = new int[znach1, znach1];
Console.WriteLine("Вторая матрица:");
for (int i = 0; i < znach1; i++)
{
    for (int j = 0; j < znach1; j++)
    {
        B[i, j] = random.Next(diopozon, diopozon1 + 1);
        Console.Write($"{B[i, j]}\t");
    }
    Console.WriteLine();
}

while (true)
{
    int lala;
    while (true)
    {
        Console.WriteLine("1) Сложить матрицы \n2) Вычитание A-B \n3) Вычитание В-А");
        if ((int.TryParse(Console.ReadLine(), out lala)) && (lala > 0 && lala < 5))
        {
            Console.Clear();
            Console.WriteLine("Первая матрица");
            for (int i = 0; i < znach1; i++)
            {
                for (int j = 0; j < znach1; j++)
                {
                    Console.Write(A[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Вторая матрица");
            for (int i = 0; i < znach1; i++)
            {
                for (int j = 0; j < znach1; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
        else
        {
            Console.WriteLine("Некорректный формат");
        }

        switch (lala)
        {
            case 1:
                Console.WriteLine("Сложение A+B");
                for (int i = 0; i < znach1; i++)
                {
                    for (int j = 0; j < znach1; j++)
                    {
                        Console.Write($"{A[i, j] + B[i, j]}\t");
                    }
                    Console.WriteLine();
                }
                break;
            case 2:
                Console.WriteLine("Выитание A-B");
                for (int i = 0; i < znach1; i++)
                {
                    for (int j = 0; j < znach1; j++)
                    {
                        Console.Write($"{A[i, j] - B[i, j]}\t");
                    }
                    Console.WriteLine();
                }
                break;
            case 3:
                Console.WriteLine("Вычитание B-A");
                for (int i = 0; i < znach1; i++)
                {
                    for (int j = 0; j < znach1; j++)
                    {
                        Console.Write($"{B[i, j] - A[i, j]}\t");
                    }
                    Console.WriteLine();
                }
                break;
        }
    }
}