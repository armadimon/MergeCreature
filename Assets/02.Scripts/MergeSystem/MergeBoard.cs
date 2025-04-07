using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeBoard : MonoBehaviour
{
    public int Rows = 5;
    public int Columns = 5;

    private MergeCell[,] _cells;

    public void Initialize()
    {
        _cells = new MergeCell[Rows, Columns];

        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                _cells[x, y] = new MergeCell(x, y);
            }
        }
    }

    public MergeCell GetCell(int x, int y) => _cells[x, y];
}