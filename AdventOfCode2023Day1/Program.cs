using var streamReader = new StreamReader("./day1-input.txt");
int total = 0;
while (!streamReader.EndOfStream)
{
    var currentLine = streamReader.ReadLine();
    if (string.IsNullOrWhiteSpace(currentLine))
        throw new Exception("Unexpected line encountered");

    char? lastParsedCharacter = null;
    var matchedCharacters = new List<char>();
    foreach (var character in currentLine.ToCharArray())
    {
        if (!IsInteger(character))
            continue;

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
