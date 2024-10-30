//TODO .tolowercase
using System.Text.Json;

namespace Hangman.Highscore;

public class HighscoreProcessor
{
    public static void SaveHighScore(string playerName, float score)
    {
        string filePath = "highscores.json";

        try
        {
            using StreamReader sr = new StreamReader(filePath);
            var FileContent = sr.ReadToEnd();
            var PrevHiScores = JsonSerializer.Deserialize<HighScore[]>(FileContent);
            sr.Close();

            float HighestScore = 0;
            HighScore PlayerWithHighestHighScore = new();

            if (PrevHiScores.Length > 0)
            {
                HighestScore = PrevHiScores.Max(x => x.Score);
                PlayerWithHighestHighScore = PrevHiScores
                    .Where(x => x.Score == HighestScore)
                    .FirstOrDefault();
            }

            if (HighestScore < score)
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    var NewHighScore = new HighScore();
                    NewHighScore.Score = score;
                    NewHighScore.UserName = playerName;
                    var UpdatedHighestScore = PrevHiScores.Prepend(NewHighScore);
                    var OrderedUpdatedHighestScore = UpdatedHighestScore.OrderByDescending(x => x.Score);
                    var Top5HighestScrs = OrderedUpdatedHighestScore.Take(5);
                    var jsonstring = JsonSerializer.Serialize(Top5HighestScrs);

                    Console.WriteLine("""
 _   _                                          
| \ | |                                         
|  \| | _____      __                           
| . ` |/ _ \ \ /\ / /                           
| |\  |  __/\ V  V /                            
\_| \_/\___| \_/\_/                             
                                                
                                                
 _   _ _       _                              _ 
| | | (_)     | |                            | |
| |_| |_  __ _| |__  ___  ___ ___  _ __ ___  | |
|  _  | |/ _` | '_ \/ __|/ __/ _ \| '__/ _ \ | |
| | | | | (_| | | | \__ \ (_| (_) | | |  __/ |_|
\_| |_/_|\__, |_| |_|___/\___\___/|_|  \___| (_)
          __/ |                                 
         |___/                 
         
""");
                    writer.WriteLine(jsonstring);

                    Console.WriteLine($"The previous high score was {HighestScore} set by {PlayerWithHighestHighScore.UserName}!");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: 309634{ex.Message}");
        }
    }
}