using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private Vector2 _cellSize;
    [SerializeField] private Vector2 _spacing;
    [SerializeField] private float _spacingKoefWidth;
    [SerializeField] private float _spacingKoefHeight;


    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputHorizontal();

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        _spacing.x = parentWidth / _spacingKoefWidth;
        _spacing.y = parentHeight / _spacingKoefHeight;

        float cellWidth = parentWidth / (float)_columns - ((_spacing.x / (float)_columns) * (_columns - 1)) - (padding.left / (float)_columns) - (padding.right / (float)_columns);
        float cellHeight = parentHeight / (float)_rows - ((_spacing.y / (float)_rows) * (_rows - 1)) - (padding.top / (float)_rows) - (padding.bottom / (float)_rows);

        _cellSize.x = cellWidth;
        _cellSize.y = cellHeight;

        int columnCount = 0;
        int rowsCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowsCount = i / _columns;
            columnCount = i % _columns;

            var item = rectChildren[i];

            var xPos = (_cellSize.x * columnCount) + (_spacing.x * columnCount) + padding.left;
            var yPos = (_cellSize.y * rowsCount) + (_spacing.y * rowsCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, _cellSize.x);
            SetChildAlongAxis(item, 1, yPos, _cellSize.y);
        }
    }

    public float GetCellSize() => Mathf.Min(_cellSize.x, _cellSize.y);

    public override void SetLayoutHorizontal()
    {
    }

    public override void SetLayoutVertical()
    {
    }
}