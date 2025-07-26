using UnityEngine;

[CreateAssetMenu(fileName = " NewCards", menuName = "Card Matching/Card Data")]
public class CardData : ScriptableObject
{

    // Data Container For Card
    public int cardID;
    public Sprite frontSprite;
    public Sprite backSprite;
}
