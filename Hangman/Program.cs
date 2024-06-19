// TODO show distinct letters.
// TODO Further improve dictionary
// TODO Remove gap between Your word was & CRUNCH
// TODO When only 1 guess is left print Guess not Guesses
// TODO Remove -1

string[] Dictionary = null;
Random random = new Random();
List<char> ArrayOfGuesses = new List<char>();
int AmountOfIncorrectGuesses = 0;
int Score = 0;
string RepeatOrNot;

do
{
    Console.WriteLine("Choose your level of difficulty.");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("For EASY type 'E'");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("For MEDIUM type 'M'");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("For HARD type 'H'");
    Console.WriteLine();
    Console.ResetColor();
    Console.WriteLine("Press 'enter' after your choice.");


    do
    {
        string Level = Console.ReadLine();
        Console.Clear();

        if (Level is "E" or "e")
        {
            Dictionary = File.ReadAllLines("EasyD.txt");
        }
        else if (Level is "M" or "m")
        {
            Dictionary = File.ReadAllLines("MediumD.txt");
        }
        else if (Level is "H" or "h")
        {
            Dictionary = File.ReadAllLines("HardD.txt");
        }
        else
        {
            Console.WriteLine("You can only choose 'e' 'm' or 'h'.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Choose your level of difficulty.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("For EASY type 'E'");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("For MEDIUM type 'M'");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("For HARD type 'H'");
            Console.WriteLine();
            Console.ResetColor();

        }
    } while (Dictionary is null);

    string WordFromDictionary = Dictionary[random.Next(Dictionary.Length)];
    char[] KnownChars = new char[WordFromDictionary.Length];

    for (int i = 0; i < WordFromDictionary.Length; i++)
    {
        KnownChars[i] = '_';
    }

    char[] WordFromDictionaryArray = WordFromDictionary.ToCharArray();

    Console.WriteLine("Please enter your guess.");
    AddBlankSpaces(KnownChars);

    while (!IsSameWord(KnownChars, WordFromDictionaryArray) && AmountOfIncorrectGuesses < 10)
    {
        Console.WriteLine();
        string PlayersGuess = Console.ReadLine();

        if (PlayersGuess!.Length == 1)
        {
            ArrayOfGuesses.Add(PlayersGuess[0]);
            Console.Clear();
            Console.WriteLine("Letters you've already guessed.");
            AddBlankSpaces(ArrayOfGuesses);

            if (WordFromDictionary.Contains(PlayersGuess))
            {
                for (int i = 0; i < WordFromDictionary.Length; i++)
                {
                    if (PlayersGuess[0] == WordFromDictionary[i])
                    {
                        KnownChars[i] = PlayersGuess[0];
                    }
                }
                AddBlankSpaces(KnownChars);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Well done you guessed correct letter!");
                Console.ResetColor();
                DisplayHangman(AmountOfIncorrectGuesses);

                if (new String(KnownChars) == WordFromDictionary)
                {
                    Console.Clear();
                    WIN();
                    Score++;

                    Console.Write("Your word was ");
                    Console.Write(WordFromDictionary);
                    Console.WriteLine();
                }
            }

            else
            {
                AddBlankSpaces(KnownChars);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops you made a mistake!");
                Console.ResetColor();
                AmountOfIncorrectGuesses++;

                DisplayHangman(AmountOfIncorrectGuesses);
            }

            Console.WriteLine($"You have {10 - AmountOfIncorrectGuesses} guesses left.");

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can only enter one letter at a time.");
        }
    }

    Console.WriteLine($"Your word was '{WordFromDictionary}' .");

    Console.WriteLine();
    Console.Write("Your current score is ");
    Console.WriteLine(Score);

    Console.WriteLine("Would you like to play again?");
    Console.WriteLine("PLEEZ PLAY AGEN");
    Console.WriteLine("If yes, type 'p'");
    RepeatOrNot = Console.ReadLine()!;
    Console.Clear();

} while (RepeatOrNot is "P" or "p");

static void DisplayHangman(int Score)
{

    var Level0 =
"""



              You haven't made a mistake yet!
                        
                       !!YIPPY!!






""";
    var Level1 =
"""
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |                  JUST A HEAD
        |                              /  \
        |                             (    )
        |                              \__/
        |                               
        |                               
        |                              
        |                            
        |                                
        |                                
        |                         
        | 
        | 
        | 
        |
  -------------- 
""";
    var Level2 =
"""
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |                  Ooh I have eyes now
        |                              /..\                   _       _
        |                             (    )                /   \   /   \
        |                              \__/                |  |  | |  |  |
        |                                                  |  |  | |  |  |
        |                                                   \ _ /   \ _ / 
        |                         
        |                                
        |                                
        |                         
        | 
        | 
        | 
        |
  -------------- 
""";
    var Level3 =
"""
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |              AND A MOUTH!
        | /                              |
        |/                               |       
        |                              /..\          
        |                             (    )   
        |                              \_0/  
        |
        |
        |                         
        |                                
        |                                
        |                         
        | 
        | 
        | 
        |
  -------------- 
""";
    var Level4 =
"""
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |              Finally I can smell!
        | /                              |                  Ahh!
        |/                               |             I smell the ocean
        |                              /..\          
        |                             ( J  )   
        |                              \_0/  
        |
        |
        |                         
        |                                
        |                                
        |                         
        | 
        | 
        | 
        |
  -------------- 
""";
    var Level5 =
    """
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |          Hmm somethings fishy
        |/                               |
        |                              /--\
        |                             ( J  )
        |                              \~_/
        |                               
        |                               
        |                              
        |                            
        |                                
        |                                
        |                         
        |                                                           --------------¬
        |                                                         |  I'm starvin'!|
        |                                                          /--------------
        |                                           _________     /   .    .
  --------------                                   (..       \_    ,  |\  /|
                                                    \       0  \  /|  \ \/ /
                           ~~~~~~~~~~~~~~~~~~~~~~~~~~\______    \/ |   \  /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                        vvvv\    \ |   /  |
                                    ~~~~~~~~~~~~~~~~~~~~\^^^^  ==   \_/   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                         `\_   ===    \.  |
                                                         / /\_   \ /      |
                                                         |/   \_  \|      /
                                                               \________/                 
  """;
    var Level6 =
    """
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |
        |                              /--\
        |                             ( J  )     Oh NO!
        |                              \~_/   
        |                                |
        |                                |
        |                                | 
        |                                | 
        |                                
        |                               
        |                              
        |                             
        |                           
        |                                          
        |                                           _________         .    .
  --------------                                   (..       \_    ,  |\  /|
                                                    \       0  \  /|  \ \/ /
                           ~~~~~~~~~~~~~~~~~~~~~~~~~~\______    \/ |   \  /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                        vvvv\    \ |   /  |
                                    ~~~~~~~~~~~~~~~~~~~~\^^^^  ==   \_/   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  |
                                                         `\_   ===    \.  |
                                                         / /\_   \ /      |
                                                         |/   \_  \|      /
                                                               \________/                 
  """;
    var Level7 =
    """
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |
        |                              /--\
        |                             ( J  )  Yikes!
        |                              \~_/
        |                                |
        |                                ^
        |                              / | 
        |                             /  | 
        |                                |
        |                         
        |                              
        |                             
        |                           
        |                                          
        |                                           _________         .    .
  --------------                                   (..       \_    ,  |\  /|
                                                    \       0  \  /|  \ \/ /
                           ~~~~~~~~~~~~~~~~~~~~~~~~~~\______    \/ |   \  /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                        vvvv\    \ |   /  |
                                    ~~~~~~~~~~~~~~~~~~~~\^^^^  ==   \_/   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  |
                                                         `\_   ===    \.  |
                                                         / /\_   \ /      |
                                                         |/   \_  \|      /
                                                               \________/                 
  """;
    var Level8 =
    """
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |
        |                              /--\
        |                             ( J  ) I cant look!
        |                              \~_/  
        |                                |
        |                                ^
        |                              / | \
        |                             /  |  \
        |                                |
        |                           
        |                             
        |                             
        |                           
        |                                          
        |                                           _________         .    .
  --------------                                   (..       \_    ,  |\  /|
                                                    \       0  \  /|  \ \/ /
                           ~~~~~~~~~~~~~~~~~~~~~~~~~~\______    \/ |   \  /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                        vvvv\    \ |   /  |
                                    ~~~~~~~~~~~~~~~~~~~~\^^^^  ==   \_/   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  |
                                                         `\_   ===    \.  |
                                                         / /\_   \ /      |
                                                         |/   \_  \|      /
                                                               \________/                 
  """;

    var Level9 =
    """
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |
        |                              /--\      AAH!
        |                             ( J  )
        |                              \~_/            PLEASE DON'T EAT ME
        |                                |
        |                                ^
        |                              / | \
        |                             /  |  \
        |                                |
        |                                ^
        |                              /  
        |                             /    
        |                           
        |                                          
        |                                           _________         .    .
  --------------                                   (..       \_    ,  |\  /|
                                                    \       0  \  /|  \ \/ /
                           ~~~~~~~~~~~~~~~~~~~~~~~~~~\______    \/ |   \  /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                        vvvv\    \ |   /  |
                                    ~~~~~~~~~~~~~~~~~~~~\^^^^  ==   \_/   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  |
                                                         `\_   ===    \.  |
                                                         / /\_   \ /      |
                                                         |/   \_  \|      /
                                                               \________/                 
  """;

    var Level10 =
    """
        []___________________________________
        |    /                           |
        |   /                            |
        |  /                             |
        | /                              |
        |/                               |
        |                              /--\
        |                             ( J  )
        |                              \~_/
        |                                |
        |                                ^
        |                              / | \
        |                             /  |  \
        |                                |
        |                                ^
        |                              /   \
        |                             /     \
        |                           
        |                                          
        |                                           _________         .    .
  --------------                                   (..       \_    ,  |\  /|
                                                    \       0  \  /|  \ \/ /
                           ~~~~~~~~~~~~~~~~~~~~~~~~~~\______    \/ |   \  /~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                        vvvv\    \ |   /  |
                                    ~~~~~~~~~~~~~~~~~~~~\^^^^  ==   \_/   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                         `\_   ===    \.  |
                                                         / /\_   \ /      |
                                                         |/   \_  \|      /
                                                               \________/                 
  """;
    var EndGame =
@"
 $$$$$\                                           $$\       
$$  __$$\                                         $$ |      
$$ /  \__| $$$$$$\  $$\   $$\ $$$$$$$\   $$$$$$$\ $$$$$$$\  
$$ |      $$  __$$\ $$ |  $$ |$$  __$$\ $$  _____|$$  __$$\ 
$$ |      $$ |  \__|$$ |  $$ |$$ |  $$ |$$ /      $$ |  $$ |
$$ |  $$\ $$ |      $$ |  $$ |$$ |  $$ |$$ |      $$ |  $$ |
\$$$$$$  |$$ |      \$$$$$$  |$$ |  $$ |\$$$$$$$\ $$ |  $$ |
 \______/ \__|       \______/ \__|  \__| \_______|\__|  \__| 
 ";

    if (Score == 0) Console.WriteLine(Level0);
    else if (Score == 1) Console.WriteLine(Level1);
    else if (Score == 2) Console.WriteLine(Level2);
    else if (Score == 3) Console.WriteLine(Level3);
    else if (Score == 4) Console.WriteLine(Level4);
    else if (Score == 5) Console.WriteLine(Level5);
    else if (Score == 6) Console.WriteLine(Level6);
    else if (Score == 7) Console.WriteLine(Level7);
    else if (Score == 8) Console.WriteLine(Level8);
    else if (Score == 9) Console.WriteLine(Level9);
    else Console.WriteLine(Level10 + Environment.NewLine + EndGame);
}

static void WIN()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
    """
__  __                                    __
\ \/ /___  __  __   _      ______  ____  / /
 \  / __ \/ / / /  | | /| / / __ \/ __ \/ / 
 / / /_/ / /_/ /   | |/ |/ / /_/ / / / /_/  
/_/\____/\__,_/    |__/|__/\____/_/ /_(_)   

""");
}

static void AddBlankSpaces(IEnumerable<char> BlankSpaces)
{
    foreach (var item in BlankSpaces)
    {
        Console.Write(item);
        Console.Write(" ");
    }
    Console.WriteLine();
    Console.WriteLine();
}

static bool IsSameWord(char[] input, char[] newArr)
{
    return new String(input) == new String(newArr);
}