using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Cell[,] cells;
    public int size = 3;

    [SerializeField] private Cell prefabSell;

    private float posX;
    private float posY;

    private void Start()
    {
        cells = new Cell[size,size];
        posX = transform.position.x;
        posY = transform.position.y;
    }

    public void CreateBoard()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                cells[x, y] = Instantiate(prefabSell, transform.position, Quaternion.identity);
                cells[x, y].transform.SetParent(transform);
                Vector2 sizeCell = cells[x, y].spiteCell.bounds.size;
                cells[x, y].transform.position = new Vector3(posX + sizeCell.x * x * 1.05f,posY + sizeCell.y * y * 1.05f);
            }
        }
    }

    public Cell[,] GetArrayCells()
    {
        return cells;
    }
}
