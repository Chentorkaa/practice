// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

Console.Clear();
void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
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
            matrix[i, j] = new Random().Next(0, 20);
        }
    }
    return matrix;
}


Console.WriteLine("Введите количество строк в массиве: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов в массиве: ");
int b = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] array = FillArray(a, b, 1, 20);
PrintArray(array);

Console.WriteLine("Введите позицию строки: ");
int x = Convert.ToInt32(Console.ReadLine()) - 1;
Console.WriteLine("Введите позицию столбца: ");
int y = Convert.ToInt32(Console.ReadLine()) - 1;
if (x > a && y > b) Console.WriteLine("Такого элемента в массиве нет");
else 
{
    object c = array.GetValue(x, y);
    Console.WriteLine($"Искомый элемент = {c}");
}
