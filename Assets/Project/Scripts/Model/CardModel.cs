

public class CardModel
{

    // Holds the state isMatched and identity cardID of a card instance 
    public CardData data;
    public bool isMatched = false;

    public int ID => data.cardID;

    public CardModel(CardData data)
    {
        this.data = data;
    }
}
