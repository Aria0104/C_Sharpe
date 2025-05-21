
Random random = new Random();   
int[,] rating = new int[5,25];
Console.WriteLine("Оценки стадентиков");

for (int i = 0; i < 5;  i++)
{
    for (int j = 0; j < 25; j++)
    {
        rating[i, j] = random.Next(2, 6);
        Console.Write(rating[i, j]+ " | ");
    }
    Console.WriteLine();
}

double[] subject = new double[5];
for (int i = 0; i < 5; i++)
{
    double sum = 0;
    for (int j = 0; j < 25; j++)
    {
        sum += rating[i, j];
    }
    subject[i] = sum / 25;
    Console.WriteLine($"Средний балл по предмету {i + 1} : {subject[i]}");
}
Console.WriteLine();

double[] studentA = new double[25];
for (int j = 0; j < 25; j++)
{
    double sum = 0;
    for (int i = 0; i < 5; i++)
    {
        sum += rating[i, j];
    }
    studentA[j] = sum / 5;
    Console.WriteLine($"Средний балл студента {j + 1}: {studentA[j]}");
}
Console.WriteLine();

double maxSubject = double.MinValue; 
double minSubject = double.MaxValue;
int indexmaxStudent =0 ;
int indexminStudent = 0;
int indexmaxSubject = 0;
int indexminSubject = 0;

for (int i = 0; i < 5; i++)
{
    if (subject[i] > maxSubject)
    {
        maxSubject = subject[i];
        indexmaxSubject = i + 1;
    }
    if (subject[i] < minSubject)
    {
        minSubject = subject[i];
        indexminSubject = i + 1;
    }
}

double maxStudent = double.MinValue;
double minStudent = double.MaxValue;

for (int i = 0; i < 25 ; i++)
{
    if (studentA[i] > maxStudent)
    {
        maxStudent = studentA[i];
        indexmaxStudent = i + 1;
    }
    if (studentA[i] < minStudent)
    {
        minStudent = studentA[i];
        indexminStudent = i + 1;
    }
}

Console.WriteLine($" Максимальный средний бал по предмету {indexmaxSubject}: {maxSubject}  |  Минмальный бал предмета {indexminSubject}: {minSubject}");
Console.WriteLine($" Максимальный средний бал студента {indexmaxStudent} : {maxStudent}    |  Минимальный средний бал у студента {indexminStudent} : {minStudent}");