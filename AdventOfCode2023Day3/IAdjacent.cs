namespace AdventOfCode2023Day3;

public interface IAdjacent
{
    IEnumerable<(int row, int column)> AdjacentCoordinates();
}