namespace Hangman.Highscore;

public class HangmanGame
{
    public static void SaveHighScore(string playerName, int score)
    {
        string filePath = "highscores.txt";

        try
        {
            // Append the player's name and score to the highscores file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{playerName}:{score}");
            }

            Console.WriteLine("High score saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving high score: {ex.Message}");
        }
    }
}