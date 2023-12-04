namespace AdventOfCode2023Day3;

public class PartNumber : IAdjacent
{
    private readonly ICollection<Part> _parts;

    public PartNumber(ICollection<Part> parts)
    {
        if (parts.Any(p => !p.IsInteger))
            throw new Exception();

        _parts = parts;
        Value = int.Parse(string.Join("", _parts.Select(x => x.Character.ToString()).ToList()));
    }

    public int Row => _parts.First().Row;
    public int Value { get; }

    public bool CoordinateMatch(Part part) => Coordinates.Any(coord => part.CoordinateMatch(coord.row, coord.column));
    public bool IsAdjacentTo(Part part) => AdjacentCoordinates().Any(coord => part.CoordinateMatch(coord.row, coord.column));
    public IEnumerable<(int row, int column)> Coordinates => _parts.Select(x => x.Coordinates).ToList();
    public IEnumerable<(int row, int column)> AdjacentCoordinates() => _parts
        .SelectMany(p => p.AdjacentCoordinates())
        //Avoid returning adjacent part coordinates that are a part of the PartNumber
        .Where(coord => _parts.All(p => !p.CoordinateMatch(coord.row, coord.column)))
        .ToList();
}