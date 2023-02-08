/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/



Console.WriteLine("Task 56");

int GetMinRowsSum(int [,] array)
{
    int minSum = 0;
    int rowMin = 0;
    for (int row = 0; row < array.GetLength(0); row++)
    {
        int rowSum = 0;
        for (int column = 0; column < array.GetLength(1); column++)
        {
            rowSum += array[row, column];
        }
        if (minSum == 0)
        {
            minSum = rowSum;
            rowMin = 1;
        }
        if (minSum > rowSum)
        {
            minSum = rowSum;
            rowMin = row + 1;
        }
    }
    return rowMin;    
}

Console.WriteLine($"Минимальная сумма элементов в {GetMinRowsSum(array)}ой строке");
