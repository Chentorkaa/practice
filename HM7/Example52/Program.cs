// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Console.Clear();
void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] FillArray(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }
    return matrix;
}

Console.WriteLine("Введите количество строк: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов: ");
int b = Convert.ToInt32(Console.ReadLine());
int[,] array = FillArray(b, b, 0, 10);
PrintArray(array);
int sum = 0;
double avarageNum = 0;
for (b = 0; b < array.GetLength(1); b++)
{
    for (a = 0; a < array.GetLength(0); a++)
    {
        sum += array[b, a];
    }
    avarageNum = sum/array.GetLength(0);
    Console.WriteLine($"Среднее арифметическое = {avarageNum:f3}");
} 
