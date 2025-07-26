using System;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardModel model;
    [SerializeField] private CardView view;
    private GameController cocntroller;
    private bool isFlipped = false;

    public void Init(CardModel model, GameController controller)
    {
        this.model = model;
        this.cocntroller = controller;
        view.SetCardVisual(model.data);
        view.SetFlipped(false);
        view.CardButton().onClick.AddListener(OnCardButtonClicked);


    }

    private void OnCardButtonClicked()
    {
        if (isFlipped || model.isMatched) return;

        isFlipped = true;
        view.SetFlipped(true);
        cocntroller.OnCardFlipped(this);
    }

    public void ResetCard()
    {
        isFlipped = false;
        view.SetFlipped(false);
    }
    public void MarkAsMAtched()
    {
        model.isMatched = true;
        view.SetInteractable(false);
    }

    public int GetCardID() => model.ID;
}
