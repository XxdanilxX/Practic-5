using System;
using System.Threading;

class Program
{
    static int[] numbers = new int[10];
    static int sum = 0;
    static int dob = 1;
    
    static void Main()
    {
        Console.OutputEncoding=System.Text.Encoding.UTF8;
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, 26);
        }
        Console.WriteLine("Елементи масиву:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }

        Thread t0 = new Thread(new ThreadStart(CalculateSum));
        Thread t1 = new Thread(new ThreadStart(CalculateDob));

        t0.Start();
        t1.Start();


        t0.Join();
        t1.Join();


        Console.WriteLine("\nСума всіх елементів: " + sum);
        Console.WriteLine("Добуток всіх елементів: " + dob);
    }

    static void CalculateSum()
    {
        lock (numbers)
        {
            foreach (var number in numbers)
            {
                sum += number;
            }
        }
    }

    static void CalculateDob()
    {
        lock (numbers)
        {
            foreach (var number in numbers)
            {
                dob *= number;
            }
        }
    }
}

