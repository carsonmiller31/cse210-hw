using System;

class Program
{
    static void Main(string[] args)
    {    
        Random  randomGenerator = new Random();

        int number = randomGenerator.Next(1, 11);   
        int guess = 0;
        do
        {
            Console.WriteLine("What is your number guess");
            guess = Convert.ToInt32(Console.ReadLine());
            if (guess > number)
            {
                Console.WriteLine("Guess is too high");
            }
            else if (guess < number)
            {
                Console.WriteLine("Guess is too low");
            }
        } while (guess != number);
        
        Console.WriteLine("You guessed it!");

    }
}