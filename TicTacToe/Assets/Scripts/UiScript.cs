using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{
    [SerializeField] private MainContoller mainContoller;
    [SerializeField] private BoardManager boardManager;
    [SerializeField] private Button start;
    [SerializeField] private Button restart;
    [SerializeField] private Button[] gameMode;

    [SerializeField] private Text scoreCross;
    [SerializeField] private Text scoreZero;
    [SerializeField] private Text tWin;
    
    public void StartGame()
    {
        start.gameObject.SetActive(false);
        for (int i = 0; i < gameMode.Length; i++)
            gameMode[i].gameObject.SetActive(true);
    }
    
    public void ActiveModeOnePlayer()
    {
        mainContoller.gameMode = MainContoller.GameMode.OnePlayer;
        boardManager.CreateBoard();
        for (int i = 0; i < gameMode.Length; i++)
            gameMode[i].gameObject.SetActive(false);
    }
    public void ActiveModeTwoPlayer()
    {
        mainContoller.gameMode = MainContoller.GameMode.TwoPlayer;
        boardManager.CreateBoard();
        for (int i = 0; i < gameMode.Length; i++)
            gameMode[i].gameObject.SetActive(false);
    }

    public void UpdateScore()
    {
        scoreCross.text = mainContoller.scoreCross.ToString();
        scoreZero.text = mainContoller.scoreZero.ToString();
    }

    public void TextWin(string textWin)
    {
        tWin.text = textWin;
        restart.gameObject.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
