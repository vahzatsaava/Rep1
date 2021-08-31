using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPause : MonoBehaviour
{
    public void RestartLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

}
