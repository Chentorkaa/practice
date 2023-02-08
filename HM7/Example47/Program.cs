// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

Console.Clear();
void PrintArray(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]:f2} \t");
        }
        Console.WriteLine();
    }
}

double[,] FillArray(int rows, int columns, int min, int max)
{
    double[,] matrix = new double[rows, columns];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().NextDouble()*(max-min);
        }
    }
    return matrix;
}
Console.WriteLine("Введите значение m (кол-во строк): ");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите значение n (кол-во cтолбцов): ");
int n = Convert.ToInt32(Console.ReadLine());
double[,] array = FillArray(m, n, 1, 20);
PrintArray(array);