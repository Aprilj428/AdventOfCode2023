namespace AdventOfCode2023Day2;

public class Pull
{
    public Pull(string pullString)
    {
        CubesPulled = pullString.Split(',').Select(x => new CubeResult(x)).ToList();
    }

    public IReadOnlyCollection<CubeResult> CubesPulled { get; }
}