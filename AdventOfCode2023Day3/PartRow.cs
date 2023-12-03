namespace AdventOfCode2023Day3;

public class PartRow
{
    private readonly ICollection<Part> _parts;

    public PartRow(int row, string rowText)
    {
        Row = row;
        _parts = rowText.ToCharArray()
            .Select((character, column) => new Part(character, row, column))
            .ToList();
    }

    public int Row { get; }

    public ICollection<PartNumber> GetPartNumbers()
    {
        var partNumberSegments = new List<Part>();
        var partNumbers = new List<PartNumber>();
        foreach (var part in _parts)
        {
            if (part.IsInteger)
            {
                partNumberSegments.Add(part);
            }
            else if (partNumberSegments.Count != 0)
            {
                partNumbers.Add(new PartNumber(partNumberSegments));
                partNumberSegments = new List<Part>();
            }
        }
        
        if (partNumberSegments.Count != 0) 
            partNumbers.Add(new PartNumber(partNumberSegments));
        
        return partNumbers;
    }
    
    public Part? FindByColumn(int column) => _parts.FirstOrDefault(part => part.Column == column);
}