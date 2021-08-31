using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;//объект меню

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))//если мы нажимаем на Q
        {
            if (isPaused)//значение isPaused ложь
            {
                Resume();//метод резюм реализуется тогда
            }
            else
            {
                PauseMenu();//иначе метод PauseMenu
            }
        }
    }

    private void PauseMenu()
    {
        pauseMenuUI.SetActive(true);//панель становится активной(ее видно)
        Time.timeScale = 0;//время останавливается
        isPaused = true;//значение isPaused есть true
    }

  public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;//ставим так чтобы не было багов
        SceneManager.LoadScene("Main_Menu");//переходим в главное меню

    }
}
