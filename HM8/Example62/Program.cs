
// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("Task 62");

rows = GetNumber("Введите количество строк:");
columns = GetNumber("Введите количество столбцов:");


int count = 1;

string MakeElement(int count)
{
    string result = String.Empty;
    if (count < 10)
    {
        result = "0" + count.ToString();
    }
    else
    {
        result = count.ToString();
    }
    return result;
}


string [,] arraySp = new string [rows, columns];

int startRow = 0;
int startColumn = 0;
int finishRow = arraySp.GetLength(0);
int finishColumn = arraySp.GetLength(1);
bool reverse = false;
int add = -1;

while (count <= rows * columns)
{
    for (int iColumn = startColumn;;)
    {     
        arraySp[startRow, iColumn] = MakeElement(count);
        Console.WriteLine($"{arraySp[startRow, iColumn]}({startRow}, {iColumn})");   
        count++;
        iColumn -= add;
        if (iColumn  == finishColumn)
        {
            finishColumn = startColumn + add;
            startColumn = iColumn + add;
            startRow -= add;
            break;
        }
        
    }
    if (count >= rows * columns)
    {
        break;
    }
    for (int iRow = startRow;;)
    {
        arraySp[iRow, startColumn] = MakeElement(count);
        Console.WriteLine($"{arraySp[iRow, startColumn]}({iRow}, {startColumn})");
        count++;
        iRow -= add;
        if (iRow  == finishRow)
        {
            finishRow = startRow + add;
            startRow = iRow + add;
            startColumn += add;
            break;
        }
    }
    if (reverse)
    {
        reverse = false;
    } 
    else 
    {
        reverse = true;
    }
    add = -add;
}

void PrintStringArray(string [,] array)
{
    for (int row = 0; row < array.GetLength(0); row++)
    {
        for (int column = 0; column < array.GetLength(1); column++)
        {
            Console.Write(array[row, column] + " ");
        }
        Console.WriteLine();
    }    
}

PrintStringArray(arraySp);
