using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class GridRenderer : MonoBehaviour
{
    [SerializeField] private int columns;
    [SerializeField] private int rows;
    [Range(0, 1f)]
    [SerializeField] private float alphaWhenFaded;
    [SerializeField] private Color defaultColor;

    private bool gridSpawned;
    private bool cellsChanged;
    private bool isFaded;
    private GameObject[,] grid;
    private HashSet<GameObject> changedCells;
    private RectTransform rectTransform;

    public int Columns => columns;
    public int Rows => rows;

    public Color DefaultColor => defaultColor;

    private void Awake()
    {
        gridSpawned = false;
        cellsChanged = false;
        isFaded = false;
        grid = new GameObject[columns, rows];
        changedCells = new HashSet<GameObject>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void DrawGrid()
    {
        if (gridSpawned)
        {
            return;
        }
        else if (grid == null)
        {
            grid = new GameObject[columns, rows];
        }

        float rectWidth = rectTransform.rect.width;
        float rectHeight = rectTransform.rect.height;
        float widthRatio = rectWidth / columns;
        float heightRatio = rectHeight / rows;
        float squareLength = widthRatio < heightRatio ? widthRatio : heightRatio;
        float halfSquareLength = squareLength / 2f;
        float xOffset = 0f;
        float yOffset = 0f;
    
        //Calculating offset of the cells based on the shortest side of the screen.
        if (squareLength == widthRatio)
        {
            yOffset += (rectHeight - (squareLength * rows)) / 2f;
        }
        else
        {
            xOffset += (rectWidth - (squareLength * columns)) / 2f;
        } 

        //Drawing cells
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject cell = new GameObject();
                cell.name = "Cell " + x + ", " + y;
                cell.transform.SetParent(transform);
                cell.transform.localScale = Vector3.one;

                Image image = cell.AddComponent(typeof(Image)) as Image;
                image.color = defaultColor;

                RectTransform rectTransform = image.rectTransform;
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.zero;
                rectTransform.anchoredPosition3D = new Vector3(
                (x * squareLength) + halfSquareLength + xOffset, 
                (y * squareLength) + halfSquareLength + yOffset, rectTransform.anchoredPosition3D.z);
                rectTransform.sizeDelta = new Vector2(squareLength, squareLength);

                grid[x, y] = cell;
            }
        }

        gridSpawned = true;
    }

    public void ResetGrid()
    {
        if (!gridSpawned || !cellsChanged)
        {
            return; 
        }

        //Resetting each cell color to default.
        foreach (GameObject cell in changedCells)
        {
            cell.GetComponent<Image>().color = defaultColor;
        }

        changedCells.Clear();
    
        UnFadeCells();       
        
        cellsChanged = false;
    }

    public void DestroyGrid()
    {
        if (!gridSpawned)
        {
            return;
        }

        foreach (GameObject cell in grid)
        {
            Destroy(cell);
        }

        grid = null;
        gridSpawned = false;
        cellsChanged = false;
    }

    public void UpdateCell(int x, int y, Color color)
    {
        if (!gridSpawned || IsInvalidCoord(x, y))
        {
            return;
        }

        GameObject cell = grid[x, y];

        if (cell.GetComponent<Image>().color.Equals(color))
        {
            return;
        }

        if (isFaded)
        {
            color.a = alphaWhenFaded;
        }

        cell.GetComponent<Image>().color = color;

        if (color.Equals(defaultColor))
        {
            changedCells.Remove(cell);

            if (changedCells.Count == 0)
            {
                cellsChanged = false;
            }
        } 
        else
        {
            changedCells.Add(cell);
            cellsChanged = true;
        }     
    }

    public void FadeCells()
    {
        if (!gridSpawned || isFaded)
        {
            return;
        }

        //Fading each cell.
        foreach (GameObject cell in grid)
        {
            Color cellColor = cell.GetComponent<Image>().color;
            Color fadedColor = new Color(cellColor.r, cellColor.g, cellColor.b, alphaWhenFaded);
            cell.GetComponent<Image>().color = fadedColor;
        }

        cellsChanged = true;
        isFaded = true;
    }

    public void UnFadeCells()
    {
        if (!gridSpawned || !isFaded)
        {
            return;
        }

        //Unfading each cell.
        foreach (GameObject cell in grid)
        {
            Color cellColor = cell.GetComponent<Image>().color;
            Color unfadedColor = new Color(cellColor.r, cellColor.g, cellColor.b, 1f);
            cell.GetComponent<Image>().color = unfadedColor;
        }

        isFaded = false;
    }

    private bool IsInvalidCoord(int x, int y)
    {
        return (x < 0) || (x >= columns) || (y < 0) || (y >= rows);
    }
}
