using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score = 0;

    public GameObject Player;

    [SerializeField]
    UIManager UIManager;
    [SerializeField]
    RandomSpawner RandomSpawner;

    public void PlayerDied()
    {
        UIManager.ToggleEndScreen(true);
    }

    public void AddScore()
    {
        Score += 1;
        UIManager.UpdateScore();
    }

    public void Restart()
    {
        Player.GetComponent<Movement>().Restart();
        KillAllEnemies();
        RandomSpawner.Reset();
        Score = 0;
        UIManager.UpdateScore();
    }
    public void Quit()
    {
        Application.Quit();
    }

    void KillAllEnemies()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in allObjects)
        {
            obj.GetComponent<Enemy>().Die();
        }
    }
}
