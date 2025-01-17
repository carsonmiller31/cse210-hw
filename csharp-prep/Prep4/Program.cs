using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        // Get numbers from user
        int number = -1; // Initialize to -1 to enter the loop
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            
            if (number != 0)  // Only add the number if it's not 0
            {
                numbers.Add(number);
            }
        }

        // number sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine("The sum of the numbers is: " + sum);


        // part 2
        // part 2
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // part 3
        int largest = numbers.Max();
        Console.WriteLine($"The largest number is: {largest}");

        // part 4
        int smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // part 5
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is:");
        foreach (int n in sortedNumbers)
        {
            Console.WriteLine(n);
        }
    }
}