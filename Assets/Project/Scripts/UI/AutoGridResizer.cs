using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(GridLayoutGroup))]

public class AutoGridResizer : MonoBehaviour
{
    [SerializeField] private Vector2 spacing = new Vector2(10, 10);

    [SerializeField] private Vector2 padding = new Vector2(20, 20);
    [SerializeField] private Vector2 cardSize = new Vector2(160, 120);
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private RectTransform container;
    private int rows, cols;
    // Update is called once per frame
    public void ResizeGrid()
    {
        float availableWidth = container.rect.width - padding.x * 2 - spacing.x * (cols - 1);
        float availableHeight = container.rect.height - padding.y * 2 - spacing.y * (rows - 1);

        float cellWidth = availableWidth / cols;
        float cellHeight = availableHeight / rows;

        grid.cellSize = new Vector2(cellWidth, cellHeight);
        grid.spacing = spacing;

        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = cols;
    }

    public void SetLayout(int newRows, int newCols)
    {
        rows = newRows;
        cols = newCols;
        ResizeGrid();
    }


}
