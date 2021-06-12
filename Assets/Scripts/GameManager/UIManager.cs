using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Text;


    [SerializeField]
    GameManager GameManager;
    [SerializeField]
    GameObject EndGameScreen;

    public void UpdateScore()
    {
        Text.GetComponent<Text>().text = GameManager.Score.ToString();
    }

    public void ToggleEndScreen(bool tog)
    {
        EndGameScreen.SetActive(tog);
    }

    public void OnRestartClicked()
    {
        GameManager.Restart();
        ToggleEndScreen(false);
    }

    public void OnQuitClicked()
    {
        GameManager.Quit();
    }
}
