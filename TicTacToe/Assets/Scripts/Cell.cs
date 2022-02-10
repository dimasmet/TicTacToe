using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public enum StatusCell
    {
        Undefined,
        Cross,
        Zero
    } 
    
    private static bool turnSprite = true;
    public StatusCell statusCell = StatusCell.Undefined;
    
    [SerializeField] private GameObject[] prefabs;
    
    private MainContoller _mainContoller;
    public SpriteRenderer spiteCell;
    
    public bool open = true;

    private void Awake()
    {
        _mainContoller = FindObjectOfType<MainContoller>();
    }

    private void OnMouseDown()
    {
        if (statusCell == StatusCell.Undefined && open && !_mainContoller.endGame)
        {
            _mainContoller.InstallSprite(this);

            open = false;
            
            if (_mainContoller.gameMode == MainContoller.GameMode.OnePlayer)
            {
                _mainContoller.BotTurn();
            }
        }
    }

}
