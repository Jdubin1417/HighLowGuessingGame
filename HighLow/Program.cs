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
            bool isGuessedCorrectly = false; // To track if the user guessed correctly
            int lastGuess = -1; // To track the last guess for checking repeated guesses
            string expectedDirection = ""; // No direction expected initially
            int AmountofGuesses = 5; // To track the amount of guesses allowed

            while (!isGuessedCorrectly && attempts < AmountofGuesses)
            {
                Console.WriteLine($"Guess a number between 1 and 10. {AmountofGuesses - attempts} Attempts Left!");
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

                // Check if the user repeated the last guess
                if (guess == lastGuess)
                {
                    Console.WriteLine("You're a goofball and I don't want to play anymore.");
                    playAgain = false; // Exit the game immediately
                    break; // Exit the guessing loop
                }

                // Check if the user is going in the wrong direction
                if ((expectedDirection == "higher" && guess <= lastGuess) || (expectedDirection == "lower" && guess >= lastGuess))
                {
                    Console.WriteLine("You're a goofball and I don't want to play anymore.");
                    playAgain = false; // Exit the game immediately
                    break; // Exit the guessing loop
                }

                // Checks if user input is equal to, higher than, or lower than the random number
                if (guess < randomNumber)
                {
                    Console.WriteLine("Higher");
                    expectedDirection = "higher";
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Lower");
                    expectedDirection = "lower";
                }
                else
                {
                    Console.WriteLine("Correct!");
                    isGuessedCorrectly = true;
                    winCount++; // Increment win count when the user guesses correctly
                }
                lastGuess = guess; // Update lastGuess for the next round
                attempts++; // Increments attempts by 1
            }

            // Only ask to play again if the user guessed correctly
            if (isGuessedCorrectly)
            {
                Console.WriteLine($"You have won {winCount} times."); // Display the number of wins

                // Ask to play again
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
                        Console.WriteLine("Goodbye!");
                        playAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'yes' or 'no'.");
                    }
                }
            }
            else if (attempts >= AmountofGuesses) // If user has run out of attempts
            {
                Console.WriteLine("You're a goofball and I don't want to play anymore.");
                playAgain = false; // Set playAgain to false
            }
            else // If kicked out, we already set playAgain to false
            {
                playAgain = false; // Set playAgain to false
            }
        }
    }
}
