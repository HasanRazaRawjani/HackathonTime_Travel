using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    private PlayerController playerScript;
    private GameObject GameUI;
    private GameObject StartMenu;
    private GameObject WinMenu;
    private GameObject LevelMenu;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        GameUI = transform.Find("GameUI").gameObject;
        StartMenu = transform.Find("StartMenu").gameObject;
        WinMenu = transform.Find("WinScreen").gameObject;
        LevelMenu = transform.Find("LevelMenu").gameObject;
        Time.timeScale = 0f;
        GameUI.SetActive(false);
        StartMenu.SetActive(true);
        WinMenu.SetActive(false);
        LevelMenu.SetActive(false);

    }

    public void ShowGameUI1()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameUI.SetActive(true);
        StartMenu.SetActive(false);
        WinMenu.SetActive(false);
        LevelMenu.SetActive(false);
    }

    public void ShowGameUI2()
    {
        SceneManager.LoadScene("Level2");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameUI.SetActive(true);
        StartMenu.SetActive(false);
        WinMenu.SetActive(false);
        LevelMenu.SetActive(false);
    }

    public void ShowGameUI3()
    {
        SceneManager.LoadScene("Level3");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameUI.SetActive(true);
        StartMenu.SetActive(false);
        WinMenu.SetActive(false);
        LevelMenu.SetActive(false);
    }

    public void ShowStartMenu()
    {
        if(SceneManager.GetActiveScene().name != "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameUI.SetActive(false);
        StartMenu.SetActive(true);
        WinMenu.SetActive(false);
        LevelMenu.SetActive(false);
    }


    public void ShowWinMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameUI.SetActive(false);
        StartMenu.SetActive(false);
        WinMenu.SetActive(true);
        LevelMenu.SetActive(false);
    }

    public void ShowLevelMenu()
    {
        if(SceneManager.GetActiveScene().name != "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameUI.SetActive(false);
        StartMenu.SetActive(false);
        WinMenu.SetActive(false);
        LevelMenu.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }


}
