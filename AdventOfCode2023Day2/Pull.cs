namespace AdventOfCode2023Day2;

public class Pull
{
    public Pull(string pullString)
    {
        CubesPulled = pullString.Split(',').Select(x => new CubeResult(x)).ToList();
    }

    public IReadOnlyCollection<CubeResult> CubesPulled { get; }

    public bool IsPossible(Dictionary<Color, int> limits)
    {
        foreach (var cubePull in CubesPulled)
        {
            var colorLimit = limits[cubePull.Color];
            if (cubePull.Count > colorLimit)
            {
                return false;
            }
        }
        
        return true;
    }
}