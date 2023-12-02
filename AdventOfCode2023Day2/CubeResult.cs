namespace AdventOfCode2023Day2;

public class CubeResult
{
    public CubeResult(string cubePull)
    {
        var splitText = cubePull.Trim().Split(" ").Select(x => x.Trim()).ToList();
        Count = int.Parse(splitText[0]);
        Color = splitText[1].ToColor();
    }

    public int Count { get; }
    public Color Color { get; }
}