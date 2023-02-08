/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

Console.WriteLine("Task 58");

int [,] TransposeMatrix(int [,] array)
{
    int [,] result = new int [array.GetLength(1), array.GetLength(0)];
    for (int row = 0; row < array.GetLength(0); row++)
    {
        for (int column = 0; column < array.GetLength(1); column++)
        {
            result[column, row] = array[row, column];
        }
    }
    return result;
}

Максим, [31.01.2023 15:52]
int[,] GetMultiply(int [,] array1, int [,] array2)
{
    array1 = TransposeMatrix(array1);
    int [,] result = new int [array2.GetLength(0), array2.GetLength(1)];
    for (int iFirstColumn = 0; iFirstColumn < array1.GetLength(1); iFirstColumn++)
    {
        for (int iSecondColumn = 0; iSecondColumn < array2.GetLength(1); iSecondColumn++)
        {
            int sumOfMultiplied = 0;
            for (int j = 0; j < array2.GetLength(0); j++)
            {
                sumOfMultiplied += (array1[j, iFirstColumn] * array2[j, iSecondColumn]);
            }
            result[iFirstColumn, iSecondColumn] = sumOfMultiplied;
        }
    }
    return result;
}

int m1Rows = GetNumber("Задайте количество строк в первой матрице:");
int m1Columns = GetNumber("Задайте количество столбцов в первой матрице:");
int m2Rows = GetNumber("Задайте количество строк во второй матрице:");
int m2Columns = GetNumber("Задайте количество столбцов во второй матрице:");
int [,] matrix1 = CreateArray(m1Rows, m1Columns);
int [,] matrix2 = CreateArray(m2Rows, m2Columns);

Console.WriteLine("Получены матрицы:");
PrintArray(matrix1);
Console.WriteLine();
PrintArray(matrix2);

if (m1Columns != m2Rows)
{
    Console.WriteLine("Такие матрицы умножить нельзя.");
}
else
{
    Console.WriteLine("Транспонированная первая матрица:");
    PrintArray(TransposeMatrix(matrix1));
    Console.WriteLine("Результат умножения:");
    int [,] multipliedMatrix = GetMultiply(matrix1, matrix2);
    PrintArray(multipliedMatrix);
}
