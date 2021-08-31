using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpDate : MonoBehaviour
{
    /// <summary>
    /// Метод запуска игры
    /// </summary>
    /// <param name="levelIndex"></param>
   public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    /// <summary>
    /// Метод выхода из игры
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
