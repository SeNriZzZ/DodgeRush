using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _level2;
    [SerializeField] private Image _lockImage;
    private ResultHolder _resultHolder;

    private void Start()
    {
        _resultHolder = FindObjectOfType<ResultHolder>();
        _resultHolder.GetResult();
        Debug.Log(_resultHolder.levelIsPassed);
        if (_resultHolder.levelIsPassed == true)
        {
            SetLevel2Interactible();
        }
        else
        {
            _level2.interactable = false;
        }
    }

    public void QuitClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void SetLevel2Interactible()
    {
        _level2.interactable = true;
        _lockImage.enabled = false;
    }

    public void SecondLevel()
    {
        Debug.Log("Second level");
    }
}
