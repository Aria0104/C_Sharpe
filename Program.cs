int diopozon;
int diopozon1;
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

int[] A = new int[21];
for (int i = 0; i < 21; i++)
{
    A[i] = random.Next(diopozon, diopozon1 + 1);
}

int[,] B = new int[6, 6];
int index = 0;

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        if (j <= i)
        {
            B[i, j] = A[index];
            index++;
        }
        else
        {
            B[i, j] = 0;
        }
    }
}

int[,] zerkalB = new int[6, 6];

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        zerkalB[i, j] = B[j, i];
    }
}

Console.WriteLine("Матрица B:");
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.Write(B[i, j] + "\t");
    }
    Console.WriteLine();
}

Console.WriteLine("\nОтзеркаленная B:");
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        Console.Write(B[j,i] + "\t");
    }
    Console.WriteLine();
}

