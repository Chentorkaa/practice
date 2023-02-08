// Задача 19. Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.

Console.Clear();
    
void CheckPalindrom(int num)
{
    if (num > 9999 && num < 100000)
    {
        int num1 = num / 10000;
        int num2 = num / 1000;
        int num3 = num2 % 10;
        int num4 = num % 10;
        int num5 = num % 100;
        int num6 = num5 / 10;
        if (num1 == num4 || num2 == num6)
        {
             Console.WriteLine($"число {num} является палиндромом");
        }
        else
        {
             Console.WriteLine($"Число {num} не является палиндромом");
        }
    }
    else
    {
        Console.WriteLine("Вы ввели не пятизначное число");
    }
}
Console.WriteLine("Введите пятизначное число: ");
int number = Convert.ToInt32(Console.ReadLine());
CheckPalindrom(number);
