using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GridMap
{
    // Singleton instance
    private static GridMap _instance = null;
    public static GridMap GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GridMap();
        }
        return _instance;
    }

    public char[] gridMap = new char[100];
    public int nrRows = 10;
    public int nrCols = 10;

    public void SetDimensions(int nrRows, int nrCols)
    {
        this.nrRows = nrRows;
        this.nrCols = nrCols;
        this.gridMap = new char[nrRows * nrCols];
    }

    private void AssertMapDimensions(int row, int col)
    {
        Assert.IsTrue(gridMap.Length >= (row+1) * (col+1));
        Assert.IsTrue(row < this.nrRows);
        Assert.IsTrue(col < this.nrCols);
    }

    public void SetAt(char value, int row, int col)
    {
        AssertMapDimensions(row, col);
        gridMap[col + row * this.nrCols] = value;
    }

    public char GetAt(int row, int col)
    {
        AssertMapDimensions(row, col);
        return gridMap[col + row * this.nrCols];
    }

    public float GetWorldPosX(int colIdx)
    {
        return 50 - colIdx * 10;
    }

    public float GetWorldPosZ(int rowIdx)
    {
        return 50 - rowIdx * 10;
    }

    public bool IsWalkable(int x, int z)
    {
        if (GetAt(z, x) != '1')
        {
            return true;
        }
        return false;
    }
}
