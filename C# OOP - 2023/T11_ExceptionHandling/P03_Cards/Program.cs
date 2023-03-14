public class StartUp
{
    static void Main()
    {
        List<Card> cards = new();
        string[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var cardProp in input)
        {
            string[] cardDetails = cardProp
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Card card = new(cardDetails[0], cardDetails[1]);
                cards.Add(card);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        Console.WriteLine(string.Join(" ", cards));
    }

}

public class Card
{
    private string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private string[] suits = { "S", "H", "D", "C" };

    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get => face;
        set
        {
            if (faces.Contains(value))
            {
                face = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }
    public string Suit
    {
        get => suit;
        set
        {
            if (suits.Contains(value))
            {
                suit = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }

    public override string ToString()
    {
        switch (Suit)
        {
            case "S":
                return $"[{Face}{"\u2660"}]";
            case "H":
                return $"[{Face}{"\u2665"}]";
            case "D":
                return $"[{Face}{"\u2666"}]";
            case "C":
                return $"[{Face}{"\u2663"}]";
            default:
                return null;
        }
    }
}