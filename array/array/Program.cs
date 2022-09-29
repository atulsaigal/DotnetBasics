using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var numbers = new List<int>() { 10, 20, 30, 40 };

        Console.WriteLine(numbers.Contains(10));
        Console.WriteLine(numbers.Contains(11));
        Console.WriteLine(numbers.Contains(20));
    }
}