using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using CustomExtensions;

public class GameBehavior : MonoBehaviour

{
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);
    }

    public bool showWinScreen = false;

    public bool showLossScreen = false;
    
    public string labelText = "Collect all 4 items and win your freedom!";

    public int maxItems = 4;

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";

                showWinScreen = true;

                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }

            else if(_playerHP >= 3)
            {
                labelText = "You been hitting the gym or something?";
            }

            else
            {
                labelText = "You're on life support";
            }
        }
    }

 
    void OnGUI()
    {
        GUI.color = Color.magenta;

        

        GUI.Box(new Rect(20, 20, 150, 25), "Health: " + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);

                Time.timeScale = 1.0f;

                Utilities.RestartLevel(0);
            }
        
       
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You Lose"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
                Utilities.RestartLevel(0);
            }
        }


    }

}
