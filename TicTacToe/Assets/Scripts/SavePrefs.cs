using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    [SerializeField] private MainContoller _mainContoller;
    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedScoreCross", _mainContoller.scoreCross);
        PlayerPrefs.SetInt("SavedScoreZero", _mainContoller.scoreZero);
        PlayerPrefs.Save();
        Debug.Log("info save!");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedScoreCross"))
        {
            _mainContoller.scoreCross = PlayerPrefs.GetInt("SavedScoreCross");
            _mainContoller.scoreZero = PlayerPrefs.GetInt("SavedScoreZero");
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        _mainContoller.scoreCross = 0;
        _mainContoller.scoreZero = 0;
        
    }
}
