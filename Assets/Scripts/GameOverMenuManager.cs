using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Health.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable() 
    { 
        Health.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Invoke("callMainMenu", 15f);

    }

    void callMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

}
