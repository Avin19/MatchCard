using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image frontImage;

    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;

    [SerializeField] private Button button;
    public void SetCardVisual(CardData data)
    {
        frontImage.sprite = data.frontSprite;
    }

    public void SetFlipped(bool flipped)
    {
        front.SetActive(flipped);
        back.SetActive(!flipped);
    }

    public void SetInteractable(bool interactable)
    {
        button.interactable = interactable;
    }

    public Button CardButton()
    {
        return button;
    }
}
