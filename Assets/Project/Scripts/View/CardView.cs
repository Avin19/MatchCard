using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image frontImage;

    public GameObject front;
    public GameObject back;

    public void SetCardVisual(CardData data)
    {
        frontImage.sprite = data.frontSprite;
    }

    public void SetFlipped(bool flipped)
    {
        front.SetActive(flipped);
        back.SetActive(flipped);
    }
}
