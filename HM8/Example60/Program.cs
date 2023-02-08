// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


Console.WriteLine("Task 60");

int [,,] CreateTripleArray(int rows, int columns, int depth)
{
    int [,,] result = new int [rows, columns, depth];
    Random rnd = new Random();
    int [] values = new int [row * column * depth];
    int countIndexValues = 0;
    for (int iDepth = 0; iDepth < depth; iDepth++)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                int value = rnd.Next(1, 100);
                while (values.Contains(value))
                {
                    value = rnd.Next(1, 100);
                }
                result[row, column, iDepth] = value;
                values[countIndexValues] = value;
                countIndexValues++;
            }
        }
    }
    return result;
}

void PrintTripleArray(int [,,] array)
{
    for (int iDepth = 0; iDepth < array.GetLength(2); iDepth++)
    {
        for (int row = 0; row < array.GetLength(1); row++)
        {
            for (int column = 0; column < array.GetLength(0); column++)
            {
                Console.Write($"{array[row, column, iDepth]}({row}, {column}, {iDepth}) ");
            }
            Console.WriteLine();
        }
    }
}

int rows = GetNumber("Введите количество строк:");
int columns = GetNumber("Введите количество столбцов:");
int depth = GetNumber("Введите глубину массива:");

int [,,] arrTriple = CreateTripleArray(rows, columns, depth);
PrintTripleArray(arrTriple);

