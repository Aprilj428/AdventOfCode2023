namespace AdventOfCode2023Day4;

public class Card
{
    private readonly List<int> _playerNumbers;
    private readonly List<int> _winningNumbers;
    
    public Card(string card)
    {
        var cardParts = card.Split('|');
        Id = int.Parse(cardParts[0].Split(':')[0].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ElementAt(1).Trim());
        _winningNumbers = cardParts[0].Split(':')[1].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
        _playerNumbers = cardParts[1].Trim().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
    }
    
    public int Id { get; }
    public int Matches => _playerNumbers.Intersect(_winningNumbers).Count();

    public List<int> NextCardsIds => Enumerable.Range(Id + 1, Matches).ToList();

    public IEnumerable<Card> CascadeValue(ICollection<Card> allCards)
    {
        var nextCascades = new List<Card> { this };
        foreach (var nextCardId in NextCardsIds)
        {
            var nextCard = allCards.FirstOrDefault(x => x.Id == nextCardId);
            if (nextCard is null)
                continue;

            var c = nextCard.CascadeValue(allCards);
            nextCascades.AddRange(c);
        }

        return nextCascades;
    } 

    public int Value => Matches switch
    {
        0 => 0,
        1 => 1,
        _ => (int)Math.Pow(2, Matches - 1)
    };
}