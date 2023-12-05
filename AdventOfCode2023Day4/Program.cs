// See https://aka.ms/new-console-template for more information

using AdventOfCode2023Day4;

using var streamReader = new StreamReader("./day4-input.txt");
Card? lastCast = null;
var cards = new List<Card>();
while (!streamReader.EndOfStream)
{
    var currentLine = streamReader.ReadLine();
    if (string.IsNullOrWhiteSpace(currentLine))
        throw new Exception("Unexpected line encountered");

    var card = new Card(currentLine);
    cards.Add(card);
}

var sumOfCardValues = cards.Sum(x => x.Value);

var cascades = cards.SelectMany(x => x.CascadeValue(cards)).ToList();

Console.WriteLine($"Total sum of all scratch cards: {sumOfCardValues}");
Console.WriteLine($"Total sum of all cascaded cards: {cascades.Count()}");
