// Задача 23. Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.

Console.Clear();
Console.WriteLine("Введите число: ");
int N = Convert.ToInt32(Console.ReadLine());
int x = 1;
while (x <= N)
{
    int cube = Convert.ToInt32(Math.Pow(x,3));
    x++;
    Console.WriteLine(cube);
}
