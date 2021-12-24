using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _heart1;
    [SerializeField] private Image _heart2;
    [SerializeField] private Image _heart3;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Image _star1;
    [SerializeField] private Image _star2;
    [SerializeField] private Image _star3;
    [SerializeField] private Sprite _star;
    
    public void UpdateLives(int currentLives)
    {
        switch (currentLives)
        {
            case 2:
                _heart3.enabled = false;
                break;
            case 1:
                _heart2.enabled = false;
                break;
            case 0:
                _heart1.enabled = false;
                break;
        }
    }

    public void ActivateWinPanel(int currentLives)
    {
        _winPanel.SetActive(true);
        switch (currentLives)
        {
            case 3:
                _star1.GetComponent<Image>().sprite = _star;
                _star2.GetComponent<Image>().sprite = _star;
                _star3.GetComponent<Image>().sprite = _star;
                break;
            case 2:
                _star1.GetComponent<Image>().sprite = _star;
                _star2.GetComponent<Image>().sprite = _star;
                break;
            case 1:
                _star1.GetComponent<Image>().sprite = _star;
                break;
        }
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
