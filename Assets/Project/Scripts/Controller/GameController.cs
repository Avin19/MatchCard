using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private int row = 4, cols = 4;

    private List<CardController> flippedCards = new List<CardController>();

    void Start()
    {
        GenerateGrid(row, cols);
    }

    private void GenerateGrid(int row, int cols)
    {
        List<CardData> cardAssets = new List<CardData>(Resources.LoadAll<CardData>("CardData"));
        List<CardData> pairedCards = new List<CardData>();

        for (int i = 0; i < (row * cols) / 2; i++)
        {
            pairedCards.Add(cardAssets[i]);
            pairedCards.Add(cardAssets[i]);
        }

        pairedCards.Shuffle();
    }
}
