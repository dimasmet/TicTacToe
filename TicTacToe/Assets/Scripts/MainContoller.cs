using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContoller : MonoBehaviour
{
    [SerializeField] private BotScript botScript;
    public enum GameMode
    {
        OnePlayer,
        TwoPlayer
    }
    public GameMode gameMode = GameMode.TwoPlayer;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private BoardManager boardManager;
    [SerializeField] private UiScript uiScript;
    [SerializeField] private SavePrefs savePrefs;

    private Cell[,] _cells;

    public bool endGame = false;
    public int scoreCross = 0;
    public int scoreZero = 0;

    private bool inTurn = true;

    private void Start()
    {
        botScript = new BotScript();
        savePrefs.LoadGame();
        uiScript.UpdateScore();
    }

    public void BotTurn()
    {
        botScript.Turn(boardManager, this);
    }
    
    public void InstallSprite(Cell cell)
    {
        int index = inTurn ? (0) : 1;
        inTurn = !inTurn;

            switch (index)
            {
                case 0:
                    cell.statusCell = Cell.StatusCell.Cross;
                    break;
                case 1:
                    cell.statusCell = Cell.StatusCell.Zero;
                    break;
            }
            GameObject sprite = Instantiate(prefabs[index], cell.transform.position, Quaternion.identity);
            sprite.transform.SetParent(transform);

            CheckWin();
            NoWinnerCheck();
    } 
    

    public void CheckWin()
    {
        _cells = new Cell[boardManager.size,boardManager.size];
        _cells = boardManager.GetArrayCells();
        
        int[] rows = new int[boardManager.size];
        int[] cols = new int[boardManager.size];
        int diagonalMain = 0;
        int diagonalSecond = 0;
        
        for (int x = 0; x < boardManager.size; x++)
        {
            for (int y = 0; y < boardManager.size; y++)
            {
                int sum;
                if (_cells[x, y].statusCell == Cell.StatusCell.Cross)
                    sum = 1;
                else
                {
                    if (_cells[x, y].statusCell == Cell.StatusCell.Zero)
                        sum = -1; 
                    else sum = 0;
                }
                rows[x] += sum;
                cols[y] += sum;

                if (x == y)
                    diagonalMain += sum;
                if (x + y + 1 == boardManager.size)
                    diagonalSecond += sum;
            }
        }

        if (diagonalMain == boardManager.size || diagonalSecond == boardManager.size)
        {
            uiScript.TextWin("Победил крестик");
            endGame = true;
            scoreCross++;
        }
        if (diagonalMain == -boardManager.size || diagonalSecond == -boardManager.size)
        {
            uiScript.TextWin("Победил нолик");
            endGame = true;
            scoreZero++;
        }

        for (int i = 0; i < boardManager.size; i++)
        {
            if (rows[i] == boardManager.size || cols[i] == boardManager.size)
            {
                uiScript.TextWin("Победил крестик");
                endGame = true;
                scoreCross++;
            }
            if (rows[i] == -boardManager.size || cols[i] == -boardManager.size)
            {
                uiScript.TextWin("Победил нолик");
                endGame = true;
                scoreZero++;
            }
        }
        
        uiScript.UpdateScore();
        savePrefs.SaveGame();
    }

    public void NoWinnerCheck()
    {
        if (endGame != true)
        {
            int numberUndefined = 0;
            for (int x = 0; x < boardManager.size; x++)
            {
                for (int y = 0; y < boardManager.size; y++)
                {
                    if (_cells[x, y].statusCell == Cell.StatusCell.Undefined)
                        numberUndefined++;
                }
            }

            if (numberUndefined == 0)
            {
                uiScript.TextWin("Ничья");
                endGame = true;
            }
        }
    }
    
}
