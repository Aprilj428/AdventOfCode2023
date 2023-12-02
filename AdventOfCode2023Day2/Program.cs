using AdventOfCode2023Day2;

var limits = new Dictionary<Color, int>
{
    { Color.Red, 12 },
    { Color.Green, 13 },
    { Color.Blue, 14 }
};

var games = new List<Game>();
using var streamReader = new StreamReader("./day2-input.txt");
while (!streamReader.EndOfStream)
{
    var currentLine = streamReader.ReadLine();
    if (string.IsNullOrWhiteSpace(currentLine))
        throw new Exception("Unexpected line encountered");

    games.Add(new Game(currentLine));
}

var totalOfImpossibleGames = games
    .Where(game => !game.IsPossible(limits))
    .Select(game => game.Id)
    .Sum();
    
Console.WriteLine($"Total of impossible games: {totalOfImpossibleGames}");