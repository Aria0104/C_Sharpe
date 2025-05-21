using System.ComponentModel.DataAnnotations.Schema;

int N;
while (true)
{
    Console.WriteLine("Введите размерность матрицы");
    if ((int.TryParse(Console.ReadLine(), out N)) && (N <= 100))
    {
        break;
    }
    else
    {
        Console.WriteLine("Нельзя вводить буковки, отрицательные и больше 100");
    }
}

int[,] snake = new int[N, N];
int num = 1;

for (int i = 0; i <= 2 * N - 2; i++)
{
    if (i % 2 == 0) // ввер по диогонали
    {
        for (int j = 0; j <= i; j++)
        {
            int l = i - j;
            if (j < N && l < N)
            {
                snake[j, l] = num;
                num++;
            }
        }
    }
    else // вниз по диоганали
    {
        for (int l = 0; l <= i; l++)
        {
            int j = i - l;
            if (j < N && l < N)
            {
                snake[j, l] = num;
                num++;
            }
        }
    }
}

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.Write($"{snake[i, j], 4}");
    }
    Console.WriteLine();
}









