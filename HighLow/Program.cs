using System;
class HighLowGame
{
    static void Main()
    {
        // Displays rules of the game to user
        Console.WriteLine("Welcome to the High-Low Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 10.");
        Console.WriteLine("You have 5 attempts to guess the number.");
        Console.WriteLine("If your guess is too high, I'll say 'Lower'.");
        Console.WriteLine("If your guess is too low, I'll say 'Higher'.");
        Console.WriteLine("Let's get started!\n");

        // Initial Value, can be changed later when user wants to quit
        bool playAgain = true;
        int winCount = 0; // Counter for number of wins

        while (playAgain)
        {
            Random random = new Random(); // Initializes random number generator
            int randomNumber = random.Next(1, 11); // Generates random number between 1 and 10
            int attempts = 0; // Tracks number of attempts the user has remaining and resets it for each playthrough
            bool isGuessedCorrectly = false;

            while (!isGuessedCorrectly && attempts < 5)
            {
                Console.WriteLine($"Guess a number between 1 and 10. Attempts left: {5 - attempts}");
                string userInput = Console.ReadLine();  // Reads user input as a string
                int guess; // Declares guess variable

                // Checks if user input is an integer
                if (!int.TryParse(userInput, out guess))
                {
                    Console.WriteLine("Please enter only an integer.");
                    continue;
                }

                // Checks if user input is between 1 and 10
                if (guess < 1 || guess > 10)
                {
                    Console.WriteLine("Remember, the number is between 1 and 10.");
                    continue;
                }

                // Checks if user input is equal to, higher than, or lower than the random number
                if (guess < randomNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Correct!");
                    isGuessedCorrectly = true;
                    winCount++; // Increment win count when the user guesses correctly
                }
                attempts++; // Increments attempts by 1
            }

            // Checks if user has guessed correctly or if they have run out of attempts
            if (attempts >= 5 && !isGuessedCorrectly)
            {
                Console.WriteLine("You're a goofball and I don't want to play anymore.");
                break;
            }

            Console.WriteLine($"You have won {winCount} times."); // Display the number of wins

            // Loop until a valid response of yes or no is given
            while (true)
            {
                Console.WriteLine("Would you like to play again? (yes/no)");
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    playAgain = true;
                    break;
                }
                else if (response == "no")
                {
                    playAgain = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'yes' or 'no'.");
                }
            }
        }
    }
}
