// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.

Console.Clear();
Console.Write("Введите N: ");
int number = int.Parse(Console.ReadLine());

PrintNumbers(number, 1);

void PrintNumbers(int start, int end)
{
    if (number < 0)
    {
        Console.Write($"{start} ");
        if (start == end) return;
        PrintNumbers(start + 1, end);
    }
    else Console.Write("Введите значение N меньше 0");
}
