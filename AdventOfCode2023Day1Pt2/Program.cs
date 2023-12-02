using AdventOfCode2023Day2;

using var streamReader = new StreamReader("./day1-input.txt");
int total = 0;
while (!streamReader.EndOfStream)
{
    var currentLine = streamReader.ReadLine();
    if (string.IsNullOrWhiteSpace(currentLine))
        throw new Exception("Unexpected line encountered");

    char? lastParsedCharacter = null;
    var matchedCharacters = new List<char>();
    var lineCharacters = currentLine.ToCharArray();
    for (var i = 0; i < lineCharacters.Length; i++)
    {
        var character = lineCharacters[i];
        if (!IsInteger(character))
        {
            var wordFormatChar = ParseWordFormatChar(lineCharacters, i);
            if (wordFormatChar is null)
                continue;

            character = wordFormatChar.Value;
        }

        lastParsedCharacter = character;

        if (IsFirstInteger(matchedCharacters))
        {
            matchedCharacters.Add(character);
        }
    }

    if (lastParsedCharacter is null)
        throw new Exception("No matching characters found for line");
    
    matchedCharacters.Add(lastParsedCharacter.Value);

    var lineValue = int.Parse(string.Join("", matchedCharacters));
    total += lineValue;
}

Console.WriteLine($"Total found: {total}");

bool IsInteger(char character) => int.TryParse(character.ToString(), out _);
bool IsFirstInteger(ICollection<char> matchedCharacters) => matchedCharacters.Count == 0;
char? ParseWordFormatChar(char[] lineCharacters, int startingIndex)
{
    var parsedCharacters = new List<char>();
    for (int i = startingIndex; i < lineCharacters.Length; i++)
    {
        var currentCharacter = lineCharacters[i];
        if (IsInteger(currentCharacter))
            return null;
        
        parsedCharacters.Add(currentCharacter);
        var charFromWordForm = string.Join("", parsedCharacters).ToCharFromWordForm();
        if (charFromWordForm is null) 
            continue;
        
        return charFromWordForm;
    }

    return null;
}