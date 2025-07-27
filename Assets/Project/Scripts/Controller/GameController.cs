using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private int row = 4, cols = 4;
    [SerializeField] private AutoGridResizer autoGridResizer;
    private int score = 0;

    private List<CardController> flippedCards = new List<CardController>();

    private int totalPairs;
    private int matchedPairs;


    public void StartGameWithLayout(int row, int col)
    {
        this.row = row;
        this.cols = col;
        autoGridResizer.SetLayout(row, cols);
        GenerateGrid(row, cols);

    }
    private void GenerateGrid(int row, int cols)
    {
        totalPairs = (row * cols) / 2;
        matchedPairs = 0;
        List<CardData> cardAssets = new List<CardData>(Resources.LoadAll<CardData>("CardData"));
        List<CardData> pairedCards = new List<CardData>();

        for (int i = 0; i < (row * cols) / 2; i++)
        {
            pairedCards.Add(cardAssets[i]);
            pairedCards.Add(cardAssets[i]);
        }

        pairedCards.Shuffle();

        foreach (CardData card in pairedCards)
        {
            GameObject go = Instantiate(cardPrefab, gridParent);
            CardController controller = go.GetComponent<CardController>();
            controller.Init(new CardModel(card), this);
        }
    }
    public void OnCardFlipped(CardController card)
    {
        flippedCards.Add(card);
        if (flippedCards.Count == 2)
        {
            StartCoroutine(Checkmatch());

        }
    }
    IEnumerator Checkmatch()
    {
        yield return new WaitForSeconds(0.5f);
        var a = flippedCards[0];
        var b = flippedCards[1];

        if (a.GetCardID() == b.GetCardID())
        {
            a.MarkAsMAtched();
            b.MarkAsMAtched();
            score += 10;
            matchedPairs++;
            UIManager.Instance.ShowStatus("Match!");
            AudioManager.Instance.Play("Match");
        }
        else
        {
            a.ResetCard();
            b.ResetCard();
            score -= 1;
            UIManager.Instance.ShowStatus("Mismatch!");
            AudioManager.Instance.Play("Mismatch");
        }
        if (matchedPairs >= totalPairs)
        {
            UIManager.Instance.ShowStatus("All matched!");
            AudioManager.Instance.Play("GameOver");
            UIManager.Instance.ShowGameOver(); // This shows a panel
        }
        UIManager.Instance.UpdateScore(score);
        flippedCards.Clear();
    }
}
