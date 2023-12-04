// See https://aka.ms/new-console-template for more information

using AdventOfCode2023Day3;

using var streamReader = new StreamReader("./day3-input.txt");
var partRows = new List<PartRow>();
int row = 0;
while (!streamReader.EndOfStream)
{
    var currentLine = streamReader.ReadLine();
    if (string.IsNullOrWhiteSpace(currentLine))
        throw new Exception("Unexpected line encountered");

    partRows.Add(new PartRow(row, currentLine));
    row++;
}

var partNumbers = partRows.SelectMany(x => x.GetPartNumbers()).ToList();

//Part 1
var partNumbersAdjacentToSymbol = partNumbers.Where(x => CheckForAdjacent(partRows, x, p => p.IsSymbol)).ToList();
var partNumberTotal = partNumbersAdjacentToSymbol.Sum(x => x.Value);

//Part 2
var potentialGears = partRows.SelectMany(x => x.GetAllPartsByCharacter('*')).ToList();
var totalOfGears = 0;
foreach (var gear in potentialGears)
{
    var adjacentPartNumbers = GetAdjacentPartNumbers(partRows, partNumbers, gear).ToList();
    if (adjacentPartNumbers.Count() == 2)
    {
        totalOfGears += adjacentPartNumbers[0].Value * adjacentPartNumbers[1].Value;
    }
}

Console.WriteLine($"Total of part numbers adjacent to symbol: {partNumberTotal}");
Console.WriteLine($"Total of gears: {totalOfGears}");

IEnumerable<PartNumber> GetAdjacentPartNumbers(ICollection<PartRow> allRows, ICollection<PartNumber> allPartNumbers, IAdjacent adjacent)
{
    var adjacentIntegersToGear = GetAdjacentParts(allRows, adjacent, p => p.IsInteger);
    foreach (var partNumber in allPartNumbers)
    {
        if (adjacentIntegersToGear.Any(x => partNumber.CoordinateMatch(x)))
            yield return partNumber;
    }
}

ICollection<Part> GetAdjacentParts(ICollection<PartRow> allRows, IAdjacent adjacent, Func<Part, bool> match)
{
    var adjacentParts = new List<Part>();
    foreach (var (rowCoord, columnCoord) in adjacent.AdjacentCoordinates())
    {
        var adjacentRow = allRows.FirstOrDefault(x => x.Row == rowCoord);
        var partInColumn = adjacentRow?.FindByColumn(columnCoord);
        if (partInColumn is null)
            continue;
        
        if (match(partInColumn))
            adjacentParts.Add(partInColumn);
        
    }
    
    return adjacentParts;
}


bool CheckForAdjacent(ICollection<PartRow> allRows, IAdjacent adjacent, Func<Part, bool> match) => GetAdjacentParts(allRows, adjacent, match).Count != 0;
