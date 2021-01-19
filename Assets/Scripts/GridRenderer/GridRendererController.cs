using System.Collections.Generic;
using UnityEngine;

public class GridRendererController : MonoBehaviour
{
    [SerializeField] List<GridRenderer> grids;

    private bool isFaded = false;

    private void Start()
    {
        //Draw grids
        foreach (GridRenderer grid in grids)
        {
            grid.DrawGrid();
        }
    }
   

    void Update()
    {
        //Redraw grids
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GridRenderer grid in grids)
            {
                grid.ResetGrid();
                isFaded = false;
                grid.UpdateCell(Random.Range(0, grid.Columns), Random.Range(0, grid.Rows), Random.ColorHSV());
            }
        }

        //Toggle fade grids
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (GridRenderer grid in grids)
            {
                if (isFaded)
                {
                    grid.UnFadeCells();
                } 
                else
                {
                    grid.FadeCells();
                }
            }

            isFaded = !isFaded;
        }
    }
}
