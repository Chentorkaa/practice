// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.

Console.Clear();
Console.Write("Введите N: ");
int firstNumber = int.Parse(Console.ReadLine());
Console.Write("Введите M: ");
int secondNumber = int.Parse(Console.ReadLine());

PrintNumbers(firstNumber, secondNumber);


void PrintNumbers(int start, int end)
{
    Console.Write($"{start} ");
    if (start == end) return;
    PrintNumbers(start + 1, end);
}
int M = firstNumber;
int N = secondNumber;
int sum = 0;
while (M < N)
{
    sum = firstNumber + (firstNumber + 1);
}
Console.Write($"Сумма элементов от {M} до {N} = {sum}");
