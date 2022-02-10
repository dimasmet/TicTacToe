using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript
{
    private Cell[,] cells;
    private List<Cell> availableCell;
    
    public void Turn(BoardManager boardManager, MainContoller mainContoller)
    {
        availableCell = new List<Cell>();
        cells = new Cell[boardManager.size,boardManager.size];
        cells = boardManager.GetArrayCells();
        for (int x = 0; x < boardManager.size; x++)
        {
            for (int y = 0; y < boardManager.size; y++)
            {
                if (cells[x,y].open)
                    availableCell.Add(cells[x,y]);
            }
        }

        if (availableCell.Count != 0)
        {
            Cell botTurn = BotChoiceRandomCell();
            botTurn.open = false;
            mainContoller.InstallSprite(botTurn);
        }

    }

    public Cell BotChoiceRandomCell()
    {
        int random = UnityEngine.Random.Range(0, availableCell.Count - 1);
        return availableCell[random];
    }
}
