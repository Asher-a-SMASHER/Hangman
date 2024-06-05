string WordFromDictionary;
char[] Anagram;
Random random = new Random();
float TotalQuestions = 0, Score = 0;

Console.WriteLine("Choose your level of difficulty.");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("For EASY type 'E'");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("For MEDIUM type 'M'");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("For HARD type 'H'");
Console.WriteLine();
Console.ResetColor();
string Level = Console.ReadLine();

string[] Dictionary = null;

if (Level is "E" or "e")
{
    Dictionary = File.ReadAllLines("Dictionaries/EasyD.txt");
}
if (Level is "M" or "m")
{
    Dictionary = File.ReadAllLines("MediumD.txt");
}
if (Level is "H" or "h")
{
    Dictionary = File.ReadAllLines("HardD.txt");
}

do
{

    WordFromDictionary = Dictionary[random.Next(Dictionary.Length)];

    do
    {
        Anagram = new char[WordFromDictionary.Length];


        for (int i = 0; i < WordFromDictionary.Length; i++)
        {
            int RandomLetter = random.Next(WordFromDictionary.Length);
            char CurrentChar = WordFromDictionary[i];
            if (Anagram[RandomLetter] == 0)
            {
                Anagram[RandomLetter] = CurrentChar;
            }

            else
            {
                i--;
            }
        }
    } while (IsSameWord(WordFromDictionary, Anagram));

    Console.WriteLine("Can you unscramble these anagrams?");
    Console.WriteLine("Make sure to spell it WRITE!");
    TotalQuestions++;

    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(Anagram);
        Console.WriteLine();
        string PlayersGuess = Console.ReadLine()!;
        Console.WriteLine();

        var CorrectAnswer = PlayersAttempt(WordFromDictionary, PlayersGuess, i == 1);
        if (CorrectAnswer)
        {
            break;
        }
    }
} while(true);
static bool IsSameWord(string input, char[] newArr)
{
    return new String(newArr) == input;
}


bool PlayersAttempt(string PossibleAnagram, string PlayersGuess, bool IsLastAttempt)
{

    if (PossibleAnagram == PlayersGuess)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("!!Well done!!");
        Console.WriteLine();
        Console.Write($"{++Score}/{TotalQuestions}");
        Console.WriteLine();
        return true;
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Not quite");

        if (IsLastAttempt == false)
        {
            Console.WriteLine("Try again");
        }
        else
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("The correct answer was:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(PossibleAnagram);
            Console.WriteLine();
            Console.ResetColor();

        }

        return false;
    }
}