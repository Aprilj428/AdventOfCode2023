namespace AdventOfCode2023Day2;

public class Game
{
    public Game(string gameResults)
    {
        var colonSeparatedResults = gameResults.Split(':');
        var gameIdString = colonSeparatedResults[0].Replace("Game", "").Trim();
        var pullsStrings = colonSeparatedResults[1].Split(';');
        
        Id = int.Parse(gameIdString);
        Pulls = pullsStrings.Select(pull => new Pull(pull)).ToList();
    }
    
    public long Id { get; }
    public IReadOnlyCollection<Pull> Pulls { get; }

    public bool IsPossible(Dictionary<Color, int> limits) => Pulls.Any(pull => !pull.IsPossible(limits));

    public int PowerOfLeastAmountOfRequiredCubes => GetHighestCountForColor(Color.Red) *
                                                    GetHighestCountForColor(Color.Blue) *
                                                    GetHighestCountForColor(Color.Green);
    
    private int GetHighestCountForColor(Color color) => Pulls
        .SelectMany(pull => pull.CubesPulled)
        .Where(cube => cube.Color == color)
        .Select(x => x.Count)
        .Max();
}