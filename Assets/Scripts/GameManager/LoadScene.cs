using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int SceneNum;

    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
