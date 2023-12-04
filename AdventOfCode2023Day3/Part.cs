namespace AdventOfCode2023Day3;

public class Part : IAdjacent
{
    public Part(char character, int row, int column)
    {
        Character = character;
        Row = row;
        Column = column;
    }
    
    public char Character { get; }
    public int Row { get; }
    public int Column { get; }
    public bool IsInteger => int.TryParse(Character.ToString(), out _);
    public bool IsSymbol => Character != '.' && !IsInteger;
    public bool IsDot => Character == '.';
    public bool IsStar => Character == '*';
    public bool CoordinateMatch(int row, int column) => Row == row && column == Column;
    public (int row, int column) Coordinates => (Row, Column);
    
    public IEnumerable<(int row, int column)> AdjacentCoordinates()
    {
        yield return (Row + 1, Column + 1);
        yield return (Row + 1, Column);
        yield return (Row, Column + 1);

        if (Column - 1 >= 0)
        {
            yield return (Row + 1, Column - 1);
            yield return (Row, Column - 1);
        }

        if (Row - 1 >= 0)
        {
            yield return (Row - 1, Column + 1);
            yield return (Row - 1, Column);
            yield return (Row - 1, Column - 1);
        }
    }
}