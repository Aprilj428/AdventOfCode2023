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
var adjacentPartNumbers = partNumbers.Where(x => CheckForAdjacent(partRows, x)).ToList();
var partNumberTotal = adjacentPartNumbers.Sum(x => x.Value);

Console.WriteLine($"Total of part numbers adjacent to symbol: {partNumberTotal}");

bool CheckForAdjacent(ICollection<PartRow> allRows, IAdjacent adjacent)
{
    foreach (var (rowCoord, columnCoord) in adjacent.AdjacentCoordinates())
    {
        var adjacentRow = allRows.FirstOrDefault(x => x.Row == rowCoord);
        if (adjacentRow is null)
            continue;
        
        var partInColumn = adjacentRow.FindByColumn(columnCoord);
        if (partInColumn?.IsSymbol == true)
            return true;
        
    }

    return false;
}
