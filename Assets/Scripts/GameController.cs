using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject winUI;
    
    public Press press;
    public int countCrush = 0;

    public Slider textCountToCrush;
    public Text currentLevelText;
    
    public ObjectSpawner objectSpawner;
    
    private int _currentLevel;

    void Start()
    {
        LoadData();
        winUI.SetActive(false);
    }

    void Update()
    {
        textCountToCrush.value = countCrush;
        if (countCrush == 20)
        {
            objectSpawner.isWork = false;
            //winUI.SetActive(true);
        }
    }

    public void NextLevel()
    {
        objectSpawner.isWork = true;
        objectSpawner.StartCoroutine("Spawn");
        countCrush = 0;
        _currentLevel++;
        currentLevelText.text = _currentLevel.ToString();
        winUI.SetActive(false);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            _currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            _currentLevel = 1;
        }
    }

    private void SaveData()
    { 
        PlayerPrefs.SetInt("Level", _currentLevel);
    }

    private void OnDestroy()
    {
        //SaveData();
    }
}
